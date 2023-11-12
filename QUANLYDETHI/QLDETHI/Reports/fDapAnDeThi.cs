﻿using DethiLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLDETHI.Reports
{
    public partial class fDapAnDeThi : DevExpress.XtraReports.UI.XtraReport
    {
        public int MaDe { get; set; }
        public fDapAnDeThi()
        {
            InitializeComponent();
        }

        public void InitData(List<DETHI_DTO> data)
        {
            objectDataSource1.DataSource = data;
        }
    }
}
