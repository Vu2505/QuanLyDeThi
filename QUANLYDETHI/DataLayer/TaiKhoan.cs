//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaiKhoan
    {
        public int IdTK { get; set; }
        public string TenGV { get; set; }
        public string Username { get; set; }
        public string Matkhau { get; set; }
        public Nullable<int> LoaiTaiKhoan { get; set; }
        public int TinhTrang { get; set; }
        public string GhiChu { get; set; }
        public string Salt { get; set; }
    }
}
