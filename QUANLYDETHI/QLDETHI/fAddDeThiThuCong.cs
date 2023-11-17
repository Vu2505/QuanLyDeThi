using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using DethiLayer;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using QLDETHI.Luutru;

namespace QLDETHI
{
    public partial class fAddDeThiThuCong : Form
    {
        private TaiKhoan user;
        int IdTK;
        public fAddDeThiThuCong()
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
        }
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        CHUONG _chuong;
        BAI _bai;
        MONHOC _monhoc;
        KHOI _khoi;
        CAUHOI _cauhoi;
        LOP _lop;
        NAMHOC _namhoc;
        Taodethi.DeThi deThi = new Taodethi.DeThi();
        Chuong chuongDangChon;
        Bai baiDangChon;
        List<CauHoi> selectedCauHoiList = new List<CauHoi>();
        HOCKY _hocky;
        THOIGIANTHI _thoigianthi;
        private void fAddDeThiThuCong_Load(object sender, EventArgs e)
        {
            _chuong = new CHUONG();
            _bai = new BAI();
            _monhoc = new MONHOC();
            _khoi = new KHOI();
            _cauhoi = new CAUHOI();
            _lop = new LOP();
            _namhoc = new NAMHOC();
            _hocky = new HOCKY();
            _thoigianthi = new THOIGIANTHI();
            loadData();
            loadCombo();
        }

        void loadCombo()
        {
            if (user.LoaiTaiKhoan == 1)
            {
                cbxMonHoc1.DataSource = _monhoc.getListFull();
                cbxMonHoc1.DisplayMember = "TenMonHoc";
                cbxMonHoc1.ValueMember = "MaMonHoc";
            }
            else
            {
                cbxMonHoc1.DataSource = _monhoc.getListFullTK(IdTK);
                cbxMonHoc1.DisplayMember = "TenMonHoc";
                cbxMonHoc1.ValueMember = "MaMonHoc";
            }

            cbxKhoi.DataSource = _khoi.getList();
            cbxKhoi.DisplayMember = "TenKhoi";
            cbxKhoi.ValueMember = "MaKhoi";

            cbxLop.DataSource = _lop.getList();
            cbxLop.DisplayMember = "TenLop";
            cbxLop.ValueMember = "MaLop";

            cbxNamHoc.DataSource = _namhoc.getList();
            cbxNamHoc.DisplayMember = "TenNamHoc";
            cbxNamHoc.ValueMember = "MaNamHoc";

            cbxHocKy.DataSource = _hocky.getList();
            cbxHocKy.DisplayMember = "TenHocKy";
            cbxHocKy.ValueMember = "MaHocKy";

            cbxThoiGianThi.DataSource = _thoigianthi.getList();
            cbxThoiGianThi.DisplayMember = "TenThoiGianThi";
            cbxThoiGianThi.ValueMember = "MaThoiGianThi";
        }

        void loadData()
        {
            if (user.LoaiTaiKhoan == 1)
            {
                gridCauHoi.DataSource = _cauhoi.getListFullGV();
                gvDanhSach.OptionsBehavior.Editable = false;
            }
            else
            {
                gridCauHoi.DataSource = _cauhoi.getListFullGV(IdTK);
                gvDanhSach.OptionsBehavior.Editable = false;
            }
        }

