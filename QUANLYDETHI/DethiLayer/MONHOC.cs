using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

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
    }
}
