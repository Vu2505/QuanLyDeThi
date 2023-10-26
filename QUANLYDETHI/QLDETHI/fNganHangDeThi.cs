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
using QLDETHI.Reports;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;

namespace QLDETHI
{
    public partial class fNganHangDeThi : Form
    {
        public fNganHangDeThi()
        {
            InitializeComponent();
        }
        NOIDUNGDETHI _noidungdethi;

        private void fNganHangDeThi_Load(object sender, EventArgs e)
        {
            _noidungdethi = new NOIDUNGDETHI();
            loadData();
        }

        void loadData()
        {
            gridDeThi.DataSource = _noidungdethi.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void barPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fDeThiChiTiet report = new fDeThiChiTiet();
            DocumentViewer documentViewer = new DocumentViewer();
            var lstDT = _noidungdethi.getListFull();
            report.InitData(lstDT);
            documentViewer.DocumentSource = report;
            report.ShowPreviewDialog();
        } 
    }
}
