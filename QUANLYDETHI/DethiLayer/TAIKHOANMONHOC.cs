using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer.DTO;

namespace DethiLayer
{
    public class TAIKHOANMONHOC
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public TaiKhoanMonHoc getItem(int id)
        {
            return db.TaiKhoanMonHocs.FirstOrDefault(x => x.Id == id);
        }

        public List<TaiKhoanMonHoc> getList()
        {
            return db.TaiKhoanMonHocs.ToList();
        }

        public TaiKhoanMonHoc Add(TaiKhoanMonHoc k)
        {
            try
            {
                db.TaiKhoanMonHocs.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public TaiKhoanMonHoc Update(TaiKhoanMonHoc k)
        {
            try
            {
                var _k = db.TaiKhoanMonHocs.FirstOrDefault(x => x.Id == k.Id);
                _k.IdTK = k.IdTK;
                _k.MaMonHoc = k.MaMonHoc;
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
                var _dt = db.TaiKhoanMonHocs.FirstOrDefault(x => x.Id == id);
                db.TaiKhoanMonHocs.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public List<TAIKHOANMONHOC_DTO> getListFull()
        {
            var lstCH = db.TaiKhoanMonHocs.ToList();
            List<TAIKHOANMONHOC_DTO> lstCHDTO = new List<TAIKHOANMONHOC_DTO>();
            TAIKHOANMONHOC_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new TAIKHOANMONHOC_DTO();
                ctDTO.Id = item.Id;
                ctDTO.MaMonHoc = item.MaMonHoc;
                ctDTO.IdTK = item.IdTK;

                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                ctDTO.TenMonHoc = mh.TenMonHoc;

                var tk = db.TaiKhoans.FirstOrDefault(b => b.IdTK == item.IdTK);
                ctDTO.Username = tk.Username;
                ctDTO.TenGV = tk.TenGV;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }

        public List<TAIKHOANMONHOC_DTO> getListFullTK(int MaGV)
        {
            var lstCH = db.TaiKhoanMonHocs.Where(x => x.IdTK == MaGV).ToList();
            List<TAIKHOANMONHOC_DTO> lstCHDTO = new List<TAIKHOANMONHOC_DTO>();
            TAIKHOANMONHOC_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new TAIKHOANMONHOC_DTO();
                ctDTO.Id = item.Id;
                ctDTO.MaMonHoc = item.MaMonHoc;
                ctDTO.IdTK = item.IdTK;

                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                ctDTO.TenMonHoc = mh.TenMonHoc;

                var tk = db.TaiKhoans.FirstOrDefault(b => b.IdTK == item.IdTK);
                ctDTO.Username = tk.Username;
                ctDTO.TenGV = tk.TenGV;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }

    }
}