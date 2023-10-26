
namespace QLDETHI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage6 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage7 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barTaoDeThuCong = new DevExpress.XtraBars.BarButtonItem();
            this.barNganHangDeThi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage8 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.BarMonHoc = new DevExpress.XtraBars.BarButtonItem();
            this.barKhoi = new DevExpress.XtraBars.BarButtonItem();
            this.barLop = new DevExpress.XtraBars.BarButtonItem();
            this.barChuong = new DevExpress.XtraBars.BarButtonItem();
            this.barBai = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barCauHoi = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.import = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage9 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.DoiMatKhau = new DevExpress.XtraBars.BarButtonItem();
            this.barDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage10 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonControl2 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.barNamHoc = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage2.ImageOptions.Image")));
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Hệ thống";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage3.ImageOptions.Image")));
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Danh mục quản lý";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Quản lý đề thi";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage5.ImageOptions.Image")));
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "Hệ thống";
            // 
            // ribbonPage6
            // 
            this.ribbonPage6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage6.ImageOptions.Image")));
            this.ribbonPage6.Name = "ribbonPage6";
            this.ribbonPage6.Text = "Danh mục quản lý";
            // 
            // ribbonPage7
            // 
            this.ribbonPage7.Name = "ribbonPage7";
            this.ribbonPage7.Text = "Quản lý đề thi";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.ItemLinks.Add(this.barTaoDeThuCong, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barNganHangDeThi, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Tạo đề thi ngẫu nhiên có điều kiện";
            this.barButtonItem3.Id = 15;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barTaoDeThuCong
            // 
            this.barTaoDeThuCong.Caption = "Tạo đề thi thủ công";
            this.barTaoDeThuCong.Id = 17;
            this.barTaoDeThuCong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barTaoDeThuCong.ImageOptions.Image")));
            this.barTaoDeThuCong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barTaoDeThuCong.ImageOptions.LargeImage")));
            this.barTaoDeThuCong.Name = "barTaoDeThuCong";
            this.barTaoDeThuCong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barTaoDeThuCong_ItemClick);
            // 
            // barNganHangDeThi
            // 
            this.barNganHangDeThi.Caption = "Ngân hàng đề thi";
            this.barNganHangDeThi.Id = 18;
            this.barNganHangDeThi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barNganHangDeThi.ImageOptions.Image")));
            this.barNganHangDeThi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barNganHangDeThi.ImageOptions.LargeImage")));
            this.barNganHangDeThi.Name = "barNganHangDeThi";
            this.barNganHangDeThi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNganHangDeThi_ItemClick);
            // 
            // ribbonPage8
            // 
            this.ribbonPage8.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage8.Name = "ribbonPage8";
            this.ribbonPage8.Text = "Quản lý đề thi";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.BarMonHoc);
            this.ribbonPageGroup3.ItemLinks.Add(this.barKhoi, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barLop, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barChuong, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barBai, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem8, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barCauHoi, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem10, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.import);
            this.ribbonPageGroup3.ItemLinks.Add(this.barNamHoc);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // BarMonHoc
            // 
            this.BarMonHoc.Caption = "Môn học";
            this.BarMonHoc.Id = 5;
            this.BarMonHoc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BarMonHoc.ImageOptions.Image")));
            this.BarMonHoc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarMonHoc.ImageOptions.LargeImage")));
            this.BarMonHoc.Name = "BarMonHoc";
            this.BarMonHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarMonHoc_ItemClick);
            // 
            // barKhoi
            // 
            this.barKhoi.Caption = "Khối";
            this.barKhoi.Id = 7;
            this.barKhoi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barKhoi.ImageOptions.Image")));
            this.barKhoi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barKhoi.ImageOptions.LargeImage")));
            this.barKhoi.Name = "barKhoi";
            this.barKhoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barKhoi_ItemClick);
            // 
            // barLop
            // 
            this.barLop.Caption = "Lớp";
            this.barLop.Id = 6;
            this.barLop.ImageOptions.Image = global::QLDETHI.Properties.Resources.business_presentation__2_;
            this.barLop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barLop.ImageOptions.LargeImage")));
            this.barLop.Name = "barLop";
            this.barLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLop_ItemClick);
            // 
            // barChuong
            // 
            this.barChuong.Caption = "Chương";
            this.barChuong.Id = 10;
            this.barChuong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barChuong.ImageOptions.SvgImage")));
            this.barChuong.Name = "barChuong";
            this.barChuong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barChuong_ItemClick);
            // 
            // barBai
            // 
            this.barBai.Caption = "Bài";
            this.barBai.Id = 11;
            this.barBai.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBai.ImageOptions.SvgImage")));
            this.barBai.Name = "barBai";
            this.barBai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBai_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Giảng viên";
            this.barButtonItem8.Id = 12;
            this.barButtonItem8.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem8.ImageOptions.SvgImage")));
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barCauHoi
            // 
            this.barCauHoi.Caption = "Câu hỏi";
            this.barCauHoi.Id = 13;
            this.barCauHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barCauHoi.ImageOptions.SvgImage")));
            this.barCauHoi.Name = "barCauHoi";
            this.barCauHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCauHoi_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "Đề thi";
            this.barButtonItem10.Id = 14;
            this.barButtonItem10.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem10.ImageOptions.SvgImage")));
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // import
            // 
            this.import.Caption = "barButtonItem5";
            this.import.Id = 19;
            this.import.Name = "import";
            this.import.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.import_ItemClick);
            // 
            // ribbonPage9
            // 
            this.ribbonPage9.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage9.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage9.ImageOptions.Image")));
            this.ribbonPage9.Name = "ribbonPage9";
            this.ribbonPage9.Text = "Danh mục quản lý";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem11);
            this.ribbonPageGroup4.ItemLinks.Add(this.DoiMatKhau, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.barDangXuat, true);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Hệ thống";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "Thông tin cá nhân";
            this.barButtonItem11.Id = 16;
            this.barButtonItem11.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem11.ImageOptions.SvgImage")));
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // DoiMatKhau
            // 
            this.DoiMatKhau.Caption = "Đổi mật khẩu";
            this.DoiMatKhau.Id = 1;
            this.DoiMatKhau.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("DoiMatKhau.ImageOptions.SvgImage")));
            this.DoiMatKhau.Name = "DoiMatKhau";
            this.DoiMatKhau.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DoiMatKhau_ItemClick);
            // 
            // barDangXuat
            // 
            this.barDangXuat.Caption = "Đăng xuất";
            this.barDangXuat.Id = 3;
            this.barDangXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDangXuat.ImageOptions.Image")));
            this.barDangXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barDangXuat.ImageOptions.LargeImage")));
            this.barDangXuat.Name = "barDangXuat";
            this.barDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDangXuat_ItemClick);
            // 
            // ribbonPage10
            // 
            this.ribbonPage10.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage10.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage10.ImageOptions.Image")));
            this.ribbonPage10.Name = "ribbonPage10";
            this.ribbonPage10.Text = "Hệ thống";
            // 
            // ribbonControl2
            // 
            this.ribbonControl2.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(37);
            this.ribbonControl2.ExpandCollapseItem.Id = 0;
            this.ribbonControl2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl2.ExpandCollapseItem,
            this.ribbonControl2.SearchEditItem,
            this.DoiMatKhau,
            this.barDangXuat,
            this.BarMonHoc,
            this.barLop,
            this.barKhoi,
            this.barButtonItem7,
            this.barChuong,
            this.barBai,
            this.barButtonItem8,
            this.barCauHoi,
            this.barButtonItem10,
            this.barButtonItem3,
            this.barButtonItem11,
            this.barTaoDeThuCong,
            this.barNganHangDeThi,
            this.import,
            this.barNamHoc});
            this.ribbonControl2.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl2.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonControl2.MaxItemId = 21;
            this.ribbonControl2.Name = "ribbonControl2";
            this.ribbonControl2.OptionsMenuMinWidth = 412;
            this.ribbonControl2.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage10,
            this.ribbonPage9,
            this.ribbonPage8});
            this.ribbonControl2.Size = new System.Drawing.Size(1039, 209);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Đăng xuất";
            this.barButtonItem7.Id = 9;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbonControl2;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // barNamHoc
            // 
            this.barNamHoc.Caption = "Năm học";
            this.barNamHoc.Id = 20;
            this.barNamHoc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barNamHoc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barNamHoc.Name = "barNamHoc";
            this.barNamHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNamHoc_ItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 693);
            this.Controls.Add(this.ribbonControl2);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl2;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage6;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem BarMonHoc;
        private DevExpress.XtraBars.BarButtonItem barLop;
        private DevExpress.XtraBars.BarButtonItem barKhoi;
        private DevExpress.XtraBars.BarButtonItem barChuong;
        private DevExpress.XtraBars.BarButtonItem barBai;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barCauHoi;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem DoiMatKhau;
        private DevExpress.XtraBars.BarButtonItem barDangXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage10;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem barTaoDeThuCong;
        private DevExpress.XtraBars.BarButtonItem barNganHangDeThi;
        private DevExpress.XtraBars.BarButtonItem import;
        private DevExpress.XtraBars.BarButtonItem barNamHoc;
    }
}

