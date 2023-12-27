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
    public partial class fBai : Form
    {
        public fBai()
        {
            InitializeComponent();
        }

        BAI _bai;
        CHUONG _chuong;
        bool _them;
        int _id;

        private void fBai_Load(object sender, EventArgs e)
        {
            _them = false;
            _chuong = new CHUONG();
            _bai = new BAI();
            _showHide(true);
            loadData();
            loadCombo();
        }

        void loadData()
        {
            gridBai.DataSource = _bai.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadCombo()
        {
            cbxChuong.DataSource = _chuong.getList();
            cbxChuong.DisplayMember = "TenChuong";
            cbxChuong.ValueMember = "MaChuong";
        }

        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            txtTen.Enabled = !kt;
            cbxChuong.Enabled = !kt;

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
                _bai.Detele(_id);
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
                Bai k = new Bai();
                k.TenBai = txtTen.Text;
                k.MaChuong = int.Parse(cbxChuong.SelectedValue.ToString());
                _bai.Add(k);
            }
            else
            {
                var k = _bai.getItem(_id);
                k.TenBai = txtTen.Text;
                k.MaChuong = int.Parse(cbxChuong.SelectedValue.ToString());
                _bai.Update(k);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaBai").ToString());
                var k = _bai.getItem(_id);
                txtTen.Text = k.TenBai;
                cbxChuong.SelectedValue = k.MaChuong;
                _bai.Update(k);
            }
        }
    }
}
