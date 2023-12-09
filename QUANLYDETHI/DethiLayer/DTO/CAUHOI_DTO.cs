using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace DethiLayer.DTO
{
    public class CAUHOI_DTO
    {
        public int MaCauHoi { get; set; }
        public string NDCH { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string DapAnDung { get; set; }
        public byte[] HinhAnh { get; set; }
        public int? MaKhoi { get; set; }
        public string TenKhoi { get; set; }
        public int? MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int? MaChuong { get; set; }
        public string TenChuong { get; set; }
        public int? MaBai { get; set; }
        public string TenBai { get; set; }
        public int? MaDoKho { get; set; }
        public string TenDoKho { get; set; }
        public int? TrangThai { get; set; }
        public string TenTinhTrang { get; set; }
        public string GhiChu { get; set; }
        public int? MaGiangVien { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
