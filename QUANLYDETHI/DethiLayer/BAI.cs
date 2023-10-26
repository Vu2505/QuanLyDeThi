using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DethiLayer
{
    public class BAI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        public static int TableWidth = 100;
        public static int TableHeight = 25;
        public Bai getItem(int id)
        {
            return db.Bais.FirstOrDefault(x => x.MaBai == id);
        }

        public List<Bai> getList()
        {
            return db.Bais.ToList();
        }

        public Bai Add(Bai k)
        {
            try
            {
                db.Bais.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public Bai Update(Bai k)
        {
            try
            {
                var _k = db.Bais.FirstOrDefault(x => x.MaBai == k.MaBai);
                _k.TenBai = k.TenBai;
                _k.MaChuong = k.MaChuong;
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
                var _lp = db.Bais.FirstOrDefault(x => x.MaBai == id);
                db.Bais.Remove(_lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
