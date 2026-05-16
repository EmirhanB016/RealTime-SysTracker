namespace HardwareMonitor
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCpu = new System.Windows.Forms.Label();
            this.lblRam = new System.Windows.Forms.Label();
            this.dgvAlarmlar = new System.Windows.Forms.DataGridView();
            this.btnAlarmEkle = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGeriAl = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCpuYuk = new System.Windows.Forms.Label();
            this.lblGpuSicaklik = new System.Windows.Forms.Label();
            this.systemNotification = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "İşlemci Sıcaklığı (°C)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "RAM Kullanımı (%)";
            // 
            // lblCpu
            // 
            this.lblCpu.AutoSize = true;
            this.lblCpu.Location = new System.Drawing.Point(164, 37);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(44, 16);
            this.lblCpu.TabIndex = 2;
            this.lblCpu.Text = "label3";
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Location = new System.Drawing.Point(164, 73);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(44, 16);
            this.lblRam.TabIndex = 3;
            this.lblRam.Text = "label4";
            // 
            // dgvAlarmlar
            // 
            this.dgvAlarmlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmlar.Location = new System.Drawing.Point(108, 260);
            this.dgvAlarmlar.Name = "dgvAlarmlar";
            this.dgvAlarmlar.RowHeadersWidth = 51;
            this.dgvAlarmlar.RowTemplate.Height = 24;
            this.dgvAlarmlar.Size = new System.Drawing.Size(631, 178);
            this.dgvAlarmlar.TabIndex = 6;
            this.dgvAlarmlar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlarmlar_CellDoubleClick);
            // 
            // btnAlarmEkle
            // 
            this.btnAlarmEkle.Location = new System.Drawing.Point(189, 216);
            this.btnAlarmEkle.Name = "btnAlarmEkle";
            this.btnAlarmEkle.Size = new System.Drawing.Size(150, 29);
            this.btnAlarmEkle.TabIndex = 7;
            this.btnAlarmEkle.Text = "Yeni Alarm Ekle";
            this.btnAlarmEkle.UseVisualStyleBackColor = true;
            this.btnAlarmEkle.Click += new System.EventHandler(this.btnAlarmEkle_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(562, 179);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(116, 31);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "Seçili Olanı Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGeriAl
            // 
            this.btnGeriAl.Location = new System.Drawing.Point(579, 216);
            this.btnGeriAl.Name = "btnGeriAl";
            this.btnGeriAl.Size = new System.Drawing.Size(80, 29);
            this.btnGeriAl.TabIndex = 9;
            this.btnGeriAl.Text = "Geri Al";
            this.btnGeriAl.UseVisualStyleBackColor = true;
            this.btnGeriAl.Click += new System.EventHandler(this.btnGeriAl_Click);
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(374, 223);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(139, 22);
            this.txtArama.TabIndex = 10;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Donanım Ara";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "CPU Yüzdesi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ekran Kartı Sıcaklığı:";
            // 
            // lblCpuYuk
            // 
            this.lblCpuYuk.AutoSize = true;
            this.lblCpuYuk.Location = new System.Drawing.Point(164, 111);
            this.lblCpuYuk.Name = "lblCpuYuk";
            this.lblCpuYuk.Size = new System.Drawing.Size(44, 16);
            this.lblCpuYuk.TabIndex = 14;
            this.lblCpuYuk.Text = "label6";
            // 
            // lblGpuSicaklik
            // 
            this.lblGpuSicaklik.AutoSize = true;
            this.lblGpuSicaklik.Location = new System.Drawing.Point(164, 146);
            this.lblGpuSicaklik.Name = "lblGpuSicaklik";
            this.lblGpuSicaklik.Size = new System.Drawing.Size(44, 16);
            this.lblGpuSicaklik.TabIndex = 15;
            this.lblGpuSicaklik.Text = "label7";
            // 
            // systemNotification
            // 
            this.systemNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("systemNotification.Icon")));
            this.systemNotification.Text = "notifyIcon1";
            this.systemNotification.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblGpuSicaklik);
            this.Controls.Add(this.lblCpuYuk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.btnGeriAl);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnAlarmEkle);
            this.Controls.Add(this.dgvAlarmlar);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.lblCpu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Sistem Monitörü ve Loglama";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.DataGridView dgvAlarmlar;
        private System.Windows.Forms.Button btnAlarmEkle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGeriAl;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCpuYuk;
        private System.Windows.Forms.Label lblGpuSicaklik;
        private System.Windows.Forms.NotifyIcon systemNotification;
    }
}

