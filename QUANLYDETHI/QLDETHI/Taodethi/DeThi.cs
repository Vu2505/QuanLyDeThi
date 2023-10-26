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

        public int SoLuongCauHoiDangTao { get => soLuongCauHoiDangTao; set => soLuongCauHoiDangTao = value; }

        public DeThi()
        {
            danhSachChuong = new List<Chuong>();
        }

        public DeThi(List<Chuong> danhSachChuong)
        {
            this.danhSachChuong = danhSachChuong;
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
            foreach(var item in danhSachChuong)
            {
                if(item.MaChuong == maChuong && item.KiemTraLaRong())
                {
                    return true;
                }
            }
            return false;
        }

        public bool KiemTraBaiCuaChuongRong(int maChuong, int maBai)
        {
            foreach (var chuong in danhSachChuong)
            {
                if (chuong.MaChuong == maChuong)
                {
                    foreach(var bai in chuong.DanhSachBai)
                    {
                        if (bai.MaBai == maBai && bai.KiemTraLaRong())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void CapNhatChuong(int maChuong, int soLuongCauDe, int soLuongCauTB, int soLuongCauKho)
        {
            foreach (var chuong in danhSachChuong)
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
                    return;
                }
            }
        }

        public void CapNhatBaiCuaChuong(int maChuong, int maBai, int soLuongCauDe, int soLuongCauTB, int soLuongCauKho)
        {
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
            }
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
    }


    public class Chuong
    {
        private int maChuong;
        private int soLuongCauDe;
        private int soLuongCauTB;
        private int soLuongCauKho;
        private HashSet<Bai> danhSachBai;

        public int MaChuong { get => maChuong;}
        public int SoLuongCauDe { get => soLuongCauDe; set => soLuongCauDe = value; }
        public int SoLuongCauTB { get => soLuongCauTB; set => soLuongCauTB = value; }
        public int SoLuongCauKho { get => soLuongCauKho; set => soLuongCauKho = value; }
        public int SoLuongCau { get => soLuongCauDe + soLuongCauTB + soLuongCauKho; }
        public HashSet<Bai> DanhSachBai { get => danhSachBai; }
        

        public Chuong(int maChuong)
        {
            this.maChuong = maChuong;
            danhSachBai = new HashSet<Bai>();
        }

        public bool KiemTraLaRong()
        {
            return SoLuongCau == 0;
        }

        public void ThemBai(Bai bai)
        {
            danhSachBai.Add(bai);
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
    }
}
