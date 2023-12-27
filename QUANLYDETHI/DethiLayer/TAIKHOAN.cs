using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer.DTO;
using System.Security.Cryptography;

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
            db = new DETHITRACNGHIEMEntities();
            TaiKhoan taiKhoanLaySalt = db.TaiKhoans.FirstOrDefault(tk => tk.Username == username);
            if (taiKhoanLaySalt == null)
                return null;

            string hashPassword = HashPassword(password, taiKhoanLaySalt.Salt);
            TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.Username == username && 
            ( tk.LoaiTaiKhoan==3 || tk.Matkhau == hashPassword));

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

        public TaiKhoan ResetPassWord(TaiKhoan dt)
        {
            try
            {
                var _dt = db.TaiKhoans.FirstOrDefault(x => x.IdTK == dt.IdTK);
                _dt.Matkhau = dt.Matkhau;
                _dt.LoaiTaiKhoan = dt.LoaiTaiKhoan;
                _dt.TinhTrang = dt.TinhTrang;
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


        public List<TAIKHOAN_DTO> getListFull()
        {
            var lstCH = db.TaiKhoans.ToList();
            List<TAIKHOAN_DTO> lstCHDTO = new List<TAIKHOAN_DTO>();
            TAIKHOAN_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new TAIKHOAN_DTO();
                ctDTO.IdTK = item.IdTK;
                ctDTO.Matkhau = item.Matkhau;
                ctDTO.Username = item.Username;
                ctDTO.TenGV = item.TenGV;
                ctDTO.GhiChu = item.GhiChu;

                ctDTO.LoaiTaiKhoan = item.LoaiTaiKhoan;
                var ltk = db.LoaiTaiKhoans.FirstOrDefault(b => b.MaLoaiTaiKhoan == item.LoaiTaiKhoan);
                ctDTO.TenLoaiTaiKhoan = ltk.TenLoaiTaiKhoan;

                ctDTO.TinhTrang = item.TinhTrang;
                var tt = db.TinhTrangs.FirstOrDefault(b => b.MaTinhTrang == item.TinhTrang);
                ctDTO.TenTinhTrang = tt.TenTinhTrang;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }

        public List<TAIKHOAN_DTO> getListFullTK(int IdTK)
        {
            var lstCH = db.TaiKhoans.Where(x => x.IdTK == IdTK).ToList();
            List<TAIKHOAN_DTO> lstCHDTO = new List<TAIKHOAN_DTO>();
            TAIKHOAN_DTO ctDTO;
            foreach (var item in lstCH)
            {
                ctDTO = new TAIKHOAN_DTO();
                ctDTO.IdTK = item.IdTK;
                ctDTO.Matkhau = item.Matkhau;
                ctDTO.Username = item.Username;
                ctDTO.TenGV = item.TenGV;
                ctDTO.GhiChu = item.GhiChu;

                ctDTO.LoaiTaiKhoan = item.LoaiTaiKhoan;
                var ltk = db.LoaiTaiKhoans.FirstOrDefault(b => b.MaLoaiTaiKhoan == item.LoaiTaiKhoan);
                ctDTO.TenLoaiTaiKhoan = ltk.TenLoaiTaiKhoan;

                ctDTO.TinhTrang = item.TinhTrang;
                var tt = db.TinhTrangs.FirstOrDefault(b => b.MaTinhTrang == item.TinhTrang);
                ctDTO.TenTinhTrang = tt.TenTinhTrang;

                lstCHDTO.Add(ctDTO);
            }
            return lstCHDTO;
        }

        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
