using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DethiLayer
{
    public class LOP
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public Lop getItem(int id)
        {
            return db.Lops.FirstOrDefault(x => x.MaLop == id);
        }

        public List<Lop> getList()
        {
            return db.Lops.ToList();
        }

        public Lop Add(Lop k)
        {
            try
            {
                db.Lops.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public Lop Update(Lop k)
        {
            try
            {
                var _k = db.Lops.FirstOrDefault(x => x.MaLop == k.MaLop);
                _k.TenLop = k.TenLop;
                _k.MaKhoi = k.MaKhoi;
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
                var _lp = db.Lops.FirstOrDefault(x => x.MaLop == id);
                db.Lops.Remove(_lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
