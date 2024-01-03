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
using DethiLayer;
using DataLayer;
using DethiLayer.DTO;
using QLDETHI.Luutru;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraGrid.Views.Base;

namespace QLDETHI
{
    public partial class fAddDeThi : DevExpress.XtraEditors.XtraForm
    {
        private TaiKhoan user;
        int IdTK;
        public fAddDeThi()
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
            danhSachMaDeThi = new List<int>();
        }
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        CHUONG _chuong;
        BAI _bai;
        MONHOC _monhoc;
        KHOI _khoi;
        CAUHOI _cauhoi;
        LOP _lop;
        Taodethi.DeThi deThi = new Taodethi.DeThi();
        Chuong chuongDangChon;
        Bai baiDangChon;
        NAMHOC _namhoc;
        NOIDUNGDETHI _noidungdethi;
        HOCKY _hocky;
        THOIGIANTHI _thoigianthi;
        List<DETHI_DTO> _lstDTDTO;
        DETHI _dethi;
        private int? selectedMaDe;
        int soLuongDeTrongChuong = 0;
        int soLuongTBTrongChuong = 0;
        int soLuongKhoTrongChuong = 0;
        int soLuongDeTrongBai = 0;
        int soLuongTBTrongBai = 0;
        int soLuongKhoTrongBai = 0;

        List<NamHoc> listNamHoc = new List<NamHoc>();
        List<HocKy> listHocKy = new List<HocKy>();
        List<ThoiGianThi> listThoiGianThi = new List<ThoiGianThi>();

        // Mặc định là thiếu câu
        Taodethi.KiemTraSoLuong trangThaiSoLuongCau = Taodethi.KiemTraSoLuong.ThieuCau;
        // Trạng thái đang cập nhật (khi chuyển chương khác hoặc bài khác)
        bool dangCapNhat = false;

        #region HienThiThongBao
        private void HienThiCauHoiQuaMucChoPhep()
        {
            MessageBox.Show("Số Câu Hỏi Đã Chọn Vượt Quá Số Câu Hỏi Muốn Tạo");
        }
        private void HienThiTaoDeThanhCong(int soLuongDe, List<string> danhsachMaHienThi)
        {

            string danhSachMa = "\nMã đề: " + string.Join("\nMã đề: ", danhsachMaHienThi);
            MessageBox.Show($"Tạo thành công {soLuongDe} đề gồm: {danhSachMa}");
        }

        private void HienThiKetQuaRangBuoc()
        {
            KiemTraSoLuongCauHoi();
            flpKetQuaRangBuoc.Controls.Clear();


            // Hiển thị tất cả thông tin trên một label
            string ketQuaText = deThi.ToString();
            var label = new Label
            {
                Text = ketQuaText,
                AutoSize = true,
            };
            flpKetQuaRangBuoc.Controls.Add(label);
        }
        #endregion

