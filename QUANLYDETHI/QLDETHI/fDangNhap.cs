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
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }
        TAIKHOAN _taikhoan;

        public fDangNhap(string username)
        {
            InitializeComponent();
            txbUserName.Text = username;
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            _taikhoan = new TAIKHOAN();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        



        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;

            if (userName == null || userName == ""
                || passWord == null || passWord == "")
            {
                MessageBox.Show("Chưa nhập username hay password");
                return;
            }
            TaiKhoan user = _taikhoan.Login(txbUserName.Text, txbPassWord.Text);

            if (user != null)
            {
                LuuTru.User = user;
                if (user.TinhTrang == 1)
                {
                    if (user.LoaiTaiKhoan == 3)
                    {
                        this.Hide();
                        fChangeResetPassWord f = new fChangeResetPassWord(user.Username);
                        f.ShowDialog();
                        return;
                    }

                    else
                    {
                        MainForm mainForm = new MainForm();
                        this.Hide();
                        mainForm.ShowDialog();

                    }

                    txbPassWord.Text = "";
                    this.Show();

                    return;
                }
                else
                {
                    MessageBox.Show("Tài khoản bị vô hiệu hóa");
                }

            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


    }
}
