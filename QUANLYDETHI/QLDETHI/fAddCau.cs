using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataLayer;
using DethiLayer;
using System.IO;
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit.API.Native;
using System.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;
using DevExpress.XtraPrinting.Native;

using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using QLDETHI.Luutru;

namespace QLDETHI.Taodethi
{
    public partial class fAddCau : DevExpress.XtraEditors.XtraForm
    {
        private string currentUsername;
        private TaiKhoan user;
        int IdTK;
        public fAddCau()
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
        }

        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        int _id;
        bool _them;
        CAUHOI _cauhoi;
        CHUONG _chuong;
        MONHOC _monhoc;
        KHOI _khoi;
        DOKHO _dokho;
        BAI _bai;
        TAIKHOANMONHOC _taikhoanmonhoc;
        TINHTRANG _tinhtrang;
        private string correctAnswer = ""; // Biến toàn cục để lưu trữ correctAnswer

        private void fAddCau_Load(object sender, EventArgs e)
        {
            _them = false;
            _chuong = new CHUONG();
            _monhoc = new MONHOC();
            _cauhoi = new CAUHOI();
            _khoi = new KHOI();
            _dokho = new DOKHO();
            _bai = new BAI();
            _tinhtrang = new TINHTRANG();
            _taikhoanmonhoc = new TAIKHOANMONHOC();
            _showHide(true);
            loadData();
            loadCombo();
        }
        void loadData()
        {  
            if(user.LoaiTaiKhoan == 1)
            {
                gridCauHoi.DataSource = _cauhoi.getListFull();
                gvDanhSach.OptionsBehavior.Editable = false;
            }
            else
            {
                gridCauHoi.DataSource = _cauhoi.getListFullGV(IdTK);
                gvDanhSach.OptionsBehavior.Editable = false;
            }
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

            cbxDoKho.DataSource = _dokho.getList();
            cbxDoKho.DisplayMember = "TenDoKho";
            cbxDoKho.ValueMember = "MaDoKho";

            cbxChuong.DataSource = _chuong.getList();
            cbxChuong.DisplayMember = "TenChuong";
            cbxChuong.ValueMember = "MaChuong";

            cbxBai.DataSource = _bai.getList();
            cbxBai.DisplayMember = "TenBai";
            cbxBai.ValueMember = "MaBai";
            
            cbxTrangThai.DataSource = _tinhtrang.getList();
            cbxTrangThai.DisplayMember = "TenTinhTrang";
            cbxTrangThai.ValueMember = "MaTinhTrang";
        }

