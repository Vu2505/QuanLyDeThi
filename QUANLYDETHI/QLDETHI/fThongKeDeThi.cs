using DataLayer;
using DethiLayer;
using DethiLayer.DTO;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using QLDETHI.Luutru;
using QLDETHI.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDETHI
{
    public partial class fThongKeDeThi : Form
    {
        public fThongKeDeThi()
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
        }

        private void fThongKeDeThi_Load(object sender, EventArgs e)
        {
            loadData(selectedMaDe);
            _dethi = new DETHI();
            CountUniqueMaDe();

        }

        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        List<DETHI_DTO> _lstDTDTO;
        private TaiKhoan user;
        DETHI _dethi= new DETHI();
        int IdTK;
        private int? selectedMaDe;

        void loadData(int? selectedMaDe)
        {
            if (user.LoaiTaiKhoan == 1)
            {
                _lstDTDTO = _dethi.getListFull(selectedMaDe);

                if (_lstDTDTO != null && _lstDTDTO.Any())
                {
                    gridDeThi.DataSource = _lstDTDTO;
                    gvDanhSach.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show("Danh sách rỗng hoặc không có dữ liệu phù hợp.");
                }
            }
            else
            {
                _lstDTDTO = _dethi.getListFullTK(IdTK, selectedMaDe);

                if (_lstDTDTO != null && _lstDTDTO.Any())
                {
                    gridDeThi.DataSource = _lstDTDTO;
                    gvDanhSach.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show("Danh sách rỗng hoặc không có dữ liệu phù hợp.");
                }
            }
        }

        private void CountUniqueMaDe()
        {
            // Lấy danh sách các giá trị của trường MaDe từ GridView
            List<int> maDeValues = new List<int>();

            // Duyệt qua từng dòng trong GridView và thêm giá trị MaDe vào danh sách
            for (int i = 0; i < gvDanhSach.RowCount; i++)
            {
                if (gvDanhSach.GetRowCellValue(i, "MaDe") != null)
                {
                    int maDe = Convert.ToInt32(gvDanhSach.GetRowCellValue(i, "MaDe"));
                    if (!maDeValues.Contains(maDe))
                    {
                        maDeValues.Add(maDe);
                    }
                }
            }
            // Số lượng mã đề không trùng nhau
            int uniqueMaDeCount = maDeValues.Count;

            // Hiển thị thông tin, ví dụ: có thể đặt vào một Label
            lbSoDeThi.Text = $"{uniqueMaDeCount}";
        }

        private void gvDanhSach_ColumnFilterChanged(object sender, EventArgs e)
        {
            CountUniqueMaDe();
        }

        private void Print_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Lấy dữ liệu từ GridView sau khi lọc
            List<DETHI_DTO> lstDT = new List<DETHI_DTO>();
            for (int i = 0; i < gvDanhSach.RowCount; i++)
            {
                // Thay đổi cách kiểm tra trạng thái của dòng
                if (gvDanhSach.IsRowLoaded(i) && gvDanhSach.IsValidRowHandle(i))
                {
                    int maCauHoi = Convert.ToInt32(gvDanhSach.GetRowCellValue(i, "MaDe"));

                    // Thay thế dòng sau với hàm lấy thông tin chi tiết của câu hỏi
                    DETHI_DTO deThi = _dethi.GetDeThiDetails(maCauHoi);

                    lstDT.Add(deThi);
                }
            }

            // Khởi tạo và hiển thị báo cáo với danh sách câu hỏi đã lọc
            ThongKeDeThi_rep report = new ThongKeDeThi_rep();
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
