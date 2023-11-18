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
using System.IO;
using DevExpress.XtraEditors;
using ClosedXML.Excel;
//using iTextSharp.text.pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
//using DevExpress.DataAccess.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Imaging;
using System.Collections;
using QLDETHI.Luutru;

namespace QLDETHI
{
    public partial class fCauHoi : Form
    {
        private TaiKhoan user;
        int IdTK;
        public fCauHoi()
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
        }
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        CHUONG _chuong;
        MONHOC _monhoc;
        CAUHOI _cauhoi;
        KHOI _khoi;
        DOKHO _dokho;
        BAI _bai;
        TINHTRANG _tinhtrang;
        bool _them;
        int _id;

        private void fCauHoi_Load(object sender, EventArgs e)
        {
            _them = false;
            _chuong = new CHUONG();
            _monhoc = new MONHOC();
            _cauhoi = new CAUHOI();
            _khoi = new KHOI();
            _dokho = new DOKHO();
            _bai = new BAI();
            _tinhtrang = new TINHTRANG();
            _showHide(true);
            loadData();
            loadCombo();

            // Tải danh sách Môn Học vào ComboBox MonHoc
            loadMonHoc();

        }

        void loadData()
        {
            //gridCauHoi.DataSource = _cauhoi.getListFull();
            //gvDanhSach.OptionsBehavior.Editable = false;

            if (user.LoaiTaiKhoan == 1)
            {
                gridCauHoi.DataSource = _cauhoi.getListFull();
                gvDanhSach.OptionsBehavior.Editable = false;
            }
            else
            {
                gridCauHoi.DataSource = _cauhoi.getListFull(IdTK);
                gvDanhSach.OptionsBehavior.Editable = false;
            }

        }


        void loadMonHoc()
        {
            
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

            cbxTinhTrang.DataSource = _tinhtrang.getList();
            cbxTinhTrang.DisplayMember = "TenTinhTrang";
            cbxTinhTrang.ValueMember = "MaTinhTrang";
        }




        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnPrint.Enabled = kt;

