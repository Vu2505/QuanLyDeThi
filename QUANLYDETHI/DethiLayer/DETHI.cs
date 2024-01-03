using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer.DTO;

namespace DethiLayer
{
    public class DETHI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        public DeThi getItem(int id)
        {
            return db.DeThis.FirstOrDefault(x => x.MaDe == id);
        }
        public List<DeThi> getList()
        {
            return db.DeThis.ToList();
        }

        public List<DETHI_DTO> getListFull(int? selectedMaDe = null)
        {

            var query = db.DeThis.AsQueryable();

            if (selectedMaDe.HasValue)
            {
                query = query.Where(item => item.MaDe == selectedMaDe);
            }
            //List<DeThi> lstDT = db.DeThis.Where(x => x.MaDe == id).ToList();
            //var lstDT = db.DeThis.ToList();
            var lstDT = query.ToList();
            List<DETHI_DTO> lstDTDTO = new List<DETHI_DTO>();
            DETHI_DTO dtDTO;
            foreach (var item in lstDT)
            {
                dtDTO = new DETHI_DTO();
                dtDTO.MaDe = item.MaDe;
                dtDTO.MaKhoi = item.MaKhoi;
                var k = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
                dtDTO.TenKhoi = k.TenKhoi;
                dtDTO.MaHienThi = item.MaHienThi;
                dtDTO.TenDeThi = item.TenDeThi;
                dtDTO.NamHoc = item.NamHoc;
                dtDTO.SoCauHoi = item.SoCauHoi;
                dtDTO.MaMonHoc = item.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                dtDTO.TenMonHoc = mh.TenMonHoc;
                dtDTO.MaLop = item.MaLop;
                var l = db.Lops.FirstOrDefault(b => b.MaLop == item.MaLop);
                dtDTO.TenLop = l.TenLop;
                dtDTO.MaGiangVien = item.MaGiangVien;
                dtDTO.MaHocKy = item.MaHocKy;
                var hk = db.HocKies.FirstOrDefault(b => b.MaHocKy == item.MaHocKy);
                dtDTO.TenHocKy = hk.TenHocKy;
                var nh = db.NamHocs.FirstOrDefault(b => b.MaNamHoc == item.NamHoc);
                dtDTO.TenNamHoc = nh.TenNamHoc;
                dtDTO.MaThoiGianThi = item.MaThoiGianThi;
                var tg = db.ThoiGianThis.FirstOrDefault(b => b.MaThoiGianThi == item.MaThoiGianThi);
                dtDTO.TenThoiGianThi = tg.TenThoiGianThi;
                dtDTO.NgayCapNhat = item.NgayCapNhat;
                lstDTDTO.Add(dtDTO);
            }

            return lstDTDTO;
        }


