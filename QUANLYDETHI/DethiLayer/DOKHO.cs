using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DethiLayer
{
    public class DOKHO
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public DoKho getItem(int id)
        {
            return db.DoKhoes.FirstOrDefault(x => x.MaDoKho == id);
        }
        public List<DoKho> getList()
        {
            return db.DoKhoes.ToList();
        }

        public DoKho Add(DoKho k)
        {
            try
            {
                db.DoKhoes.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public DoKho Update(DoKho k)
        {
            try
            {
                var _k = db.DoKhoes.FirstOrDefault(x => x.MaDoKho == k.MaDoKho);
                _k.TenDoKho = k.TenDoKho;
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
                var _dt = db.DoKhoes.FirstOrDefault(x => x.MaDoKho == id);
                db.DoKhoes.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
