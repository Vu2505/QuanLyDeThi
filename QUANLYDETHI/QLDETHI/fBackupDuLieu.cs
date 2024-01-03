using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class fBackupDuLieu : DevExpress.XtraEditors.XtraForm
    {
        public fBackupDuLieu()
        {
            InitializeComponent();
        }

        private void fBackupDuLieu_Load(object sender, EventArgs e)
        {
            txtUrl.Enabled = false;
            btnBackup.Enabled = false;
        }

        //SqlConnection con = new SqlConnection("data source=.;initial catalog=DETHITRACNGHIEM;user id=sa;password=123;");
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                txtUrl.Text = fb.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(Luutru.LuuTru.ConnectionString))
            {
                string db = connection.Database.ToString();
                if (string.IsNullOrEmpty(txtUrl.Text))
                {
                    MessageBox.Show("Vui lòng chọn đường dẫn file backup.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                    string sql = "BACKUP DATABASE [" + db + "] TO DISK = '" + txtUrl.Text + "\\" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    //SplashScreenManager.CloseForm(true);
                    MessageBox.Show("Backup dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBackup.Enabled = false;
                }
            }
        }
    }
}