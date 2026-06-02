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

            this.pnlHeader          = new System.Windows.Forms.Panel();
            this.lblAppTitle        = new System.Windows.Forms.Label();
            this.pnlCpu             = new System.Windows.Forms.Panel();
            this.pnlGpu             = new System.Windows.Forms.Panel();
            this.pnlRam             = new System.Windows.Forms.Panel();

            this.lblCpuBaslik       = new System.Windows.Forms.Label();
            this.label1             = new System.Windows.Forms.Label();
            this.lblCpu             = new System.Windows.Forms.Label();
            this.label4             = new System.Windows.Forms.Label();
            this.lblCpuYuk          = new System.Windows.Forms.Label();

            this.lblGpuBaslik       = new System.Windows.Forms.Label();
            this.label5             = new System.Windows.Forms.Label();
            this.lblGpuSicaklik     = new System.Windows.Forms.Label();
            this.labelGpuYuk        = new System.Windows.Forms.Label();
            this.lblGpuYuk          = new System.Windows.Forms.Label();
            this.labelVram          = new System.Windows.Forms.Label();
            this.lblVram            = new System.Windows.Forms.Label();

            this.lblRamBaslik       = new System.Windows.Forms.Label();
            this.label2             = new System.Windows.Forms.Label();
            this.lblRam             = new System.Windows.Forms.Label();
            this.labelRamGb         = new System.Windows.Forms.Label();
            this.lblRamGb           = new System.Windows.Forms.Label();
            this.chkOtomatikBaslat  = new System.Windows.Forms.CheckBox();
            this.button1            = new System.Windows.Forms.Button();

            this.btnAlarmEkle       = new System.Windows.Forms.Button();
            this.label3             = new System.Windows.Forms.Label();
            this.txtArama           = new System.Windows.Forms.TextBox();
            this.btnSil             = new System.Windows.Forms.Button();
            this.btnGeriAl          = new System.Windows.Forms.Button();
            this.dgvAlarmlar        = new System.Windows.Forms.DataGridView();

            this.systemNotification     = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1      = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1             = new System.Windows.Forms.Timer(this.components);
            this.timer2             = new System.Windows.Forms.Timer(this.components);

            this.pnlHeader.SuspendLayout();
            this.pnlCpu.SuspendLayout();
            this.pnlGpu.SuspendLayout();
            this.pnlRam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();

            // ── HEADER ──
            this.pnlHeader.Dock    = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height  = 44;
            this.pnlHeader.Name    = "pnlHeader";
            this.pnlHeader.TabIndex = 99;
            this.pnlHeader.Controls.Add(this.lblAppTitle);

            this.lblAppTitle.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblAppTitle.Name      = "lblAppTitle";
            this.lblAppTitle.Text      = "⚡  RealTime SysTracker";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.TabIndex  = 0;

            // ── CPU KARTI ──
            this.pnlCpu.Location = new System.Drawing.Point(10, 52);
            this.pnlCpu.Name     = "pnlCpu";
            this.pnlCpu.Size     = new System.Drawing.Size(278, 162);
            this.pnlCpu.TabIndex = 100;
            this.pnlCpu.Controls.Add(this.lblCpuBaslik);
            this.pnlCpu.Controls.Add(this.label1);
            this.pnlCpu.Controls.Add(this.lblCpu);
            this.pnlCpu.Controls.Add(this.label4);
            this.pnlCpu.Controls.Add(this.lblCpuYuk);

            this.lblCpuBaslik.AutoSize = false;
            this.lblCpuBaslik.Location = new System.Drawing.Point(12, 10);
            this.lblCpuBaslik.Size     = new System.Drawing.Size(250, 24);
            this.lblCpuBaslik.Text     = "▌  CPU";
            this.lblCpuBaslik.Font     = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCpuBaslik.TabIndex = 0;

            this.label1.AutoSize  = true;
            this.label1.Location  = new System.Drawing.Point(14, 50);
            this.label1.Text      = "Sıcaklık (°C)";
            this.label1.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label1.TabIndex  = 1;
            this.label1.Click    += new System.EventHandler(this.label1_Click);

            this.lblCpu.AutoSize  = true;
            this.lblCpu.Location  = new System.Drawing.Point(14, 68);
            this.lblCpu.Text      = "--";
            this.lblCpu.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCpu.TabIndex  = 2;

            this.label4.AutoSize  = true;
            this.label4.Location  = new System.Drawing.Point(14, 104);
            this.label4.Text      = "Yük (%)";
            this.label4.Font      = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label4.TabIndex  = 3;

            this.lblCpuYuk.AutoSize  = true;
            this.lblCpuYuk.Location  = new System.Drawing.Point(14, 122);
            this.lblCpuYuk.Text      = "--";
            this.lblCpuYuk.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCpuYuk.TabIndex  = 4;

            // ── GPU KARTI ──
            this.pnlGpu.Location = new System.Drawing.Point(298, 52);
            this.pnlGpu.Name     = "pnlGpu";
            this.pnlGpu.Size     = new System.Drawing.Size(278, 162);
            this.pnlGpu.TabIndex = 101;
            this.pnlGpu.Controls.Add(this.lblGpuBaslik);
            this.pnlGpu.Controls.Add(this.label5);
            this.pnlGpu.Controls.Add(this.lblGpuSicaklik);
            this.pnlGpu.Controls.Add(this.labelGpuYuk);
            this.pnlGpu.Controls.Add(this.lblGpuYuk);
            this.pnlGpu.Controls.Add(this.labelVram);
            this.pnlGpu.Controls.Add(this.lblVram);

            this.lblGpuBaslik.AutoSize = false;
            this.lblGpuBaslik.Location = new System.Drawing.Point(12, 10);
            this.lblGpuBaslik.Size     = new System.Drawing.Size(250, 24);
            this.lblGpuBaslik.Text     = "▌  GPU";
            this.lblGpuBaslik.Font     = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblGpuBaslik.TabIndex = 0;

            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(14, 50);
            this.label5.Text = "Sıcaklık (°C)"; this.label5.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.label5.TabIndex = 1;

            this.lblGpuSicaklik.AutoSize = true; this.lblGpuSicaklik.Location = new System.Drawing.Point(14, 65);
            this.lblGpuSicaklik.Text = "--"; this.lblGpuSicaklik.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold); this.lblGpuSicaklik.TabIndex = 2;

            this.labelGpuYuk.AutoSize = true; this.labelGpuYuk.Location = new System.Drawing.Point(14, 97);
            this.labelGpuYuk.Text = "Yük (%)"; this.labelGpuYuk.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.labelGpuYuk.TabIndex = 3;

            this.lblGpuYuk.AutoSize = true; this.lblGpuYuk.Location = new System.Drawing.Point(14, 112);
            this.lblGpuYuk.Text = "--"; this.lblGpuYuk.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold); this.lblGpuYuk.TabIndex = 4;

            this.labelVram.AutoSize = true; this.labelVram.Location = new System.Drawing.Point(14, 140);
            this.labelVram.Text = "VRAM"; this.labelVram.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.labelVram.TabIndex = 5;

            this.lblVram.AutoSize = true; this.lblVram.Location = new System.Drawing.Point(60, 138);
            this.lblVram.Text = "--"; this.lblVram.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblVram.TabIndex = 6;

            // ── RAM KARTI ──
            this.pnlRam.Location = new System.Drawing.Point(586, 52);
            this.pnlRam.Name     = "pnlRam";
            this.pnlRam.Size     = new System.Drawing.Size(296, 162);
            this.pnlRam.TabIndex = 102;
            this.pnlRam.Controls.Add(this.lblRamBaslik);
            this.pnlRam.Controls.Add(this.label2);
            this.pnlRam.Controls.Add(this.lblRam);
            this.pnlRam.Controls.Add(this.labelRamGb);
            this.pnlRam.Controls.Add(this.lblRamGb);
            this.pnlRam.Controls.Add(this.chkOtomatikBaslat);
            this.pnlRam.Controls.Add(this.button1);

            this.lblRamBaslik.AutoSize = false;
            this.lblRamBaslik.Location = new System.Drawing.Point(12, 10);
            this.lblRamBaslik.Size     = new System.Drawing.Size(268, 24);
            this.lblRamBaslik.Text     = "▌  RAM";
            this.lblRamBaslik.Font     = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblRamBaslik.TabIndex = 0;

            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Text = "Kullanım (%)"; this.label2.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.label2.TabIndex = 1;

            this.lblRam.AutoSize = true; this.lblRam.Location = new System.Drawing.Point(14, 65);
            this.lblRam.Text = "--"; this.lblRam.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold); this.lblRam.TabIndex = 2;

            this.labelRamGb.AutoSize = true; this.labelRamGb.Location = new System.Drawing.Point(14, 97);
            this.labelRamGb.Text = "Kapasite (GB)"; this.labelRamGb.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.labelRamGb.TabIndex = 3;

            this.lblRamGb.AutoSize = true; this.lblRamGb.Location = new System.Drawing.Point(14, 112);
            this.lblRamGb.Text = "--"; this.lblRamGb.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.lblRamGb.TabIndex = 4;

            this.chkOtomatikBaslat.AutoSize = true;
            this.chkOtomatikBaslat.Location = new System.Drawing.Point(14, 140);
            this.chkOtomatikBaslat.Text     = "Windows ile Başlat";
            this.chkOtomatikBaslat.Font     = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkOtomatikBaslat.TabIndex = 5;
            this.chkOtomatikBaslat.UseVisualStyleBackColor = false;
            this.chkOtomatikBaslat.CheckedChanged += new System.EventHandler(this.chkOtomatikBaslat_CheckedChanged);

            this.button1.Location = new System.Drawing.Point(152, 134);
            this.button1.Name     = "button1";
            this.button1.Size     = new System.Drawing.Size(130, 28);
            this.button1.TabIndex = 6;
            this.button1.Text     = "📊 Grafikleri Gör";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // ── ALARM BÖLÜMÜ ──
            this.btnAlarmEkle.Location = new System.Drawing.Point(10, 224);
            this.btnAlarmEkle.Name     = "btnAlarmEkle";
            this.btnAlarmEkle.Size     = new System.Drawing.Size(175, 36);
            this.btnAlarmEkle.TabIndex = 7;
            this.btnAlarmEkle.Text     = "＋  Yeni Alarm Ekle";
            this.btnAlarmEkle.Font     = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAlarmEkle.UseVisualStyleBackColor = true;
            this.btnAlarmEkle.Click += new System.EventHandler(this.btnAlarmEkle_Click);

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 234);
            this.label3.Name     = "label3";
            this.label3.Text     = "Ara:";
            this.label3.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.TabIndex = 11;

            this.txtArama.Location = new System.Drawing.Point(234, 230);
            this.txtArama.Name     = "txtArama";
            this.txtArama.Size     = new System.Drawing.Size(150, 22);
            this.txtArama.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.txtArama.TabIndex = 10;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);

            this.btnSil.Location = new System.Drawing.Point(622, 224);
            this.btnSil.Name     = "btnSil";
            this.btnSil.Size     = new System.Drawing.Size(138, 36);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text     = "🗑  Seçili Olanı Sil";
            this.btnSil.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);

            this.btnGeriAl.Location = new System.Drawing.Point(768, 224);
            this.btnGeriAl.Name     = "btnGeriAl";
            this.btnGeriAl.Size     = new System.Drawing.Size(114, 36);
            this.btnGeriAl.TabIndex = 9;
            this.btnGeriAl.Text     = "↩  Geri Al";
            this.btnGeriAl.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnGeriAl.UseVisualStyleBackColor = true;
            this.btnGeriAl.Click += new System.EventHandler(this.btnGeriAl_Click);

            this.dgvAlarmlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmlar.Location      = new System.Drawing.Point(10, 268);
            this.dgvAlarmlar.Name          = "dgvAlarmlar";
            this.dgvAlarmlar.RowHeadersWidth = 51;
            this.dgvAlarmlar.RowTemplate.Height = 28;
            this.dgvAlarmlar.Size          = new System.Drawing.Size(872, 222);
            this.dgvAlarmlar.TabIndex      = 6;
            this.dgvAlarmlar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlarmlar_CellDoubleClick);

            // ── SİSTEM ──
            this.timer1.Enabled  = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick    += new System.EventHandler(this.timer1_Tick);
            this.timer2.Tick    += new System.EventHandler(this.timer2_Tick);

            this.systemNotification.ContextMenuStrip = this.contextMenuStrip1;
            this.systemNotification.Icon    = ((System.Drawing.Icon)(resources.GetObject("systemNotification.Icon")));
            this.systemNotification.Text    = "RealTime SysTracker";
            this.systemNotification.Visible = true;
            this.systemNotification.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.systemNotification_MouseDoubleClick);

            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.çıkışToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);

            // ── FORM ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(892, 500);
            this.Text                = "RealTime SysTracker";
            this.Name                = "Form1";
            this.FormClosing        += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);

            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCpu);
            this.Controls.Add(this.pnlGpu);
            this.Controls.Add(this.pnlRam);
            this.Controls.Add(this.btnAlarmEkle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGeriAl);
            this.Controls.Add(this.dgvAlarmlar);

            this.pnlHeader.ResumeLayout(false);
            this.pnlCpu.ResumeLayout(false); this.pnlCpu.PerformLayout();
            this.pnlGpu.ResumeLayout(false); this.pnlGpu.PerformLayout();
            this.pnlRam.ResumeLayout(false); this.pnlRam.PerformLayout();
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