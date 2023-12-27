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
using DethiLayer.DTO;
using QLDETHI.Luutru;
namespace QLDETHI
{
    public partial class fChangeResetPassWord : Form
    {
        private string currentUsername;

        public fChangeResetPassWord()
        {
            InitializeComponent();
        }

        public fChangeResetPassWord(string username)
        {
            InitializeComponent();
            txbUserName.Text = username;
            currentUsername = username;
        }
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public bool KiemTra()
        {
            if (txbNewPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới !!!", "Thông báo");
                txbNewPassword.Focus();
                return false;
            }
            else if (txbAgainNewPassword.Text == "")
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu !!!", "Thông báo");
                txbAgainNewPassword.Focus();
                return false;
            }
            return true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string newPassword = txbNewPassword.Text;
            string newAgainPassword = txbAgainNewPassword.Text;

            // Kiểm tra mật khẩu cũ có đúng không (điều này phụ thuộc vào thiết kế cơ sở dữ liệu của bạn)
            var user = db.TaiKhoans.FirstOrDefault(u => u.Username == currentUsername && u.LoaiTaiKhoan == 3);

            if (KiemTra())
            {
                try
                {
                    if (user != null && newPassword == newAgainPassword)
                    {
                        // Cập nhật mật khẩu mới cho người dùng
                        user.Matkhau = TAIKHOAN.HashPassword(newPassword, user.Salt);
                        user.LoaiTaiKhoan = 2;
                        db.SaveChanges();
                        MessageBox.Show("Mật khẩu đã được thay đổi thành công.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu xác nhận không đúng!");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void chbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienThi.Checked)
            {
                txbNewPassword.Properties.UseSystemPasswordChar = false;
                txbAgainNewPassword.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txbNewPassword.Properties.UseSystemPasswordChar = true;
                txbAgainNewPassword.Properties.UseSystemPasswordChar = true;
            }
        }
    }
}
