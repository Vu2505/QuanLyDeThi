using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace DethiLayer
{
    public class TINHTRANG
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public TinhTrang getItem(int id)
        {
            return db.TinhTrangs.FirstOrDefault(x => x.MaTinhTrang == id);
        }

        public List<TinhTrang> getList()
        {
            return db.TinhTrangs.ToList();
        }

        public TinhTrang Add(TinhTrang k)
        {
            try
            {
                db.TinhTrangs.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public TinhTrang Update(TinhTrang k)
        {
            try
            {
                var _k = db.TinhTrangs.FirstOrDefault(x => x.MaTinhTrang == k.MaTinhTrang);
                _k.TenTinhTrang = k.TenTinhTrang;
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
                var _dt = db.TinhTrangs.FirstOrDefault(x => x.MaTinhTrang == id);
                db.TinhTrangs.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
