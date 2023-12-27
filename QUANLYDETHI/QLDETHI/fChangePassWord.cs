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
    public partial class fChangePassWord : Form
    {
        private string currentUsername;
        private TaiKhoan globalUser;
        public fChangePassWord()
        {
            InitializeComponent();
            globalUser = LuuTru.User;
            currentUsername = globalUser.Username;
        }
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string oldPassword = TAIKHOAN.HashPassword(txbOldPassword.Text, globalUser.Salt);
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
                        user.Matkhau = TAIKHOAN.HashPassword(newPassword, user.Salt);
                        db.SaveChanges();
                        MessageBox.Show("Mật khẩu đã được thay đổi thành công.");
                        this.Close();
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
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
