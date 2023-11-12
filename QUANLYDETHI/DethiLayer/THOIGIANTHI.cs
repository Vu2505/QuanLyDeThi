using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace DethiLayer
{
    public class THOIGIANTHI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public ThoiGianThi getItem(int id)
        {
            return db.ThoiGianThis.FirstOrDefault(x => x.MaThoiGianThi == id);
        }

        public List<ThoiGianThi> getList()
        {
            return db.ThoiGianThis.ToList();
        }

        public ThoiGianThi Add(ThoiGianThi k)
        {
            try
            {
                db.ThoiGianThis.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public ThoiGianThi Update(ThoiGianThi k)
        {
            try
            {
                var _k = db.ThoiGianThis.FirstOrDefault(x => x.MaThoiGianThi == k.MaThoiGianThi);
                _k.TenThoiGianThi = k.TenThoiGianThi;
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
                var _dt = db.ThoiGianThis.FirstOrDefault(x => x.MaThoiGianThi == id);
                db.ThoiGianThis.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
