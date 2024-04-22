
namespace QLDETHI
{
    partial class fNganHangDeThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNganHangDeThi));
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barDaoDe = new DevExpress.XtraBars.BarButtonItem();
            this.Print = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barThem = new DevExpress.XtraBars.BarButtonItem();
            this.barSua = new DevExpress.XtraBars.BarButtonItem();
            this.barLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.gridDeThi = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaHienThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenMonHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKhoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNamHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDeThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenHocKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenThoiGianThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ThuTuCauHoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NDCH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.A = new DevExpress.XtraGrid.Columns.GridColumn();
            this.B = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C = new DevExpress.XtraGrid.Columns.GridColumn();
            this.D = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DapAnDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar1});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barThem,
            this.barSua,
            this.barLuu,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barDaoDe,
            this.Print});
            this.barManager2.MainMenu = this.bar2;
            this.barManager2.MaxItemId = 11;
            this.barManager2.StatusBar = this.bar1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barDaoDe, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.Print, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barDaoDe
            // 
            this.barDaoDe.Caption = "Đảo đề";
            this.barDaoDe.Id = 7;
            this.barDaoDe.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barDaoDe.ImageOptions.SvgImage")));
            this.barDaoDe.Name = "barDaoDe";
            this.barDaoDe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDaoDe_ItemClick);
            // 
            // Print
            // 
            this.Print.Caption = "Print";
            this.Print.Id = 10;
            this.Print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Print.ImageOptions.SvgImage")));
            this.Print.Name = "Print";
            this.Print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barPrint_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Status bar";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Status bar";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager2;
            this.barDockControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl1.Size = new System.Drawing.Size(1924, 30);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 702);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl2.Size = new System.Drawing.Size(1924, 20);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 30);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl3.Size = new System.Drawing.Size(0, 672);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1924, 30);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl4.Size = new System.Drawing.Size(0, 672);
            // 
            // barThem
            // 
            this.barThem.Caption = "Thêm";
            this.barThem.Id = 0;
            this.barThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barThem.ImageOptions.SvgImage")));
            this.barThem.Name = "barThem";
            // 
            // barSua
            // 
            this.barSua.Caption = "Sửa";
            this.barSua.Id = 2;
            this.barSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barSua.ImageOptions.SvgImage")));
            this.barSua.Name = "barSua";
            // 
            // barLuu
            // 
            this.barLuu.Caption = "Lưu";
            this.barLuu.Id = 3;
            this.barLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barLuu.ImageOptions.SvgImage")));
            this.barLuu.Name = "barLuu";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Hủy";
            this.barButtonItem6.Id = 4;
            this.barButtonItem6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem6.ImageOptions.SvgImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Đóng";
            this.barButtonItem7.Id = 5;
            this.barButtonItem7.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem7.ImageOptions.SvgImage")));
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // gridDeThi
            // 
            this.gridDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDeThi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(12);
            this.gridDeThi.Location = new System.Drawing.Point(0, 30);
            this.gridDeThi.MainView = this.gvDanhSach;
            this.gridDeThi.Margin = new System.Windows.Forms.Padding(12);
            this.gridDeThi.MenuManager = this.barManager2;
            this.gridDeThi.Name = "gridDeThi";
            this.gridDeThi.Size = new System.Drawing.Size(1924, 672);
            this.gridDeThi.TabIndex = 22;
            this.gridDeThi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaDe,
            this.MaHienThi,
            this.TenMonHoc,
            this.TenKhoi,
            this.TenNamHoc,
            this.TenDeThi,
            this.TenHocKy,
            this.NgayCapNhat,
            this.TenThoiGianThi,
            this.ThuTuCauHoi,
            this.NDCH,
            this.A,
            this.B,
            this.C,
            this.D,
            this.DapAnDung,
            this.ID});
            this.gvDanhSach.DetailHeight = 1331;
            this.gvDanhSach.GridControl = this.gridDeThi;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.Click += new System.EventHandler(this.gvDanhSach_Click);
            // 
            // MaDe
            // 
            this.MaDe.Caption = "ID Đề";
            this.MaDe.FieldName = "MaDe";
            this.MaDe.MaxWidth = 90;
            this.MaDe.MinWidth = 10;
            this.MaDe.Name = "MaDe";
            this.MaDe.Visible = true;
            this.MaDe.VisibleIndex = 1;
            this.MaDe.Width = 90;
            // 
            // MaHienThi
            // 
            this.MaHienThi.Caption = "Mã Hiển Thị";
            this.MaHienThi.FieldName = "MaHienThi";
            this.MaHienThi.MinWidth = 10;
            this.MaHienThi.Name = "MaHienThi";
            this.MaHienThi.Visible = true;
            this.MaHienThi.VisibleIndex = 2;
            this.MaHienThi.Width = 81;
            // 
            // TenMonHoc
            // 
            this.TenMonHoc.Caption = "Môn Học";
            this.TenMonHoc.FieldName = "TenMonHoc";
            this.TenMonHoc.MinWidth = 95;
            this.TenMonHoc.Name = "TenMonHoc";
            this.TenMonHoc.Visible = true;
            this.TenMonHoc.VisibleIndex = 3;
            this.TenMonHoc.Width = 95;
            // 
            // TenKhoi
            // 
            this.TenKhoi.Caption = "Khối";
            this.TenKhoi.FieldName = "TenKhoi";
            this.TenKhoi.MinWidth = 10;
            this.TenKhoi.Name = "TenKhoi";
            this.TenKhoi.Visible = true;
            this.TenKhoi.VisibleIndex = 4;
            this.TenKhoi.Width = 59;
            // 
            // TenNamHoc
            // 
            this.TenNamHoc.Caption = "Năm học";
            this.TenNamHoc.FieldName = "TenNamHoc";
            this.TenNamHoc.MinWidth = 10;
            this.TenNamHoc.Name = "TenNamHoc";
            this.TenNamHoc.Visible = true;
            this.TenNamHoc.VisibleIndex = 5;
            this.TenNamHoc.Width = 87;
            // 
            // TenDeThi
            // 
            this.TenDeThi.Caption = "Tên đề thi";
            this.TenDeThi.FieldName = "TenDeThi";
            this.TenDeThi.MinWidth = 95;
            this.TenDeThi.Name = "TenDeThi";
            this.TenDeThi.Visible = true;
            this.TenDeThi.VisibleIndex = 6;
            this.TenDeThi.Width = 167;
            // 
            // TenHocKy
            // 
            this.TenHocKy.Caption = "Học kì";
            this.TenHocKy.FieldName = "TenHocKy";
            this.TenHocKy.MinWidth = 25;
            this.TenHocKy.Name = "TenHocKy";
            this.TenHocKy.Visible = true;
            this.TenHocKy.VisibleIndex = 8;
            this.TenHocKy.Width = 78;
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.Caption = "Ngày cập nhật";
            this.NgayCapNhat.FieldName = "NgayCapNhat";
            this.NgayCapNhat.MaxWidth = 95;
            this.NgayCapNhat.MinWidth = 95;
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Visible = true;
            this.NgayCapNhat.VisibleIndex = 16;
            this.NgayCapNhat.Width = 95;
            // 
            // TenThoiGianThi
            // 
            this.TenThoiGianThi.Caption = "Thời gian thi";
            this.TenThoiGianThi.FieldName = "TenThoiGianThi";
            this.TenThoiGianThi.MinWidth = 39;
            this.TenThoiGianThi.Name = "TenThoiGianThi";
            this.TenThoiGianThi.Visible = true;
            this.TenThoiGianThi.VisibleIndex = 7;
            this.TenThoiGianThi.Width = 86;
            // 
            // ThuTuCauHoi
            // 
            this.ThuTuCauHoi.Caption = "STT";
            this.ThuTuCauHoi.FieldName = "ThuTuCauHoi";
            this.ThuTuCauHoi.MinWidth = 25;
            this.ThuTuCauHoi.Name = "ThuTuCauHoi";
            this.ThuTuCauHoi.Visible = true;
            this.ThuTuCauHoi.VisibleIndex = 9;
            this.ThuTuCauHoi.Width = 41;
            // 
            // NDCH
            // 
            this.NDCH.Caption = "NDCH";
            this.NDCH.FieldName = "NDCH";
            this.NDCH.MinWidth = 25;
            this.NDCH.Name = "NDCH";
            this.NDCH.Visible = true;
            this.NDCH.VisibleIndex = 10;
            this.NDCH.Width = 159;
            // 
            // A
            // 
            this.A.Caption = "A";
            this.A.FieldName = "A";
            this.A.MinWidth = 25;
            this.A.Name = "A";
            this.A.Visible = true;
            this.A.VisibleIndex = 11;
            this.A.Width = 159;
            // 
            // B
            // 
            this.B.Caption = "B";
            this.B.FieldName = "B";
            this.B.MinWidth = 25;
            this.B.Name = "B";
            this.B.Visible = true;
            this.B.VisibleIndex = 12;
            this.B.Width = 159;
            // 
            // C
            // 
            this.C.Caption = "C";
            this.C.FieldName = "C";
            this.C.MinWidth = 25;
            this.C.Name = "C";
            this.C.Visible = true;
            this.C.VisibleIndex = 13;
            this.C.Width = 159;
            // 
            // D
            // 
            this.D.Caption = "D";
            this.D.FieldName = "D";
            this.D.MinWidth = 25;
            this.D.Name = "D";
            this.D.Visible = true;
            this.D.VisibleIndex = 14;
            this.D.Width = 159;
            // 
            // DapAnDung
            // 
            this.DapAnDung.Caption = "Đáp án đúng";
            this.DapAnDung.FieldName = "DapAnDung";
            this.DapAnDung.MinWidth = 25;
            this.DapAnDung.Name = "DapAnDung";
            this.DapAnDung.Visible = true;
            this.DapAnDung.VisibleIndex = 15;
            this.DapAnDung.Width = 131;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 25;
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 89;
            // 
            // fNganHangDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 722);
            this.Controls.Add(this.gridDeThi);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "fNganHangDeThi";
            this.Text = "Ngân hàng đề thi";
            this.Load += new System.EventHandler(this.fNganHangDeThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barLuu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barDaoDe;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarButtonItem Print;
        public DevExpress.XtraGrid.GridControl gridDeThi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn MaDe;
        private DevExpress.XtraGrid.Columns.GridColumn MaHienThi;
        private DevExpress.XtraGrid.Columns.GridColumn TenMonHoc;
        private DevExpress.XtraGrid.Columns.GridColumn TenKhoi;
        private DevExpress.XtraGrid.Columns.GridColumn TenNamHoc;
        private DevExpress.XtraGrid.Columns.GridColumn TenDeThi;
        private DevExpress.XtraGrid.Columns.GridColumn TenHocKy;
        private DevExpress.XtraGrid.Columns.GridColumn NgayCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn TenThoiGianThi;
        private DevExpress.XtraGrid.Columns.GridColumn ThuTuCauHoi;
        private DevExpress.XtraGrid.Columns.GridColumn NDCH;
        private DevExpress.XtraGrid.Columns.GridColumn A;
        private DevExpress.XtraGrid.Columns.GridColumn B;
        private DevExpress.XtraGrid.Columns.GridColumn C;
        private DevExpress.XtraGrid.Columns.GridColumn D;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn DapAnDung;
    }
}