        #region DatLaiGiaTri
        void CapNhatLaiSoLuongCauHoiCuaChuong()
        {
            // Reset lại
            nudDe.Maximum = 100;
            nudTrungBinh.Maximum = 100;
            nudKho.Maximum = 100;

            Dictionary<String, int> map = deThi.InRaSoLuongCauHoiCuaChuong(chuongDangChon.MaChuong);
            nudDe.Value = map["soLuongCauDe"];
            nudTrungBinh.Value = map["soLuongCauTB"];
            nudKho.Value = map["soLuongCauKho"];

            soLuongDeTrongChuong = map["soLuongCauDe"];
            soLuongTBTrongChuong = map["soLuongCauTB"];
            soLuongKhoTrongChuong = map["soLuongCauKho"];
            if(user.LoaiTaiKhoan == 1)
            {
                tongCauDeChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 1).ToString();
                tongCauTBChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 2).ToString();
                tongCauKhoChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 3).ToString();

            }
            else
            {
                tongCauDeChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 1, user.IdTK).ToString();
                tongCauTBChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 2, user.IdTK).ToString();
                tongCauKhoChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 3, user.IdTK).ToString();

            }
            // Đặt giới hạn max
            nudDe.Maximum = decimal.Parse(tongCauDeChuong.Text);
            nudTrungBinh.Maximum = decimal.Parse(tongCauTBChuong.Text);
            nudKho.Maximum = decimal.Parse(tongCauKhoChuong.Text);

            lbTongCauChuong.Text = (nudDe.Maximum + nudTrungBinh.Maximum + nudKho.Maximum).ToString();
        }

        void CapNhatLaiSoLuongCauHoiCuaBai()
        {
            // Reset lại
            nubBaiDe.Maximum = 100;
            nubBaiTB.Maximum = 100;
            nubBaiKho.Maximum = 100;

            Dictionary<String, int> map = deThi.InRaSoLuongCauHoiCuaBaiTrongChuong(chuongDangChon.MaChuong, baiDangChon.MaBai);
            nubBaiDe.Value = map["soLuongCauDe"];
            nubBaiTB.Value = map["soLuongCauTB"];
            nubBaiKho.Value = map["soLuongCauKho"];

            if(user.LoaiTaiKhoan == 1)
            {
                tongCauDeBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 1).ToString();
                tongCauTBBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 2).ToString();
                tongCauKhoBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 3).ToString();
            }
            else
            {
                tongCauDeBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 1, user.IdTK).ToString();
                tongCauTBBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 2, user.IdTK).ToString();
                tongCauKhoBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 3, user.IdTK).ToString();
            }


            // Đặt giới hạn max

            nubBaiDe.Maximum = decimal.Parse(tongCauDeBai.Text);
            nubBaiTB.Maximum = decimal.Parse(tongCauTBBai.Text);
            nubBaiKho.Maximum = decimal.Parse(tongCauKhoBai.Text);

            lbTongCauBai.Text = (nubBaiDe.Maximum + nubBaiTB.Maximum + nubBaiKho.Maximum).ToString();

            lbTongSoCauDaChon.Text = deThi.SoLuongCauHoiDangTao.ToString();
            lbTongSoCauMuonTao.Text = deThi.SoLuongCauHoiMuonTao.ToString();

        }
        #endregion

        #region KiemTraGiaTri
        private void KiemTraSoLuongCauHoi()
        {
            var result = deThi.KiemTraSoLuongCauHoi();
            if (result == Taodethi.KiemTraSoLuong.DuCau)
            {
                btnTaoDe.Enabled = true;
            }
            else
            {
                btnTaoDe.Enabled = false;
                if(result == Taodethi.KiemTraSoLuong.ThuaCau)
                {
                    HienThiCauHoiQuaMucChoPhep();
                    return;
                }
            }

            lbTongSoCauDaChon.Text = deThi.SoLuongCauHoiDangTao.ToString();
            lbTongSoCauMuonTao.Text = deThi.SoLuongCauHoiMuonTao.ToString();
        }
        #endregion

        #region MoiGiaTri
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
        #endregion
        //private ImageCollection imageCollection; // Thêm dòng này


        //private bool _isEditMode = false;

        //private void EnterEditMode()
        //{
        //    _isEditMode = true;
        //}

        //private void ExitEditMode()
        //{
        //    _isEditMode = false;
        //}
        private void gvDanhSach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    MessageBox.Show("RowUpdated event triggered");
            //    DataRowView rowView = e.Row as DataRowView;
            //    if (rowView != null)
            //    {
            //        int maDe = Convert.ToInt32(rowView["MaDe"]);
            //        string tenDeThi = rowView["TenDeThi"].ToString();
            //        int mahienthi = Convert.ToInt32(rowView["MaHienThi"]);
            //        // Cập nhật vào cơ sở dữ liệu
            //        UpdateDeThi(maDe, tenDeThi, mahienthi);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error in RowUpdated event: {ex.Message}");
            //}
            //try
            //{
            //    MessageBox.Show("CellValueChanged event triggered");

            //    int rowHandle = gvDanhSach.FocusedRowHandle;
            //    int maDe = Convert.ToInt32(gvDanhSach.GetRowCellValue(rowHandle, "MaDe"));
            //    string tenDeThi = gvDanhSach.GetRowCellValue(rowHandle, "TenDeThi").ToString();
            //    int mahienthi = Convert.ToInt32(gvDanhSach.GetRowCellValue(rowHandle, "MaHienThi"));

            //    // Cập nhật vào cơ sở dữ liệu
            //    UpdateDeThi(maDe, tenDeThi, mahienthi);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error in CellValueChanged event: {ex.Message}");
            //}
        }
        private void fAddDeThi_Load(object sender, EventArgs e)
        {
            // Cho GridControl
            gridDeThi.UseEmbeddedNavigator = true;
            //gvDanhSach.CellValueChanged += gvDanhSach_CellValueChanged;
            //gvDanhSach.RowUpdated += gvDanhSach_RowUpdated;
            _chuong = new CHUONG();
            _bai = new BAI();
            _monhoc = new MONHOC();
            _khoi = new KHOI();
            _cauhoi = new CAUHOI();
            _lop = new LOP();
            _namhoc = new NAMHOC();
            _hocky = new HOCKY();
            _thoigianthi = new THOIGIANTHI();
            _noidungdethi = new NOIDUNGDETHI();
            _dethi = new DETHI();
            loadData(selectedMaDe);
            loadCombo();
            gvDanhSach.EditFormPrepared += GridView_EditFormPrepared;

            gvDanhSach.ShownEditor += (s, ee) => {
                GridView view = s as GridView;
                
                view.ActiveEditor.Properties.ReadOnly =
                    gvDanhSach.FocusedColumn.FieldName == "MaDe";
            };

            RepositoryItemButtonEdit commandsEdit = new RepositoryItemButtonEdit { AutoHeight = false, Name = "CommandsEdit", TextEditStyle = TextEditStyles.HideTextEditor };
            commandsEdit.Buttons.Clear();

            commandsEdit.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Glyph, "Sửa", -1, true, true, false,ImageLocation.MiddleLeft, null)
            });
            gridDeThi.RepositoryItems.Add(commandsEdit);

            //commandsEdit.Buttons.AddRange(new EditorButton[] {
            //    new EditorButton(ButtonPredefines.Glyph, "Sửa", -1, true, true, false, ImageLocation.MiddleLeft, imageCollection != null && imageCollection.Images.Count > 0 ? imageCollection.Images[0] : null)
            //});


            GridColumn _commandsColumn = gvDanhSach.Columns.AddField("Hành động");
            _commandsColumn.UnboundDataType = typeof(object);
            _commandsColumn.Visible = true;
            _commandsColumn.Width = 45;

            _commandsColumn.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;

            gvDanhSach.CustomRowCellEdit += (s, ee) =>
            {
                //MessageBox.Show("CustomRowCellEdit");
                if (ee.RowHandle == gvDanhSach.FocusedRowHandle && ee.Column == _commandsColumn)
                    ee.RepositoryItem = commandsEdit;
            };

            gvDanhSach.CustomRowCellEditForEditing += (s, ee) =>
            {
                //MessageBox.Show("CustomRowCellEditForEditing");
                if (ee.RowHandle == gvDanhSach.FocusedRowHandle && ee.Column == _commandsColumn)
                    ee.RepositoryItem = commandsEdit;
            };

            gvDanhSach.ShowingEditor += (s, ee) =>
            {
                ee.Cancel = gvDanhSach.FocusedColumn != _commandsColumn;
            };

            gvDanhSach.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            gvDanhSach.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            gvDanhSach.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            gvDanhSach.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;

            commandsEdit.ButtonClick += (s, ee) =>
            {
                //MessageBox.Show(ee.Button.Caption);
                switch (ee.Button.Caption)
                {
                    case "Sửa":
                        gvDanhSach.CloseEditor();
                        gvDanhSach.ShowEditForm();
                        break;
                }
            };
        }
        private void GridView_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {           

            Control ctrl = MyExtenstions.FindControl(e.Panel, "Cancel");
            if (ctrl != null)
            {
                ctrl.Text = "Đóng";
                //EnterEditMode();
                //(ctrl as SimpleButton).ImageOptions.Image = imageCollection.Images[2];

            }

            ctrl = MyExtenstions.FindControl(e.Panel, "Update");
            if (ctrl != null)
            {
                //ExitEditMode();
                //(ctrl as SimpleButton).ImageOptions.Image = imageCollection.Images[3];
                ctrl.Text = "Cập nhật";
            }
        }

        void loadCombo()
        {
            cbxKhoi.DataSource = _khoi.getList();
            cbxKhoi.DisplayMember = "TenKhoi";
            cbxKhoi.ValueMember = "MaKhoi";

            cbxLop.DataSource = _lop.getList();
            cbxLop.DisplayMember = "TenLop";
            cbxLop.ValueMember = "MaLop";

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


            cbxNamHoc.DataSource = _namhoc.getList();
            cbxNamHoc.DisplayMember = "TenNamHoc";
            cbxNamHoc.ValueMember = "MaNamHoc";

            //cbxMonHoc1.DataSource = _monhoc.getList();
            //cbxMonHoc1.DisplayMember = "TenMonHoc";
            //cbxMonHoc1.ValueMember = "MaMonHoc";

            cbxThoiGianThi.DataSource = _thoigianthi.getList();
            cbxThoiGianThi.DisplayMember = "TenThoiGianThi";
            cbxThoiGianThi.ValueMember = "MaThoiGianThi";

            cbxHocKy.DataSource = _hocky.getList();
            cbxHocKy.DisplayMember = "TenHocKy";
            cbxHocKy.ValueMember = "MaHocKy";

            listNamHoc = _namhoc.getList();
            listHocKy = _hocky.getList();
            listThoiGianThi = _thoigianthi.getList();

            ricmbHocKy.Items.Clear();
            foreach(var item in listHocKy)
            {
                ricmbHocKy.Items.Add(item.TenHocKy);
            }

            ricmbNamHoc.Items.Clear();
            foreach (var item in listNamHoc)
            {
                ricmbNamHoc.Items.Add(item.TenNamHoc);
            }

            ricmbThoiGianThi.Items.Clear();
            foreach (var item in listThoiGianThi)
            {
                ricmbThoiGianThi.Items.Add(item.TenThoiGianThi);
            }
        }


        void loadData(int? selectedMaDe)
        {
            if (user.LoaiTaiKhoan == 1)
            {
                _lstDTDTO = _dethi.getListFull(selectedMaDe);

                if (_lstDTDTO != null && _lstDTDTO.Any())
                {
                    gridDeThi.DataSource = _lstDTDTO;
                    //gvDanhSach.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show("Danh sách rỗng hoặc không có dữ liệu phù hợp.");
                }
            }
            else
            {
                _lstDTDTO = _dethi.getListFullTK(IdTK, selectedMaDe);

                if (_lstDTDTO != null && _lstDTDTO.Any())
                {
                    gridDeThi.DataSource = _lstDTDTO;
                    //gvDanhSach.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show("Danh sách rỗng hoặc không có dữ liệu phù hợp.");
                }
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
                deThi.LamSach();

                int selectedMonHocId = (int)cbxMonHoc1.SelectedValue;
                // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                List<Chuong> chuongList = db.Chuongs.Where(c => c.MaMonHoc == selectedMonHocId).ToList();

                foreach (Chuong item in chuongList)
                {
                    deThi.ThemChuong(item.MaChuong);

                    Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                    btn.Text = item.TenChuong + Environment.NewLine;
                    btn.Click += btnChuong_Click;
                    btn.Tag = item;
                    btn.BackColor = Color.White;
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
            dangCapNhat = true;
            // Xóa tất cả các nút hiện có trong flpBai
            flpBai.Controls.Clear();

            // Lấy thông tin liên quan từ nút được nhấp (ví dụ: item.MaChuong)
            Button clickedButton = (Button)sender;
            chuongDangChon = (Chuong)clickedButton.Tag;

            int maChuong = int.Parse(chuongDangChon.MaChuong.ToString()); // Giả sử bạn đã đặt Tag cho nút là maChuong

            if (!rdDeTheoChuong.Checked)
            {              
                // Dựa vào maChuong, tạo danh sách các bài tương ứng
                List<Bai> baiList = db.Bais.Where(c => c.MaChuong == maChuong).ToList();
                foreach (Bai item in baiList)
                {
                    deThi.ThemBaiVaoChuong(chuongDangChon.MaChuong, item.MaBai);

                    Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                    btn.Text = item.TenBai + Environment.NewLine;
                    btn.Click += btnBai_Click;
                    btn.Tag = item;
                    flpBai.Controls.Add(btn);

                    if (deThi.KiemTraBaiCuaChuongRong(chuongDangChon.MaChuong, item.MaBai))
                    {
                        btn.BackColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = Color.Yellow;
                    }                    
                }
            }

            // Sau cung thi cap nhat lai 
            CapNhatLaiSoLuongCauHoiCuaChuong();

            // Sau khi hoàn thành load dữ liệu liên quan
            // thì trạng thái là đã cập nhật 
            dangCapNhat = false;
        }

        void btnBai_Click(object sender, EventArgs e)
        {            
            Button clickedButton = (Button)sender;
            baiDangChon = (Bai) clickedButton.Tag;
            
            // Sau cung thi cap nhat lai 
            CapNhatLaiSoLuongCauHoiCuaBai();
            CapNhatLaiSoLuongCauHoiCuaChuong();

            // Sau khi hoàn thành load dữ liệu liên quan
            // thì trạng thái là đã cập nhật 
            dangCapNhat = false;
        }

        void ThayDoiSoLuongCauHoiCuaChuong(object sender, EventArgs e)
        {
            // Nếu đang cập nhất số lượng câu hỏi khi nhấn chương mới 
            // thì chỉ cần thay đổi nudDe, nudTrungBinh, nudKho (tức là không làm gì)
            if (dangCapNhat)
                return;

            if (rdDeTheoChuong.Checked)
            {                
                int soLuongCauDe = int.Parse(nudDe.Value.ToString());
                int soLuongCauTB = int.Parse(nudTrungBinh.Value.ToString());
                int soLuongCauKho = int.Parse(nudKho.Value.ToString());
                

                if(trangThaiSoLuongCau == Taodethi.KiemTraSoLuong.DuCau)
                {
                    // Nếu tăng 1 trong 3 cái thì thông báo (chenhlech > 0)
                    int chenhlechCauDe = soLuongCauDe - soLuongDeTrongChuong;
                    int chenhlechCauTB = soLuongCauTB - soLuongTBTrongChuong;
                    int chenhlechCauKho = soLuongCauKho - soLuongKhoTrongChuong;

                    if(chenhlechCauDe > 0)
                    {
                        HienThiCauHoiQuaMucChoPhep();
                        // Trả về trạng thái ban đầu
                        nudDe.Value = decimal.Parse(soLuongDeTrongChuong.ToString());
                        // Không chạy đoạn sau 
                        return;

                    }
                    else if (chenhlechCauTB > 0)
                    {
                        HienThiCauHoiQuaMucChoPhep();
                        nudTrungBinh.Value = decimal.Parse(soLuongCauTB.ToString());
                        return;
                    }
                    else if(chenhlechCauTB > 0)
                    {
                        HienThiCauHoiQuaMucChoPhep();
                        nudKho.Value = decimal.Parse(soLuongKhoTrongChuong.ToString());
                        return;
                    }                    
                }               

                int selectedMonHocId = (int)cbxMonHoc1.SelectedValue;
                // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                List<Chuong> chuongList = db.Chuongs.Where(c => c.MaMonHoc == selectedMonHocId).ToList();

                var kiemTraSoLuongCau = deThi.CapNhatChuong(chuongDangChon.MaChuong, soLuongCauDe, soLuongCauTB, soLuongCauKho);

                KiemTraSoLuongCauHoi();

                if (kiemTraSoLuongCau == Taodethi.KiemTraSoLuong.ThuaCau)
                {
                    int chenhlechCauDe = soLuongCauDe - soLuongDeTrongChuong;
                    int chenhlechCauTB = soLuongCauTB - soLuongTBTrongChuong;
                    int chenhlechCauKho = soLuongCauKho - soLuongKhoTrongChuong;

                    if(chenhlechCauDe > 0)
                    {
                        nudDe.Value = decimal.Parse(soLuongDeTrongChuong.ToString());
                        return;
                    }
                    if (chenhlechCauTB > 0)
                    {
                        nudTrungBinh.Value = decimal.Parse(soLuongTBTrongChuong.ToString());
                        return;
                    }

                    if (chenhlechCauKho > 0)
                    {
                        nudKho.Value = decimal.Parse(soLuongKhoTrongChuong.ToString());
                        return;
                    }
                }
                else
                {
                    soLuongDeTrongChuong = soLuongCauDe;
                    soLuongTBTrongChuong = soLuongCauTB;
                    soLuongKhoTrongChuong = soLuongCauKho;

                    trangThaiSoLuongCau = kiemTraSoLuongCau;
                }
                flpChuong.Controls.Clear();

                foreach (Chuong item in chuongList)
                {
                    Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                    btn.Text = item.TenChuong + Environment.NewLine;
                    btn.Click += btnChuong_Click;
                    btn.Tag = item;

                    if (deThi.KiemTraChuongRong(item.MaChuong))
                    {
                        btn.BackColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = Color.Yellow;
                    }
                    flpChuong.Controls.Add(btn);
                }

                HienThiKetQuaRangBuoc();
            }
        }

        void ThayDoiSoLuongCauHoiCuaBai(object sender, EventArgs e)
        {
            // Nếu đang cập nhật số lượng câu hỏi khi nhấn bài mới 
            // thì tương tự như nhấn chương mới
            if (dangCapNhat)
                return;

            if (rdDeBaiTheoChuong.Checked)
            {
                // Reset số lượng câu hỏi của chương
                nudDe.Value = 0;
                nudTrungBinh.Value = 0;
                nudKho.Value = 0; 

                int soLuongCauDe = int.Parse(nubBaiDe.Value.ToString());
                int soLuongCauTB = int.Parse(nubBaiTB.Value.ToString());
                int soLuongCauKho = int.Parse(nubBaiKho.Value.ToString());

                var kiemTraSoLuongCau = deThi.CapNhatBaiCuaChuong(chuongDangChon.MaChuong, baiDangChon.MaBai, soLuongCauDe, soLuongCauTB, soLuongCauKho);

                KiemTraSoLuongCauHoi();

                if (kiemTraSoLuongCau == Taodethi.KiemTraSoLuong.ThuaCau)
                {
                    int chenhlechCauDe = soLuongCauDe - soLuongDeTrongBai;
                    int chenhlechCauTB = soLuongCauTB - soLuongTBTrongBai;
                    int chenhlechCauKho = soLuongCauKho - soLuongKhoTrongBai;

                    if (chenhlechCauDe != 0)
                    {
                        nubBaiDe.Value = decimal.Parse(soLuongDeTrongBai.ToString());
                        return;
                    }
                    if (chenhlechCauTB != 0)
                    {
                        nubBaiTB.Value = decimal.Parse(soLuongTBTrongBai.ToString());
                        return;
                    }

                    if (chenhlechCauKho != 0)
                    {
                        nubBaiKho.Value = decimal.Parse(soLuongKhoTrongBai.ToString());
                        return;
                    }
                }
                else
                {
                    soLuongDeTrongBai = soLuongCauDe;
                    soLuongTBTrongBai = soLuongCauTB;
                    soLuongKhoTrongBai = soLuongCauKho;
                }

                // Thay doi mau cua button Bai
                flpBai.Controls.Clear();
                List<Bai> baiList = db.Bais.Where(c => c.MaChuong == chuongDangChon.MaChuong).ToList();                
                foreach(Bai item in baiList)
                {
                    Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                    btn.Text = item.TenBai + Environment.NewLine;
                    btn.Click += btnBai_Click;
                    btn.Tag = item;

                    if (deThi.KiemTraBaiCuaChuongRong(chuongDangChon.MaChuong, item.MaBai))
                    {
                        btn.BackColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = Color.Yellow;
                    }

                    flpBai.Controls.Add(btn);
                }

                CapNhatLaiSoLuongCauHoiCuaChuong();

                // Thay doi mau cua button Chuong
                flpChuong.Controls.Clear();
                int selectedMonHocId = (int)cbxMonHoc1.SelectedValue;
                
                int maChuong = int.Parse(chuongDangChon.MaChuong.ToString());
                List<Chuong> chuongList = db.Chuongs.Where(c => c.MaMonHoc == selectedMonHocId).ToList();

                foreach (Chuong item in chuongList)
                {
                    Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                    btn.Text = item.TenChuong + Environment.NewLine;
                    btn.Click += btnChuong_Click;
                    btn.Tag = item;

                    if (deThi.KiemTraChuongRong(item.MaChuong))
                    {
                        btn.BackColor = Color.White;
                    }
                    else
                    {
                        btn.BackColor = Color.Yellow;
                    }                    

                    flpChuong.Controls.Add(btn);
                }
                HienThiKetQuaRangBuoc();
            }            
        }

        private void rdDeTheoChuong_CheckedChanged(object sender, EventArgs e)
        {
            nubBaiDe.Enabled = false;
            nubBaiTB.Enabled = false;
            nubBaiKho.Enabled = false;

            nudDe.Enabled = true;
            nudTrungBinh.Enabled = true;
            nudKho.Enabled = true;
        }

        private void rdDeBaiTheoChuong_CheckedChanged(object sender, EventArgs e)
        {
            nudDe.Enabled = false;
            nudTrungBinh.Enabled = false;
            nudKho.Enabled = false;

            nubBaiDe.Enabled = true;
            nubBaiTB.Enabled = true;
            nubBaiKho.Enabled = true;
        }

        private List<int> danhSachMaDeThi; // Thêm biến danh sách MaDeThi

        private void btnTaoDe_Click(object sender, EventArgs e)
        {            
            int soLuongDe = int.Parse(nubSoLuongDe.Value.ToString());
            List<string> danhSachMaHienThi = new List<string>();
            for (int i = 0; i < soLuongDe; ++i)
            {
                List<CAUHOI_DTO> list = new List<CAUHOI_DTO>();
                if (rdDeTheoChuong.Checked)
                {
                    list = deThi.GetCauHoiTheoChuong(user);
                }
                else
                {
                    list = deThi.GetCauHoiTheoBai(user);
                }
                int maHienThi = GenerateNewMaHienThi();
                danhSachMaHienThi.Add(maHienThi.ToString());
                // Tạo đề thi mới
                DeThi newDeThi = new DeThi
                {
                    NamHoc = (int)cbxNamHoc.SelectedValue, // Thay bằng giá trị thích hợp
                    TenDeThi = txbTenDeThi.Text,   // Thay bằng giá trị thích hợp
                    MaHienThi = maHienThi,
                    MaThoiGianThi = (int)cbxThoiGianThi.SelectedValue, // Thay bằng giá trị thích hợp
                    SoCauHoi = int.Parse(nubSoLuongCauHoi.Value.ToString()), // Số câu hỏi được chọn
                    MaMonHoc = (int)cbxMonHoc1.SelectedValue, // Mã môn học
                    MaKhoi = (int)cbxKhoi.SelectedValue, // Mã khối
                    MaLop = (int)cbxLop.SelectedValue, // Mã lớp
                    MaHocKy = (int)cbxHocKy.SelectedValue,
                    MaGiangVien = IdTK, // Thay bằng giá trị thích hợp
                    NgayCapNhat = DateTime.UtcNow
                };
                // Thêm đề thi vào cơ sở dữ liệu
                db.DeThis.Add(newDeThi);
                db.SaveChanges(); // Lưu thay đổi để có mã đề thi mới

                // Lấy mã đề thi vừa tạo ra
                int maDeThi = newDeThi.MaDe; // Mã đề thi mới

                //danhSachMaDeThi.Add(maDeThi); // Thêm MaDeThi vào danh sách
                int thuTuCauHoi = 1; // Đặt số thứ tự của câu hỏi

                foreach (var cauHoi in list)
                {
                    if (cauHoi != null)
                    {
                        string dapAnDung = cauHoi.DapAnDung;

                        NoiDungDeThi noiDungDeThi = new NoiDungDeThi
                        {
                            MaDe = maDeThi,
                            MaCauHoi = cauHoi.MaCauHoi,
                            ThuTuCauHoi = thuTuCauHoi,
                            ThuTuXepDapAn = 1
                        };
                        // Thêm noiDungDeThi vào cơ sở dữ liệu
                        db.NoiDungDeThis.Add(noiDungDeThi);

                        thuTuCauHoi++;
                    }
                }
            }
            db.SaveChanges();
            HienThiTaoDeThanhCong(soLuongDe, danhSachMaHienThi);
            loadData(selectedMaDe);

        }

        private void nubSoLuongCauHoi_ValueChanged(object sender, EventArgs e)
        {
            deThi.SoLuongCauHoiMuonTao = int.Parse(nubSoLuongCauHoi.Value.ToString());
            KiemTraSoLuongCauHoi();
        }

        private void gvDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                //MessageBox.Show("RowUpdated event triggered");
                ColumnView view = sender as ColumnView;
                view.CloseEditor();
                if (view.UpdateCurrentRow())
                {
                    // Use data source API to save changes.                    
                    DataRowView rowView = e.Row as DataRowView;

                    int maDe = Convert.ToInt32(gvDanhSach.GetRowCellValue(view.FocusedRowHandle, "MaDe").ToString());
                    string tenDeThi = gvDanhSach.GetRowCellValue(view.FocusedRowHandle, "TenDeThi").ToString();
                    int mahienthi = Convert.ToInt32(gvDanhSach.GetRowCellValue(view.FocusedRowHandle, "MaHienThi").ToString());
                    string namhoc = gvDanhSach.GetRowCellValue(view.FocusedRowHandle, "TenNamHoc").ToString();
                    string hocky = gvDanhSach.GetRowCellValue(view.FocusedRowHandle, "TenHocKy").ToString();
                    string thoigianthi = gvDanhSach.GetRowCellValue(view.FocusedRowHandle, "TenThoiGianThi").ToString();

                    int manamhoc = 0;
                    foreach(var item in listNamHoc)
                    {
                        if(namhoc == item.TenNamHoc)
                        {
                            manamhoc = item.MaNamHoc;
                            break;
                        }
                    }

                    int mahocky = 0;
                    foreach (var item in listHocKy)
                    {
                        if (hocky == item.TenHocKy)
                        {
                            mahocky = item.MaHocKy;
                            break;
                        }
                    }

                    int mathoigianthi = 0;
                    foreach (var item in listThoiGianThi)
                    {
                        if (thoigianthi == item.TenThoiGianThi)
                        {
                            mathoigianthi = item.MaThoiGianThi;
                            break;
                        }
                    }

                    //MessageBox.Show($"maDe: {maDe}, tenDeThi: {tenDeThi}, mahienthi: {mahienthi}\nnamhoc: {namhoc}, hocky: {hocky}, thoigianthi: {thoigianthi}");

                    // Cập nhật vào cơ sở dữ liệu
                    UpdateDeThi(maDe, tenDeThi, mahienthi, manamhoc, mahocky, mathoigianthi);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in RowUpdated event: {ex.Message}");
            }
            //var madethi = gvDanhSach.GetFocusedRowCellValue("MaDe").ToString();
            ////var tendethi = gvDanhSach.GetFocusedRowCellValue["TenDeThi"].ToString();
            ////var mahienthi = gvDanhSach.GetFocusedRowCellValue["MaHienThi"].ToString();
            ////var manmahoc = gvDanhSach.GetFocusedRowCellValue["MaNamHoc"].ToString();
            ////var mahocky = gvDanhSach.GetFocusedRowCellValue["MaHocKy"].ToString();
            ////var thoigianthi = gvDanhSach.GetFocusedRowCellValue["ThoiGianThi"].ToString();
            //MessageBox.Show("Chỉnh sửa thành công" + madethi + "\n");
        }

        private void UpdateDeThi(int maDe, string tenDeThi, int mahienthi, int manamhoc, int mahocky, int mathoigianthi)
        {
            var dt = _dethi.getItem(maDe);
            dt.TenDeThi = tenDeThi;
            dt.MaHienThi = mahienthi;
            dt.NamHoc = manamhoc;
            dt.MaHocKy = mahocky;
            dt.MaThoiGianThi = mathoigianthi;
            _dethi.Update(dt);
        }

        private void PrevenTcharactersComboBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
    public static class MyExtenstions
    {

        public static Control FindControl(this Control root, string text)
        {
            if (root == null) throw new ArgumentNullException("root");
            foreach (Control child in root.Controls)
            {
                if (child.Text == text) return child;
                Control found = FindControl(child, text);
                if (found != null) return found;
            }
            return null;
        }
    }
}