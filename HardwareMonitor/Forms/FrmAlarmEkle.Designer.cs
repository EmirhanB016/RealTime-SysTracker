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
            this.label3 = new System.Windows.Forms.Label();
            this.numBildirimSayisi = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGeriAl = new System.Windows.Forms.Button();
            this.dgvAlarmlar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numBildirimSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlar)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDonanim
            // 
            this.cmbDonanim.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbDonanim.FormattingEnabled = true;
            this.cmbDonanim.Items.AddRange(new object[] {
            "İşlemci Sıcaklığı (°C)",
            "İşlemci Yükü (%)",
            "RAM Kullanımı (%)",
            "Ekran Kartı Sıcaklığı (°C)",
            "Ekran Kartı Yükü (%)",
            "VRAM Kullanımı (MB)"});
            this.cmbDonanim.Location = new System.Drawing.Point(64, 104);
            this.cmbDonanim.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDonanim.Name = "cmbDonanim";
            this.cmbDonanim.Size = new System.Drawing.Size(166, 28);
            this.cmbDonanim.TabIndex = 0;
            this.cmbDonanim.SelectedIndexChanged += new System.EventHandler(this.cmbDonanim_SelectedIndexChanged);
            // 
            // txtSinirDeger
            // 
            this.txtSinirDeger.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSinirDeger.Location = new System.Drawing.Point(353, 105);
            this.txtSinirDeger.Margin = new System.Windows.Forms.Padding(2);
            this.txtSinirDeger.Name = "txtSinirDeger";
            this.txtSinirDeger.Size = new System.Drawing.Size(114, 27);
            this.txtSinirDeger.TabIndex = 1;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(370, 171);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(78, 29);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(96, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Donanım Seçin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(349, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sınır Değer Girin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(595, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bildirim Sayısı";
            // 
            // numBildirimSayisi
            // 
            this.numBildirimSayisi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numBildirimSayisi.Location = new System.Drawing.Point(599, 106);
            this.numBildirimSayisi.Margin = new System.Windows.Forms.Padding(2);
            this.numBildirimSayisi.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numBildirimSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBildirimSayisi.Name = "numBildirimSayisi";
            this.numBildirimSayisi.Size = new System.Drawing.Size(90, 27);
            this.numBildirimSayisi.TabIndex = 6;
            this.numBildirimSayisi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(60, 260);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ara:";
            // 
            // txtArama
            // 
            this.txtArama.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtArama.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtArama.Location = new System.Drawing.Point(100, 257);
            this.txtArama.Margin = new System.Windows.Forms.Padding(2);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(114, 27);
            this.txtArama.TabIndex = 13;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(510, 256);
            this.btnSil.Margin = new System.Windows.Forms.Padding(2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(157, 29);
            this.btnSil.TabIndex = 15;
            this.btnSil.Text = "🗑  Seçili Olanı Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGeriAl
            // 
            this.btnGeriAl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeriAl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeriAl.Location = new System.Drawing.Point(681, 256);
            this.btnGeriAl.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeriAl.Name = "btnGeriAl";
            this.btnGeriAl.Size = new System.Drawing.Size(86, 29);
            this.btnGeriAl.TabIndex = 16;
            this.btnGeriAl.Text = "↩  Geri Al";
            this.btnGeriAl.UseVisualStyleBackColor = true;
            this.btnGeriAl.Click += new System.EventHandler(this.btnGeriAl_Click);
            // 
            // dgvAlarmlar
            // 
            this.dgvAlarmlar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlarmlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmlar.Location = new System.Drawing.Point(49, 325);
            this.dgvAlarmlar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAlarmlar.Name = "dgvAlarmlar";
            this.dgvAlarmlar.RowHeadersWidth = 51;
            this.dgvAlarmlar.RowTemplate.Height = 28;
            this.dgvAlarmlar.Size = new System.Drawing.Size(718, 182);
            this.dgvAlarmlar.TabIndex = 17;
            this.dgvAlarmlar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlarmlar_CellDoubleClick);
            this.dgvAlarmlar.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAlarmlar_DataBindingComplete);
            // 
            // FrmAlarmEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 550);
            this.Controls.Add(this.dgvAlarmlar);
            this.Controls.Add(this.btnGeriAl);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.txtArama);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numBildirimSayisi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtSinirDeger);
            this.Controls.Add(this.cmbDonanim);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmAlarmEkle";
            this.Text = "Yeni Alarm Kuralı Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.numBildirimSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDonanim;
        private System.Windows.Forms.TextBox txtSinirDeger;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBildirimSayisi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGeriAl;
        private System.Windows.Forms.DataGridView dgvAlarmlar;
    }
}