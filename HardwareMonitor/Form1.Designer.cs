namespace HardwareMonitor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pnlCpu = new System.Windows.Forms.Panel();
            this.lblCpuBaslik = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCpu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCpuYuk = new System.Windows.Forms.Label();
            this.pnlGpu = new System.Windows.Forms.Panel();
            this.lblGpuBaslik = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGpuSicaklik = new System.Windows.Forms.Label();
            this.labelGpuYuk = new System.Windows.Forms.Label();
            this.lblGpuYuk = new System.Windows.Forms.Label();
            this.labelVram = new System.Windows.Forms.Label();
            this.lblVram = new System.Windows.Forms.Label();
            this.pnlRam = new System.Windows.Forms.Panel();
            this.lblRamBaslik = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRam = new System.Windows.Forms.Label();
            this.labelRamGb = new System.Windows.Forms.Label();
            this.lblRamGb = new System.Windows.Forms.Label();
            this.chkOtomatikBaslat = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAlarmEkle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGeriAl = new System.Windows.Forms.Button();
            this.dgvAlarmlar = new System.Windows.Forms.DataGridView();
            this.systemNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlCpu.SuspendLayout();
            this.pnlGpu.SuspendLayout();
            this.pnlRam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(980, 44);
            this.pnlHeader.TabIndex = 99;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(980, 44);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "⚡  RealTime SysTracker";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCpu
            // 
            this.pnlCpu.Controls.Add(this.lblCpuBaslik);
            this.pnlCpu.Controls.Add(this.label1);
            this.pnlCpu.Controls.Add(this.lblCpu);
            this.pnlCpu.Controls.Add(this.label4);
            this.pnlCpu.Controls.Add(this.lblCpuYuk);
            this.pnlCpu.Location = new System.Drawing.Point(10, 47);
            this.pnlCpu.Name = "pnlCpu";
            this.pnlCpu.Size = new System.Drawing.Size(278, 178);
            this.pnlCpu.TabIndex = 100;
            // 
            // lblCpuBaslik
            // 
            this.lblCpuBaslik.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCpuBaslik.Location = new System.Drawing.Point(12, 10);
            this.lblCpuBaslik.Name = "lblCpuBaslik";
            this.lblCpuBaslik.Size = new System.Drawing.Size(250, 24);
            this.lblCpuBaslik.TabIndex = 0;
            this.lblCpuBaslik.Text = "▌  CPU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sıcaklık (°C)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblCpu
            // 
            this.lblCpu.AutoSize = true;
            this.lblCpu.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCpu.Location = new System.Drawing.Point(14, 68);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(31, 30);
            this.lblCpu.TabIndex = 2;
            this.lblCpu.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Yük (%)";
            // 
            // lblCpuYuk
            // 
            this.lblCpuYuk.AutoSize = true;
            this.lblCpuYuk.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCpuYuk.Location = new System.Drawing.Point(14, 122);
            this.lblCpuYuk.Name = "lblCpuYuk";
            this.lblCpuYuk.Size = new System.Drawing.Size(31, 30);
            this.lblCpuYuk.TabIndex = 4;
            this.lblCpuYuk.Text = "--";
            // 
            // pnlGpu
            // 
            this.pnlGpu.Controls.Add(this.lblGpuBaslik);
            this.pnlGpu.Controls.Add(this.label5);
            this.pnlGpu.Controls.Add(this.lblGpuSicaklik);
            this.pnlGpu.Controls.Add(this.labelGpuYuk);
            this.pnlGpu.Controls.Add(this.lblGpuYuk);
            this.pnlGpu.Controls.Add(this.labelVram);
            this.pnlGpu.Controls.Add(this.lblVram);
            this.pnlGpu.Location = new System.Drawing.Point(337, 47);
            this.pnlGpu.Name = "pnlGpu";
            this.pnlGpu.Size = new System.Drawing.Size(308, 178);
            this.pnlGpu.TabIndex = 101;
            // 
            // lblGpuBaslik
            // 
            this.lblGpuBaslik.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGpuBaslik.Location = new System.Drawing.Point(12, 10);
            this.lblGpuBaslik.Name = "lblGpuBaslik";
            this.lblGpuBaslik.Size = new System.Drawing.Size(250, 24);
            this.lblGpuBaslik.TabIndex = 0;
            this.lblGpuBaslik.Text = "▌  GPU";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label5.Location = new System.Drawing.Point(14, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Sıcaklık (°C)";
            // 
            // lblGpuSicaklik
            // 
            this.lblGpuSicaklik.AutoSize = true;
            this.lblGpuSicaklik.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGpuSicaklik.Location = new System.Drawing.Point(14, 65);
            this.lblGpuSicaklik.Name = "lblGpuSicaklik";
            this.lblGpuSicaklik.Size = new System.Drawing.Size(31, 30);
            this.lblGpuSicaklik.TabIndex = 2;
            this.lblGpuSicaklik.Text = "--";
            // 
            // labelGpuYuk
            // 
            this.labelGpuYuk.AutoSize = true;
            this.labelGpuYuk.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.labelGpuYuk.Location = new System.Drawing.Point(14, 97);
            this.labelGpuYuk.Name = "labelGpuYuk";
            this.labelGpuYuk.Size = new System.Drawing.Size(58, 20);
            this.labelGpuYuk.TabIndex = 3;
            this.labelGpuYuk.Text = "Yük (%)";
            // 
            // lblGpuYuk
            // 
            this.lblGpuYuk.AutoSize = true;
            this.lblGpuYuk.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblGpuYuk.Location = new System.Drawing.Point(14, 112);
            this.lblGpuYuk.Name = "lblGpuYuk";
            this.lblGpuYuk.Size = new System.Drawing.Size(31, 30);
            this.lblGpuYuk.TabIndex = 4;
            this.lblGpuYuk.Text = "--";
            // 
            // labelVram
            // 
            this.labelVram.AutoSize = true;
            this.labelVram.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.labelVram.Location = new System.Drawing.Point(14, 140);
            this.labelVram.Name = "labelVram";
            this.labelVram.Size = new System.Drawing.Size(50, 20);
            this.labelVram.TabIndex = 5;
            this.labelVram.Text = "VRAM";
            // 
            // lblVram
            // 
            this.lblVram.AutoSize = true;
            this.lblVram.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVram.Location = new System.Drawing.Point(70, 139);
            this.lblVram.Name = "lblVram";
            this.lblVram.Size = new System.Drawing.Size(21, 20);
            this.lblVram.TabIndex = 6;
            this.lblVram.Text = "--";
            // 
            // pnlRam
            // 
            this.pnlRam.Controls.Add(this.lblRamBaslik);
            this.pnlRam.Controls.Add(this.label2);
            this.pnlRam.Controls.Add(this.lblRam);
            this.pnlRam.Controls.Add(this.labelRamGb);
            this.pnlRam.Controls.Add(this.lblRamGb);
            this.pnlRam.Location = new System.Drawing.Point(693, 47);
            this.pnlRam.Name = "pnlRam";
            this.pnlRam.Size = new System.Drawing.Size(275, 178);
            this.pnlRam.TabIndex = 102;
            // 
            // lblRamBaslik
            // 
            this.lblRamBaslik.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblRamBaslik.Location = new System.Drawing.Point(7, 10);
            this.lblRamBaslik.Name = "lblRamBaslik";
            this.lblRamBaslik.Size = new System.Drawing.Size(265, 24);
            this.lblRamBaslik.TabIndex = 0;
            this.lblRamBaslik.Text = "▌  RAM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanım (%)";
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRam.Location = new System.Drawing.Point(14, 65);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(31, 30);
            this.lblRam.TabIndex = 2;
            this.lblRam.Text = "--";
            // 
            // labelRamGb
            // 
            this.labelRamGb.AutoSize = true;
            this.labelRamGb.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.labelRamGb.Location = new System.Drawing.Point(14, 97);
            this.labelRamGb.Name = "labelRamGb";
            this.labelRamGb.Size = new System.Drawing.Size(99, 20);
            this.labelRamGb.TabIndex = 3;
            this.labelRamGb.Text = "Kapasite (GB)";
            // 
            // lblRamGb
            // 
            this.lblRamGb.AutoSize = true;
            this.lblRamGb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRamGb.Location = new System.Drawing.Point(14, 112);
            this.lblRamGb.Name = "lblRamGb";
            this.lblRamGb.Size = new System.Drawing.Size(24, 23);
            this.lblRamGb.TabIndex = 4;
            this.lblRamGb.Text = "--";
            // 
            // chkOtomatikBaslat
            // 
            this.chkOtomatikBaslat.AutoSize = true;
            this.chkOtomatikBaslat.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkOtomatikBaslat.Location = new System.Drawing.Point(356, 230);
            this.chkOtomatikBaslat.Name = "chkOtomatikBaslat";
            this.chkOtomatikBaslat.Size = new System.Drawing.Size(156, 24);
            this.chkOtomatikBaslat.TabIndex = 5;
            this.chkOtomatikBaslat.Text = "Windows ile Başlat";
            this.chkOtomatikBaslat.UseVisualStyleBackColor = false;
            this.chkOtomatikBaslat.CheckedChanged += new System.EventHandler(this.chkOtomatikBaslat_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "📊 Grafikleri Gör";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAlarmEkle
            // 
            this.btnAlarmEkle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAlarmEkle.Location = new System.Drawing.Point(10, 252);
            this.btnAlarmEkle.Name = "btnAlarmEkle";
            this.btnAlarmEkle.Size = new System.Drawing.Size(175, 36);
            this.btnAlarmEkle.TabIndex = 7;
            this.btnAlarmEkle.Text = "＋  Yeni Alarm Ekle";
            this.btnAlarmEkle.UseVisualStyleBackColor = true;
            this.btnAlarmEkle.Click += new System.EventHandler(this.btnAlarmEkle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(198, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ara:";
            // 
            // txtArama
            // 
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArama.Location = new System.Drawing.Point(239, 260);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(150, 27);
            this.txtArama.TabIndex = 10;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSil.Location = new System.Drawing.Point(677, 254);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(171, 36);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "🗑  Seçili Olanı Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGeriAl
            // 
            this.btnGeriAl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnGeriAl.Location = new System.Drawing.Point(854, 254);
            this.btnGeriAl.Name = "btnGeriAl";
            this.btnGeriAl.Size = new System.Drawing.Size(114, 36);
            this.btnGeriAl.TabIndex = 9;
            this.btnGeriAl.Text = "↩  Geri Al";
            this.btnGeriAl.UseVisualStyleBackColor = true;
            this.btnGeriAl.Click += new System.EventHandler(this.btnGeriAl_Click);
            // 
            // dgvAlarmlar
            // 
            this.dgvAlarmlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmlar.Location = new System.Drawing.Point(10, 303);
            this.dgvAlarmlar.Name = "dgvAlarmlar";
            this.dgvAlarmlar.RowHeadersWidth = 51;
            this.dgvAlarmlar.RowTemplate.Height = 28;
            this.dgvAlarmlar.Size = new System.Drawing.Size(958, 222);
            this.dgvAlarmlar.TabIndex = 6;
            this.dgvAlarmlar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlarmlar_CellDoubleClick);
            // 
            // systemNotification
            // 
            this.systemNotification.ContextMenuStrip = this.contextMenuStrip1;
            this.systemNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("systemNotification.Icon")));
            this.systemNotification.Text = "RealTime SysTracker";
            this.systemNotification.Visible = true;
            this.systemNotification.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.systemNotification_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çıkışToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 572);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCpu);
            this.Controls.Add(this.pnlGpu);
            this.Controls.Add(this.pnlRam);
            this.Controls.Add(this.chkOtomatikBaslat);
            this.Controls.Add(this.btnAlarmEkle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGeriAl);
            this.Controls.Add(this.dgvAlarmlar);
            this.Name = "Form1";
            this.Text = "RealTime SysTracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.pnlHeader.ResumeLayout(false);
            this.pnlCpu.ResumeLayout(false);
            this.pnlCpu.PerformLayout();
            this.pnlGpu.ResumeLayout(false);
            this.pnlGpu.PerformLayout();
            this.pnlRam.ResumeLayout(false);
            this.pnlRam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Panel pnlCpu;
        private System.Windows.Forms.Panel pnlGpu;
        private System.Windows.Forms.Panel pnlRam;
        private System.Windows.Forms.Label lblCpuBaslik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCpuYuk;
        private System.Windows.Forms.Label lblGpuBaslik;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGpuSicaklik;
        private System.Windows.Forms.Label labelGpuYuk;
        private System.Windows.Forms.Label lblGpuYuk;
        private System.Windows.Forms.Label labelVram;
        private System.Windows.Forms.Label lblVram;
        private System.Windows.Forms.Label lblRamBaslik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.Label labelRamGb;
        private System.Windows.Forms.Label lblRamGb;
        private System.Windows.Forms.CheckBox chkOtomatikBaslat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAlarmEkle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGeriAl;
        private System.Windows.Forms.DataGridView dgvAlarmlar;
        private System.Windows.Forms.NotifyIcon systemNotification;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}