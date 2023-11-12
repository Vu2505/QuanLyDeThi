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
                _k.DoKho = k.MaKhoi;
                _k.TrangThai = k.TrangThai;
                _k.GhiChu = k.GhiChu;
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

        public int SoLuongCauHoiTheoBai(int maBai, int doKho)
        {
            return db.CauHois.ToList()
                .Count(x => x.MaBai == maBai && x.DoKho == doKho);
        }

        public int SoLuongCauHoiTheoChuong(int maChuong, int doKho)
        {
            return db.CauHois.ToList()
                .Count(x => x.MaChuong == maChuong && x.DoKho == doKho);
        }

        public List<CAUHOI_DTO> getListRanDomChuong(int maChuong, int doKho, int soLuong)
        {
            var lstCH = db.CauHois
                .Where(x => x.MaChuong == maChuong && x.DoKho == doKho)
                .OrderBy(x => Guid.NewGuid()).Take(soLuong)
                .ToList();
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
                ctDTO.GhiChu = item.GhiChu;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }

        public List<CAUHOI_DTO> getListRanDomBai(int maBai, int doKho, int soLuong)
        {
            var lstCH = db.CauHois
                .Where(x => x.MaBai == maBai && x.DoKho == doKho)
                .OrderBy(x => Guid.NewGuid()).Take(soLuong)
                .ToList();
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
                ctDTO.GhiChu = item.GhiChu;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }


        public List<CAUHOI_DTO> getListFull()
        {
            var lstCH = db.CauHois.ToList();
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
                ctDTO.GhiChu = item.GhiChu;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }
    }
}
