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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            this.CauHois = new HashSet<CauHoi>();
            this.DeThis = new HashSet<DeThi>();
            this.TaiKhoanMonHocs = new HashSet<TaiKhoanMonHoc>();
        }
    
        public int IdTK { get; set; }
        public string TenGV { get; set; }
        public string Username { get; set; }
        public string Matkhau { get; set; }
        public Nullable<int> LoaiTaiKhoan { get; set; }
        public int TinhTrang { get; set; }
        public string GhiChu { get; set; }
        public string Salt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHoi> CauHois { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeThi> DeThis { get; set; }
        public virtual LoaiTaiKhoan LoaiTaiKhoan1 { get; set; }
        public virtual TinhTrang TinhTrang1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoanMonHoc> TaiKhoanMonHocs { get; set; }
    }
}
