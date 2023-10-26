using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace DethiLayer
{
    public class NAMHOC
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public NamHoc getItem(int id)
        {
            return db.NamHocs.FirstOrDefault(x => x.MaNamHoc == id);
        }

        public List<NamHoc> getList()
        {
            return db.NamHocs.ToList();
        }

        public NamHoc Add(NamHoc dt)
        {
            try
            {
                db.NamHocs.Add(dt);
                db.SaveChanges();
                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public NamHoc Update(NamHoc dt)
        {
            try
            {
                var _dt = db.NamHocs.FirstOrDefault(x => x.MaNamHoc == dt.MaNamHoc);
                _dt.TenNamHoc = dt.TenNamHoc;
                _dt.MaNamHoc = dt.MaNamHoc;
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
                var _dt = db.NamHocs.FirstOrDefault(x => x.MaNamHoc == id);
                db.NamHocs.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
