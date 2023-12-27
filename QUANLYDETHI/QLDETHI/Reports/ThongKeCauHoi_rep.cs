using DethiLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLDETHI.Reports
{
    public partial class ThongKeCauHoi_rep : DevExpress.XtraReports.UI.XtraReport
    {
        public ThongKeCauHoi_rep()
        {
            InitializeComponent();
        }
        public void InitData(List<CAUHOI_DTO> data)
        {
            objectDataSource1.DataSource = data;
        }
    }
}
