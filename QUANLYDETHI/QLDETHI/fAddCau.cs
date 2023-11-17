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

        //public fAddCau(MaGV)
        //{
        //    InitializeComponent();
        //    user = LuuTru.User;
        //    MaGV = user.IdTK;
        //}
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
                //cbxMonHoc1.Controls.Clear();
                //int selectedKhoiId = (int)cbxKhoi.SelectedValue;

                //// Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                //var MonHocList = db.MonHocs.Where(c => c.MaKhoi == selectedKhoiId).ToList();
                //cbxMonHoc1.DataSource = MonHocList;
                //cbxMonHoc1.DisplayMember = "TenMonHoc";
                //cbxMonHoc1.ValueMember = "MaMonHoc";

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
                f2.txbKhoi.Text = k.MaKhoi.ToString();
                f2.txbMonHoc.Text = k.MaMonHoc.ToString();
                f2.txbChuong.Text = k.MaChuong.ToString();
                f2.txbBai.Text = k.MaBai.ToString();
                f2.txbDoKho.Text = k.DoKho.ToString();
                f2.txbTrangThai.Text = k.TrangThai.ToString();
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
        #region Work with word
        //đoạn này còn xài tốt đừng xóa

        //private void richWordDeThi_Click(object sender, EventArgs e)
        //{
        //    // Lấy dòng văn bản được bôi đen
        //    DocumentRange selectedRange = richWordDeThi.Document.Selection;

        //    if (selectedRange.Length > 0)
        //    {
        //        string selectedText = richWordDeThi.Document.GetText(selectedRange);

        //        // Khai báo biểu thức chính quy để tìm các dòng chứa câu hỏi và đáp án
        //        //string cauHoiPattern = @"Câu \d+(?:\s+:\s+)?(.*?)(?:\?\s)?\nA\. (.*?)\nB\. (.*?)\nC\. (.*?)\nD\. (.*?)(?:\s|$)";
        //        string cauHoiPattern = @"Câu \d+\.(.*?)(?:\?\s)?\nA\. (.*?)\nB\. (.*?)\nC\. (.*?)\nD\. (.*?)(?:\s|$)";

        //        // Tìm các mẫu khớp trong selectedText
        //        MatchCollection matches = Regex.Matches(selectedText, cauHoiPattern);

        //        // Nếu có mẫu nào khớp, lấy thông tin từ mẫu đầu tiên (giả sử có chỉ một mẫu khớp)
        //        foreach (System.Text.RegularExpressions.Match match in matches)
        //        {
        //            string question = match.Groups[1].Value;
        //            string optionA = match.Groups[2].Value;
        //            string optionB = match.Groups[3].Value;
        //            string optionC = match.Groups[4].Value;
        //            string optionD = match.Groups[5].Value;
        //            // Lưu thông tin vào cơ sở dữ liệu
        //            SaveData(question, optionA, optionB, optionC, optionD);

        //        }
        //    }
        //    else
        //    {
        //        // Nếu không có gì được bôi đen, bạn có thể xử lý theo cách phù hợp cho ứng dụng của mình.
        //    }
        //}



        private void richWordDeThi_Click(object sender, EventArgs e)
        {
            //// Lấy dòng văn bản được bôi đen
            //DocumentRange selectedRange = richWordDeThi.Document.Selection;

            //if (selectedRange.Length > 0)
            //{

            //    //// Lấy màu sắc của văn bản được bôi đen
            //    //CharacterProperties charProps = richWordDeThi.Document.BeginUpdateCharacters(selectedRange);
            //    //Color? textColor = charProps.ForeColor; // Màu sắc của văn bản

            //    //if (textColor.HasValue)
            //    //{
            //    //    // Hiển thị thông báo về màu sắc
            //    //    MessageBox.Show($"Màu văn bản: {textColor.Value} - {textColor.Value.IsEmpty}");                 

            //    //    // Tại đây, bạn có thể xác định xem màu sắc có khớp với màu bạn đang tìm không và thực hiện các tác vụ cần thiết.
            //    //}

            //    //// Kết thúc cập nhật màu sắc
            //    //richWordDeThi.Document.EndUpdateCharacters(charProps);

            //    string selectedText = richWordDeThi.Document.GetText(selectedRange);

            //    // Khai báo biểu thức chính quy để tìm các dòng chứa câu hỏi và đáp án
            //    string cauHoiPattern = @"Câu \d+\s*\.\s*(.+)\s*?A\.\s*(.+)\s*?B\.\s*(.+)\s*?C\.\s*(.+)\s*?D\.\s*(.+)\s*?";

            //    // Tìm các mẫu khớp trong selectedText
            //    MatchCollection matches = Regex.Matches(selectedText, cauHoiPattern);

            //    // Vị trí con trỏ trong selectRange
            //    int index = 0;
            //    // Nếu có mẫu nào khớp, lấy thông tin từ mẫu đầu tiên (giả sử có chỉ một mẫu khớp)
            //    foreach (System.Text.RegularExpressions.Match match in matches)
            //    {
            //        string question = match.Groups[1].Value;
            //        string optionA = match.Groups[2].Value;
            //        string optionB = match.Groups[3].Value;
            //        string optionC = match.Groups[4].Value;
            //        string optionD = match.Groups[5].Value;

            //        // Xác đinh vị trí câu hỏi (vì question chỉ lưu nội dung câu hỏi)
            //        // Nên công thêm cả độ dài "Câu <x>. "
            //        // ở đây dùng bù trừ, tính luôn kí tự \n
            //        index += selectedText.Length - (optionA.Length + optionB.Length + optionC.Length + optionD.Length + 3);
            //        DocumentPosition currentPosition = richWordDeThi.Document.CreatePosition(selectedRange.Start.ToInt() + index);
            //        DocumentRange range = richWordDeThi.Document.CreateRange(currentPosition, optionA.Length);
            //        string selectText = richWordDeThi.Document.GetText(range);


            //        DocumentPosition questionPosition = richWordDeThi.Document.CreatePosition(selectedRange.Start.ToInt() + index);
            //        index += optionA.Length
            //            + optionB.Length
            //            + optionC.Length
            //            + optionD.Length;

            //        // Xác định đáp án đúng dựa trên màu của chữ
            //        string correctAnswer = DetermineCorrectAnswer(selectedRange, currentPosition, optionA, optionB, optionC, optionD);


            //        // Lưu thông tin vào cơ sở dữ liệu
            //        SaveData(question.Trim(), optionA.Trim(), optionB.Trim(), optionC.Trim(), optionD.Trim(), correctAnswer);

            //    }
            //}
            //else
            //{
            //    // Nếu không có gì được bôi đen, bạn có thể xử lý theo cách phù hợp cho ứng dụng của mình.
            //}
        }


        //private string DetermineCorrectAnswer(DocumentRange selectedRange, DocumentPosition currentPosition, string optionA, string optionB, string optionC, string optionD)
        //{
            //correctAnswer = "";

            //for (int i = 0; i < optionA.Length && correctAnswer == ""; i++)
            //{
            //    currentPosition = richWordDeThi.Document.CreatePosition(currentPosition.ToInt() + i);
            //    DocumentRange range = richWordDeThi.Document.CreateRange(currentPosition, 1);

            //    CharacterProperties charProps = richWordDeThi.Document.BeginUpdateCharacters(range);

            //    if (IsRedColor(charProps.ForeColor))
            //    {
            //        // Nếu màu sắc là đỏ, thì ký tự hiện tại là một phần của đáp án đúng
            //        correctAnswer += richWordDeThi.Document.GetText(range);
            //        //correctAnswer = "A";
            //    }

            //    richWordDeThi.Document.EndUpdateCharacters(charProps);
            //}

            //for (int i = 0; i < optionB.Length && correctAnswer == ""; i++)
            //{
            //    currentPosition = richWordDeThi.Document.CreatePosition(currentPosition.ToInt() + i);
            //    DocumentRange range = richWordDeThi.Document.CreateRange(currentPosition, 1);
            //    CharacterProperties charProps = richWordDeThi.Document.BeginUpdateCharacters(range);

            //    if (IsRedColor(charProps.ForeColor))
            //    {
            //        // Nếu màu sắc là đỏ, thì ký tự hiện tại là một phần của đáp án đúng
            //        //correctAnswer += GetOptionForIndex(i);
            //        //correctAnswer = "B";
            //        correctAnswer += richWordDeThi.Document.GetText(range);
            //    }

            //    richWordDeThi.Document.EndUpdateCharacters(charProps);
            //}
            //for (int i = 0; i < optionC.Length && correctAnswer == ""; i++)
            //{
            //    currentPosition = richWordDeThi.Document.CreatePosition(currentPosition.ToInt() + i);
            //    DocumentRange range = richWordDeThi.Document.CreateRange(currentPosition, 1);
            //    CharacterProperties charProps = richWordDeThi.Document.BeginUpdateCharacters(range);

            //    if (IsRedColor(charProps.ForeColor))
            //    {
            //        // Nếu màu sắc là đỏ, thì ký tự hiện tại là một phần của đáp án đúng
            //        //correctAnswer += GetOptionForIndex(i);
            //        //correctAnswer = "C";
            //        correctAnswer += richWordDeThi.Document.GetText(range);
            //    }

            //    richWordDeThi.Document.EndUpdateCharacters(charProps);
            //}

            //for (int i = 0; i < optionD.Length && correctAnswer == ""; i++)
            //{
            //    currentPosition = richWordDeThi.Document.CreatePosition(currentPosition.ToInt() + i);
            //    DocumentRange range = richWordDeThi.Document.CreateRange(currentPosition, 1);
            //    CharacterProperties charProps = richWordDeThi.Document.BeginUpdateCharacters(range);

            //    if (IsRedColor(charProps.ForeColor))
            //    {
            //        // Nếu màu sắc là đỏ, thì ký tự hiện tại là một phần của đáp án đúng
            //        //correctAnswer += GetOptionForIndex(i);
            //        //correctAnswer = "D";
            //        correctAnswer += richWordDeThi.Document.GetText(range);

            //    }

            //    richWordDeThi.Document.EndUpdateCharacters(charProps);
            //}

            //return correctAnswer;


        //}


        //private bool IsRedColor(Color? color)
        //{
        //    //// So sánh màu với màu đỏ cụ thể
        //    //return color.HasValue && color.Value.A == 255 && color.Value.R == 255 && color.Value.G == 0 && color.Value.B == 0;

        //    // Có được tô màu hay không
        //    return color.HasValue && !color.Value.IsEmpty;
        //}


        #endregion



        void _showHide(bool kt)
        {
            barLuu.Enabled = !kt;
            barHuy.Enabled = !kt;
            barThem.Enabled = kt;
            barSua.Enabled = kt;
            barXoa.Enabled = kt;
            barDong.Enabled = kt;
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
                    k.HinhAnh = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);
                    // Kiểm tra xem có ảnh mới được chọn hay không
                    // Kiểm tra xem ảnh hiện tại có phải là ảnh mặc định không
                    if (IsDefaultImage(picHinhAnh.Image))
                    {
                        k.HinhAnh = null; // Đặt giá trị HinhAnh thành null nếu đang sử dụng ảnh mặc định
                    }
                    else
                    {
                        // Sử dụng đường dẫn tương đối đến thư mục "image"
                        //string defaultImagePath = "QUANLYDETHI/QLYDETHI/image/image-preview-icon-picture-placeholder-vector-31284806.jpg";
                        k.HinhAnh = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);
                    }
                    k.MaKhoi = int.Parse(cbxKhoi.SelectedValue.ToString());
                    k.MaMonHoc = int.Parse(cbxMonHoc1.SelectedValue.ToString());
                    k.MaChuong = int.Parse(cbxChuong.SelectedValue.ToString());
                    k.MaBai = int.Parse(cbxBai.SelectedValue.ToString());
                    k.DoKho = int.Parse(cbxDoKho.SelectedValue.ToString());
                    k.TrangThai = int.Parse(cbxTrangThai.Text);
                    k.GhiChu = txtGhiChu.Text;
                    _cauhoi.Add(k);
                //}
                };
            }
        }
        // Phương thức kiểm tra xem ảnh có phải là ảnh mặc định hay không
        bool IsDefaultImage(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Sử dụng đường dẫn tương đối đến thư mục "image"
                string defaultImagePath = "..\\..\\image\\image-preview-icon-picture-placeholder-vector-31284806.jpg";
                Image defaultImage = Image.FromFile(defaultImagePath);
                defaultImage.Save(ms, ImageFormat.Jpeg);
                byte[] defaultImageBytes = ms.ToArray();

                using (MemoryStream imageMs = new MemoryStream())
                {
                    image.Save(imageMs, image.RawFormat);
                    byte[] imageBytes = imageMs.ToArray();

                    return StructuralComparisons.StructuralEqualityComparer.Equals(imageBytes, defaultImageBytes);
                }
            }
        }
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat fomat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, fomat);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
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

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png, .jpg)|*.png;*.jpg";
            openFile.Title = "Chọn hình ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = Image.FromFile(openFile.FileName);
                picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private MatchCollection matches;

        
        private void barLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (matches != null && matches.Count > 0)
            {
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    string cauhoi = match.Groups[1].Value;
                    string dapAnA = match.Groups[2].Value;
                    string dapAnB = match.Groups[3].Value;
                    string dapAnC = match.Groups[4].Value;
                    string dapAnD = match.Groups[5].Value;

                    SaveData(cauhoi, dapAnA, dapAnB, dapAnC, dapAnD, correctAnswer);
                }
                loadData();
                _them = false;
            }
            else
            {
                // Xử lý khi không có mẫu hoặc matches là null
            }

            loadData();
        }
        

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaCauHoi").ToString());
                var k = _cauhoi.getItem(_id);
                picHinhAnh.Image = Base64ToImage(k.HinhAnh);
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
                cbxTrangThai.Text = k.TrangThai.ToString();
                txtGhiChu.Text = k.GhiChu;
                _cauhoi.Update(k);
            }

        }

        private void btnThemCH_Click(object sender, EventArgs e)
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
                        // In câu hỏi và các đáp án tương ứng
                        //Console.WriteLine(currentQuestion);
                        //for (int i = 0; i < 4; i++)
                        //{
                        //    Console.WriteLine($"Đáp án {((char)('A' + i))}: {currentAnswers[i]}");
                        //}

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
        }

        private Word.WdColor GetRowColor(Word.Paragraph paragraph)
        {
            // Lấy định dạng của dòng
            Word.ParagraphFormat format = paragraph.Format;

            // Lấy màu sắc từ định dạng
            Word.Shading shading = format.Shading;
            Word.WdColor color = shading.BackgroundPatternColor;

            return color;
        }
    }

}