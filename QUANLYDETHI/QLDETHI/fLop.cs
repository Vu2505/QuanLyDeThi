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
    public partial class fLop : Form
    {
        public fLop()
        {
            InitializeComponent();
        }


        LOP _lop;
        KHOI _khoi;
        bool _them;
        int _id;

        private void fLop_Load(object sender, EventArgs e)
        {
            _them = false;
            _lop = new LOP();
            _khoi = new KHOI();
            _showHide(true);
            loadData();
            loadCombo();
        }

        void loadData()
        {
            gridLop.DataSource = _lop.getList();
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
                _lop.Detele(_id);
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
                Lop k = new Lop();
                k.TenLop = txtTen.Text;
                k.MaKhoi = int.Parse(cbxKhoi.SelectedValue.ToString());
                _lop.Add(k);
            }
            else
            {
                var k = _lop.getItem(_id);
                k.TenLop = txtTen.Text;
                k.MaKhoi = int.Parse(cbxKhoi.SelectedValue.ToString());
                _lop.Update(k);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaLop").ToString());
            txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TenLop").ToString();
            cbxKhoi.Text = gvDanhSach.GetFocusedRowCellValue("MaKhoi").ToString();
        }

        
    }
}
