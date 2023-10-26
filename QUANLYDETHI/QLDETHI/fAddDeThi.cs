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

        #region DatLaiGiaTri
        void CapNhatLaiSoLuongCauHoiCuaChuong()
        {
            Dictionary<String, int> map = deThi.InRaSoLuongCauHoiCuaChuong(chuongDangChon.MaChuong);
            nudDe.Value = map["soLuongCauDe"];
            nudTrungBinh.Value = map["soLuongCauTB"];
            nudKho.Value = map["soLuongCauKho"];

            tongCauDeChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 1).ToString();
            tongCauTBChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 2).ToString();
            tongCauKhoChuong.Text = _cauhoi.SoLuongCauHoiTheoChuong(chuongDangChon.MaChuong, 3).ToString();

        }

        void CapNhatLaiSoLuongCauHoiCuaBai()
        {
            Dictionary<String, int> map = deThi.InRaSoLuongCauHoiCuaBaiTrongChuong(chuongDangChon.MaChuong, baiDangChon.MaBai);
            nubBaiDe.Value = map["soLuongCauDe"];
            nubBaiTB.Value = map["soLuongCauTB"];
            nubBaiKho.Value = map["soLuongCauKho"];

            tongCauDeBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 1).ToString();
            tongCauTBBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 2).ToString();
            tongCauKhoBai.Text = _cauhoi.SoLuongCauHoiTheoBai(baiDangChon.MaBai, 3).ToString();
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
            //LoadTable();
            //LoadBai();
            loadCombo();
        }

        void loadCombo()
        {
            cbxMonHoc1.DataSource = _monhoc.getList();
            cbxMonHoc1.DisplayMember = "TenMonHoc";
            cbxMonHoc1.ValueMember = "MaMonHoc";

            cbxKhoi.DataSource = _khoi.getList();
            cbxKhoi.DisplayMember = "TenKhoi";
            cbxKhoi.ValueMember = "MaKhoi";

            cbxLop.DataSource = _lop.getList();
            cbxLop.DisplayMember = "TenLop";
            cbxLop.ValueMember = "MaLop";

        }

            void LoadTable()
        {
            flpChuong.Controls.Clear();
            List<Chuong> tableList = _chuong.getList();

            foreach (Chuong item in tableList)
            {
                Button btn = new Button() { Width = CHUONG.TableWidth, Height = CHUONG.TableHeight };
                btn.Text = item.TenChuong + Environment.NewLine;
                //btn.Click += btn_Click;
                //btn.Tag = item;
                flpChuong.Controls.Add(btn);
            }
        }

        void LoadBai()
        {
            flpBai.Controls.Clear();
            List<Bai> tableList = _bai.getList();

            foreach (Bai item in tableList)
            {
                Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                btn.Text = item.TenBai + Environment.NewLine;
                //btn.Click += btn_Click;
                //btn.Tag = item;
                flpBai.Controls.Add(btn);
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
                    Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                    btn.Text = item.TenChuong + Environment.NewLine;
                    btn.Click += btnChuong_Click;
                    btn.Tag = item;
                    btn.BackColor = Color.White;
                    flpChuong.Controls.Add(btn);
                    deThi.ThemChuong(item.MaChuong);
                }
                //cbxChuong.DataSource = chuongList;
                //cbxChuong.DisplayMember = "TenChuong";
                //cbxChuong.ValueMember = "MaChuong";
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
            foreach (Bai item in baiList)
            {
                Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                btn.Text = item.TenBai + Environment.NewLine;
                btn.Click += btnBai_Click;
                btn.Tag = item;
                flpBai.Controls.Add(btn);
                deThi.ThemBaiVaoChuong(chuongDangChon.MaChuong, item.MaBai);
            }

            // Sau cung thi cap nhat lai 
            CapNhatLaiSoLuongCauHoiCuaChuong();
        }

        void btnBai_Click(object sender, EventArgs e)
        {            
            Button clickedButton = (Button)sender;
            baiDangChon = (Bai) clickedButton.Tag;
            
            // Sau cung thi cap nhat lai 
            CapNhatLaiSoLuongCauHoiCuaBai();
        }

        void ThayDoiSoLuongCauHoiCuaChuong(object sender, EventArgs e)
        {
            int soLuongCauDe = int.Parse(nudDe.Value.ToString());
            int soLuongCauTB = int.Parse(nudTrungBinh.Value.ToString());
            int soLuongCauKho = int.Parse(nudKho.Value.ToString());

            flpChuong.Controls.Clear();

            int selectedMonHocId = (int)cbxMonHoc1.SelectedValue;
            // Giá trị đã được ép kiểu thành kiểu int và lưu trong selectedMonHocId.
            List<Chuong> chuongList = db.Chuongs.Where(c => c.MaMonHoc == selectedMonHocId).ToList();

            deThi.CapNhatChuong(chuongDangChon.MaChuong, soLuongCauDe, soLuongCauTB, soLuongCauKho);

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
        }

        void ThayDoiSoLuongCauHoiCuaBai(object sender, EventArgs e)
        {
            // Reset số lượng câu hỏi của chương
            //nudDe = 0;
            //nudTrungBinh = 0;
            //nudKho = 0;

            flpBai.Controls.Clear();

            int soLuongCauDe = int.Parse(nubBaiDe.Value.ToString());
            int soLuongCauTB = int.Parse(nubBaiTB.Value.ToString());
            int soLuongCauKho = int.Parse(nubBaiKho.Value.ToString());

            deThi.CapNhatBaiCuaChuong(chuongDangChon.MaChuong, baiDangChon.MaBai, soLuongCauDe, soLuongCauTB, soLuongCauKho);

            List<Bai> baiList = db.Bais.Where(c => c.MaChuong == chuongDangChon.MaChuong).ToList();
            foreach (Bai item in baiList)
            {
                Button btn = new Button() { Width = BAI.TableWidth, Height = BAI.TableHeight };
                btn.Text = item.TenBai + Environment.NewLine;
                btn.Click += btnBai_Click;
                btn.Tag = item;

                if(deThi.KiemTraBaiCuaChuongRong(chuongDangChon.MaChuong, item.MaBai))
                {
                    btn.BackColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.Green;
                }

                flpBai.Controls.Add(btn);                
            }
        }

        private void chbDeTheoChuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDeTheoChuong.Checked)
            {
                chbDeBaiTheoChuong.Enabled = false;
                chbDeNgauNhien.Enabled = false;
                nubBaiDe.Enabled = false;
                nubBaiTB.Enabled = false;
                nubBaiKho.Enabled = false;

            }
            else
            {
                chbDeBaiTheoChuong.Enabled = true;
                chbDeNgauNhien.Enabled = true;
                nubBaiDe.Enabled = true;
                nubBaiTB.Enabled = true;
                nubBaiKho.Enabled = true;
            }
        }

        private void chbDeBaiTheoChuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDeBaiTheoChuong.Checked)
            {
                chbDeTheoChuong.Enabled = false;
                chbDeNgauNhien.Enabled = false;
                nudDe.Enabled = false;
                nudTrungBinh.Enabled = false;
                nudKho.Enabled = false;

            }
            else
            {
                chbDeTheoChuong.Enabled = true;
                chbDeNgauNhien.Enabled = true;
                nudDe.Enabled = true;
                nudTrungBinh.Enabled = true;
                nudKho.Enabled = true;
            }

        }
    }
}