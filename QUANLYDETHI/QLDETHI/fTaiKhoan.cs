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

namespace QLDETHI
{
    public partial class fTaiKhoan : Form
    {
        public fTaiKhoan()
        {
            InitializeComponent();
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
            btnDong.Enabled = kt;
            btnPrint.Enabled = kt;
            txbTenGV.Enabled = !kt;

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

        void SaveData()
        {
            if (_them)
            {
                TaiKhoan tk = new TaiKhoan();
                tk.TenGV = txbTenGV.Text;
                tk.Username = txbUserName.Text;
                tk.Matkhau = txbMatKhau.Text;
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
                tk.Matkhau = txbMatKhau.Text;
                tk.LoaiTaiKhoan = int.Parse(cbxLoaiTaiKhoan.SelectedValue.ToString());
                tk.TinhTrang = int.Parse(cbxTinhTrang.SelectedValue.ToString());
                tk.GhiChu = txbGhiChu.Text;
                _taikhoan.Update(tk);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
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
