using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DethiLayer;
using DataLayer;
using DethiLayer.DTO;
using DevExpress.XtraGrid;
using System.Diagnostics;
using QLDETHI.Luutru;

namespace QLDETHI
{
    public partial class fDaoDeThi : Form
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        private int selectedMaDe;
        NOIDUNGDETHI _noidungdethi;

        private TaiKhoan user;
        int IdTK;
        public fDaoDeThi(int? selectedMaDe)
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
            // Kiểm tra xem selectedMaDe có giá trị không
            if (selectedMaDe.HasValue)
            {
                this.selectedMaDe = selectedMaDe.Value;
            }
            else
            {
                // Xử lý khi selectedMaDe không có giá trị
                // Ví dụ: hiển thị thông báo lỗi hoặc làm gì đó khác
                MessageBox.Show("Mã đề không hợp lệ hoặc không được chọn.");
                this.Close(); // Đóng form nếu không có mã đề hợp lệ
            }
        }

        private void fDaoDeThi_Load(object sender, EventArgs e)
        {
            _noidungdethi = new NOIDUNGDETHI();
            // Kiểm tra xem selectedMaDe có giá trị
            if (selectedMaDe > 0)
            {
                // Load đề thi đã chọn
                var selectedDeThi = _noidungdethi.getListFull(selectedMaDe);
            }
            else
            {
                // Xử lý khi selectedMaDe không hợp lệ
                MessageBox.Show("Mã đề không hợp lệ hoặc không được chọn.");
                this.Close(); // Đóng form nếu không có mã đề hợp lệ
            }
        }

        private void btnDaoDe_Click(object sender, EventArgs e)
        {
            // Lấy thông tin đề gốc
            var originalDeThi = _noidungdethi.getListFull(selectedMaDe);

            if (originalDeThi != null && originalDeThi.Count > 0)
            {
                int numCopies = (int)nbSoLuongDe.Value;
                var duplicatedDeThis = new List<DETHI_DTO>();

                // Random những câu hỏi và lưu vào DB 
                for (int i = 0; i < numCopies; i++)
                {                
                    // Tạo phiên bản mới của đề thi
                    var newDeThi = new DETHI_DTO();

                    newDeThi.NamHoc = originalDeThi[i].NamHoc;
                    newDeThi.MaHienThi = GenerateNewMaHienThi(); // Tạo mã hiển thị mới (ví dụ: 156, 209, 320)
                    newDeThi.TenDeThi = originalDeThi[i].TenDeThi;
                    newDeThi.MaThoiGianThi = originalDeThi[i].MaThoiGianThi;
                    newDeThi.MaHocKy = originalDeThi[i].MaHocKy;
                    newDeThi.MaMonHoc = originalDeThi[i].MaMonHoc;
                    newDeThi.MaKhoi = originalDeThi[i].MaKhoi;
                    newDeThi.MaLop = originalDeThi[i].MaLop;
                    newDeThi.MaGiangVien = IdTK;

                    newDeThi.SoCauHoi = originalDeThi.Count;

                    // Đảo ngẫu nhiên thứ tự của câu hỏi
                    List<CauHoi> randomQuestions = RandomizeQuestions(originalDeThi[i].CauHois);

                    // Lưu các câu hỏi đã đảo ngẫu nhiên vào đề mới
                    newDeThi.CauHois = randomQuestions;

                    // Đảo ngẫu nhiên đáp án A, B, C, D và cập nhật đáp án đúng
                    foreach (var cauHoi in newDeThi.CauHois)
                    {
                        RandomizeQuestionAnswers(cauHoi);
                    }
                    // Lưu thông tin đề thi mới vào cơ sở dữ liệu
                    SaveNewDeThiToDatabase(newDeThi);
                }
                // Truy cập gridDeThi từ form gốc và cập nhật danh sách đề thi
                fNganHangDeThi parentForm = this.Owner as fNganHangDeThi;
                if (parentForm != null)
                {
                    //parentForm.UpdateGridDeThi(duplicatedDeThis);
                    parentForm.UpdateGridDeThi();
                    this.Close();
                }
                this.Close();
                MessageBox.Show($"Đảo thành công {numCopies} đề");
                this.Close();


            }
        }
        
        private void SaveNewDeThiToDatabase(DETHI_DTO newDeThi)
        {
            using (DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities())
            {
                // Tạo một đối tượng Random
                Random random = new Random();
                // Tạo số ngẫu nhiên từ 1 đến 24
                int thuTuXepDapAn = random.Next(1, 25);

                int thuTuCauHoi = 1;
                // Lưu thông tin liên quan đến DeThi
                var deThiEntity = new DeThi
                {
                    NamHoc = newDeThi.NamHoc,
                    MaHienThi = newDeThi.MaHienThi,
                    TenDeThi = newDeThi.TenDeThi,
                    MaThoiGianThi = newDeThi.MaThoiGianThi,
                    MaHocKy = newDeThi.MaHocKy,
                    SoCauHoi = newDeThi.SoCauHoi,
                    MaMonHoc = newDeThi.MaMonHoc,
                    MaKhoi = newDeThi.MaKhoi,
                    MaLop = newDeThi.MaLop,
                    MaGiangVien = newDeThi.MaGiangVien
                };
                db.DeThis.Add(deThiEntity);
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                // Gán MaDe của đề mới
                newDeThi.MaDe = deThiEntity.MaDe;
                try
                {
                // Lưu thông tin liên quan đến NoiDungDeThi
                foreach (var cauHoi in newDeThi.CauHois)
                {
                    var noiDungDeThiEntity = new NoiDungDeThi
                    {
                        MaDe = deThiEntity.MaDe, // Lấy MaDe từ đề thi đã thêm vào cơ sở dữ liệu
                        MaCauHoi = cauHoi.MaCauHoi,
                        ThuTuCauHoi = thuTuCauHoi,                        
                        ThuTuXepDapAn = thuTuXepDapAn
                    };

                    thuTuCauHoi++;
                    db.NoiDungDeThis.Add(noiDungDeThiEntity);
                }
                db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // In thông báo lỗi ra để kiểm tra vấn đề trong quá trình tạo đối tượng newDeThi
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Hàm để đảo ngẫu nhiên một mảng các đáp án
        private string[] RandomizeAnswers(string[] answers)
        {
            Random rng = new Random();
            string[] randomizedAnswers = answers.OrderBy(x => rng.Next()).ToArray();
            return randomizedAnswers;
        }


        private string ShuffleContent(string originalContent)
        {
            char[] characters = originalContent.ToCharArray();
            Random rng = new Random();
            int n = characters.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                char value = characters[k];
                characters[k] = characters[n];
                characters[n] = value;
            }
            return new string(characters);
        }

        private List<CauHoi> RandomizeQuestions(List<CauHoi> questions)
        {
            if (questions != null)
            {
                List<CauHoi> randomizedQuestions = new List<CauHoi>(questions);
                Random rng = new Random();

                int n = randomizedQuestions.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    CauHoi value = randomizedQuestions[k];
                    randomizedQuestions[k] = randomizedQuestions[n];
                    randomizedQuestions[n] = value;
                }
                return randomizedQuestions;
            }
            else
            {
                // Xử lý khi danh sách questions là null (ví dụ: trả về danh sách trống)
                return new List<CauHoi>();
            }
        }

        private void RandomizeQuestionAnswers(CauHoi question)
        {
            // Lưu đáp án ban đầu
            string originalA = question.A;
            string originalB = question.B;
            string originalC = question.C;
            string originalD = question.D;

            if (question.DapAnDung == "A")
            {
                question.DapAnDung = originalA;
            }
            else if (question.DapAnDung == "B")
            {
                question.DapAnDung = originalB;
            }
            else if (question.DapAnDung == "C")
            {
                question.DapAnDung = originalC;
            }
            else if (question.DapAnDung == "D")
            {
                question.DapAnDung = originalD;
            }

            // Đảo ngẫu nhiên các đáp án
            string[] randomizedAnswers = RandomizeAnswers(new[] { originalA, originalB, originalC, originalD });

            // Cập nhật đáp án A, B, C, D theo vị trí đảo ngẫu nhiên
            question.A = randomizedAnswers[0];
            question.B = randomizedAnswers[1];
            question.C = randomizedAnswers[2];
            question.D = randomizedAnswers[3];

            // Cập nhật đáp án đúng tương ứng với đáp án đã đảo ngẫu nhiên
            if (question.A == question.DapAnDung)
            {
                question.DapAnDung = "A";
            }
            else if (question.B == question.DapAnDung)
            {
                question.DapAnDung = "B";
            }
            else if (question.C == question.DapAnDung)
            {
                question.DapAnDung = "C";
            }
            else if (question.D == question.DapAnDung)
            {
                question.DapAnDung = "D";
            }
        }

        private int GenerateNewMaHienThi()
        {
            using (DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities())
            {
                int newMaHienThi;
                do
                {
                    newMaHienThi = new Random().Next(100, 1000);
                }
                while (db.DeThis.Any(d => d.MaHienThi == newMaHienThi));
                return newMaHienThi;
            }
        }
    }
}
