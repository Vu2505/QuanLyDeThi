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
    public partial class fLoaiTaiKhoan : Form
    {
        public fLoaiTaiKhoan()
        {
            InitializeComponent();
        }

        private void fLoaiTaiKhoan_Load(object sender, EventArgs e)
        {
            _them = false;
            _loaitaikhoan = new LOAITAIKHOAN();
            _showHide(true);
            loadData();
        }

        LOAITAIKHOAN _loaitaikhoan;
        bool _them;
        int _id;

        void loadData()
        {
            gridLoaiTaiKhoan.DataSource = _loaitaikhoan.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
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
            txtTen.Enabled = !kt;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            _showHide(false);
            _them = true;
            txtTen.Text = string.Empty;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _loaitaikhoan.Detele(_id);
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
                LoaiTaiKhoan k = new LoaiTaiKhoan();
                k.TenLoaiTaiKhoan = txtTen.Text;
                _loaitaikhoan.Add(k);
            }
            else
            {
                var k = _loaitaikhoan.getItem(_id);
                k.TenLoaiTaiKhoan = txtTen.Text;
                _loaitaikhoan.Update(k);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaLoaiTaiKhoan").ToString());
                var k = _loaitaikhoan.getItem(_id);
                txtTen.Text = k.TenLoaiTaiKhoan;
                _loaitaikhoan.Update(k);
            }
        }
    }
}
