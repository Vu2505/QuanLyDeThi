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
    public partial class fChuong : Form
    {
        public fChuong()
        {
            InitializeComponent();
        }

        CHUONG _chuong;
        MONHOC _monhoc;
        bool _them;
        int _id;

        private void fChuong_Load(object sender, EventArgs e)
        {
            _them = false;
            _chuong = new CHUONG();
            _monhoc = new MONHOC();
            _showHide(true);
            loadData();
            loadCombo();

        }

        void loadData()
        {
            gridChuong.DataSource = _chuong.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            //DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
            //var result = from c in db.Chuongs
            //             where c.MaChuong == 1
            //             select c;
            //gridChuong.DataSource = result.ToList();
            //gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadCombo()
        {
            //DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
            //var result = from c in db.MonHocs
            //             where c.MaMonHoc == 1
            //             select c;
            //cbxMonHoc.DataSource = result.ToList();
            cbxMonHoc.DataSource = _monhoc.getList();
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxMonHoc.ValueMember = "MaMonHoc";
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            txtTen.Enabled = !kt;
            cbxMonHoc.Enabled = !kt;

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
                _chuong.Detele(_id);
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
                Chuong k = new Chuong();
                k.TenChuong = txtTen.Text;
                k.MaMonHoc = int.Parse(cbxMonHoc.SelectedValue.ToString());
                _chuong.Add(k);
            }
            else
            {
                var k = _chuong.getItem(_id);
                k.TenChuong = txtTen.Text;
                k.MaMonHoc = int.Parse(cbxMonHoc.SelectedValue.ToString());
                _chuong.Update(k);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaChuong").ToString());
                var k = _chuong.getItem(_id);
                txtTen.Text = k.TenChuong;
                cbxMonHoc.SelectedValue = k.MaMonHoc;
                _chuong.Update(k);
            }
        }

    }
}