        private void cbxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (user.LoaiTaiKhoan == 1)
                {
                    cbxMonHoc1.Controls.Clear();
                    int selectedKhoiId = (int)cbxKhoi.SelectedValue;

                    // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                    var MonHocList = db.MonHocs.Where(c => c.MaKhoi == selectedKhoiId).ToList();
                    cbxMonHoc1.DataSource = MonHocList;
                    cbxMonHoc1.DisplayMember = "TenMonHoc";
                    cbxMonHoc1.ValueMember = "MaMonHoc";
                }
                else
                {
                    cbxMonHoc1.Controls.Clear();
                    int selectedKhoiId = (int)cbxKhoi.SelectedValue;

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
                cbxChuong.Controls.Clear();
                int selectedMonHocId = (int)cbxMonHoc1.SelectedValue;
                // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                var chuongList = db.Chuongs.Where(c => c.MaMonHoc == selectedMonHocId).ToList();
                cbxChuong.DataSource = chuongList;
                cbxChuong.DisplayMember = "TenChuong";
                cbxChuong.ValueMember = "MaChuong";
            }
            catch (InvalidCastException ex)
            {
                // Xử lý trường hợp không thể ép kiểu thành công.
                //MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void cbxChuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbxBai.Controls.Clear();
                int selectedChuongId = (int)cbxChuong.SelectedValue;
                // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                var baiList = db.Bais.Where(c => c.MaChuong == selectedChuongId).ToList();
                cbxBai.DataSource = baiList;
                cbxBai.DisplayMember = "TenBai";
                cbxBai.ValueMember = "MaBai";
            }
            catch (InvalidCastException ex)
            {
                // Xử lý trường hợp không thể ép kiểu thành công.
                //MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            fDetailsCauHoi f2 = new fDetailsCauHoi();
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaCauHoi").ToString());
                var k = _cauhoi.getItem(_id);
                f2.txbNDCH.Text = k.NDCH;
                f2.txbA.Text = k.A;
                f2.txbB.Text = k.B;
                f2.txbC.Text = k.C;
                f2.txbD.Text = k.D;
                f2.txbDapAnDung.Text = k.DapAnDung;
                f2.picHinhAnh.Image = Base64ToImage(k.HinhAnh);

                if (k.MaKhoi.HasValue)
                {
                    string ten = _cauhoi.getListInfoCauHoi(FieldCauHoi.MaKhoi, (int)k.MaKhoi);
                    f2.txbKhoi.Text = ten;
                }

                if (k.MaMonHoc.HasValue)
                {
                    string ten = _cauhoi.getListInfoCauHoi(FieldCauHoi.MaMonHoc, (int)k.MaMonHoc);
                    f2.txbMonHoc.Text = ten;
                }

                if (k.MaChuong.HasValue)
                {
                    string ten = _cauhoi.getListInfoCauHoi(FieldCauHoi.MaChuong, (int)k.MaChuong);
                    f2.txbChuong.Text = ten;
                }

                if (k.MaBai.HasValue)
                {
                    string ten = _cauhoi.getListInfoCauHoi(FieldCauHoi.MaBai, (int)k.MaBai);
                    f2.txbBai.Text = ten;
                }

                if (k.DoKho.HasValue)
                {
                    string ten = _cauhoi.getListInfoCauHoi(FieldCauHoi.DoKho, (int)k.DoKho);
                    f2.txbDoKho.Text = ten;
                }
                if (k.TrangThai.HasValue)
                {
                    string ten = _cauhoi.getListInfoCauHoi(FieldCauHoi.TrangThai, (int)k.TrangThai);
                    f2.txbTrangThai.Text = ten;
                }  
                f2.txbGhiChu.Text = k.GhiChu;
                _cauhoi.Update(k);
            }
            f2.ShowDialog();
        }

        private void btnAddFileWord_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.doc;*.docx|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                txbNameFile.Text = filePath;
                richWordDeThi.LoadDocument(filePath);
            }
        }
       
        private void richWordDeThi_Click(object sender, EventArgs e)
        {
            
        }

        void _showHide(bool kt)
        {
            barLuu.Enabled = !kt;
            barHuy.Enabled = !kt;
            barThem.Enabled = kt;

            cbxKhoi.Enabled = !kt;
            cbxMonHoc1.Enabled = !kt;
            cbxChuong.Enabled = !kt;
            cbxBai.Enabled = !kt;
            
            cbxDoKho.Enabled = !kt;
            cbxTrangThai.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            //barPrint.Enabled = kt;
            //txtNDCH.Enabled = !kt;
        }
        private void barThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
        }

        void SaveData(string question, string optionA, string optionB, string optionC, string optionD, string correctAnswer)
        {
            if (_them)
            {
                CauHoi k = new CauHoi();
                {
                    k.NDCH = question; // Sử dụng giá trị từ biến cauhoiText
                    k.A = optionA;    // Sử dụng giá trị từ biến dapAnAText
                    k.B = optionB;    // Sử dụng giá trị từ biến dapAnBText
                    k.C = optionC;    // Sử dụng giá trị từ biến dapAnCText
                    k.D = optionD;    // Sử dụng giá trị từ biến dapAnDText
                    k.DapAnDung = correctAnswer;
                    // Kiểm tra xem có ảnh mới được chọn hay không
                    // Kiểm tra xem ảnh hiện tại có phải là ảnh mặc định không
                    k.MaKhoi = int.Parse(cbxKhoi.SelectedValue.ToString());
                    k.MaMonHoc = int.Parse(cbxMonHoc1.SelectedValue.ToString());
                    k.MaChuong = int.Parse(cbxChuong.SelectedValue.ToString());
                    k.MaBai = int.Parse(cbxBai.SelectedValue.ToString());
                    k.DoKho = int.Parse(cbxDoKho.SelectedValue.ToString());
                    k.TrangThai = int.Parse(cbxTrangThai.SelectedValue.ToString());
                    k.MaGiangVien = IdTK;
                    k.GhiChu = txtGhiChu.Text;
                    k.NgayCapNhat = DateTime.UtcNow;
                    _cauhoi.Add(k);
                };
            }
        }
        public Image Base64ToImage(byte[] imageBytes)
        {
            string defaultImagePath = "..\\..\\image\\image-preview-icon-picture-placeholder-vector-31284806.jpg";
            Image image = Image.FromFile(defaultImagePath); ;
            if (imageBytes != null)
            {
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                image = Image.FromStream(ms, true);
            }
            return image;
        }

        private MatchCollection matches;
        private void barLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Đường dẫn đến tệp Word
            string filePath = txbNameFile.Text;

            // Mở ứng dụng Word
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false;

            // Mở tài liệu
            Word.Document doc = wordApp.Documents.Open(filePath);

            bool isQuestion = false;
            string currentQuestion = "";
            string[] currentAnswers = new string[4];
            // Default
            string correctAnswer = "A";

            _them = true;
            int countQuestions = 0;
            foreach (Word.Paragraph paragraph in doc.Paragraphs)
            {
                string text = paragraph.Range.Text.Trim();

                if (text.StartsWith("Câu"))
                {
                    if (isQuestion)
                    {
                        //Thêm câu hỏi vào db
                        SaveData(currentQuestion, currentAnswers[0], currentAnswers[1], currentAnswers[2], currentAnswers[3], correctAnswer);
                        countQuestions += 1;
                    }
                    isQuestion = true;
                    currentQuestion = text.Substring(text.IndexOf(".") + 1);
                    currentAnswers = new string[4];
                }
                else if (isQuestion && !string.IsNullOrWhiteSpace(text))
                {
                    // Lấy đáp án từ các đoạn văn bản không trống
                    if (text.StartsWith("A. "))
                    {
                        currentAnswers[0] = text.Substring(3);
                        if (paragraph.Range.Font.Color != Word.WdColor.wdColorAutomatic)
                        {
                            correctAnswer = "A";
                        }
                    }
                    else if (text.StartsWith("B. "))
                    {
                        currentAnswers[1] = text.Substring(3);
                        if (paragraph.Range.Font.Color != Word.WdColor.wdColorAutomatic)
                        {
                            correctAnswer = "B";
                        }
                    }
                    else if (text.StartsWith("C. "))
                    {
                        currentAnswers[2] = text.Substring(3);
                        if (paragraph.Range.Font.Color != Word.WdColor.wdColorAutomatic)
                        {
                            correctAnswer = "C";
                        }
                    }
                    else if (text.StartsWith("D. "))
                    {
                        currentAnswers[3] = text.Substring(3);
                        if (paragraph.Range.Font.Color != Word.WdColor.wdColorAutomatic)
                        {
                            correctAnswer = "D";
                        }
                    }
                }
            }

            //Thêm câu hỏi cuối vào db
            SaveData(currentQuestion, currentAnswers[0], currentAnswers[1], currentAnswers[2], currentAnswers[3], correctAnswer);
            countQuestions += 1;

            _them = false;
            // Đóng tài liệu và ứng dụng Word
            doc.Close(false);
            Marshal.ReleaseComObject(doc);
            wordApp.Quit();
            Marshal.ReleaseComObject(wordApp);

            MessageBox.Show("Thêm thành công " + countQuestions + " câu");
            loadData();
            _them = false;
            _showHide(true);
        }

        private void barSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaCauHoi").ToString());
                var k = _cauhoi.getItem(_id);
                cbxKhoi.SelectedValue = k.MaKhoi;
                cbxMonHoc1.SelectedValue = k.MaMonHoc;
                cbxChuong.SelectedValue = k.MaChuong;
                try
                {
                    int selectedChuongId = (int)cbxChuong.SelectedValue;
                    // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                    var baiList = db.Bais.Where(c => c.MaChuong == selectedChuongId).ToList();
                    cbxBai.DataSource = baiList;
                    cbxBai.DisplayMember = "TenBai";
                    cbxBai.ValueMember = "MaBai";
                }
                catch (InvalidCastException ex)
                {
                    // Xử lý trường hợp không thể ép kiểu thành công.
                    //MessageBox.Show("Lỗi: " + ex.Message);
                }
                cbxBai.SelectedValue = k.MaBai;
                cbxDoKho.SelectedValue = k.DoKho;
                cbxTrangThai.SelectedValue = k.TrangThai;
                txtGhiChu.Text = k.GhiChu;
                _cauhoi.Update(k);
            }
        }

        private void barHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }
    }

}