using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DethiLayer.DTO;

namespace DethiLayer
{
    public class NOIDUNGDETHI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        public NoiDungDeThi getItem(int id)
        {
            return db.NoiDungDeThis.FirstOrDefault(x => x.ID == id);
        }

        public List<NoiDungDeThi> getList()
        {
            return db.NoiDungDeThis.ToList();
        }

        public List<DETHI_DTO> getListFull()
        {
            var lstDT = db.NoiDungDeThis.ToList();
            List<DETHI_DTO> lstDTDTO = new List<DETHI_DTO>();
            DETHI_DTO dtDTO;
            foreach (var item in lstDT)
            {
                dtDTO = new DETHI_DTO();
                dtDTO.ID = item.ID;
                dtDTO.MaDe = item.MaDe;
                dtDTO.MaCauHoi = item.MaCauHoi;
                dtDTO.ThuTuCauHoi = item.ThuTuCauHoi;
                dtDTO.ThuTuXepDapAn = item.ThuTuXepDapAn;

                var mk = db.DeThis.FirstOrDefault(b => b.MaDe == item.MaDe);
                dtDTO.MaKhoi = mk.MaKhoi;
                var mkhoi = db.Khois.FirstOrDefault(b => b.MaKhoi == mk.MaKhoi);
                dtDTO.TenKhoi = mkhoi.TenKhoi;
                dtDTO.MaHienThi = mk.MaHienThi;
                dtDTO.NamHoc = mk.NamHoc;
                var nh = db.NamHocs.FirstOrDefault(b => b.MaNamHoc == mk.NamHoc);
                dtDTO.TenNamHoc = nh.TenNamHoc;
                dtDTO.KyThi = mk.KyThi;
                dtDTO.HinhThucThi = mk.HinhThucThi;

                dtDTO.MaMonHoc = mk.MaMonHoc;
                var mh = db.MonHocs.FirstOrDefault(b => b.MaMonHoc == mk.MaMonHoc);
                dtDTO.TenMonHoc = mh.TenMonHoc;

                var ch = db.CauHois.FirstOrDefault(b => b.MaCauHoi == item.MaCauHoi);
                dtDTO.NDCH = ch.NDCH;
                dtDTO.A = ch.A;
                dtDTO.B = ch.B;
                dtDTO.C = ch.C;
                dtDTO.D = ch.D;
                dtDTO.DapAnDung = ch.DapAnDung;
                dtDTO.HinhAnh = ch.HinhAnh;

                lstDTDTO.Add(dtDTO);
            }

            return lstDTDTO;
        }
    }
}
