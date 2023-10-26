﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DethiLayer
{
    public class CAUHOI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public CauHoi getItem(int id)
        {
            return db.CauHois.FirstOrDefault(x => x.MaCauHoi == id);
        }
        public List<CauHoi> getList()
        {
            return db.CauHois.ToList();
        }

        //them 
        public CauHoi Add(CauHoi k)
        {
            try
            {
                db.CauHois.Add(k);
                db.SaveChanges();
                return k;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        //sửa
        public CauHoi Update(CauHoi k)
        {
            try
            {
                var _k = db.CauHois.FirstOrDefault(x => x.MaCauHoi == k.MaCauHoi);
                _k.NDCH = k.NDCH;
                _k.A = k.A;
                _k.B = k.B;
                _k.C = k.C;
                _k.D = k.D;
                _k.DapAnDung = k.DapAnDung;
                _k.HinhAnh = k.HinhAnh;
                _k.MaKhoi = k.MaKhoi;
                _k.MaMonHoc = k.MaMonHoc;
                _k.MaChuong = k.MaChuong;
                _k.MaBai = k.MaBai;
                _k.DoKho = k.MaKhoi;
                _k.TrangThai = k.TrangThai;
                _k.GhiChu = k.GhiChu;
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
                var _lp = db.CauHois.FirstOrDefault(x => x.MaCauHoi == id);
                db.CauHois.Remove(_lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        //public CauHoi getList (int id)
        //{
        //    return db.CauHois.FirstOrDefault(x => x.MaCauHoi == id )
        //}

        public int SoLuongCauHoiTheoBai(int maBai, int doKho)
        {
            return db.CauHois.ToList()
                .Count(x => x.MaBai == maBai && x.DoKho == doKho);
        }

        public int SoLuongCauHoiTheoChuong(int maChuong, int doKho)
        {
            return db.CauHois.ToList()
                .Count(x => x.MaChuong == maChuong && x.DoKho == doKho);
        }
    }
}