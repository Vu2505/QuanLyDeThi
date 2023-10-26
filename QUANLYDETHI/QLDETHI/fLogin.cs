using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using DethiLayer;
using QLDETHI.Luutru;

namespace QLDETHI
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        TAIKHOAN _taikhoan;
        private void btn_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            _taikhoan = new TAIKHOAN();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan user = _taikhoan.Login(txbUserName.Text, txbPassWord.Text);

            if (user != null)
            {
                LuuTru.User = user;
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        //public bool Login(string username, string password)
        //{
        //    using (DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities())
        //    {
        //        // Kiểm tra tài khoản dựa trên tên đăng nhập và mật khẩu.
        //        TaiKhoan taiKhoan = db.TaiKhoans.FirstOrDefault(tk => tk.Username == username && tk.Matkhau == password);

        //        if (taiKhoan != null)
        //        {
        //            // Đăng nhập thành công, tại đây bạn có thể lấy thông tin tài khoản hoặc làm bất kỳ công việc nào cần thiết.
        //            return true;
        //        }
        //    }

        //    return false; // Đăng nhập thất bại
        //}
    }
}
