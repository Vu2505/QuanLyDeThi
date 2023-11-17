using DataLayer;
using DethiLayer;
using DethiLayer.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDETHI.Taodethi
{

    public class DeThi
    {
        private List<Chuong> danhSachChuong;

        private int soLuongCauHoiMuonTao;
        private int soLuongCauHoiDangTao;
        public int SoLuongCauHoiDangTao { get => soLuongCauHoiDangTao; }
        public int SoLuongCauHoiMuonTao { get => soLuongCauHoiMuonTao; set => soLuongCauHoiMuonTao = value; }

        public DeThi()
        {
            danhSachChuong = new List<Chuong>();
        }

        public bool KiemTraLaRong()
        {
            foreach (var item in danhSachChuong)
            {
                // Ko rong (SL > 0)
                if (!item.KiemTraLaRong())
                {
                    return false;
                }
            }
            return true;
        }

        public bool KiemTraChuongRong(int maChuong)
        {
            bool chuongDoLaRong = true;

            foreach (var item in danhSachChuong)
            {
                if(item.MaChuong == maChuong && !item.KiemTraLaRong())
                {
                    chuongDoLaRong = false;
                }
            }
            return chuongDoLaRong;
        }

        public bool KiemTraBaiCuaChuongRong(int maChuong, int maBai)
        {
            // Đặt giá trị mặc định của bài là rỗng
            bool baiDoLaRong = true;
            foreach (var chuong in danhSachChuong)
            {
                if (chuong.MaChuong == maChuong)
                {
                    foreach(var bai in chuong.DanhSachBai)
                    {
                        if (bai.MaBai == maBai && !bai.KiemTraLaRong())
                        {
                            baiDoLaRong = false;
                        }
                    }
                }
            }
            return baiDoLaRong;
        }

        public KiemTraSoLuong CapNhatChuong(int maChuong, int soLuongCauDe, int soLuongCauTB, int soLuongCauKho)
        {
            soLuongCauHoiDangTao = 0;
            foreach(var chuong in danhSachChuong)
            {
                if (chuong.MaChuong == maChuong)
                {
                    chuong.SoLuongCauDe = soLuongCauDe;
                    chuong.SoLuongCauTB = soLuongCauTB;
                    chuong.SoLuongCauKho = soLuongCauKho;

                    // Reset sl cau hoi trong bai cua chuong do
                    foreach(var bai in chuong.DanhSachBai)
                    {
                        bai.SoLuongCauDe = 0;
                        bai.SoLuongCauTB = 0;
                        bai.SoLuongCauKho = 0;
                    }                    
                }
                soLuongCauHoiDangTao += chuong.SoLuongCau;
            }
            return KiemTraSoLuongCauHoi();
        }

        public KiemTraSoLuong CapNhatBaiCuaChuong(int maChuong, int maBai, int soLuongCauDe, int soLuongCauTB, int soLuongCauKho)
        {
            soLuongCauHoiDangTao = 0;
            foreach (var chuong in danhSachChuong)
            {
                if (chuong.MaChuong == maChuong)
                {
                    // Reset lại
                    chuong.SoLuongCauDe = 0;
                    chuong.SoLuongCauTB = 0;
                    chuong.SoLuongCauKho = 0;

                    foreach (var bai in chuong.DanhSachBai)
                    {
                        if(bai.MaBai == maBai)
                        {
                            bai.SoLuongCauDe = soLuongCauDe;
                            bai.SoLuongCauTB = soLuongCauTB;
                            bai.SoLuongCauKho = soLuongCauKho;                            
                        }
                        chuong.SoLuongCauDe += bai.SoLuongCauDe;
                        chuong.SoLuongCauTB += bai.SoLuongCauTB;
                        chuong.SoLuongCauKho += bai.SoLuongCauKho;
                    }
                }
                soLuongCauHoiDangTao += chuong.SoLuongCau;
            }
            return KiemTraSoLuongCauHoi();
        }


        public void ThemChuong(int maChuong)
        {
            danhSachChuong.Add(new Chuong(maChuong));
        }

        public void ThemBaiVaoChuong(int maChuong, int maBai)
        {
            foreach(var chuong in danhSachChuong)
            {
                if(chuong.MaChuong == maChuong)
                {
                    chuong.ThemBai(new Bai(maBai));
                }                
            }
        }

        public void LamSach()
        {
            danhSachChuong.Clear();
        }

        public Dictionary<String, int> InRaSoLuongCauHoiCuaChuong(int maChuong)
        {
            foreach(var item in danhSachChuong)
            {
                if(item.MaChuong == maChuong)
                {
                    return item.InRaSoLuongCauHoi();
                }
            }

            // Trả về mặc định
            Dictionary<String, int> map = new Dictionary<String, int>();
            map.Add("soLuongCauDe", 0);
            map.Add("soLuongCauTB", 0);
            map.Add("soLuongCauKho", 0);
            return map;
        }

        public Dictionary<String, int> InRaSoLuongCauHoiCuaBaiTrongChuong(int maChuong, int maBai)
        {
            foreach (var chuong in danhSachChuong)
            {
                if (chuong.MaChuong == maChuong)
                {
                    foreach(var bai in chuong.DanhSachBai)
                    {
                        if(bai.MaBai == maBai)
                        {
                            return bai.InRaSoLuongCauHoi();
                        }
                    }

                }
            }

            // Trả về mặc định
            Dictionary<String, int> map = new Dictionary<String, int>();
            map.Add("soLuongCauDe", 0);
            map.Add("soLuongCauTB", 0);
            map.Add("soLuongCauKho", 0);
            return map;
        }

        public override string ToString()
        {            
            List<string> result = new List<string>();
            foreach (var chuong in danhSachChuong)
            {
                if (!chuong.KiemTraLaRong())
                {
                    result.Add(chuong.ToString());
                }
            }

            return $"{string.Join("\n", result)}";
        }

        public KiemTraSoLuong KiemTraSoLuongCauHoi()
        {
            var result = KiemTraSoLuong.DuCau;
            if(soLuongCauHoiMuonTao > soLuongCauHoiDangTao)
            {
                result = KiemTraSoLuong.ThieuCau;
            }
            else if (soLuongCauHoiDangTao > soLuongCauHoiMuonTao)
            {
                result = KiemTraSoLuong.ThuaCau;
            }
            return result;
        }

        public List<CAUHOI_DTO> GetCauHoiTheoChuong(TaiKhoan user)
        {
            CAUHOI db = new CAUHOI();
            List<CAUHOI_DTO> result = new List<CAUHOI_DTO>();
            
            foreach (var chuong in danhSachChuong)
            {
                result.AddRange(chuong.GetCauHoi(user));
            }

            return result;
        }

        public List<CAUHOI_DTO> GetCauHoiTheoBai(TaiKhoan user)
        {
            CAUHOI db = new CAUHOI();
            List<CAUHOI_DTO> result = new List<CAUHOI_DTO>();

            foreach (var chuong in danhSachChuong)
            {
                result.AddRange(chuong.GetCauHoiTheoBai(user));
            }

            return result;
        }

    }


    public class Chuong
    {
        private int maChuong;
        private int soLuongCauDe;
        private int soLuongCauTB;
        private int soLuongCauKho;
        private List<Bai> danhSachBai;

        public int MaChuong { get => maChuong;}
        public int SoLuongCauDe { get => soLuongCauDe; set => soLuongCauDe = value; }
        public int SoLuongCauTB { get => soLuongCauTB; set => soLuongCauTB = value; }
        public int SoLuongCauKho { get => soLuongCauKho; set => soLuongCauKho = value; }
        public int SoLuongCau { get => soLuongCauDe + soLuongCauTB + soLuongCauKho; }
        public List<Bai> DanhSachBai { get => danhSachBai; }
        
        public Chuong(int maChuong)
        {
            this.maChuong = maChuong;
            danhSachBai = new List<Bai>();
        }

        public bool KiemTraLaRong()
        {
            return SoLuongCau == 0;
        }

        public void ThemBai(Bai themBai)
        {
            bool baiKhongCoTrongDanhSach = true;
            foreach(var bai in danhSachBai)
            {
                if(bai.MaBai == themBai.MaBai)
                {
                    baiKhongCoTrongDanhSach = false;
                    break;
                }
            }
            if (baiKhongCoTrongDanhSach)
            {
                danhSachBai.Add(themBai);
            }
        }

        public void ThemCauHoiVaoBai(int maBai, int soLuongCauDe, int soLuongCauTB, int soLuongCauKho)
        {
            foreach(var item in danhSachBai)
            {
                if(item.MaBai == maBai)
                {
                    item.SoLuongCauDe = soLuongCauDe;
                    item.SoLuongCauTB = soLuongCauTB;
                    item.SoLuongCauKho = soLuongCauKho;
                }
            }
        }

        public Dictionary<String, int> InRaSoLuongCauHoi()
        {
            Dictionary<String, int> map = new Dictionary<String, int>();
            map.Add("soLuongCauDe", soLuongCauDe);
            map.Add("soLuongCauTB", soLuongCauTB);
            map.Add("soLuongCauKho", soLuongCauKho);
            return map;
        }

        public override string ToString()
        {
            var _chuong = new CHUONG();
            string tenChuong = _chuong.getItem(maChuong).TenChuong;
            List<string> result = new List<string>();
            foreach (var bai in danhSachBai)
            {
                if (!bai.KiemTraLaRong())
                {
                    result.Add(bai.ToString());
                }
            }
            if(result != null && result.Count != 0)
            {
                return $"{tenChuong}: Tổng Số Câu: {SoLuongCau} [{string.Join(" | ", result)}]";
            }
            return $"{tenChuong}: Tổng Số Câu: {SoLuongCau} |(Dễ: {soLuongCauDe} câu, Trung bình: {soLuongCauTB} câu, Khó: {soLuongCauKho} câu)";
        }

        public List<CAUHOI_DTO> GetCauHoi(TaiKhoan user)
        {
            CAUHOI db = new CAUHOI();
            List<CAUHOI_DTO> result = new List<CAUHOI_DTO>();
            if(user.LoaiTaiKhoan == 1)
            {
                result.AddRange(db.getListRanDomChuong(maChuong, 1, soLuongCauDe));
                result.AddRange(db.getListRanDomChuong(maChuong, 2, soLuongCauTB));
                result.AddRange(db.getListRanDomChuong(maChuong, 3, soLuongCauKho));
            }
            else
            {
                result.AddRange(db.getListRanDomChuong(maChuong, 1, soLuongCauDe, user.IdTK));
                result.AddRange(db.getListRanDomChuong(maChuong, 2, soLuongCauTB, user.IdTK));
                result.AddRange(db.getListRanDomChuong(maChuong, 3, soLuongCauKho, user.IdTK));
            }
            
            return result;
        }

        public List<CAUHOI_DTO> GetCauHoiTheoBai(TaiKhoan user)
        {
            CAUHOI db = new CAUHOI();
            List<CAUHOI_DTO> result = new List<CAUHOI_DTO>();
            
            foreach (var bai in danhSachBai)
            {
                result.AddRange(bai.GetCauHoi(user));
            }

            return result;
        }
 

    }

    public class Bai
    {
        private int maBai;
        private int soLuongCauDe;
        private int soLuongCauTB;
        private int soLuongCauKho;
        
        public int MaBai { get => maBai; }
        public int SoLuongCauDe { get => soLuongCauDe; set => soLuongCauDe = value; }
        public int SoLuongCauTB { get => soLuongCauTB; set => soLuongCauTB = value; }
        public int SoLuongCauKho { get => soLuongCauKho; set => soLuongCauKho = value; }
        public int SoLuongCau { get => soLuongCauDe + soLuongCauTB + soLuongCauKho; }

        public Bai(int maBai)
        {
            this.maBai = maBai;
            soLuongCauDe = 0;
            soLuongCauTB = 0;
            soLuongCauKho = 0;
        }

        public Bai(int maBai, int soLuongDe, int soLuongTB, int soLuongKho)
        {
            this.maBai = maBai;
            this.soLuongCauDe = soLuongDe;
            this.soLuongCauTB = soLuongTB;
            this.soLuongCauKho = soLuongKho;
        }

        public bool KiemTraLaRong()
        {
            return SoLuongCau == 0;
        }

        public void CapNhatSoLuongCauHoi(int soLuongCauDe, int soLuongCauTB, int soLuongCauKho)
        {
            this.soLuongCauDe = soLuongCauDe;
            this.soLuongCauTB = soLuongCauTB;
            this.soLuongCauKho = soLuongCauKho;
        }

        public Dictionary<String, int> InRaSoLuongCauHoi()
        {
            Dictionary<String, int> map = new Dictionary<String, int>();
            map.Add("soLuongCauDe", soLuongCauDe);
            map.Add("soLuongCauTB", soLuongCauTB);
            map.Add("soLuongCauKho", soLuongCauKho);
            return map;
        }
        public override string ToString()
        {
            var _bai = new BAI();
            string tenBai = _bai.getItem(maBai).TenBai;
            return $"{tenBai}: Dễ: {soLuongCauDe} câu, Trung bình: {soLuongCauTB} câu, Khó: {soLuongCauKho} câu";
        }

        public List<CAUHOI_DTO> GetCauHoi(TaiKhoan user)
        {
            CAUHOI db = new CAUHOI();
            List<CAUHOI_DTO> result = new List<CAUHOI_DTO>();
            if(user.LoaiTaiKhoan == 1)
            {
                result.AddRange(db.getListRanDomBai(maBai, 1, soLuongCauDe));
                result.AddRange(db.getListRanDomBai(maBai, 2, soLuongCauTB));
                result.AddRange(db.getListRanDomBai(maBai, 3, soLuongCauKho));
            }
            else
            {
                result.AddRange(db.getListRanDomBai(maBai, 1, soLuongCauDe, user.IdTK));
                result.AddRange(db.getListRanDomBai(maBai, 2, soLuongCauTB, user.IdTK));
                result.AddRange(db.getListRanDomBai(maBai, 3, soLuongCauKho, user.IdTK));
            }
            
            return result;
        }
    }

    public enum KiemTraSoLuong
    {
        ThieuCau,
        DuCau,
        ThuaCau,
    }
}
