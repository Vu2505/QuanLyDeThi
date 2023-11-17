using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace DethiLayer
{
    public class LOAITAIKHOAN
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public LoaiTaiKhoan getItem(int id)
        {
            return db.LoaiTaiKhoans.FirstOrDefault(x => x.MaLoaiTaiKhoan == id);
        }

        public List<LoaiTaiKhoan> getList()
        {
            return db.LoaiTaiKhoans.ToList();
        }

        public LoaiTaiKhoan Add(LoaiTaiKhoan k)
        {
            try
            {
                db.LoaiTaiKhoans.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public LoaiTaiKhoan Update(LoaiTaiKhoan k)
        {
            try
            {
                var _k = db.LoaiTaiKhoans.FirstOrDefault(x => x.MaLoaiTaiKhoan == k.MaLoaiTaiKhoan);
                _k.TenLoaiTaiKhoan = k.TenLoaiTaiKhoan;
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
                var _dt = db.LoaiTaiKhoans.FirstOrDefault(x => x.MaLoaiTaiKhoan == id);
                db.LoaiTaiKhoans.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

    }
}
