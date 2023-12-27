using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using DethiLayer;
using DethiLayer.DTO;
using QLDETHI.Luutru;

namespace QLDETHI
{
    public partial class fTaiKhoan : Form
    {
        private TaiKhoan user;

        public fTaiKhoan()
        {
            InitializeComponent();
            user = LuuTru.User;
        }

        public fTaiKhoan(string username)
        {
            InitializeComponent();
            txbUserName.Text = username;
        }


        TAIKHOAN _taikhoan;
        LOAITAIKHOAN _loaitaikhoan;
        TINHTRANG _tinhtrang;
        bool _them;
        int _id;

        private void fTaiKhoan_Load(object sender, EventArgs e)
        {
            _them = false;
            _taikhoan = new TAIKHOAN();
            _loaitaikhoan = new LOAITAIKHOAN();
            _tinhtrang = new TINHTRANG();
            _showHide(true);
            loadData();
            loadCombo();
        }
        void loadData()
        {
            gridTaiKhoan.DataSource = _taikhoan.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void loadCombo()
        {
            cbxLoaiTaiKhoan.DataSource = _loaitaikhoan.getList();
            cbxLoaiTaiKhoan.DisplayMember = "TenLoaiTaiKhoan";
            cbxLoaiTaiKhoan.ValueMember = "MaLoaiTaiKhoan";


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
            btnReset.Enabled = kt;
            txbTenGV.Enabled = !kt;
            txbGhiChu.Enabled = !kt;
            txbMatKhau.Enabled = !kt;
            txbUserName.Enabled = !kt;
            cbxLoaiTaiKhoan.Enabled = !kt;
            cbxTinhTrang.Enabled = !kt;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            txbTenGV.Text = string.Empty;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _taikhoan.Detele(_id);
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
            _showHide(true);
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

        }
        private string GenerateRandomSalt()
        {
            byte[] saltBytes = new byte[16]; // Độ dài của salt (có thể điều chỉnh)
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return BitConverter.ToString(saltBytes).Replace("-", "").ToLower();
        }

        void SaveData()
        {
            if (_them)
            {
                TaiKhoan tk = new TaiKhoan();
                tk.TenGV = txbTenGV.Text;
                tk.Username = txbUserName.Text;
                tk.Matkhau = txbMatKhau.Text;
                tk.Salt = GenerateRandomSalt(); // Thêm salt ngẫu nhiên
                tk.Matkhau = TAIKHOAN.HashPassword(txbMatKhau.Text, tk.Salt);
                tk.LoaiTaiKhoan = int.Parse(cbxLoaiTaiKhoan.SelectedValue.ToString());
                tk.TinhTrang = int.Parse(cbxTinhTrang.SelectedValue.ToString());
                tk.GhiChu = txbGhiChu.Text;
                _taikhoan.Add(tk);
            }
            else
            {
                var tk = _taikhoan.getItem(_id);
                tk.TenGV = txbTenGV.Text;
                tk.Username = txbUserName.Text;
                // Không thay đổi salt khi cập nhật mật khẩu
                tk.Matkhau = TAIKHOAN.HashPassword(txbMatKhau.Text, tk.Salt);
                tk.LoaiTaiKhoan = int.Parse(cbxLoaiTaiKhoan.SelectedValue.ToString());
                tk.TinhTrang = int.Parse(cbxTinhTrang.SelectedValue.ToString());
                tk.GhiChu = txbGhiChu.Text;
                _taikhoan.Update(tk);
            }
        }

        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tk = _taikhoan.getItem(_id);
            if (cbxLoaiTaiKhoan.Text == "user")
            {
                tk.Salt = GenerateRandomSalt(); // Tạo salt mới khi reset mật khẩu
                tk.Matkhau = TAIKHOAN.HashPassword("", tk.Salt); // Đặt mật khẩu về rỗng và băm lại
                tk.LoaiTaiKhoan = 3;
                tk.TinhTrang = 1;
                _taikhoan.ResetPassWord(tk);
                MessageBox.Show("Reset tài khoản thành công");
                loadData();
            }
            else if (cbxLoaiTaiKhoan.Text == "admin")
            {
                MessageBox.Show("không thể reset mật khẩu của quản lý");
            }

        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IdTK").ToString());
                var k = _taikhoan.getItem(_id);
                txbTenGV.Text = k.TenGV;
                txbUserName.Text = k.Username;
                txbMatKhau.Text = k.Matkhau;
                cbxLoaiTaiKhoan.SelectedValue = k.LoaiTaiKhoan;
                cbxTinhTrang.SelectedValue = k.TinhTrang;
                txbGhiChu.Text = k.GhiChu;
                _taikhoan.Update(k);
            }
        }

       
    }
}
