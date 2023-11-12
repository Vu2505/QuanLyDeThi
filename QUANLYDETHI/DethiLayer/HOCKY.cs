using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace DethiLayer
{
    public class HOCKY
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public HocKy getItem(int id)
        {
            return db.HocKies.FirstOrDefault(x => x.MaHocKy == id);
        }

        public List<HocKy> getList()
        {
            return db.HocKies.ToList();
        }

        public HocKy Add(HocKy k)
        {
            try
            {
                db.HocKies.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public HocKy Update(HocKy k)
        {
            try
            {
                var _k = db.HocKies.FirstOrDefault(x => x.MaHocKy == k.MaHocKy);
                _k.TenHocKy = k.TenHocKy;
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
                var _dt = db.HocKies.FirstOrDefault(x => x.MaHocKy == id);
                db.HocKies.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
