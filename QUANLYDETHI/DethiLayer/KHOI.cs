using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer;

namespace DethiLayer
{
    public class KHOI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public Khoi getItem(int id)
        {
            return db.Khois.FirstOrDefault(x => x.MaKhoi == id);
        }

        public List<Khoi> getList()
        {
            return db.Khois.ToList();
        }

        public Khoi Add(Khoi k)
        {
            try
            {
                db.Khois.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public Khoi Update(Khoi k)
        {
            try
            {
                var _k = db.Khois.FirstOrDefault(x => x.MaKhoi == k.MaKhoi);
                _k.TenKhoi = k.TenKhoi;
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
                var _dt = db.Khois.FirstOrDefault(x => x.MaKhoi == id);
                db.Khois.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }


        
    }
}
