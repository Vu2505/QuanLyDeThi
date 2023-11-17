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
    public partial class fChangePassWord : Form
    {
        private string currentUsername;
        private TaiKhoan user;
        public fChangePassWord()
        {
            InitializeComponent();
            user = LuuTru.User;
            currentUsername = user.Username;
        }
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string oldPassword = txbOldPassword.Text;
            string newPassword = txbNewPassword.Text;

            // Kiểm tra mật khẩu cũ có đúng không (điều này phụ thuộc vào thiết kế cơ sở dữ liệu của bạn)
            var user = db.TaiKhoans.FirstOrDefault(u => u.Username == currentUsername && u.Matkhau == oldPassword);

            if (KiemTra())
            {
                try
                {
                    if (user == null)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng.");
                    }
                    else
                    {
                        // Cập nhật mật khẩu mới cho người dùng
                        user.Matkhau = newPassword;
                        db.SaveChanges();
                        MessageBox.Show("Mật khẩu đã được thay đổi thành công.");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        public bool KiemTra()
        {

            if (txbOldPassword.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại !!!", "Thông báo");
                txbOldPassword.Focus();
                return false;
            }
            else if (txbNewPassword.Text == "")
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

        private void chbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienThi.Checked)
            {
                txbOldPassword.Properties.UseSystemPasswordChar = false;
                txbNewPassword.Properties.UseSystemPasswordChar = false;
                txbAgainNewPassword.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txbOldPassword.Properties.UseSystemPasswordChar = true;
                txbNewPassword.Properties.UseSystemPasswordChar = true;
                txbAgainNewPassword.Properties.UseSystemPasswordChar = true;
            }
        }


        //private void txbAgainNewPassword_TextChanged(object sender, EventArgs e)
        //{
        //    if (txbNewPassword.Text != txbAgainNewPassword.Text)
        //    {
        //        ptbDeny.Visible = true;
        //        ptbAccept.Visible = false;
        //        btnUpdate.Enabled = false;
        //    }
        //    else
        //    {
        //        ptbDeny.Visible = false;
        //        ptbAccept.Visible = true;
        //        btnUpdate.Enabled = true;
        //    }
        //}
    }
}
