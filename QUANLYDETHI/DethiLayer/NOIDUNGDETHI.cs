using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DethiLayer.DTO;

namespace DethiLayer
{
    public class NOIDUNGDETHI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        private static Dictionary<int, List<string>> thuTuDapAn = new Dictionary<int, List<string>>() {
            //ABCD
            {1, new List<string>() {"A", "B", "C", "D"}},
            //ABDC
            {2, new List<string>() {"A", "B", "D", "C"}},
            //ACBD
            {3, new List<string>() {"A", "C", "B", "D"}},
            //ACDB
            {4, new List<string>() {"A", "C", "D", "B"}},
            //ADBC
            {5, new List<string>() {"A", "D", "B", "C"}},
            //ADCB
            {6, new List<string>() {"A", "D", "C", "B"}},
            //BACD
            {7, new List<string>() {"B", "A", "C", "D"}},
            //BADC
            {8, new List<string>() {"B", "A", "D", "C"}},
            //BCAD
            {9, new List<string>() {"B", "C", "A", "D"}},
            //BCDA
            {10, new List<string>() {"B", "C", "D", "A"}},
            //BDAC
            {11, new List<string>() {"B", "D", "A", "C"}},
            //BDCA
            {12, new List<string>() {"B", "D", "C", "A"}},
            //CABD
            {13, new List<string>() {"C", "A", "B", "D"}},
            //CADB
            {14, new List<string>() {"C", "A", "D", "B"}},
            //CBAD
            {15, new List<string>() {"C", "B", "A", "D"}},
            //CBDA
            {16, new List<string>() {"C", "B", "D", "A"}},
            //CDAB
            {17, new List<string>() {"C", "D", "A", "B"}},
            //CDBA
            {18, new List<string>() {"C", "D", "B", "A"}},
            //DABC
            {19, new List<string>() {"D", "A", "B", "C"}},
            //DACB
            {20, new List<string>() {"D", "A", "C", "B"}},
            //DBAC
            {21, new List<string>() {"D", "B", "A", "C"}},
            //DBCA
            {22, new List<string>() {"D", "B", "C", "A"}},
            //DCAB
            {23, new List<string>() {"D", "C", "A", "B"}},
            //DCBA
            {24, new List<string>() {"D", "C", "B", "A"}},
        };
        public NoiDungDeThi getItem(int id)
        {
            return db.NoiDungDeThis.FirstOrDefault(x => x.ID == id);
        }

        public List<NoiDungDeThi> getList()
        {
            return db.NoiDungDeThis.ToList();
        }

        public List<DETHI_DTO> getListFull(int? selectedMaDe = null)
        {

            ////var lstDT = db.NoiDungDeThis.ToList();
             var query = db.NoiDungDeThis.AsQueryable();

            if (selectedMaDe.HasValue)
            {
                query = query.Where(item => item.MaDe == selectedMaDe);
            }

            //var lstDT = db.NoiDungDeThis.Where(item => item.MaDe == selectedMaDe).ToList();
            var lstDT = query.ToList();
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
                dtDTO.MaLop = mk.MaLop;
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

                var noiDungDTList = db.NoiDungDeThis.Where(b => b.MaDe == item.MaDe).ToList();
                var chiTietCauHoiList = new List<CauHoi>();
                foreach(var dong in noiDungDTList)
                {
                    chiTietCauHoiList.Add(db.CauHois.FirstOrDefault(b => b.MaCauHoi == dong.MaCauHoi));
                }
                dtDTO.CauHois = chiTietCauHoiList;
                dtDTO.NDCH = ch.NDCH;

                // Đảo vị trí đáp án dựa theo thứ tự đáp án
                int thuTu = (int)dtDTO.ThuTuXepDapAn;
                thuTu = thuTu < 25 && thuTu > 0 ? thuTu : 1;

                List<string> thuTuSapXep = thuTuDapAn[thuTu];
                List<string> mapIDtoQuestion = new List<string>();
                foreach(var i in thuTuSapXep)
                {
                    switch (i)
                    {
                        case "A":
                            mapIDtoQuestion.Add(ch.A);
                            break;
                        case "B":
                            mapIDtoQuestion.Add(ch.B);
                            break;
                        case "C":
                            mapIDtoQuestion.Add(ch.C);
                            break;
                        case "D":
                            mapIDtoQuestion.Add(ch.D);
                            break;
                        default:
                            break;
                    }
                }
                dtDTO.A = mapIDtoQuestion.ElementAt(0);
                dtDTO.B = mapIDtoQuestion.ElementAt(1);
                dtDTO.C = mapIDtoQuestion.ElementAt(2);
                dtDTO.D = mapIDtoQuestion.ElementAt(3);

                // Tìm lại đáp án đúng
                string chiTietDapAnDung = "";
                switch (ch.DapAnDung)
                {
                    case "A":
                        chiTietDapAnDung = ch.A;
                        break;
                    case "B":
                        chiTietDapAnDung = ch.B;
                        break;
                    case "C":
                        chiTietDapAnDung = ch.C;
                        break;
                    case "D":
                        chiTietDapAnDung = ch.D;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < mapIDtoQuestion.Count; ++i){
                    if(mapIDtoQuestion.ElementAt(i) == chiTietDapAnDung)
                    {
                        if(i == 0)
                        {
                            dtDTO.DapAnDung = "A";
                        }
                        if (i == 1)
                        {
                            dtDTO.DapAnDung = "B";
                        }
                        if (i == 2)
                        {
                            dtDTO.DapAnDung = "C";
                        }
                        if (i == 3)
                        {
                            dtDTO.DapAnDung = "D";
                        }
                    }
                }
                
                dtDTO.HinhAnh = ch.HinhAnh;

                lstDTDTO.Add(dtDTO);
            }
            return lstDTDTO;
        }
    }
}
