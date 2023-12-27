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
    public partial class fTaiKhoanMonHoc : Form
    {
        public fTaiKhoanMonHoc()
        {
            InitializeComponent();
        }

        

        TAIKHOANMONHOC _taikhoanmonhoc;
        MONHOC _monhoc;
        TAIKHOAN _taikhoan;
        bool _them;
        int _id;


        private void fTaiKhoanMonHoc_Load(object sender, EventArgs e)
        {
            _them = false;
            _taikhoanmonhoc = new TAIKHOANMONHOC();
            _monhoc = new MONHOC();
            _taikhoan = new TAIKHOAN();
            _showHide(true);
            loadData();
            loadCombo();
        }

        void loadData()
        {
            gridTaiKhoanMonHoc.DataSource = _taikhoanmonhoc.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void loadCombo()
        {
            cbxMonHoc.DataSource = _monhoc.getList();
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxMonHoc.ValueMember = "MaMonHoc";


            cbxTaiKhoan.DataSource = _taikhoan.getList();
            cbxTaiKhoan.DisplayMember = "Username";
            cbxTaiKhoan.ValueMember = "IdTK";
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            cbxMonHoc.Enabled = !kt;
            cbxTaiKhoan.Enabled = !kt;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            _showHide(false);
            _them = true;
            //txtTen.Text = string.Empty;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _taikhoanmonhoc.Detele(_id);
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
                TaiKhoanMonHoc k = new TaiKhoanMonHoc();
                k.MaMonHoc = int.Parse(cbxMonHoc.SelectedValue.ToString());
                k.IdTK = int.Parse(cbxTaiKhoan.SelectedValue.ToString());
                _taikhoanmonhoc.Add(k);
            }
            else
            {
                var k = _taikhoanmonhoc.getItem(_id);
                k.MaMonHoc = int.Parse(cbxMonHoc.SelectedValue.ToString());
                k.IdTK = int.Parse(cbxTaiKhoan.SelectedValue.ToString());
                _taikhoanmonhoc.Update(k);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("Id").ToString());
                var k = _taikhoanmonhoc.getItem(_id);
                cbxMonHoc.SelectedValue = k.MaMonHoc;
                cbxTaiKhoan.SelectedValue = k.IdTK;
                _taikhoanmonhoc.Update(k);
            }
        }
    }
}
