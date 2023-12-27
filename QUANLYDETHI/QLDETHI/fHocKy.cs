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
    public partial class fHocKy : Form
    {
        public fHocKy()
        {
            InitializeComponent();
        }

        HOCKY _hocky;
        bool _them;
        int _id;
        private void fHocKy_Load(object sender, EventArgs e)
        {
            _hocky = new HOCKY();
            _showHide(true);
            loadData();
        }

        void loadData()
        {
            gridHocKy.DataSource = _hocky.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
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
                _hocky.Detele(_id);
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
                HocKy k = new HocKy();
                k.TenHocKy = txtTen.Text;
                _hocky.Add(k);
            }
            else
            {
                var k = _hocky.getItem(_id);
                k.TenHocKy = txtTen.Text;
                _hocky.Update(k);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaHocKy").ToString());
                var k = _hocky.getItem(_id);
                txtTen.Text = k.TenHocKy;
                _hocky.Update(k);
            }
        }
    }
}
