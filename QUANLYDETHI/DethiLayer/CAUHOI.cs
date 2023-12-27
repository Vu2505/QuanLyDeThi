using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer.DTO;

namespace DethiLayer
{
    public class CAUHOI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        public CauHoi getItem(int id)
        {
            return db.CauHois.FirstOrDefault(x => x.MaCauHoi == id);
        }
        public List<CauHoi> getList()
        {
            return db.CauHois.ToList();
        }

        //them 
        public CauHoi Add(CauHoi k)
        {
            try
            {
                db.CauHois.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        //sửa
        public CauHoi Update(CauHoi k)
        {
            try
            {
                var _k = db.CauHois.FirstOrDefault(x => x.MaCauHoi == k.MaCauHoi);
                _k.NDCH = k.NDCH;
                _k.A = k.A;
                _k.B = k.B;
                _k.C = k.C;
                _k.D = k.D;
                _k.DapAnDung = k.DapAnDung;
                _k.HinhAnh = k.HinhAnh;
                _k.MaKhoi = k.MaKhoi;
                _k.MaMonHoc = k.MaMonHoc;
                _k.MaChuong = k.MaChuong;
                _k.MaBai = k.MaBai;
                _k.DoKho = k.DoKho;
                _k.TrangThai = k.TrangThai;
                _k.GhiChu = k.GhiChu;
                _k.NgayCapNhat = k.NgayCapNhat;
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }


        public void Detele(int id)
        {
            try
            {
                var _lp = db.CauHois.FirstOrDefault(x => x.MaCauHoi == id);
                db.CauHois.Remove(_lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        //public CauHoi getList (int id)
        //{
        //    return db.CauHois.FirstOrDefault(x => x.MaCauHoi == id )
        //}

        public int SoLuongCauHoiTheoBai(int maBai, int doKho, int? IdTK = null)
        {
            if (IdTK.HasValue)
            {
                return db.CauHois.Where(x => x.MaGiangVien == IdTK && x.TrangThai ==1).ToList()
                                .Count(x => x.MaBai == maBai && x.DoKho == doKho);
            }
            return db.CauHois.ToList()
                .Count(x => x.MaBai == maBai && x.DoKho == doKho && x.TrangThai == 1);
        }

        public int SoLuongCauHoiTheoChuong(int maChuong, int doKho, int? IdTK = null)
        {
            if (IdTK.HasValue)
            {
                return db.CauHois.Where(x => x.MaGiangVien == IdTK && x.TrangThai == 1).ToList()
                                .Count(x => x.MaChuong == maChuong && x.DoKho == doKho);
            }
            return db.CauHois.ToList()
                .Count(x => x.MaChuong == maChuong && x.DoKho == doKho && x.TrangThai == 1);
        }

        public List<CAUHOI_DTO> getListRanDomChuong(int maChuong, int doKho, int soLuong, int? IdTK = null)
        {            
            var lstCH = db.CauHois
                .Where(x => x.MaChuong == maChuong && x.DoKho == doKho && x.TrangThai == 1)
                .OrderBy(x => Guid.NewGuid()).Take(soLuong)
                .ToList();

            if (IdTK.HasValue)
            {
                lstCH = db.CauHois
                .Where(x => x.MaChuong == maChuong && x.DoKho == doKho && x.MaGiangVien == IdTK & x.TrangThai == 1)
                .OrderBy(x => Guid.NewGuid()).Take(soLuong)
                .ToList();
            }
            List<CAUHOI_DTO> lstCHDTO = new List<CAUHOI_DTO>();
            CAUHOI_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new CAUHOI_DTO();
                ctDTO.MaCauHoi = item.MaCauHoi;
                ctDTO.NDCH = item.NDCH;
                ctDTO.A = item.A;
                ctDTO.B = item.B;
                ctDTO.C = item.C;
                ctDTO.D = item.D;
                ctDTO.DapAnDung = item.DapAnDung;
                ctDTO.HinhAnh = item.HinhAnh;
                ctDTO.MaKhoi = item.MaKhoi;
                var k = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
                ctDTO.TenKhoi = k.TenKhoi;
                ctDTO.MaMonHoc = item.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                ctDTO.TenMonHoc = mh.TenMonHoc;

                ctDTO.MaChuong = item.MaChuong;
                var c = db.Chuongs.FirstOrDefault(b => b.MaChuong == item.MaChuong);
                ctDTO.TenChuong = c.TenChuong;


                ctDTO.MaBai = item.MaBai;
                var cb = db.Bais.FirstOrDefault(b => b.MaBai == item.MaBai);
                ctDTO.TenBai = cb.TenBai;

                ctDTO.MaDoKho = item.DoKho;
                var dk = db.DoKhoes.FirstOrDefault(b => b.MaDoKho == item.DoKho);
                ctDTO.TenDoKho = dk.TenDoKho;

                ctDTO.TrangThai = item.TrangThai;

                var tt = db.TinhTrangs.FirstOrDefault(b => b.MaTinhTrang == item.TrangThai);
                ctDTO.TenTinhTrang = tt.TenTinhTrang;

                ctDTO.GhiChu = item.GhiChu;
                ctDTO.NgayCapNhat = item.NgayCapNhat;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }

        public List<CAUHOI_DTO> getListRanDomBai(int maBai, int doKho, int soLuong, int? IdTK = null)
        {
            var lstCH = db.CauHois
                .Where(x => x.MaBai == maBai && x.DoKho == doKho && x.TrangThai ==1)
                .OrderBy(x => Guid.NewGuid()).Take(soLuong)
                .ToList();

            if (IdTK.HasValue)
            {
                lstCH = db.CauHois
                .Where(x => x.MaBai == maBai && x.DoKho == doKho && x.MaGiangVien == IdTK && x.TrangThai ==1)
                .OrderBy(x => Guid.NewGuid()).Take(soLuong)
                .ToList();
            }
            List<CAUHOI_DTO> lstCHDTO = new List<CAUHOI_DTO>();
            CAUHOI_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new CAUHOI_DTO();
                ctDTO.MaCauHoi = item.MaCauHoi;
                ctDTO.NDCH = item.NDCH;
                ctDTO.A = item.A;
                ctDTO.B = item.B;
                ctDTO.C = item.C;
                ctDTO.D = item.D;
                ctDTO.DapAnDung = item.DapAnDung;
                ctDTO.HinhAnh = item.HinhAnh;
                ctDTO.MaKhoi = item.MaKhoi;
                var k = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
                ctDTO.TenKhoi = k.TenKhoi;
                ctDTO.MaMonHoc = item.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                ctDTO.TenMonHoc = mh.TenMonHoc;

                ctDTO.MaChuong = item.MaChuong;
                var c = db.Chuongs.FirstOrDefault(b => b.MaChuong == item.MaChuong);
                ctDTO.TenChuong = c.TenChuong;


                ctDTO.MaBai = item.MaBai;
                var cb = db.Bais.FirstOrDefault(b => b.MaBai == item.MaBai);
                ctDTO.TenBai = cb.TenBai;

                ctDTO.MaDoKho = item.DoKho;
                var dk = db.DoKhoes.FirstOrDefault(b => b.MaDoKho == item.DoKho);
                ctDTO.TenDoKho = dk.TenDoKho;

                ctDTO.TrangThai = item.TrangThai;
                var tt = db.TinhTrangs.FirstOrDefault(b => b.MaTinhTrang == item.TrangThai);
                ctDTO.TenTinhTrang = tt.TenTinhTrang;
                ctDTO.GhiChu = item.GhiChu;
                ctDTO.NgayCapNhat = item.NgayCapNhat;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }


        public List<CAUHOI_DTO> getListFull(int? IdTK = null)
        {

            var lstCH = db.CauHois.ToList();

            if (IdTK.HasValue)
            {
                lstCH = db.CauHois.Where(x => x.MaGiangVien == IdTK).ToList();
            }
            
            List<CAUHOI_DTO> lstCHDTO = new List<CAUHOI_DTO>();
            CAUHOI_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new CAUHOI_DTO();
                ctDTO.MaCauHoi = item.MaCauHoi;
                ctDTO.NDCH = item.NDCH;
                ctDTO.A = item.A;
                ctDTO.B = item.B;
                ctDTO.C = item.C;
                ctDTO.D = item.D;
                ctDTO.DapAnDung = item.DapAnDung;
                ctDTO.HinhAnh = item.HinhAnh;
                ctDTO.MaKhoi = item.MaKhoi;
                var k = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
                ctDTO.TenKhoi = k.TenKhoi;
                ctDTO.MaMonHoc = item.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                ctDTO.TenMonHoc = mh.TenMonHoc;

                ctDTO.MaChuong = item.MaChuong;
                var c = db.Chuongs.FirstOrDefault(b => b.MaChuong == item.MaChuong);
                ctDTO.TenChuong = c.TenChuong;

                
                ctDTO.MaBai = item.MaBai;
                var cb = db.Bais.FirstOrDefault(b => b.MaBai == item.MaBai);
                ctDTO.TenBai = cb.TenBai;

                ctDTO.MaDoKho = item.DoKho;
                var dk = db.DoKhoes.FirstOrDefault(b => b.MaDoKho == item.DoKho);
                ctDTO.TenDoKho = dk.TenDoKho;

                ctDTO.TrangThai = item.TrangThai;
                var tt = db.TinhTrangs.FirstOrDefault(b => b.MaTinhTrang == item.TrangThai);
                ctDTO.TenTinhTrang = tt.TenTinhTrang;

                ctDTO.NgayCapNhat = item.NgayCapNhat;

                ctDTO.GhiChu = item.GhiChu;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }

        public string getListInfoCauHoi(FieldCauHoi field, int ma)
        {
            string tenLayTheoMa = "";
            switch (field)
            {
                case FieldCauHoi.MaKhoi:
                    tenLayTheoMa = db.Khois.FirstOrDefault(x => x.MaKhoi == ma).TenKhoi;
                    break;

                case FieldCauHoi.MaMonHoc:
                    tenLayTheoMa = db.MonHocs.FirstOrDefault(x => x.MaMonHoc == ma).TenMonHoc;
                    break;
                case FieldCauHoi.MaChuong:
                    tenLayTheoMa = db.Chuongs.FirstOrDefault(x => x.MaChuong == ma).TenChuong;
                    break;
                case FieldCauHoi.MaBai:
                    tenLayTheoMa = db.Bais.FirstOrDefault(x => x.MaBai == ma).TenBai;
                    break;
                case FieldCauHoi.DoKho:
                    tenLayTheoMa = db.DoKhoes.FirstOrDefault(x => x.MaDoKho == ma).TenDoKho;
                    break;
                case FieldCauHoi.TrangThai:
                    tenLayTheoMa = db.TinhTrangs.FirstOrDefault(x => x.MaTinhTrang == ma).TenTinhTrang;
                    break;
            }
            return tenLayTheoMa;
        }


        public List<CAUHOI_DTO> getListFullGV(int? IdTK = null)
        {

            var lstCH = db.CauHois.Where(x => x.TrangThai == 1).ToList();

            if (IdTK.HasValue)
            {
                lstCH = db.CauHois.Where(x => x.MaGiangVien == IdTK && x.TrangThai == 1).ToList();
            }

            List<CAUHOI_DTO> lstCHDTO = new List<CAUHOI_DTO>();
            CAUHOI_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new CAUHOI_DTO();
                ctDTO.MaCauHoi = item.MaCauHoi;
                ctDTO.NDCH = item.NDCH;
                ctDTO.A = item.A;
                ctDTO.B = item.B;
                ctDTO.C = item.C;
                ctDTO.D = item.D;
                ctDTO.DapAnDung = item.DapAnDung;
                ctDTO.HinhAnh = item.HinhAnh;
                ctDTO.MaKhoi = item.MaKhoi;
                var k = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
                ctDTO.TenKhoi = k.TenKhoi;
                ctDTO.MaMonHoc = item.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                ctDTO.TenMonHoc = mh.TenMonHoc;

                ctDTO.MaChuong = item.MaChuong;
                var c = db.Chuongs.FirstOrDefault(b => b.MaChuong == item.MaChuong);
                ctDTO.TenChuong = c.TenChuong;


                ctDTO.MaBai = item.MaBai;
                var cb = db.Bais.FirstOrDefault(b => b.MaBai == item.MaBai);
                ctDTO.TenBai = cb.TenBai;

                ctDTO.MaDoKho = item.DoKho;
                var dk = db.DoKhoes.FirstOrDefault(b => b.MaDoKho == item.DoKho);
                ctDTO.TenDoKho = dk.TenDoKho;

                ctDTO.TrangThai = item.TrangThai;
                var tt = db.TinhTrangs.FirstOrDefault(b => b.MaTinhTrang == item.TrangThai);
                ctDTO.TenTinhTrang = tt.TenTinhTrang;
                ctDTO.GhiChu = item.GhiChu;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }



        public List<CAUHOI_DTO> getListCauHoiThuCong(int maBai ,int? IdTK = null)
        {

            var lstCH = db.CauHois.Where(x => x.TrangThai == 1 && x.MaBai == maBai).ToList();

            if (IdTK.HasValue)
            {
                lstCH = db.CauHois.Where(x => x.MaGiangVien == IdTK && x.TrangThai == 1 && x.MaBai == maBai).ToList();
            }

            List<CAUHOI_DTO> lstCHDTO = new List<CAUHOI_DTO>();
            CAUHOI_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new CAUHOI_DTO();
                ctDTO.MaCauHoi = item.MaCauHoi;
                ctDTO.NDCH = item.NDCH;
                ctDTO.A = item.A;
                ctDTO.B = item.B;
                ctDTO.C = item.C;
                ctDTO.D = item.D;
                ctDTO.DapAnDung = item.DapAnDung;
                ctDTO.HinhAnh = item.HinhAnh;
                ctDTO.MaKhoi = item.MaKhoi;
                var k = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
                ctDTO.TenKhoi = k.TenKhoi;
                ctDTO.MaMonHoc = item.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                ctDTO.TenMonHoc = mh.TenMonHoc;

                ctDTO.MaChuong = item.MaChuong;
                var c = db.Chuongs.FirstOrDefault(b => b.MaChuong == item.MaChuong);
                ctDTO.TenChuong = c.TenChuong;

                ctDTO.MaBai = item.MaBai;
                var cb = db.Bais.FirstOrDefault(b => b.MaBai == item.MaBai);
                ctDTO.TenBai = cb.TenBai;

                ctDTO.MaDoKho = item.DoKho;
                var dk = db.DoKhoes.FirstOrDefault(b => b.MaDoKho == item.DoKho);
                ctDTO.TenDoKho = dk.TenDoKho;

                ctDTO.TrangThai = item.TrangThai;
                var tt = db.TinhTrangs.FirstOrDefault(b => b.MaTinhTrang == item.TrangThai);
                ctDTO.TenTinhTrang = tt.TenTinhTrang;
                ctDTO.GhiChu = item.GhiChu;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }

            // Các thuộc tính và phương thức khác của lớp CAUHOI

        public CAUHOI_DTO GetCauHoiDetails(int maCauHoi)
        {
            using (DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities())
            {
                // Assume CAUHOI_DTO is a class containing details of a question
                // Assume CauHoi is the entity corresponding to the database table
                var cauHoiDetails = new CAUHOI_DTO();
                    
                CauHoi cauHoi = db.CauHois
                    .Where(c => c.MaCauHoi == maCauHoi).FirstOrDefault();

                cauHoiDetails.NDCH = cauHoi.NDCH;
                cauHoiDetails.A = cauHoi.A;
                cauHoiDetails.B = cauHoi.B;
                cauHoiDetails.C = cauHoi.C;
                cauHoiDetails.D = cauHoi.D;
                cauHoiDetails.DapAnDung = cauHoi.DapAnDung;
                cauHoiDetails.TenKhoi = db.Khois.FirstOrDefault(b => b.MaKhoi == cauHoi.MaKhoi).TenKhoi;
                cauHoiDetails.TenDoKho = db.DoKhoes.FirstOrDefault(b => b.MaDoKho == cauHoi.DoKho).TenDoKho;

                return cauHoiDetails;
            }
        }
    }
    public enum FieldCauHoi
    {
        MaKhoi,
        MaMonHoc,
        MaChuong,
        MaBai,
        DoKho,
        TrangThai
    }
}
