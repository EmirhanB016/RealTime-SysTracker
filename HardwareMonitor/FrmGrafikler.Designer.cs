namespace HardwareMonitor
{
    partial class FrmGrafikler
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea ca1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea ca2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea ca3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea ca4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea ca5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

            this.chartCpuSicaklik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCpuYuk      = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGpuSicaklik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGpuYuk      = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRam         = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvLoglar        = new System.Windows.Forms.DataGridView();
            this.lblOrtCpu        = new System.Windows.Forms.Label();
            this.lblOrtRam        = new System.Windows.Forms.Label();
            this.cmbZamanSecimi   = new System.Windows.Forms.ComboBox();
            this.timerCanliAkis   = new System.Windows.Forms.Timer(this.components);
            this.btnExcelAktar    = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.chartCpuSicaklik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpuYuk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpuSicaklik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpuYuk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoglar)).BeginInit();
            this.SuspendLayout();

            // Satır 1: CPU Sıcaklığı | CPU Yükü | GPU Sıcaklığı
            ca1.Name = "main";
            this.chartCpuSicaklik.ChartAreas.Add(ca1);
            this.chartCpuSicaklik.Location = new System.Drawing.Point(10, 10);
            this.chartCpuSicaklik.Name     = "chartCpuSicaklik";
            this.chartCpuSicaklik.Size     = new System.Drawing.Size(318, 165);
            this.chartCpuSicaklik.TabIndex = 10;

            ca2.Name = "main";
            this.chartCpuYuk.ChartAreas.Add(ca2);
            this.chartCpuYuk.Location = new System.Drawing.Point(338, 10);
            this.chartCpuYuk.Name     = "chartCpuYuk";
            this.chartCpuYuk.Size     = new System.Drawing.Size(318, 165);
            this.chartCpuYuk.TabIndex = 11;

            ca3.Name = "main";
            this.chartGpuSicaklik.ChartAreas.Add(ca3);
            this.chartGpuSicaklik.Location = new System.Drawing.Point(666, 10);
            this.chartGpuSicaklik.Name     = "chartGpuSicaklik";
            this.chartGpuSicaklik.Size     = new System.Drawing.Size(318, 165);
            this.chartGpuSicaklik.TabIndex = 12;

            // Satır 2: GPU Yükü | RAM
            ca4.Name = "main";
            this.chartGpuYuk.ChartAreas.Add(ca4);
            this.chartGpuYuk.Location = new System.Drawing.Point(10, 185);
            this.chartGpuYuk.Name     = "chartGpuYuk";
            this.chartGpuYuk.Size     = new System.Drawing.Size(487, 165);
            this.chartGpuYuk.TabIndex = 13;

            ca5.Name = "main";
            this.chartRam.ChartAreas.Add(ca5);
            this.chartRam.Location = new System.Drawing.Point(507, 185);
            this.chartRam.Name     = "chartRam";
            this.chartRam.Size     = new System.Drawing.Size(477, 165);
            this.chartRam.TabIndex = 14;

            // İstatistik bar
            this.cmbZamanSecimi.FormattingEnabled = true;
            this.cmbZamanSecimi.Items.AddRange(new object[] { "5 Dakika", "15 Dakika", "30 Dakika" });
            this.cmbZamanSecimi.Location = new System.Drawing.Point(10, 362);
            this.cmbZamanSecimi.Name     = "cmbZamanSecimi";
            this.cmbZamanSecimi.Size     = new System.Drawing.Size(121, 24);
            this.cmbZamanSecimi.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbZamanSecimi.TabIndex = 3;
            this.cmbZamanSecimi.SelectedIndexChanged += new System.EventHandler(this.cmbZamanSecimi_SelectedIndexChanged);

            this.lblOrtCpu.AutoSize  = true;
            this.lblOrtCpu.Location  = new System.Drawing.Point(145, 366);
            this.lblOrtCpu.Name      = "lblOrtCpu";
            this.lblOrtCpu.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrtCpu.Text      = "---";
            this.lblOrtCpu.TabIndex  = 1;

            this.lblOrtRam.AutoSize  = true;
            this.lblOrtRam.Location  = new System.Drawing.Point(500, 366);
            this.lblOrtRam.Name      = "lblOrtRam";
            this.lblOrtRam.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrtRam.Text      = "---";
            this.lblOrtRam.TabIndex  = 2;

            this.btnExcelAktar.Location = new System.Drawing.Point(740, 358);
            this.btnExcelAktar.Name     = "btnExcelAktar";
            this.btnExcelAktar.Size     = new System.Drawing.Size(244, 33);
            this.btnExcelAktar.Text     = "📥  Excel / CSV Olarak Aktar";
            this.btnExcelAktar.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExcelAktar.TabIndex = 4;
            this.btnExcelAktar.UseVisualStyleBackColor = true;
            this.btnExcelAktar.Click += new System.EventHandler(this.btnExcelAktar_Click);

            // Log tablosu
            this.dgvLoglar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoglar.Location       = new System.Drawing.Point(10, 400);
            this.dgvLoglar.Name           = "dgvLoglar";
            this.dgvLoglar.RowHeadersWidth = 51;
            this.dgvLoglar.RowTemplate.Height = 26;
            this.dgvLoglar.Size           = new System.Drawing.Size(974, 265);
            this.dgvLoglar.TabIndex       = 0;

            this.timerCanliAkis.Tick += new System.EventHandler(this.timerCanliAkis_Tick);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(994, 678);
            this.Text                = "Grafikler ve Loglar";
            this.Name                = "FrmGrafikler";
            this.Load               += new System.EventHandler(this.FrmGrafikler_Load);

            this.Controls.Add(this.chartCpuSicaklik);
            this.Controls.Add(this.chartCpuYuk);
            this.Controls.Add(this.chartGpuSicaklik);
            this.Controls.Add(this.chartGpuYuk);
            this.Controls.Add(this.chartRam);
            this.Controls.Add(this.cmbZamanSecimi);
            this.Controls.Add(this.lblOrtCpu);
            this.Controls.Add(this.lblOrtRam);
            this.Controls.Add(this.btnExcelAktar);
            this.Controls.Add(this.dgvLoglar);

            ((System.ComponentModel.ISupportInitialize)(this.chartCpuSicaklik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpuYuk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpuSicaklik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpuYuk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoglar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chartCpuSicaklik;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCpuYuk;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGpuSicaklik;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGpuYuk;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRam;
        private System.Windows.Forms.DataGridView dgvLoglar;
        private System.Windows.Forms.Label lblOrtCpu;
        private System.Windows.Forms.Label lblOrtRam;
        private System.Windows.Forms.ComboBox cmbZamanSecimi;
        private System.Windows.Forms.Timer timerCanliAkis;
        private System.Windows.Forms.Button btnExcelAktar;
    }
}