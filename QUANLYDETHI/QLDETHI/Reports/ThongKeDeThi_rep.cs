using DethiLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLDETHI.Reports
{
    public partial class ThongKeDeThi_rep : DevExpress.XtraReports.UI.XtraReport
    {
        public ThongKeDeThi_rep()
        {
            InitializeComponent();
        }
        public void InitData(List<DETHI_DTO> data)
        {
            objectDataSource1.DataSource = data;
        }
    }
}
