using DethiLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLDETHI.Reports
{
    public partial class fDeThiChiTiet : DevExpress.XtraReports.UI.XtraReport
    {
        public fDeThiChiTiet()
        {
            InitializeComponent();
        }

        public void InitData(List<DETHI_DTO> data)
        {
            objectDataSource1.DataSource = data;
        }
    }
}