        private void cbxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (user.LoaiTaiKhoan == 1)
                {
                    cbxLop.Controls.Clear();
                    cbxMonHoc1.Controls.Clear();
                    int selectedKhoiId = (int)cbxKhoi.SelectedValue;

                    var LopList = db.Lops.Where(c => c.MaKhoi == selectedKhoiId).ToList();
                    cbxLop.DataSource = LopList;
                    cbxLop.DisplayMember = "TenLop";
                    cbxLop.ValueMember = "MaLop";

                    // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                    var MonHocList = db.MonHocs.Where(c => c.MaKhoi == selectedKhoiId).ToList();
                    cbxMonHoc1.DataSource = MonHocList;
                    cbxMonHoc1.DisplayMember = "TenMonHoc";
                    cbxMonHoc1.ValueMember = "MaMonHoc";
                }
                else
                {
                    cbxLop.Controls.Clear();
                    cbxMonHoc1.Controls.Clear();
                    int selectedKhoiId = (int)cbxKhoi.SelectedValue;

                    var LopList = db.Lops.Where(c => c.MaKhoi == selectedKhoiId).ToList();
                    cbxLop.DataSource = LopList;
                    cbxLop.DisplayMember = "TenLop";
                    cbxLop.ValueMember = "MaLop";

                    // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                    var MonHocList = db.MonHocs
                                .Where(c => c.MaKhoi == selectedKhoiId)
                                .Where(c => db.TaiKhoanMonHocs.Any(tm => tm.MaMonHoc == c.MaMonHoc && tm.IdTK == IdTK))
                                .ToList();
                    cbxMonHoc1.DataSource = MonHocList;
                    cbxMonHoc1.DisplayMember = "TenMonHoc";
                    cbxMonHoc1.ValueMember = "MaMonHoc";
                }
            }
            catch (InvalidCastException ex)
            {
                // Xử lý trường hợp không thể ép kiểu thành công.
                //MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void cbxMonHoc1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                flpChuong.Controls.Clear();
                int selectedMonHocId = (int)cbxMonHoc1.SelectedValue;

                // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                List<Chuong> chuongList = db.Chuongs.Where(c => c.MaMonHoc == selectedMonHocId).ToList();
                foreach (Chuong item in chuongList)
                {
                    Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                    btn.Text = item.TenChuong + Environment.NewLine;
                    btn.Click += btnChuong_Click;
                    btn.Tag = item;
                    //btn.BackColor = Color.White;
                    flpChuong.Controls.Add(btn);
                }
            }
            catch (InvalidCastException ex)
            {
                // Xử lý trường hợp không thể ép kiểu thành công.
                //MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        void btnChuong_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các nút hiện có trong flpBai
            flpBai.Controls.Clear();

            // Lấy thông tin liên quan từ nút được nhấp (ví dụ: item.MaChuong)
            Button clickedButton = (Button)sender;
            chuongDangChon = (Chuong)clickedButton.Tag;
            int maChuong = int.Parse(chuongDangChon.MaChuong.ToString()); // Giả sử bạn đã đặt Tag cho nút là maChuong

            // Dựa vào maChuong, tạo danh sách các bài tương ứng
            List<Bai> baiList = db.Bais.Where(c => c.MaChuong == maChuong).ToList();

            // Lưu trạng thái màu của các bài
            Dictionary<int, Color> baiColors = new Dictionary<int, Color>();
            foreach (Bai item in baiList)
            {
                Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                btn.Text = item.TenBai + Environment.NewLine;
                btn.Click += btnBai_Click;
                btn.Tag = item;
                var cauHoisInBai = db.CauHois.Where(c => c.MaBai == item.MaBai).ToList();

                // Kiểm tra xem bài có câu hỏi được chọn không và cập nhật màu cho bài
                if (cauHoisInBai.Any(cauHoi => selectedCauHoiStates.ContainsKey(cauHoi.MaCauHoi) && selectedCauHoiStates[cauHoi.MaCauHoi]))
                {
                    btn.BackColor = Color.Yellow; // Màu của bài khi có câu hỏi được chọn
                }
                else
                {
                    btn.BackColor = Color.White; // Màu gốc của bài khi không có câu hỏi được chọn
                }
                flpBai.Controls.Add(btn);
                deThi.ThemBaiVaoChuong(chuongDangChon.MaChuong, item.MaBai);
            }
        }

        bool AnyCauHoiSelectedInBai(int maBai)
        {
            return db.CauHois.Any(c => c.MaBai == maBai && db.NoiDungDeThis.Any(nd => nd.MaCauHoi == c.MaCauHoi));
        }

        void btnBai_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            baiDangChon = (Bai)clickedButton.Tag;
            int maBai = baiDangChon.MaBai;

            // Đảm bảo sự tồn tại của baiButton trong danh sách các bài
            Button baiButton = flpBai.Controls.OfType<Button>().FirstOrDefault(btn => (Bai)btn.Tag == baiDangChon);
            if (baiButton == null)
            {
                // Nếu baiButton không tồn tại, tạo baiButton mới và đặt trạng thái chọn bài
                baiButton = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                baiButton.Text = baiDangChon.TenBai + Environment.NewLine;
                baiButton.Click += btnBai_Click;
                baiButton.Tag = baiDangChon;

                // Kiểm tra xem bài đã chứa câu hỏi nào được chọn hay chưa
                bool anyCauHoiSelectedInBai = AnyCauHoiSelectedInBai(maBai);
                if (anyCauHoiSelectedInBai)
                {
                    baiButton.BackColor = Color.Yellow; // Màu của bài khi có câu hỏi được chọn
                }
                else
                {
                    baiButton.BackColor = Color.White; // Màu gốc của bài khi không có câu hỏi được chọn
                }
                flpBai.Controls.Add(baiButton);
                deThi.ThemBaiVaoChuong(chuongDangChon.MaChuong, maBai);
                LoadCauHoiForBai(maBai);
            }
            else
            {
                // Nếu baiButton đã tồn tại, không đặt lại màu
                // Đảm bảo cập nhật lại checkbox cho câu hỏi trong bài
                LoadCauHoiForBai(maBai);
            }
        }

        private void LoadCauHoiForBai(int maBai)
        {
            // Lấy danh sách câu hỏi cho bài được chọn
            var cauHoiList = db.CauHois.Where(c => c.MaBai == maBai).ToList();

            // Đặt nguồn dữ liệu cho GridControl
            gridCauHoi.DataSource = cauHoiList;

            // Đảm bảo cập nhật trạng thái của các checkbox dựa trên selectedCauHoiStates
            foreach (CauHoi cauHoi in cauHoiList)
            {
                int maCauHoi = cauHoi.MaCauHoi;
                ////Đặt trạng thái cho checkbox trong GridView dựa trên selectedCauHoiStates
                //bool isChecked = selectedCauHoiStates.ContainsKey(maCauHoi) && selectedCauHoiStates[maCauHoi];
                // Đặt trạng thái cho checkbox trong GridView dựa trên selectedCauHoiStates
                if (selectedCauHoiStates.ContainsKey(maCauHoi) && selectedCauHoiStates[maCauHoi])
                {
                    for (int i = 0; i < gvDanhSach.RowCount; i++)
                    {
                        CauHoi rowCauHoi = (CauHoi)gvDanhSach.GetRow(i);
                        if (rowCauHoi.MaCauHoi == maCauHoi)
                        {
                            gvDanhSach.SelectRow(i);
                            break;
                        }
                    }
                }
            }
        }

        List<int> selectedMaCauHoiIds = new List<int>();
        // Khai báo biến để lưu trạng thái chọn của từng câu hỏi
        Dictionary<int, bool> selectedCauHoiStates = new Dictionary<int, bool>();

        //private bool isGridViewSelectionEvent = true;
        private void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                CauHoi cauHoi = (CauHoi)gvDanhSach.GetRow(e.ControllerRow);
                int maCauHoi = cauHoi.MaCauHoi;

                if (gvDanhSach.IsRowSelected(e.ControllerRow))
                {
                    // Dòng được chọn
                    if (!selectedMaCauHoiIds.Contains(maCauHoi))
                    {
                        selectedMaCauHoiIds.Add(maCauHoi);
                    }
                    // Cập nhật trạng thái chọn trong biến
                    selectedCauHoiStates[maCauHoi] = true;
                }
                else
                {
                    // Dòng bị bỏ chọn
                    if (selectedMaCauHoiIds.Contains(maCauHoi))
                    {
                        selectedMaCauHoiIds.Remove(maCauHoi);
                    }
                    // Cập nhật trạng thái chọn trong biến
                    selectedCauHoiStates[maCauHoi] = false;
                }

                // Cập nhật giao diện người dùng
                UpdateCauHoiColors();

                // Cập nhật flpKetQuaRangBuoc
                UpdateKetQuaRangBuoc();

                // Cập nhật lbTongSoCauDaChon
                UpdateTongSoCauDaChon();
            }
        }

        // Hàm cập nhật lbTongSoCauDaChon
        private void UpdateTongSoCauDaChon()
        {
            int tongSoCauMuonTao = (int)nudSoCauHoiMuonTao.Value; // Số câu muốn tạo từ numericUpDown
            int tongSoCauDaChon = selectedMaCauHoiIds.Count;
            // Kiểm tra xem tổng số câu đã chọn có vượt quá số câu muốn tạo hay không
            // Kiểm tra xem tổng số câu đã chọn có vượt quá số câu muốn tạo hay không
            if (tongSoCauDaChon > tongSoCauMuonTao)
            {
                MessageBox.Show("Số câu đã chọn vượt quá số câu muốn tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Bạn có thể thực hiện một số xử lý tại đây, ví dụ, hủy chọn dòng cuối cùng hoặc bất kỳ xử lý nào khác cần thiết.
                // Ví dụ: Bỏ chọn dòng cuối cùng
                lbTongSoCauDaChon.Text = tongSoCauDaChon.ToString();
                gvDanhSach.UnselectRow(gvDanhSach.FocusedRowHandle);
            }
            else
            {
                lbTongSoCauDaChon.Text = tongSoCauDaChon.ToString();
            }
        }

        private void UpdateKetQuaRangBuoc()
        {
            flpKetQuaRangBuoc.Controls.Clear();
            // Tạo danh sách các chuỗi thông tin cho chương và bài có câu hỏi
            List<string> ketQuaRangBuoc = new List<string>();
            if (chuongDangChon != null)
            {
                var chuongButtons = flpChuong.Controls.OfType<Button>().Where(btn => btn.BackColor == Color.Yellow).ToList();
                foreach (var chuongButton in chuongButtons)
                {
                    Chuong chuong = (Chuong)chuongButton.Tag;
                    int maChuong = chuong.MaChuong;
                    var baiButtons = flpBai.Controls.OfType<Button>().Where(btn => ((Bai)btn.Tag).MaChuong == maChuong && btn.BackColor == Color.Yellow).ToList();
                    List<string> chuongInfo = new List<string>();
                    foreach (var baiButton in baiButtons)
                    {
                        Bai bai = (Bai)baiButton.Tag;
                        int maBai = bai.MaBai;
                        var cauHoisInBai = db.CauHois.Where(c => c.MaBai == maBai).ToList();

                        int selectedCauHoiCount = cauHoisInBai.Count(cauHoi => selectedCauHoiStates.ContainsKey(cauHoi.MaCauHoi) && selectedCauHoiStates[cauHoi.MaCauHoi]);

                        if (selectedCauHoiCount > 0)
                        {
                            // Tạo chuỗi thông tin bài có câu hỏi
                            string baiInfo = $"{bai.TenBai}: {selectedCauHoiCount} câu";
                            chuongInfo.Add(baiInfo);
                        }
                    }
                    if (chuongInfo.Any())
                    {
                        // Tạo chuỗi chứa thông tin của chương hiện tại
                        string chuongInfoText = $"{chuong.TenChuong}: ({string.Join(" | ", chuongInfo)})";
                        ketQuaRangBuoc.Add(chuongInfoText);
                    }
                }
            }

            // Hiển thị tất cả thông tin trên một label
            string ketQuaText = string.Join(" | ", ketQuaRangBuoc);
            var label = new Label
            {
                Text = ketQuaText,
                AutoSize = true,
            };
            flpKetQuaRangBuoc.Controls.Add(label);
        }

        // Khai báo Dictionary để lưu trạng thái màu của từng chương và bài
        Dictionary<int, bool> chuongColorStatus = new Dictionary<int, bool>();
        Dictionary<int, bool> baiColorStatus = new Dictionary<int, bool>();
        private void UpdateCauHoiColors()
        {
            // Xóa tất cả trạng thái màu cũ
            foreach (var chuongButton in flpChuong.Controls.OfType<Button>())
            {
                chuongButton.BackColor = Color.White; // Màu gốc của chương
                Chuong chuong = (Chuong)chuongButton.Tag;
                int maChuong = chuong.MaChuong;
                chuongColorStatus[maChuong] = false;
            }
            foreach (var baiButton in flpBai.Controls.OfType<Button>())
            {
                baiButton.BackColor = Color.White; // Màu gốc của bài
                Bai bai = (Bai)baiButton.Tag;
                int maBai = bai.MaBai;
                baiColorStatus[maBai] = false;
            }

            // Duyệt qua tất cả câu hỏi và cập nhật Dictionary
            foreach (var cauHoi in db.CauHois)
            {
                int maChuong = cauHoi.MaChuong.GetValueOrDefault();
                int maBai = cauHoi.MaBai.GetValueOrDefault();

                // Kiểm tra xem câu hỏi này đã được chọn hay chưa
                bool cauHoiSelected = selectedCauHoiStates.ContainsKey(cauHoi.MaCauHoi) && selectedCauHoiStates[cauHoi.MaCauHoi];

                // Nếu câu hỏi đã được chọn, cập nhật trạng thái màu cho chương và bài
                if (cauHoiSelected)
                {
                    chuongColorStatus[maChuong] = true;
                    baiColorStatus[maBai] = true;
                }
            }

            // Duyệt qua tất cả nút chương và cập nhật màu
            foreach (var chuongButton in flpChuong.Controls.OfType<Button>())
            {
                Chuong chuong = (Chuong)chuongButton.Tag;
                int maChuong = chuong.MaChuong;

                if (chuongColorStatus.ContainsKey(maChuong) && chuongColorStatus[maChuong])
                {
                    chuongButton.BackColor = Color.Yellow; // Màu của chương khi có câu hỏi được chọn
                }
            }

            // Duyệt qua tất cả nút bài và cập nhật màu
            foreach (var baiButton in flpBai.Controls.OfType<Button>())
            {
                Bai bai = (Bai)baiButton.Tag;
                int maBai = bai.MaBai;

                if (baiColorStatus.ContainsKey(maBai) && baiColorStatus[maBai])
                {
                    baiButton.BackColor = Color.Yellow; // Màu của bài khi có câu hỏi được chọn
                }
            }
        }

        private void nudSoCauHoiMuonTao_ValueChanged(object sender, EventArgs e)
        {
            int tongSoCauMuonTao = (int)nudSoCauHoiMuonTao.Value;
            lbTongSoCauMuonTao.Text = tongSoCauMuonTao.ToString();

            // Kiểm tra điều kiện trước khi tạo đề thi
            int tongSoCauDaChon = selectedMaCauHoiIds.Count;

            if (tongSoCauDaChon > tongSoCauMuonTao)
            {
                MessageBox.Show("Tổng số câu đã chọn không được vượt quá tổng số câu muốn tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Đặt lại giá trị của NumericUpDown về giá trị trước khi thay đổi
                nudSoCauHoiMuonTao.Value = selectedMaCauHoiIds.Count;
            }

        }

        void btnTaoDeThi_Click(object sender, EventArgs e)
        {
            int tongSoCauMuonTao = (int)nudSoCauHoiMuonTao.Value;
            int tongSoCauDaChon = selectedMaCauHoiIds.Count;

            if (tongSoCauDaChon < tongSoCauMuonTao)
            {
                MessageBox.Show("Tổng số câu đã chọn không đủ để tạo đề thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Tạo đề thi mới
            DeThi newDeThi = new DeThi
            {
                NamHoc = (int)cbxNamHoc.SelectedValue, // Thay bằng giá trị thích hợp
                TenDeThi = txbTenDeThi.Text,   // Thay bằng giá trị thích hợp
                MaHienThi = GenerateNewMaHienThi(),
                MaThoiGianThi = (int)cbxThoiGianThi.SelectedValue, // Thay bằng giá trị thích hợp
                SoCauHoi = selectedMaCauHoiIds.Count, // Số câu hỏi được chọn
                MaMonHoc = (int)cbxMonHoc1.SelectedValue, // Mã môn học
                MaKhoi = (int)cbxKhoi.SelectedValue, // Mã khối
                MaLop = (int)cbxLop.SelectedValue, // Mã lớp
                MaHocKy = (int)cbxHocKy.SelectedValue,
                MaGiangVien = IdTK, // Thay bằng giá trị thích hợp
            };

            // Thêm đề thi vào cơ sở dữ liệu
            db.DeThis.Add(newDeThi);
            db.SaveChanges(); // Lưu thay đổi để có mã đề thi mới

            // Lấy mã đề thi vừa tạo ra
            int maDeThi = newDeThi.MaDe; // Mã đề thi mới

            int thuTuCauHoi = 1; // Đặt số thứ tự của câu hỏi

            foreach (int cauHoiId in selectedMaCauHoiIds)
            {
                // Lấy thông tin câu hỏi từ ID
                CauHoi cauHoi = db.CauHois.FirstOrDefault(c => c.MaCauHoi == cauHoiId);
                if (cauHoi != null)
                {
                    string dapAnDung = cauHoi.DapAnDung;

                    NoiDungDeThi noiDungDeThi = new NoiDungDeThi
                    {
                        MaDe = maDeThi,
                        MaCauHoi = cauHoiId,
                        ThuTuCauHoi = thuTuCauHoi,
                        ThuTuXepDapAn = 1,
                    };

                    // Thêm noiDungDeThi vào cơ sở dữ liệu
                    db.NoiDungDeThis.Add(noiDungDeThi);

                    thuTuCauHoi++;
                }
            }
            db.SaveChanges();
            
            MessageBox.Show($"Tạo thành công đề {newDeThi.MaHienThi} gồm {newDeThi.SoCauHoi} câu");
            selectedMaCauHoiIds.Clear();

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
