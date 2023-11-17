using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DethiLayer.DTO
{
    public class TAIKHOAN_DTO
    {
        public int IdTK { get; set; }
        public string TenGV { get; set; }
        public string Username { get; set; }
        public string Matkhau { get; set; }
        public int? LoaiTaiKhoan { get; set; }
        public string TenLoaiTaiKhoan { get; set; }
        public int? TinhTrang { get; set; }
        public string TenTinhTrang { get; set; }
        public string GhiChu { get; set; }
    }
}
