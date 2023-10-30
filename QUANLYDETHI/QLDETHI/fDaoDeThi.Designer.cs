
namespace QLDETHI
{
    partial class fDaoDeThi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.nbSoLuongDe = new System.Windows.Forms.NumericUpDown();
            this.btnDaoDe = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nbSoLuongDe)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(58, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(143, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số lượng đề muốn tạo:";
            // 
            // nbSoLuongDe
            // 
            this.nbSoLuongDe.Location = new System.Drawing.Point(217, 52);
            this.nbSoLuongDe.Name = "nbSoLuongDe";
            this.nbSoLuongDe.Size = new System.Drawing.Size(144, 22);
            this.nbSoLuongDe.TabIndex = 1;
            // 
            // btnDaoDe
            // 
            this.btnDaoDe.Location = new System.Drawing.Point(75, 109);
            this.btnDaoDe.Name = "btnDaoDe";
            this.btnDaoDe.Size = new System.Drawing.Size(138, 38);
            this.btnDaoDe.TabIndex = 2;
            this.btnDaoDe.Text = "Đảo đề";
            this.btnDaoDe.UseVisualStyleBackColor = true;
            this.btnDaoDe.Click += new System.EventHandler(this.btnDaoDe_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(237, 109);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(118, 38);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // fDaoDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 207);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDaoDe);
            this.Controls.Add(this.nbSoLuongDe);
            this.Controls.Add(this.labelControl1);
            this.Name = "fDaoDeThi";
            this.Text = "fDaoDeThi";
            this.Load += new System.EventHandler(this.fDaoDeThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nbSoLuongDe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.NumericUpDown nbSoLuongDe;
        private System.Windows.Forms.Button btnDaoDe;
        private System.Windows.Forms.Button btnHuy;
    }
}