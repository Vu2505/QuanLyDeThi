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

        public fLogin(string username)
        {
            InitializeComponent();
            txbUserName.Text = username;
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
                if(user.TinhTrang == 1)
                {
                    if (user.LoaiTaiKhoan == 3)
                    {
                        this.Hide();
                        fChangeResetPassWord f = new fChangeResetPassWord(user.Username);
                        f.ShowDialog();
                    }
                    else
                    {
                        LuuTru.User = user;
                        MainForm mainForm = new MainForm();
                        this.Hide();
                        mainForm.ShowDialog();
                        
                    }
                    LuuTru.User = new TaiKhoan();
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

        private void txbUserName_Click(object sender, EventArgs e)
        {
            txbUserName.BackColor = Color.White;
            panelUserName.BackColor = Color.White;
            panelPassword.BackColor = SystemColors.Control;
            txbPassWord.BackColor = SystemColors.Control;
        }

        private void txbPassWord_TextChanged(object sender, EventArgs e)
        {
            txbPassWord.BackColor = Color.White;
            panelPassword.BackColor = Color.White;
            panelUserName.BackColor = SystemColors.Control;
            txbUserName.BackColor = SystemColors.Control;
        }

        private void chbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbHienThi.Checked)
            {
                txbPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassWord.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                // Người dùng đã chọn OK, thoát chương trình
                Application.Exit();
            }
            else
            {
                // Người dùng đã chọn Cancel, không thoát chương trình
                cancel = true;
            }
        }

        private bool cancel = false;
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                // Người dùng đã chọn OK, thoát chương trình
                Application.Exit();
            }
            else
            {
                // Người dùng đã chọn Cancel, không thoát chương trình
                cancel = true;
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
