using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer.DTO;

namespace DethiLayer
{
    public class CHUONG
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public static int TableWidth = 100;
        public static int TableHeight = 40;
        public Chuong getItem(int id)
        {
            return db.Chuongs.FirstOrDefault(x => x.MaChuong == id);
        }

        public List<Chuong> getList()
        {
            return db.Chuongs.ToList();
        }


        //them 
        public Chuong Add(Chuong k)
        {
            try
            {
                db.Chuongs.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        //sửa
        public Chuong Update(Chuong k)
        {
            try
            {
                var _k = db.Chuongs.FirstOrDefault(x => x.MaChuong == k.MaChuong);
                _k.TenChuong = k.TenChuong;
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
                var _lp = db.Chuongs.FirstOrDefault(x => x.MaChuong == id);
                db.Chuongs.Remove(_lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public List<CHUONG_DTO> getListFull()
        {
            var lstB = db.Chuongs.ToList();
            List<CHUONG_DTO> lstBDTO = new List<CHUONG_DTO>();
            CHUONG_DTO bDTO;
            foreach (var item in lstB)
            {
                bDTO = new CHUONG_DTO();
                bDTO.MaChuong = item.MaChuong;
                bDTO.TenChuong = item.TenChuong;
                bDTO.MaMonHoc = item.MaMonHoc;
                var c = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == item.MaMonHoc);
                bDTO.TenMonHoc = c.TenMonHoc;

                lstBDTO.Add(bDTO);
            }
            return lstBDTO;
        }
    }
}
