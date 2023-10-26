using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace DethiLayer.DTO
{
    public class DETHI_DTO
    {

        public int ID { get; set; }
        public int? MaDe { get; set; }
        public int? MaCauHoi { get; set; }
        public int? ThuTuCauHoi { get; set; }
        public int? ThuTuXepDapAn { get; set; }
        public int? NamHoc { get; set; }
        public string TenNamHoc { get; set; }
        public int? MaHienThi { get; set; }
        public string KyThi { get; set; }
        public string HinhThucThi { get; set; }
        public int? SoCauHoi { get; set; }
        public int? MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int? MaKhoi { get; set; }
        public string TenKhoi { get; set; }
        public string NDCH { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string DapAnDung { get; set; }
        public byte[] HinhAnh { get; set; }
    }
}
