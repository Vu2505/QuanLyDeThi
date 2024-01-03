using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

        public static string ConnectionString => DecryptConnectionString(EncryptConnectionString(
            ConfigurationManager.ConnectionStrings["DETHITRACNGHIEMEntities"].ConnectionString));
        private const string EncryptionKey = "YourEncryptionKey"; // Thay đổi khóa theo nhu cầu của bạn

        private static string EncryptConnectionString(string connectionString)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(connectionString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    connectionString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return connectionString;
        }

        private static string DecryptConnectionString(string encryptedConnectionString)
        {
            byte[] cipherBytes = Convert.FromBase64String(encryptedConnectionString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    encryptedConnectionString = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            // Tìm vị trí bắt đầu của connection string
            int start = encryptedConnectionString.IndexOf("data source=");

            if (start != -1)
            {
                // Tìm vị trí kết thúc của connection string
                // Lấy connection string từ metadata
                int end = encryptedConnectionString.LastIndexOf('"');
                if (end != -1)
                {
                    encryptedConnectionString = encryptedConnectionString.Substring(start, end - start);
                }

            }

            return encryptedConnectionString;
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
