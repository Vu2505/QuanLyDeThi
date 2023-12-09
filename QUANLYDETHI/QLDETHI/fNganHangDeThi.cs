using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DethiLayer;
using DataLayer;
using QLDETHI.Reports;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DethiLayer.DTO;
using DevExpress.XtraGrid;
using QLDETHI.Luutru;
using DevExpress.XtraGrid.Views.Grid;

namespace QLDETHI
{
    public partial class fNganHangDeThi : Form
    {
        private TaiKhoan user;
        int IdTK;
        public fNganHangDeThi()
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
        }
        NOIDUNGDETHI _noidungdethi;
        List<DETHI_DTO> _lstDTDTO;
        List<DETHI_DTO> _lstDTDTOTK;
        DETHI _dethi;
        int _id;
        // Lưu mã đề đã chọn
        private int? selectedMaDe;
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        //public void UpdateGridDeThiWithMaDe(int maDeThi)
        //{
        //    // Cập nhật GridView và GridControl với MaDeThi
        //    int rowHandle = gvDanhSach.LocateByValue("MaDe", maDeThi, null);

        //    if (rowHandle != GridControl.InvalidRowHandle)
        //    {
        //        gvDanhSach.FocusedRowHandle = rowHandle;
        //    }
        //}

        //public void UpdateGridDeThiWithMaDe1(List<int> danhSachMaDeThi)
        //{
        //    //// Cập nhật GridView và GridControl với danh sách MaDeThi
        //    //foreach (int maDeThi in danhSachMaDeThi)
        //    //{
        //    //    // Kiểm tra xem đề thi có mã nằm trong danh sách không
        //    //    if (db.DeThis.Any(d => d.MaDe == maDeThi))
        //    //    {
        //    //        int rowHandle = gvDanhSach.LocateByValue("MaDe", maDeThi, null);

        //    //        if (rowHandle != GridControl.InvalidRowHandle)
        //    //        {
        //    //            gvDanhSach.FocusedRowHandle = rowHandle;
        //    //        }
        //    //    }
        //    //}

        //    // Cập nhật GridView và GridControl với danh sách MaDeThi
        //    if (DanhSachMaDeThiMoiTao != null)
        //    {
        //        // Lọc dữ liệu để chỉ cập nhật cho các đề mới tạo
        //        var dsDeThiMoiTao = _lstDTDTO.Where(dt => _danhSachMaDeThiMoiTao.Contains((int)dt.MaDe)).ToList();

        //        gridDeThi.DataSource = dsDeThiMoiTao;
        //        gvDanhSach.OptionsBehavior.Editable = false;
        //    }
        //}

        //private List<int> _danhSachMaDeThiMoiTao;

        //// Property để nhận danh sách đề mới tạo
        //public List<int> DanhSachMaDeThiMoiTao
        //{
        //    get { return _danhSachMaDeThiMoiTao; }
        //    set { _danhSachMaDeThiMoiTao = value; }
        //}

        //// ... (các phần khác của form)

        //private void UpdateGridDeThi1()
        //{
        //    if (_danhSachMaDeThiMoiTao != null)
        //    {
        //        // Lọc dữ liệu để chỉ hiển thị các đề mới tạo
        //        var dsDeThiMoiTao = _lstDTDTO.Where(dt => _danhSachMaDeThiMoiTao.Contains((int)dt.MaDe)).ToList();

        //        gridDeThi.DataSource = dsDeThiMoiTao;
        //        gvDanhSach.OptionsBehavior.Editable = false;
        //    }
        //}


        private void fNganHangDeThi_Load(object sender, EventArgs e)
        {
            _noidungdethi = new NOIDUNGDETHI();
            _dethi = new DETHI();
            loadData(selectedMaDe);
        }

        void loadData(int? selectedMaDe = null)
        {
            if (user.LoaiTaiKhoan == 1)
            {
                _lstDTDTO = _noidungdethi.getListFull(selectedMaDe);

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
                _lstDTDTOTK = _noidungdethi.getListFullTK(IdTK, selectedMaDe);

                if (_lstDTDTOTK != null && _lstDTDTOTK.Any())
                {

                    gridDeThi.DataSource = _lstDTDTOTK;
                    gvDanhSach.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show("Danh sách rỗng hoặc không có dữ liệu phù hợp.");
                }
            }
        }

        private void barPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (selectedMaDe.HasValue) // Kiểm tra xem đã chọn mã đề hay chưa
            {
                // Khởi tạo và hiển thị báo cáo với mã đề đã chọn
                fDeThiChiTiet report = new fDeThiChiTiet();
                DocumentViewer documentViewer = new DocumentViewer();
                var lstDT = _noidungdethi.getListFull(selectedMaDe); // Sử dụng mã đề đã chọn
                report.InitData(lstDT);

                documentViewer.DocumentSource = report;
                report.ShowPreviewDialog();


                fDapAnDeThi report1 = new fDapAnDeThi();
                //DocumentViewer documentViewer1 = new DocumentViewer();
                //var lstDT1 = _noidungdethi.getListFull(selectedMaDe); // Sử dụng mã đề đã chọn
                report1.InitData(lstDT);

                documentViewer.DocumentSource = report1;
                report1.ShowPreviewDialog();
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            int selectedRowHandle = gvDanhSach.FocusedRowHandle;
            if (selectedRowHandle >= 0)
            {
                object maDe = gvDanhSach.GetRowCellValue(selectedRowHandle, "MaDe");
                if (maDe != null)
                {
                    selectedMaDe = Convert.ToInt32(maDe); // Chuyển đổi sang kiểu int
                }
            }

        }

        private void barDaoDe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Lấy mã đề đã chọn
            if (selectedMaDe.HasValue)
            {
                // Hiển thị form fDaoDeThi và truyền mã đề đã chọn
                using (var fDaoDeThiForm = new fDaoDeThi(selectedMaDe.Value))
                {
                    fDaoDeThiForm.ShowDialog();
                    
                }
            }
            loadData();
        }

        public GridControl GetGridDeThi()
        {
            return gridDeThi; // Trả về GridControl cho các form khác
        }

        public void UpdateGridDeThi()
        {
            loadData(selectedMaDe);
        }
    }
}
