using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDETHI
{
    public partial class fKhoiPhucDuLieu : DevExpress.XtraEditors.XtraForm
    {
        
        public fKhoiPhucDuLieu()
        {
            InitializeComponent();
        }                

        //SqlConnection con = new SqlConnection("data source=.;initial catalog=DETHITRACNGHIEM;user id=sa;password=123;");
        private void fKhoiPhucDuLieu_Load(object sender, EventArgs e)
        {
            txtUrl.Enabled = false;
            btnRestone.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Backup file (.bak)|*.bak";
            openFile.Title = "Phục hồi dữ liệu";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtUrl.Text = openFile.FileName;
                btnRestone.Enabled = true;
            }
        }

        private void btnRestone_Click(object sender, EventArgs e)
        {
            //SqlConnection connection = new SqlConnection(DecryptConnectionString("yourEncryptedConnectionString"));
            //string database = "DETHITRACNGHIEM";
            //string connectionString = "data source=.;initial catalog=" + database + ";user id=sa;password=123;";

            using (SqlConnection connection = new SqlConnection(Luutru.LuuTru.ConnectionString))
            {
                connection.Open();
                try
                {
                    string database = connection.Database;
                    string sql1 = "ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    SqlCommand cmd1 = new SqlCommand(sql1, connection);
                    cmd1.ExecuteNonQuery();

                    string sql2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK ='" + txtUrl.Text + "' WITH REPLACE";
                    SqlCommand cmd2 = new SqlCommand(sql2, connection);
                    cmd2.ExecuteNonQuery();

                    string sql3 = "ALTER DATABASE [" + database + "] SET MULTI_USER";
                    SqlCommand cmd3 = new SqlCommand(sql3, connection);
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Khôi phục dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRestone.Enabled = false;
                }
                catch (Exception ex)
                {
                    btnRestone.Enabled = false;
                    MessageBox.Show("Khôi phục dữ liệu không thành công. Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}