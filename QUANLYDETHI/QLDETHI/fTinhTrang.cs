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
    public partial class fTinhTrang : Form
    {
        public fTinhTrang()
        {
            InitializeComponent();
        }

        private void fTinhTrang_Load(object sender, EventArgs e)
        {
            _them = false;
            _tinhtrang = new TINHTRANG();
            _showHide(true);
            loadData();
        }

        TINHTRANG _tinhtrang;
        bool _them;
        int _id;

        void loadData()
        {
            gridTinhTrang.DataSource = _tinhtrang.getList();
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
                _tinhtrang.Detele(_id);
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
                TinhTrang k = new TinhTrang();
                k.TenTinhTrang = txtTen.Text;
                _tinhtrang.Add(k);
            }
            else
            {
                var k = _tinhtrang.getItem(_id);
                k.TenTinhTrang = txtTen.Text;
                _tinhtrang.Update(k);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaTinhTrang").ToString());
                var k = _tinhtrang.getItem(_id);
                txtTen.Text = k.TenTinhTrang;
                _tinhtrang.Update(k);
            }
        }
    }
}
