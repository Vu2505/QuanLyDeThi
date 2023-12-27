
namespace QLDETHI
{
    partial class fThongKeCauHoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThongKeCauHoi));
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
            this.gridCauHoi = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaCauHoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NDCH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.A = new DevExpress.XtraGrid.Columns.GridColumn();
            this.B = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C = new DevExpress.XtraGrid.Columns.GridColumn();
            this.D = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DapAnDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HinhAnh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKhoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenMonHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenChuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenBai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenDoKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenTinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lbSoCauHoi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCauHoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSoDeThi1
            // 
            this.lbSoDeThi1.AutoSize = true;
            this.lbSoDeThi1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDeThi1.Location = new System.Drawing.Point(23, 22);
            this.lbSoDeThi1.Name = "lbSoDeThi1";
            this.lbSoDeThi1.Size = new System.Drawing.Size(132, 25);
            this.lbSoDeThi1.TabIndex = 0;
            this.lbSoDeThi1.Text = "Tổng câu hỏi:";
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
            this.splitContainer1.Panel1.Controls.Add(this.gridCauHoi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbSoCauHoi);
            this.splitContainer1.Panel2.Controls.Add(this.lbSoDeThi1);
            this.splitContainer1.Size = new System.Drawing.Size(1924, 672);
            this.splitContainer1.SplitterDistance = 616;
            this.splitContainer1.TabIndex = 18;
            // 
            // gridCauHoi
            // 
            this.gridCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCauHoi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridCauHoi.Location = new System.Drawing.Point(0, 0);
            this.gridCauHoi.MainView = this.gvDanhSach;
            this.gridCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridCauHoi.Name = "gridCauHoi";
            this.gridCauHoi.Size = new System.Drawing.Size(1924, 616);
            this.gridCauHoi.TabIndex = 1;
            this.gridCauHoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaCauHoi,
            this.NDCH,
            this.A,
            this.B,
            this.C,
            this.D,
            this.DapAnDung,
            this.HinhAnh,
            this.TenKhoi,
            this.TenMonHoc,
            this.TenChuong,
            this.TenBai,
            this.TenDoKho,
            this.TenTinhTrang,
            this.NgayCapNhat,
            this.GhiChu});
            this.gvDanhSach.GridControl = this.gridCauHoi;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhSach.ColumnFilterChanged += new System.EventHandler(this.gvDanhSach_ColumnFilterChanged);
            // 
            // MaCauHoi
            // 
            this.MaCauHoi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.MaCauHoi.AppearanceCell.Options.UseFont = true;
            this.MaCauHoi.Caption = "ID";
            this.MaCauHoi.FieldName = "MaCauHoi";
            this.MaCauHoi.MinWidth = 25;
            this.MaCauHoi.Name = "MaCauHoi";
            this.MaCauHoi.Visible = true;
            this.MaCauHoi.VisibleIndex = 0;
            this.MaCauHoi.Width = 93;
            // 
            // NDCH
            // 
            this.NDCH.Caption = "ND Câu Hỏi";
            this.NDCH.FieldName = "NDCH";
            this.NDCH.MinWidth = 25;
            this.NDCH.Name = "NDCH";
            this.NDCH.Visible = true;
            this.NDCH.VisibleIndex = 1;
            this.NDCH.Width = 93;
            // 
            // A
            // 
            this.A.Caption = "A";
            this.A.FieldName = "A";
            this.A.MinWidth = 25;
            this.A.Name = "A";
            this.A.Visible = true;
            this.A.VisibleIndex = 2;
            this.A.Width = 93;
            // 
            // B
            // 
            this.B.Caption = "B";
            this.B.FieldName = "B";
            this.B.MinWidth = 25;
            this.B.Name = "B";
            this.B.Visible = true;
            this.B.VisibleIndex = 3;
            this.B.Width = 93;
            // 
            // C
            // 
            this.C.Caption = "C";
            this.C.FieldName = "C";
            this.C.MinWidth = 25;
            this.C.Name = "C";
            this.C.Visible = true;
            this.C.VisibleIndex = 4;
            this.C.Width = 93;
            // 
            // D
            // 
            this.D.Caption = "D";
            this.D.FieldName = "D";
            this.D.MinWidth = 25;
            this.D.Name = "D";
            this.D.Visible = true;
            this.D.VisibleIndex = 5;
            this.D.Width = 93;
            // 
            // DapAnDung
            // 
            this.DapAnDung.Caption = "Đáp án đúng";
            this.DapAnDung.FieldName = "DapAnDung";
            this.DapAnDung.MinWidth = 25;
            this.DapAnDung.Name = "DapAnDung";
            this.DapAnDung.Visible = true;
            this.DapAnDung.VisibleIndex = 6;
            this.DapAnDung.Width = 93;
            // 
            // HinhAnh
            // 
            this.HinhAnh.Caption = "Hình Ảnh";
            this.HinhAnh.FieldName = "HinhAnh";
            this.HinhAnh.MinWidth = 25;
            this.HinhAnh.Name = "HinhAnh";
            this.HinhAnh.Visible = true;
            this.HinhAnh.VisibleIndex = 7;
            this.HinhAnh.Width = 93;
            // 
            // TenKhoi
            // 
            this.TenKhoi.Caption = "Khối";
            this.TenKhoi.FieldName = "TenKhoi";
            this.TenKhoi.MinWidth = 25;
            this.TenKhoi.Name = "TenKhoi";
            this.TenKhoi.Visible = true;
            this.TenKhoi.VisibleIndex = 8;
            this.TenKhoi.Width = 93;
            // 
            // TenMonHoc
            // 
            this.TenMonHoc.Caption = "Môn Học";
            this.TenMonHoc.FieldName = "TenMonHoc";
            this.TenMonHoc.MinWidth = 25;
            this.TenMonHoc.Name = "TenMonHoc";
            this.TenMonHoc.Visible = true;
            this.TenMonHoc.VisibleIndex = 9;
            this.TenMonHoc.Width = 93;
            // 
            // TenChuong
            // 
            this.TenChuong.Caption = "Chương";
            this.TenChuong.FieldName = "TenChuong";
            this.TenChuong.MinWidth = 25;
            this.TenChuong.Name = "TenChuong";
            this.TenChuong.Visible = true;
            this.TenChuong.VisibleIndex = 10;
            this.TenChuong.Width = 93;
            // 
            // TenBai
            // 
            this.TenBai.Caption = "Bài";
            this.TenBai.FieldName = "TenBai";
            this.TenBai.MinWidth = 25;
            this.TenBai.Name = "TenBai";
            this.TenBai.Visible = true;
            this.TenBai.VisibleIndex = 11;
            this.TenBai.Width = 93;
            // 
            // TenDoKho
            // 
            this.TenDoKho.Caption = "Độ Khó";
            this.TenDoKho.FieldName = "TenDoKho";
            this.TenDoKho.MinWidth = 25;
            this.TenDoKho.Name = "TenDoKho";
            this.TenDoKho.Visible = true;
            this.TenDoKho.VisibleIndex = 12;
            this.TenDoKho.Width = 93;
            // 
            // TenTinhTrang
            // 
            this.TenTinhTrang.Caption = "Trạng Thái";
            this.TenTinhTrang.FieldName = "TenTinhTrang";
            this.TenTinhTrang.MinWidth = 25;
            this.TenTinhTrang.Name = "TenTinhTrang";
            this.TenTinhTrang.Visible = true;
            this.TenTinhTrang.VisibleIndex = 13;
            this.TenTinhTrang.Width = 93;
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.Caption = "Ngày cập nhật";
            this.NgayCapNhat.FieldName = "NgayCapNhat";
            this.NgayCapNhat.MinWidth = 25;
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Visible = true;
            this.NgayCapNhat.VisibleIndex = 14;
            this.NgayCapNhat.Width = 94;
            // 
            // GhiChu
            // 
            this.GhiChu.Caption = "Ghi chú";
            this.GhiChu.FieldName = "GhiChu";
            this.GhiChu.MinWidth = 25;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 15;
            this.GhiChu.Width = 93;
            // 
            // lbSoCauHoi
            // 
            this.lbSoCauHoi.AutoSize = true;
            this.lbSoCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoCauHoi.Location = new System.Drawing.Point(161, 22);
            this.lbSoCauHoi.Name = "lbSoCauHoi";
            this.lbSoCauHoi.Size = new System.Drawing.Size(23, 25);
            this.lbSoCauHoi.TabIndex = 1;
            this.lbSoCauHoi.Text = "0";
            // 
            // fThongKeCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 722);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "fThongKeCauHoi";
            this.Text = "fThongKeCauHoi";
            this.Load += new System.EventHandler(this.fThongKeCauHoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCauHoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label lbSoCauHoi;
        private DevExpress.XtraBars.BarButtonItem barThem;
        private DevExpress.XtraBars.BarButtonItem barSua;
        private DevExpress.XtraBars.BarButtonItem barLuu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraGrid.GridControl gridCauHoi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn MaCauHoi;
        private DevExpress.XtraGrid.Columns.GridColumn NDCH;
        private DevExpress.XtraGrid.Columns.GridColumn A;
        private DevExpress.XtraGrid.Columns.GridColumn B;
        private DevExpress.XtraGrid.Columns.GridColumn C;
        private DevExpress.XtraGrid.Columns.GridColumn D;
        private DevExpress.XtraGrid.Columns.GridColumn DapAnDung;
        private DevExpress.XtraGrid.Columns.GridColumn HinhAnh;
        private DevExpress.XtraGrid.Columns.GridColumn TenKhoi;
        private DevExpress.XtraGrid.Columns.GridColumn TenMonHoc;
        private DevExpress.XtraGrid.Columns.GridColumn TenChuong;
        private DevExpress.XtraGrid.Columns.GridColumn TenBai;
        private DevExpress.XtraGrid.Columns.GridColumn TenDoKho;
        private DevExpress.XtraGrid.Columns.GridColumn TenTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn NgayCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
    }
}