            cbxKhoi.Enabled = !kt;
            cbxMonHoc1.Enabled = !kt;
            cbxChuong.Enabled = !kt;
            cbxBai.Enabled = !kt;
            cbxDoKho.Enabled = !kt;
            txtNDCH.Enabled = !kt;
            txtA.Enabled = !kt;
            txtB.Enabled = !kt;
            txtC.Enabled = !kt;
            txtD.Enabled = !kt;
            cbxBai.Enabled = !kt;
            cbxDoKho.Enabled = !kt;
            cbxDapAnDung.Enabled = !kt;
            cbxTinhTrang.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            //txtNDCH.Enabled = !kt;
        }

        private void cbxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(user.LoaiTaiKhoan == 1)
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


        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            //txtNDCH.Text = string.Empty;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _cauhoi.Detele(_id);
                loadData();
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("FoodData");

                    // Đặt chiều rộng cột cho tất cả các cột là 15
                    for (int col = 0; col < gvDanhSach.Columns.Count; col++)
                    {
                        worksheet.Column(col + 1).Width = 15;
                    }

                    // Tiêu đề cột
                    for (int i = 0; i < gvDanhSach.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = gvDanhSach.Columns[i].Caption;
                    }

                    for (int row = 0; row < gvDanhSach.RowCount; row++)
                    {
                        // Đặt chiều cao hàng là 60
                        worksheet.Row(row + 2).Height = 60;

                        for (int col = 0; col < gvDanhSach.Columns.Count; col++)
                        {
                            if (gvDanhSach.Columns[col].FieldName == "HinhAnh") // Xử lý cột hình ảnh
                            {
                                byte[] imageBytes = gvDanhSach.GetRowCellValue(row, gvDanhSach.Columns[col]) as byte[];
                                if (imageBytes != null)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        var image = worksheet.AddPicture(ms).MoveTo(worksheet.Cell(row + 2, col + 1));
                                        image.Width = 80;
                                        image.Height = 80;
                                    }
                                }
                            }
                            else
                            {
                                object cellValue = gvDanhSach.GetRowCellValue(row, gvDanhSach.Columns[col]);
                                worksheet.Cell(row + 2, col + 1).Value = cellValue != null ? cellValue.ToString() : string.Empty;
                            }
                        }
                    }

                    workbook.SaveAs(filePath);
                }

                XtraMessageBox.Show("Dữ liệu đã được xuất ra tệp Excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     
        void SaveData()
        {
            if (_them)
            {
                CauHoi k = new CauHoi();
                k.NDCH = txtNDCH.Text;
                k.A = txtA.Text;
                k.B = txtB.Text;
                k.C = txtC.Text;
                k.D = txtD.Text;
                k.DapAnDung = cbxDapAnDung.Text;
                //k.HinhAnh = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);
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
                k.TrangThai = int.Parse(cbxTinhTrang.SelectedValue.ToString());
                k.GhiChu = txtGhiChu.Text;
                _cauhoi.Add(k);
            }
            else
            {
                
                
                var k = _cauhoi.getItem(_id);
                if (k != null)
                {
                    k.NDCH = txtNDCH.Text;
                k.A = txtA.Text;
                k.B = txtB.Text;
                k.C = txtC.Text;
                k.D = txtD.Text;
                k.DapAnDung = cbxDapAnDung.Text;
                //k.HinhAnh = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);

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
                k.TrangThai = int.Parse(cbxTinhTrang.SelectedValue.ToString());
                k.GhiChu = txtGhiChu.Text;
                _cauhoi.Update(k);
                }
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

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaCauHoi").ToString());
                var k  = _cauhoi.getItem(_id);
                txtNDCH.Text = k.NDCH;
                txtA.Text = k.A;
                txtB.Text = k.B;
                txtC.Text = k.C;
                txtD.Text = k.D;
                cbxDapAnDung.Text = k.DapAnDung;
               
                picHinhAnh.Image = Base64ToImage(k.HinhAnh);
                cbxKhoi.SelectedValue = k.MaKhoi;
                cbxMonHoc1.SelectedValue = k.MaMonHoc;
                //try
                //{
                //    int selectedMonHocId = (int)cbxMonHoc1.SelectedValue;
                //    // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                //    var chuongList = db.Chuongs.Where(c => c.MaMonHoc == selectedMonHocId).ToList();
                //    cbxBai.DataSource = chuongList;
                //    cbxBai.DisplayMember = "TenChuong";
                //    cbxBai.ValueMember = "MaChuong";
                //}
                //catch (InvalidCastException ex)
                //{
                //    // Xử lý trường hợp không thể ép kiểu thành công.
                //    //MessageBox.Show("Lỗi: " + ex.Message);
                //}
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
                cbxTinhTrang.SelectedValue = k.TrangThai;

                cbxTinhTrang.SelectedValue = k.TrangThai;
                txtGhiChu.Text= k.GhiChu;
                _cauhoi.Update(k);
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

        private void btnPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "Danh sách món ăn";

                XFont font = new XFont("Arial", 7);
                int rowHeight = 60; // Điều chỉnh chiều cao của mỗi hàng
                double y = 20; // Vị trí bắt đầu của hàng đầu tiên

                // Đặt kích thước trang PDF
                PdfPage page = pdf.AddPage();
                page.Width = XUnit.FromInch(21); // Kích thước trang Letter (8.5 x 11 inch)
                page.Height = XUnit.FromInch(8.5);

                XGraphics gfx = XGraphics.FromPdfPage(page);

                for (int row = 0; row < gvDanhSach.RowCount; row++)
                {
                    double x = 20;

                    if (row == 0)
                    {
                        // Vẽ tiêu đề cột cho trang đầu tiên
                        foreach (DevExpress.XtraGrid.Columns.GridColumn column in gvDanhSach.Columns)
                        {
                            gfx.DrawString(column.Caption, font, XBrushes.Black, x, y);
                            x += 100;
                        }
                        y += 20; // Điều chỉnh khoảng cách giữa tiêu đề cột và dữ liệu
                        x = 20;
                    }

                    for (int col = 0; col < gvDanhSach.Columns.Count; col++)
                    {
                        object cellValue = gvDanhSach.GetRowCellValue(row, gvDanhSach.Columns[col]);
                        if (gvDanhSach.Columns[col].FieldName == "HinhAnh")
                        {
                            byte[] imageBytes = cellValue as byte[];
                            if (imageBytes != null)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

                                    // Điều chỉnh kích thước của hình ảnh để tối ưu hóa trên trang
                                    double imageWidth = 50;
                                    double imageHeight = 30;
                                    XImage xImage = XImage.FromStream(ms);
                                    gfx.DrawImage(xImage, x, y, imageWidth, imageHeight);
                                }
                            }
                            else
                            {
                                gfx.DrawString("", font, XBrushes.Black, x, y);
                            }
                        }
                        else
                        {
                            gfx.DrawString(cellValue != null ? cellValue.ToString() : string.Empty, font, XBrushes.Black, x, y);
                        }

                        x += 100;
                    }

                    y += rowHeight;

                    // Kiểm tra nếu không đủ không gian cho hàng tiếp theo, tạo trang mới
                    if (y + rowHeight > page.Height - 20 && row < gvDanhSach.RowCount - 1)
                    {
                        page = pdf.AddPage();
                        page.Width = XUnit.FromInch(21);
                        page.Height = XUnit.FromInch(8.5);
                        gfx = XGraphics.FromPdfPage(page);
                        y = 20;
                    }
                }
                pdf.Save(filePath);
                XtraMessageBox.Show("Dữ liệu đã được xuất ra tệp PDF thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Files|*.docx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Khởi tạo ứng dụng Word và tài liệu mới
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Add();

                // Tạo một đối tượng Range chứa toàn bộ nội dung của tài liệu
                Word.Range range = doc.Content;

                // Tạo bảng trong tài liệu Word
                Word.Table table = doc.Tables.Add(range, gvDanhSach.RowCount + 1, gvDanhSach.Columns.Count);

                // Đặt căn giữa cho bảng
                table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                // Đặt chiều rộng cột cho tất cả các cột là 15
                for (int col = 0; col < gvDanhSach.Columns.Count; col++)
                {
                    table.Cell(1, col + 1).Range.Text = gvDanhSach.Columns[col].Caption;

                    // Đặt chiều rộng cho từng cột
                    float columnWidth = 60f; // Điều chỉnh chiều rộng theo nhu cầu
                    table.Columns[col + 1].SetWidth(columnWidth, Word.WdRulerStyle.wdAdjustNone);
                }

                // Tạo thư mục tạm thời để lưu trữ hình ảnh
                string tempFolderPath = Path.Combine(Path.GetTempPath(), "TempImages");
                Directory.CreateDirectory(tempFolderPath);

                // Đổ dữ liệu vào bảng
                for (int row = 0; row < gvDanhSach.RowCount; row++)
                {
                    for (int col = 0; col < gvDanhSach.Columns.Count; col++)
                    {
                        // Nếu cột đang xét là cột HinhAnh
                        if (gvDanhSach.Columns[col].FieldName == "HinhAnh")
                        {
                            byte[] imageBytes = gvDanhSach.GetRowCellValue(row, gvDanhSach.Columns[col]) as byte[];
                            if (imageBytes != null)
                            {
                                // Lưu hình ảnh vào tệp tạm thời
                                string tempImagePath = Path.Combine(tempFolderPath, $"TempImage_{row}_{col}.png");
                                File.WriteAllBytes(tempImagePath, imageBytes);

                                // Chèn hình ảnh từ tệp tạm thời vào tài liệu Word
                                Word.InlineShape shape = table.Cell(row + 2, col + 1).Range.InlineShapes.AddPicture(
                                    tempImagePath, Type.Missing, Type.Missing, Type.Missing);
                                shape.Width = 50; // Điều chỉnh kích thước hình ảnh
                                shape.Height = 50;
                            }
                        }
                        else
                        {
                            object cellValue = gvDanhSach.GetRowCellValue(row, gvDanhSach.Columns[col]);
                            table.Cell(row + 2, col + 1).Range.Text = cellValue != null ? cellValue.ToString() : string.Empty;
                        }
                    }
                }
                // Chỉnh kích thước trang (phổ giấy) trong tài liệu Word
                doc.PageSetup.PageWidth = (float)(14 * 72); // Kích thước ngang (8.5 inch)
                doc.PageSetup.PageHeight = (float)(8.5 * 72); // Kích thước dọc (11 inch)

                // Đóng và xóa tệp tạm thời
                doc.SaveAs2(filePath);
                doc.Close();
                wordApp.Quit();
                Directory.Delete(tempFolderPath, true);

                XtraMessageBox.Show("Dữ liệu đã được xuất ra tệp Word thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
