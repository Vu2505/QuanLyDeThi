using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDETHI.Luutru
{
    public class LuuTru
    {
        private static TaiKhoan user;
        public static TaiKhoan User
        {
            get { return user; }
            set { user = value; }
        }
    }

    //class LuuTru
    //{
    //    static void Main(string[] args)
    //    {
    //        TaiKhoan user = new TaiKhoan();
    //        bool dangNhapHopLe = true;
    //        if(dangNhapHopLe)
    //        {
    //            LuuTru.User = user;
    //            Console.WriteLine(LuuTru.User);
    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid");
    //        }
    //        Console.ReadLine();
    //    }
    //}
}
