using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DethiLayer.DTO
{
    public class TAIKHOANMONHOC_DTO
    {
        public int Id { get; set; }
        public int? IdTK { get; set; }
        public string Username { get; set; }
        public string TenGV { get; set; }
        public int? MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
    }
}
