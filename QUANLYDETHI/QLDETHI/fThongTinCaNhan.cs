using DataLayer;
using DethiLayer.DTO;
using QLDETHI.Luutru;
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
namespace QLDETHI
{
    public partial class fThongTinCaNhan : Form
    {
        private TaiKhoan user;
        int IdTK;
        TAIKHOAN _taikhoan;
        public fThongTinCaNhan()
        {
            InitializeComponent();
            user = LuuTru.User;
            IdTK = user.IdTK;
        }

        private void fThongTinCaNhan_Load(object sender, EventArgs e)
        {
            _taikhoan = new TAIKHOAN();
            label8.Text = user.TenGV;
            label7.Text = user.Username;
            

            var tk = _taikhoan.getListFullTK(IdTK);
            if (tk.Any())
            {
                var tkInfo = tk.First();
                label5.Text = tkInfo.TenTinhTrang;
                label6.Text = tkInfo.TenLoaiTaiKhoan;
            }
        }
    }
}
