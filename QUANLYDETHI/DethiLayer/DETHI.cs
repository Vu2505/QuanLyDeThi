using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer.DTO;

namespace DethiLayer
{
    public class DETHI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        public DeThi getItem(int id)
        {
            return db.DeThis.FirstOrDefault(x => x.MaDe == id);
        }
        public List<DeThi> getList()
        {
            return db.DeThis.ToList();
        }

        //public List<DETHI_DTO> getListFull()
        //{
        //    //List<DeThi> lstDT = db.DeThis.Where(x => x.MaDe == id).ToList();
        //    var lstDT = db.DeThis.ToList();
        //    List<DETHI_DTO> lstDTDTO = new List<DETHI_DTO>();
        //    DETHI_DTO dtDTO;
        //    foreach (var item in lstDT)
        //    {
        //        dtDTO = new DETHI_DTO();
        //        dtDTO.MaDe = item.MaDe;
        //        dtDTO.MaKhoi = item.MaKhoi;

        //        var k = db.Khois.FirstOrDefault(b => b.MaKhoi == item.MaKhoi);
        //        dtDTO.TenKhoi = k.TenKhoi;
        //        dtDTO.MaHienThi = item.MaHienThi;
        //        dtDTO.NamHoc = item.NamHoc;
        //        var nh = db.NamHocs.FirstOrDefault(b => b.MaNamHoc == item.NamHoc);
        //        dtDTO.TenNamHoc = nh.TenNamHoc;
        //        dtDTO.KyThi = item.KyThi;
        //        dtDTO.HinhThucThi = item.HinhThucThi;

        //        var mk = db.NoiDungDeThis.FirstOrDefault(b => b.MaDe == item.MaDe);
        //        dtDTO.ID = mk.ID;
        //        dtDTO.MaCauHoi = mk.MaCauHoi;
        //        dtDTO.ThuTuCauHoi = mk.ThuTuCauHoi;
        //        dtDTO.ThuTuXepDapAn = mk.ThuTuXepDapAn;

        //        var ch = db.CauHois.FirstOrDefault(b => b.MaCauHoi == mk.MaCauHoi);
        //        dtDTO.NDCH = ch.NDCH;
        //        dtDTO.A = ch.A;
        //        dtDTO.B = ch.B;
        //        dtDTO.C = ch.C;
        //        dtDTO.D = ch.D;
        //        dtDTO.DapAnDung = ch.DapAnDung;
        //        dtDTO.HinhAnh = ch.HinhAnh;

        //        lstDTDTO.Add(dtDTO);
        //    }

        //    return lstDTDTO;
        //}
    }
}
