using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataLayer;
using DethiLayer;
using System.IO;

namespace QLDETHI.Taodethi
{
    public partial class fAddCau : DevExpress.XtraEditors.XtraForm
    {
        public fAddCau()
        {
            InitializeComponent();
        }

        int _id;

        CAUHOI _cauhoi;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fAddCau_Load(object sender, EventArgs e)
        {
            _cauhoi = new CAUHOI();
            loadData();


        }
        void loadData()
        {
            gridCauHoi.DataSource = _cauhoi.getList();
            gvDanhSach.OptionsBehavior.Editable = false;

        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            fDetailsCauHoi f2 = new fDetailsCauHoi();
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MaCauHoi").ToString());
                var k = _cauhoi.getItem(_id);
                f2.txbNDCH.Text = k.NDCH;
                f2.txbA.Text = k.A;
                f2.txbB.Text = k.B;
                f2.txbC.Text = k.C;
                f2.txbD.Text = k.D;
                f2.txbDapAnDung.Text = k.DapAnDung;
                f2.picHinhAnh.Image = Base64ToImage(k.HinhAnh);
                f2.txbKhoi.Text = k.MaKhoi.ToString();
                f2.txbMonHoc.Text = k.MaMonHoc.ToString();
                f2.txbChuong.Text = k.MaChuong.ToString();
                f2.txbBai.Text = k.MaBai.ToString();
                f2.txbDoKho.Text = k.DoKho.ToString();
                f2.txbTrangThai.Text = k.TrangThai.ToString();
                f2.txbGhiChu.Text = k.GhiChu;
                _cauhoi.Update(k);
            }
            f2.ShowDialog();
        }

        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat fomat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, fomat);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public Image Base64ToImage(byte[] imageBytes)
        {
            string defaultImagePath = "..\\..\\image\\image-preview-icon-picture-placeholder-vector-31284806.jpg";
            Image image = Image.FromFile(defaultImagePath); ;
            if (imageBytes != null)
            {
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                image = Image.FromStream(ms, true);
            }
            return image;
        }
    }
}