        public DeThi Update(DeThi k)
        {
            try
            {
                var _k = db.DeThis.FirstOrDefault(x => x.MaDe == k.MaDe);
                _k.MaHienThi = k.MaHienThi;
                _k.TenDeThi = k.TenDeThi;
                _k.NamHoc = k.NamHoc;
                _k.MaHocKy = k.MaHocKy;
                _k.MaThoiGianThi = k.MaThoiGianThi;
                //_k.MaKhoi = k.MaKhoi;
                //_k.MaHocKy = k.MaHocKy;
                //_k.MaThoiGianThi = k.MaThoiGianThi;

                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public List<DETHI_DTO> getListFullTK(int IdTK, int? selectedMaDe = null)
        {

            var query = db.DeThis.AsQueryable();

            if (selectedMaDe.HasValue)
            {
                query = query.Where(item => item.MaDe == selectedMaDe);
            }
            //List<DeThi> lstDT = db.DeThis.Where(x => x.MaDe == id).ToList();
            //var lstDT = db.DeThis.ToList();
            query = query.Where(item => db.DeThis.Any(dt => dt.MaDe == item.MaDe && dt.MaGiangVien == IdTK));

            var lstDT = query.ToList();
            List<DETHI_DTO> lstDTDTO = new List<DETHI_DTO>();
            DETHI_DTO dtDTO;
            foreach (var item in lstDT)
            {
                dtDTO = new DETHI_DTO();
                dtDTO.MaDe = item.MaDe;
                dtDTO.MaKhoi = item.MaKhoi;
                var k = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
                dtDTO.TenKhoi = k.TenKhoi;
                dtDTO.MaHienThi = item.MaHienThi;
                dtDTO.TenDeThi = item.TenDeThi;
                dtDTO.NamHoc = item.NamHoc;
                dtDTO.SoCauHoi = item.SoCauHoi;
                dtDTO.MaMonHoc = item.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                dtDTO.TenMonHoc = mh.TenMonHoc;
                dtDTO.MaLop = item.MaLop;
                var l = db.Lops.FirstOrDefault(b => b.MaLop == item.MaLop);
                dtDTO.TenLop = l.TenLop;
                dtDTO.MaGiangVien = item.MaGiangVien;
                dtDTO.MaHocKy = item.MaHocKy;
                var hk = db.HocKies.FirstOrDefault(b => b.MaHocKy == item.MaHocKy);
                dtDTO.TenHocKy = hk.TenHocKy;
                var nh = db.NamHocs.FirstOrDefault(b => b.MaNamHoc == item.NamHoc);
                dtDTO.TenNamHoc = nh.TenNamHoc;
                dtDTO.MaThoiGianThi = item.MaThoiGianThi;
                var tg = db.ThoiGianThis.FirstOrDefault(b => b.MaThoiGianThi == item.MaThoiGianThi);
                dtDTO.TenThoiGianThi = tg.TenThoiGianThi;
                dtDTO.NgayCapNhat = item.NgayCapNhat;
                lstDTDTO.Add(dtDTO);
            }

            return lstDTDTO;
        }

        public DETHI_DTO GetDeThiDetails(int maDe)
        {
            using (DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities())
            {
                // Assume CAUHOI_DTO is a class containing details of a question
                // Assume CauHoi is the entity corresponding to the database table
                var deThiDetails = new DETHI_DTO();

                DeThi deThi = db.DeThis.Where(c => c.MaDe == maDe).FirstOrDefault();


                deThiDetails.MaDe = deThi.MaDe;
                deThiDetails.MaKhoi = deThi.MaKhoi;
                var k = db.Khois.FirstOrDefault(b => b.MaKhoi == deThi.MaKhoi);
                deThiDetails.TenKhoi = k.TenKhoi;
                deThiDetails.MaHienThi = deThi.MaHienThi;
                deThiDetails.TenDeThi = deThi.TenDeThi;
                deThiDetails.NamHoc = deThi.NamHoc;
                deThiDetails.SoCauHoi = deThi.SoCauHoi;
                deThiDetails.MaMonHoc = deThi.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == deThi.MaMonHoc);
                deThiDetails.TenMonHoc = mh.TenMonHoc;

                var nh = db.NamHocs.FirstOrDefault(b => b.MaNamHoc == deThi.NamHoc);
                deThiDetails.TenNamHoc = nh.TenNamHoc;

                var hk = db.HocKies.FirstOrDefault(b => b.MaHocKy == deThi.MaHocKy);
                deThiDetails.TenHocKy = hk.TenHocKy;


                deThiDetails.MaLop = deThi.MaLop;
                var l = db.Lops.FirstOrDefault(b => b.MaLop == deThi.MaLop);
                deThiDetails.TenLop = l.TenLop;

                //cauHoiDetails.NDCH = cauHoi.NDCH;
                //cauHoiDetails.A = cauHoi.A;
                //cauHoiDetails.B = cauHoi.B;
                //cauHoiDetails.C = cauHoi.C;
                //cauHoiDetails.D = cauHoi.D;
                //cauHoiDetails.DapAnDung = cauHoi.DapAnDung;
                //cauHoiDetails.TenKhoi = db.Khois.FirstOrDefault(b => b.MaKhoi == cauHoi.MaKhoi).TenKhoi;
                //cauHoiDetails.TenDoKho = db.DoKhoes.FirstOrDefault(b => b.MaDoKho == cauHoi.DoKho).TenDoKho;

                return deThiDetails;
            }
        }
    }
}