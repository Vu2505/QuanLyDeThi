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

namespace QLDETHI
{
    public partial class fAddDeThi : DevExpress.XtraEditors.XtraForm
    {
        public fAddDeThi()
        {
            InitializeComponent();
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

            tongCauDeChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 1).ToString();
            tongCauTBChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 2).ToString();
            tongCauKhoChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 3).ToString();

            // Đặt giới hạn max
            nudDe.Maximum = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 1);
            nudTrungBinh.Maximum = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 2);
            nudKho.Maximum = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 3);

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

            tongCauDeBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 1).ToString();
            tongCauTBBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 2).ToString();
            tongCauKhoBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 3).ToString();

            // Đặt giới hạn max
            nubBaiDe.Maximum = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 1);
            nubBaiTB.Maximum = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 2);
            nubBaiKho.Maximum = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 3);

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

        private void fAddDeThi_Load(object sender, EventArgs e)
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
            _noidungdethi = new NOIDUNGDETHI();
            _dethi = new DETHI();
            loadData(selectedMaDe);
            //LoadTable();
            //LoadBai();
            loadCombo();
        }

        void loadCombo()
        {
            //cbxMonHoc1.DataSource = _monhoc.getList();
            //cbxMonHoc1.DisplayMember = "TenMonHoc";
            //cbxMonHoc1.ValueMember = "MaMonHoc";

            cbxKhoi.DataSource = _khoi.getList();
            cbxKhoi.DisplayMember = "TenKhoi";
            cbxKhoi.ValueMember = "MaKhoi";

            cbxLop.DataSource = _lop.getList();
            cbxLop.DisplayMember = "TenLop";
            cbxLop.ValueMember = "MaLop";



            cbxNamHoc.DataSource = _namhoc.getList();
            cbxNamHoc.DisplayMember = "TenNamHoc";
            cbxNamHoc.ValueMember = "MaNamHoc";

            cbxMonHoc1.DataSource = _monhoc.getList();
            cbxMonHoc1.DisplayMember = "TenMonHoc";
            cbxMonHoc1.ValueMember = "MaMonHoc";

            cbxThoiGianThi.DataSource = _thoigianthi.getList();
            cbxThoiGianThi.DisplayMember = "TenThoiGianThi";
            cbxThoiGianThi.ValueMember = "MaThoiGianThi";

            cbxHocKy.DataSource = _hocky.getList();
            cbxHocKy.DisplayMember = "TenHocKy";
            cbxHocKy.ValueMember = "MaHocKy";
        }


        void loadData(int? selectedMaDe)
        {
            _lstDTDTO = _noidungdethi.getListFull(selectedMaDe);

            if (_lstDTDTO != null && _lstDTDTO.Any())
            {
                gridDeThi.DataSource = _lstDTDTO;
                gvDanhSach.OptionsBehavior.Editable = false;
            }
            else
            {
                MessageBox.Show("Danh sách rỗng hoặc không có dữ liệu phù hợp.");
            }
        }


        private void cbxKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cbxKhoi.Controls.Clear();
                int selectedKhoiId = (int)cbxKhoi.SelectedValue;

                // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
                var MonHocList = db.MonHocs.Where(c => c.MaKhoi == selectedKhoiId).ToList();
                cbxMonHoc1.DataSource = MonHocList;
                cbxMonHoc1.DisplayMember = "TenMonHoc";
                cbxMonHoc1.ValueMember = "MaMonHoc";


                var LopList = db.Lops.Where(c => c.MaKhoi == selectedKhoiId).ToList();
                cbxLop.DataSource = LopList;
                cbxLop.DisplayMember = "TenLop";
                cbxLop.ValueMember = "MaLop";
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
                        btn.BackColor = Color.Green;
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
                        btn.BackColor = Color.Green;
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
                        btn.BackColor = Color.Green;
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
                        btn.BackColor = Color.Green;
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

        private void btnTaoDe_Click(object sender, EventArgs e)
        {            
            int soLuongDe = int.Parse(nubSoLuongDe.Value.ToString());
            List<string> danhSachMaHienThi = new List<string>();
            for (int i = 0; i < soLuongDe; ++i)
            {
                List<CAUHOI_DTO> list = new List<CAUHOI_DTO>();
                if (rdDeTheoChuong.Checked)
                {
                    list = deThi.GetCauHoiTheoChuong();
                }
                else
                {
                    list = deThi.GetCauHoiTheoBai();
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
                    MaGiangVien = 1, // Thay bằng giá trị thích hợp
                };

                // Thêm đề thi vào cơ sở dữ liệu
                db.DeThis.Add(newDeThi);
                db.SaveChanges(); // Lưu thay đổi để có mã đề thi mới

                // Lấy mã đề thi vừa tạo ra
                int maDeThi = newDeThi.MaDe; // Mã đề thi mới

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

        }

        private void nubSoLuongCauHoi_ValueChanged(object sender, EventArgs e)
        {
            deThi.SoLuongCauHoiMuonTao = int.Parse(nubSoLuongCauHoi.Value.ToString());
            KiemTraSoLuongCauHoi();
        }
    }
}