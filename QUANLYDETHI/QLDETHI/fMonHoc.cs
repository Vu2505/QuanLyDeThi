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
    public partial class fMonHoc : Form
    {
        public fMonHoc()
        {
            InitializeComponent();
        }

        MONHOC _monhoc;
        KHOI _khoi;
        bool _them;
        int _id;

        private void fMonHoc_Load(object sender, EventArgs e)
        {
            _them = false;
            _monhoc = new MONHOC();
            _khoi = new KHOI();
            _showHide(true);
            loadData();
            loadCombo();
        }

        void loadData()
        {
            gridMonHoc.DataSource = _monhoc.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void loadCombo()
        {
            cbxKhoi.DataSource = _khoi.getList();
            cbxKhoi.DisplayMember = "TenKhoi";
            cbxKhoi.ValueMember = "MaKhoi";
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            txtTen.Enabled = !kt;
            cbxKhoi.Enabled = !kt;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            _showHide(false);
            _them = true;
            txtTen.Text = string.Empty;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa không?","Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                _monhoc.Detele(_id);
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
            if(_them)
            {
                MonHoc mh = new MonHoc();
                mh.TenMonHoc = txtTen.Text;
                mh.MaKhoi = int.Parse(cbxKhoi.SelectedValue.ToString());
                _monhoc.Add(mh);
            }
            else
            {
                var mh = _monhoc.getItem(_id);
                mh.TenMonHoc = txtTen.Text;
                mh.MaKhoi = int.Parse(cbxKhoi.SelectedValue.ToString());
                _monhoc.Update(mh);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaMonHoc").ToString());
                var k = _monhoc.getItem(_id);
                txtTen.Text = k.TenMonHoc;
                cbxKhoi.SelectedValue = k.MaKhoi;
                _monhoc.Update(k);
            }
        }
    }
}
