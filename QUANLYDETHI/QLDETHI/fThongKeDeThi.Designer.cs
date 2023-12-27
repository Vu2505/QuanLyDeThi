
namespace QLDETHI
{
    partial class fThongKeDeThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThongKeDeThi));
            this.barDockControl8 = new DevExpress.XtraBars.BarDockControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaHienThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoCauHoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNamHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenHocKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDeThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenThoiGianThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lbSoDeThi = new System.Windows.Forms.Label();
            this.lbSoDeThi1 = new System.Windows.Forms.Label();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridDeThi = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenMonHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKhoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControl8
            // 
            this.barDockControl8.CausesValidation = false;
            this.barDockControl8.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl8.Location = new System.Drawing.Point(1924, 30);
            this.barDockControl8.Manager = null;
            this.barDockControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl8.Size = new System.Drawing.Size(0, 672);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaDe,
            this.MaHienThi,
            this.SoCauHoi,
            this.TenNamHoc,
            this.TenHocKy,
            this.TenDeThi,
            this.TenThoiGianThi,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.TenLop});
            this.gridView1.Name = "gridView1";
            // 
            // MaDe
            // 
            this.MaDe.Caption = "Mã Đề";
            this.MaDe.FieldName = "MaDe";
            this.MaDe.MinWidth = 25;
            this.MaDe.Name = "MaDe";
            this.MaDe.Width = 94;
            // 
            // MaHienThi
            // 
            this.MaHienThi.Caption = "Mã Hiển Thị";
            this.MaHienThi.FieldName = "MaHienThi";
            this.MaHienThi.MinWidth = 25;
            this.MaHienThi.Name = "MaHienThi";
            this.MaHienThi.Width = 94;
            // 
            // SoCauHoi
            // 
            this.SoCauHoi.Caption = "Số Câu Hỏi";
            this.SoCauHoi.FieldName = "SoCauHoi";
            this.SoCauHoi.MinWidth = 25;
            this.SoCauHoi.Name = "SoCauHoi";
            this.SoCauHoi.Width = 94;
            // 
            // TenNamHoc
            // 
            this.TenNamHoc.Caption = "Năm học";
            this.TenNamHoc.FieldName = "TenNamHoc";
            this.TenNamHoc.MinWidth = 25;
            this.TenNamHoc.Name = "TenNamHoc";
            this.TenNamHoc.Width = 94;
            // 
            // TenHocKy
            // 
            this.TenHocKy.Caption = "Học Kỳ";
            this.TenHocKy.FieldName = "TenHocKy";
            this.TenHocKy.MinWidth = 25;
            this.TenHocKy.Name = "TenHocKy";
            this.TenHocKy.Width = 94;
            // 
            // TenDeThi
            // 
            this.TenDeThi.Caption = "Tên đề thi";
            this.TenDeThi.FieldName = "TenDeThi";
            this.TenDeThi.MinWidth = 25;
            this.TenDeThi.Name = "TenDeThi";
            this.TenDeThi.Width = 94;
            // 
            // TenThoiGianThi
            // 
            this.TenThoiGianThi.Caption = "Thời gian thi";
            this.TenThoiGianThi.FieldName = "TenThoiGianThi";
            this.TenThoiGianThi.MinWidth = 25;
            this.TenThoiGianThi.Name = "TenThoiGianThi";
            this.TenThoiGianThi.Width = 94;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Môn học";
            this.gridColumn1.FieldName = "TenMonHoc";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Khối";
            this.gridColumn2.FieldName = "TenKhoi";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 94;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ngày cập nhật";
            this.gridColumn3.FieldName = "NgayCapNhat";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Width = 94;
            // 
            // TenLop
            // 
            this.TenLop.Caption = "Lớp";
            this.TenLop.FieldName = "TenLop";
            this.TenLop.MinWidth = 25;
            this.TenLop.Name = "TenLop";
            this.TenLop.Width = 94;
            // 
            // lbSoDeThi
            // 
            this.lbSoDeThi.AutoSize = true;
            this.lbSoDeThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDeThi.Location = new System.Drawing.Point(155, 22);
            this.lbSoDeThi.Name = "lbSoDeThi";
            this.lbSoDeThi.Size = new System.Drawing.Size(23, 25);
            this.lbSoDeThi.TabIndex = 1;
            this.lbSoDeThi.Text = "0";
            // 
            // lbSoDeThi1
            // 
            this.lbSoDeThi1.AutoSize = true;
            this.lbSoDeThi1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDeThi1.Location = new System.Drawing.Point(23, 22);
            this.lbSoDeThi1.Name = "lbSoDeThi1";
            this.lbSoDeThi1.Size = new System.Drawing.Size(116, 25);
            this.lbSoDeThi1.TabIndex = 0;
            this.lbSoDeThi1.Text = "Tổng đề thi:";
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
            // 
            // Print
            // 
            this.Print.Caption = "Print";
            this.Print.Id = 10;
            this.Print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Print.ImageOptions.SvgImage")));
            this.Print.Name = "Print";
            this.Print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Print_ItemClick);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridDeThi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbSoDeThi);
            this.splitContainer1.Panel2.Controls.Add(this.lbSoDeThi1);
            this.splitContainer1.Size = new System.Drawing.Size(1924, 672);
            this.splitContainer1.SplitterDistance = 616;
            this.splitContainer1.TabIndex = 25;
            // 
            // gridDeThi
            // 
            this.gridDeThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDeThi.Location = new System.Drawing.Point(0, 0);
            this.gridDeThi.MainView = this.gvDanhSach;
            this.gridDeThi.Name = "gridDeThi";
            this.gridDeThi.Size = new System.Drawing.Size(1924, 616);
            this.gridDeThi.TabIndex = 1;
            this.gridDeThi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.TenMonHoc,
            this.TenKhoi,
            this.NgayCapNhat,
            this.gridColumn11});
            this.gvDanhSach.GridControl = this.gridDeThi;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.ColumnFilterChanged += new System.EventHandler(this.gvDanhSach_ColumnFilterChanged);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mã Đề";
            this.gridColumn4.FieldName = "MaDe";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 94;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mã Hiển Thị";
            this.gridColumn5.FieldName = "MaHienThi";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 94;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số Câu Hỏi";
            this.gridColumn6.FieldName = "SoCauHoi";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 94;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Năm học";
            this.gridColumn7.FieldName = "TenNamHoc";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 94;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Học Kỳ";
            this.gridColumn8.FieldName = "TenHocKy";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 94;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tên đề thi";
            this.gridColumn9.FieldName = "TenDeThi";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 94;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Thời gian thi";
            this.gridColumn10.FieldName = "TenThoiGianThi";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 94;
            // 
            // TenMonHoc
            // 
            this.TenMonHoc.Caption = "Môn học";
            this.TenMonHoc.FieldName = "TenMonHoc";
            this.TenMonHoc.MinWidth = 25;
            this.TenMonHoc.Name = "TenMonHoc";
            this.TenMonHoc.Visible = true;
            this.TenMonHoc.VisibleIndex = 7;
            this.TenMonHoc.Width = 94;
            // 
            // TenKhoi
            // 
            this.TenKhoi.Caption = "Khối";
            this.TenKhoi.FieldName = "TenKhoi";
            this.TenKhoi.MinWidth = 25;
            this.TenKhoi.Name = "TenKhoi";
            this.TenKhoi.Visible = true;
            this.TenKhoi.VisibleIndex = 8;
            this.TenKhoi.Width = 94;
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.Caption = "Ngày cập nhật";
            this.NgayCapNhat.FieldName = "NgayCapNhat";
            this.NgayCapNhat.MinWidth = 25;
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Visible = true;
            this.NgayCapNhat.VisibleIndex = 9;
            this.NgayCapNhat.Width = 94;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Lớp";
            this.gridColumn11.FieldName = "TenLop";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            this.gridColumn11.Width = 94;
            // 
            // fThongKeDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 722);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControl8);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "fThongKeDeThi";
            this.Text = "fThongKeDeThi";
            this.Load += new System.EventHandler(this.fThongKeDeThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDeThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarDockControl barDockControl8;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MaDe;
        private DevExpress.XtraGrid.Columns.GridColumn MaHienThi;
        private DevExpress.XtraGrid.Columns.GridColumn SoCauHoi;
        private DevExpress.XtraGrid.Columns.GridColumn TenNamHoc;
        private DevExpress.XtraGrid.Columns.GridColumn TenHocKy;
        private DevExpress.XtraGrid.Columns.GridColumn TenDeThi;
        private DevExpress.XtraGrid.Columns.GridColumn TenThoiGianThi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn TenLop;
        private System.Windows.Forms.Label lbSoDeThi;
        private System.Windows.Forms.Label lbSoDeThi1;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barDaoDe;
        private DevExpress.XtraBars.BarButtonItem Print;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barLuu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraGrid.GridControl gridDeThi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn TenMonHoc;
        private DevExpress.XtraGrid.Columns.GridColumn TenKhoi;
        private DevExpress.XtraGrid.Columns.GridColumn NgayCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}