namespace HardwareMonitor
{
    partial class FrmGrafikler
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
            this.components = new System.ComponentModel.Container();
            this.dgvLoglar = new System.Windows.Forms.DataGridView();
            this.lblOrtCpu = new System.Windows.Forms.Label();
            this.lblOrtRam = new System.Windows.Forms.Label();
            this.cmbZamanSecimi = new System.Windows.Forms.ComboBox();
            this.timerCanliAkis = new System.Windows.Forms.Timer(this.components);
            this.btnExcelAktar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoglar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLoglar
            // 
            this.dgvLoglar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoglar.Location = new System.Drawing.Point(12, 267);
            this.dgvLoglar.Name = "dgvLoglar";
            this.dgvLoglar.RowHeadersWidth = 51;
            this.dgvLoglar.RowTemplate.Height = 24;
            this.dgvLoglar.Size = new System.Drawing.Size(949, 275);
            this.dgvLoglar.TabIndex = 0;
            // 
            // lblOrtCpu
            // 
            this.lblOrtCpu.AutoSize = true;
            this.lblOrtCpu.Location = new System.Drawing.Point(205, 159);
            this.lblOrtCpu.Name = "lblOrtCpu";
            this.lblOrtCpu.Size = new System.Drawing.Size(44, 16);
            this.lblOrtCpu.TabIndex = 1;
            this.lblOrtCpu.Text = "label1";
            // 
            // lblOrtRam
            // 
            this.lblOrtRam.AutoSize = true;
            this.lblOrtRam.Location = new System.Drawing.Point(534, 159);
            this.lblOrtRam.Name = "lblOrtRam";
            this.lblOrtRam.Size = new System.Drawing.Size(44, 16);
            this.lblOrtRam.TabIndex = 2;
            this.lblOrtRam.Text = "label2";
            // 
            // cmbZamanSecimi
            // 
            this.cmbZamanSecimi.FormattingEnabled = true;
            this.cmbZamanSecimi.Items.AddRange(new object[] {
            "5 Dakika",
            "15 Dakika",
            "30 Dakika"});
            this.cmbZamanSecimi.Location = new System.Drawing.Point(78, 49);
            this.cmbZamanSecimi.Name = "cmbZamanSecimi";
            this.cmbZamanSecimi.Size = new System.Drawing.Size(121, 24);
            this.cmbZamanSecimi.TabIndex = 3;
            // 
            // timerCanliAkis
            // 
            this.timerCanliAkis.Tick += new System.EventHandler(this.timerCanliAkis_Tick);
            // 
            // btnExcelAktar
            // 
            this.btnExcelAktar.Location = new System.Drawing.Point(649, 49);
            this.btnExcelAktar.Name = "btnExcelAktar";
            this.btnExcelAktar.Size = new System.Drawing.Size(245, 33);
            this.btnExcelAktar.TabIndex = 4;
            this.btnExcelAktar.Text = "Excel / CSV Olarak Aktar";
            this.btnExcelAktar.UseVisualStyleBackColor = true;
            this.btnExcelAktar.Click += new System.EventHandler(this.btnExcelAktar_Click);
            // 
            // FrmGrafikler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 554);
            this.Controls.Add(this.btnExcelAktar);
            this.Controls.Add(this.cmbZamanSecimi);
            this.Controls.Add(this.lblOrtRam);
            this.Controls.Add(this.lblOrtCpu);
            this.Controls.Add(this.dgvLoglar);
            this.Name = "FrmGrafikler";
            this.Text = "FrmGrafikler";
            this.Load += new System.EventHandler(this.FrmGrafikler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoglar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoglar;
        private System.Windows.Forms.Label lblOrtCpu;
        private System.Windows.Forms.Label lblOrtRam;
        private System.Windows.Forms.ComboBox cmbZamanSecimi;
        private System.Windows.Forms.Timer timerCanliAkis;
        private System.Windows.Forms.Button btnExcelAktar;
    }
}