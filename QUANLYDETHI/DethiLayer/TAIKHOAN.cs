using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;


namespace DethiLayer
{
    public class TAIKHOAN
    {
        DETHITRACNGHIEMEntities db;

        public TAIKHOAN()
        {
            db = new DETHITRACNGHIEMEntities();
        }

        public TaiKhoan getItem(int id)
        {
            return db.TaiKhoans.FirstOrDefault(x => x.IdTK == id);
        }

        public TaiKhoan Login(string username, string password)
        {

            TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.Username == username && tk.Matkhau == password);
            return taiKhoan;


            //var us = db.TaiKhoans.FirstOrDefault(x => x.Username == username && x.Matkhau == pass);
            //if (us != null)
            //    return 1;
            //else
            //    return 0;
        }

        public List<TaiKhoan> getList()
        {
            return db.TaiKhoans.ToList();
        }

        public TaiKhoan Add(TaiKhoan dt)
        {
            try
            {
                db.TaiKhoans.Add(dt);
                db.SaveChanges();
                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public TaiKhoan Update(TaiKhoan dt)
        {
            try
            {
                var _dt = db.TaiKhoans.FirstOrDefault(x => x.IdTK == dt.IdTK);
                _dt.TenGV = dt.TenGV;
                _dt.Username = dt.Username;
                _dt.Matkhau = dt.Matkhau;
                _dt.LoaiTaiKhoan = dt.LoaiTaiKhoan;
                _dt.TinhTrang = dt.TinhTrang;
                _dt.GhiChu = dt.GhiChu;
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
                var _dt = db.TaiKhoans.FirstOrDefault(x => x.IdTK == id);
                db.TaiKhoans.Remove(_dt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

    }
}
