using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer.DTO;

namespace DethiLayer
{
    public class MONHOC
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public MonHoc getItem(int id)
        {
            return db.MonHocs.FirstOrDefault(x => x.MaMonHoc == id);
        }

        public List<MonHoc> getList()
        {
            return db.MonHocs.ToList();
        }

        public MonHoc Add(MonHoc dt)
        {
            try
            {
                db.MonHocs.Add(dt);
                db.SaveChanges();
                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: "+ex.Message);
            }
        }

        public MonHoc Update(MonHoc dt)
        {
            try
            {
                var _dt = db.MonHocs.FirstOrDefault(x => x.MaMonHoc == dt.MaMonHoc);
                _dt.TenMonHoc = dt.TenMonHoc;
                _dt.MaKhoi = dt.MaKhoi;
                db.SaveChanges();
                return dt;
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
                var _dt = db.MonHocs.FirstOrDefault(x => x.MaMonHoc == id);
                db.MonHocs.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public List<MONHOC_DTO> getListFull()
        {
            var lstB = db.MonHocs.ToList();
            List<MONHOC_DTO> lstBDTO = new List<MONHOC_DTO>();
            MONHOC_DTO bDTO;
            foreach (var item in lstB)
            {
                bDTO = new MONHOC_DTO();
                bDTO.MaMonHoc = item.MaMonHoc;
                bDTO.TenMonHoc = item.TenMonHoc;
                bDTO.MaKhoi = item.MaKhoi;
                var c = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
                bDTO.TenKhoi = c.TenKhoi;

                lstBDTO.Add(bDTO);
            }
            return lstBDTO;
        }
    }
}
