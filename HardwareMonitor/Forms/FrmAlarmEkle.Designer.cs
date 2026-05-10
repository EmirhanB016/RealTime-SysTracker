namespace HardwareMonitor.Forms
{
    partial class FrmAlarmEkle
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
            this.cmbDonanim = new System.Windows.Forms.ComboBox();
            this.txtSinirDeger = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDonanim
            // 
            this.cmbDonanim.FormattingEnabled = true;
            this.cmbDonanim.Items.AddRange(new object[] {
            "İşlemci Sıcaklığı",
            "RAM Kullanımı"});
            this.cmbDonanim.Location = new System.Drawing.Point(86, 181);
            this.cmbDonanim.Name = "cmbDonanim";
            this.cmbDonanim.Size = new System.Drawing.Size(121, 24);
            this.cmbDonanim.TabIndex = 0;
            // 
            // txtSinirDeger
            // 
            this.txtSinirDeger.Location = new System.Drawing.Point(270, 183);
            this.txtSinirDeger.Name = "txtSinirDeger";
            this.txtSinirDeger.Size = new System.Drawing.Size(100, 22);
            this.txtSinirDeger.TabIndex = 1;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(313, 307);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Donanım Seçin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sınır Değer Girin";
            // 
            // FrmAlarmEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtSinirDeger);
            this.Controls.Add(this.cmbDonanim);
            this.Name = "FrmAlarmEkle";
            this.Text = "Yeni Alarm Kuralı Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDonanim;
        private System.Windows.Forms.TextBox txtSinirDeger;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}