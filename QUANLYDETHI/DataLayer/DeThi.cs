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
    
    public partial class DeThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeThi()
        {
            this.NoiDungDeThis = new HashSet<NoiDungDeThi>();
        }
    
        public int MaDe { get; set; }
        public Nullable<int> NamHoc { get; set; }
        public Nullable<int> MaHienThi { get; set; }
        public string TenDeThi { get; set; }
        public Nullable<int> SoCauHoi { get; set; }
        public Nullable<int> MaMonHoc { get; set; }
        public Nullable<int> MaKhoi { get; set; }
        public Nullable<int> MaLop { get; set; }
        public Nullable<int> MaGiangVien { get; set; }
        public Nullable<int> MaHocKy { get; set; }
        public Nullable<int> MaThoiGianThi { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
    
        public virtual HocKy HocKy { get; set; }
        public virtual Khoi Khoi { get; set; }
        public virtual Lop Lop { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual NamHoc NamHoc1 { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual ThoiGianThi ThoiGianThi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoiDungDeThi> NoiDungDeThis { get; set; }
    }
}
