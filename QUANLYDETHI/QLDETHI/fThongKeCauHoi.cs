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
using DevExpress.XtraPrinting.Preview;
using QLDETHI.Luutru;
using DevExpress.XtraReports.UI;
using QLDETHI.Reports;
using DethiLayer.DTO;
using DevExpress.XtraGrid.Views.Grid;

namespace QLDETHI
{
    public partial class fThongKeCauHoi : Form
    {
        private TaiKhoan user;
        int IdTK;
        public fThongKeCauHoi()
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
        }

        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        CAUHOI _cauhoi;

        private void fThongKeCauHoi_Load(object sender, EventArgs e)
        {
            _cauhoi = new CAUHOI();
            loadData();
            CountUniqueMaDe();
        }

        void loadData()
        {
            //gridCauHoi.DataSource = _cauhoi.getListFull();
            //gvDanhSach.OptionsBehavior.Editable = false;

            if (user.LoaiTaiKhoan == 1)
            {
                gridCauHoi.DataSource = _cauhoi.getListFull();
                gvDanhSach.OptionsBehavior.Editable = false;
            }
            else
            {
                gridCauHoi.DataSource = _cauhoi.getListFull(IdTK);
                gvDanhSach.OptionsBehavior.Editable = false;
            }
        }

        private void CountUniqueMaDe()
        {
            // Lấy danh sách các giá trị của trường MaDe từ GridView
            List<int> maDeValues = new List<int>();

            // Duyệt qua từng dòng trong GridView và thêm giá trị MaDe vào danh sách
            for (int i = 0; i < gvDanhSach.RowCount; i++)
            {
                if (gvDanhSach.GetRowCellValue(i, "MaCauHoi") != null)
                {
                    int maCauHoi = Convert.ToInt32(gvDanhSach.GetRowCellValue(i, "MaCauHoi"));
                    if (!maDeValues.Contains(maCauHoi))
                    {
                        maDeValues.Add(maCauHoi);
                    }
                }
            }

            // Số lượng mã đề không trùng nhau
            int uniqueMaDeCount = maDeValues.Count;

            // Hiển thị thông tin, ví dụ: có thể đặt vào một Label
            lbSoCauHoi.Text = $"{uniqueMaDeCount}";
        }

        private void gvDanhSach_ColumnFilterChanged(object sender, EventArgs e)
        {
            CountUniqueMaDe();
        }


        private void Print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // Lấy dữ liệu từ GridView sau khi lọc
            List<CAUHOI_DTO> lstDT = new List<CAUHOI_DTO>();
            for (int i = 0; i < gvDanhSach.RowCount; i++)
            {
                // Thay đổi cách kiểm tra trạng thái của dòng
                if (gvDanhSach.IsRowLoaded(i) && gvDanhSach.IsValidRowHandle(i))
                {
                    int maCauHoi = Convert.ToInt32(gvDanhSach.GetRowCellValue(i, "MaCauHoi"));

                    // Thay thế dòng sau với hàm lấy thông tin chi tiết của câu hỏi
                    CAUHOI_DTO cauHoi = _cauhoi.GetCauHoiDetails(maCauHoi);

                    lstDT.Add(cauHoi);
                }
            }

            // Khởi tạo và hiển thị báo cáo với danh sách câu hỏi đã lọc
            ThongKeCauHoi_rep report = new ThongKeCauHoi_rep();
            report.InitData(lstDT);
            DocumentViewer documentViewer = new DocumentViewer();
            documentViewer.DocumentSource = report;
            report.ShowPreviewDialog();
        }

        private void barXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel 2007 or higher (.xlsx)|*.xlsx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                gvDanhSach.ExportToXlsx(sf.FileName);
            }
        }
    }
}
