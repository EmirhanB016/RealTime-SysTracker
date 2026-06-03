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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chartCpuSicaklik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCpuYuk = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGpuSicaklik = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGpuYuk = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvLoglar = new System.Windows.Forms.DataGridView();
            this.lblOrtCpu = new System.Windows.Forms.Label();
            this.lblOrtRam = new System.Windows.Forms.Label();
            this.cmbZamanSecimi = new System.Windows.Forms.ComboBox();
            this.timerCanliAkis = new System.Windows.Forms.Timer(this.components);
            this.btnExcelAktar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpuSicaklik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCpuYuk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpuSicaklik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpuYuk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoglar)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCpuSicaklik
            // 
            chartArea1.Name = "main";
            this.chartCpuSicaklik.ChartAreas.Add(chartArea1);
            this.chartCpuSicaklik.Location = new System.Drawing.Point(21, 8);
            this.chartCpuSicaklik.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartCpuSicaklik.Name = "chartCpuSicaklik";
            this.chartCpuSicaklik.Size = new System.Drawing.Size(238, 134);
            this.chartCpuSicaklik.TabIndex = 10;
            // 
            // chartCpuYuk
            // 
            chartArea2.Name = "main";
            this.chartCpuYuk.ChartAreas.Add(chartArea2);
            this.chartCpuYuk.Location = new System.Drawing.Point(271, 8);
            this.chartCpuYuk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartCpuYuk.Name = "chartCpuYuk";
            this.chartCpuYuk.Size = new System.Drawing.Size(238, 134);
            this.chartCpuYuk.TabIndex = 11;
            // 
            // chartGpuSicaklik
            // 
            chartArea3.Name = "main";
            this.chartGpuSicaklik.ChartAreas.Add(chartArea3);
            this.chartGpuSicaklik.Location = new System.Drawing.Point(522, 8);
            this.chartGpuSicaklik.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartGpuSicaklik.Name = "chartGpuSicaklik";
            this.chartGpuSicaklik.Size = new System.Drawing.Size(238, 134);
            this.chartGpuSicaklik.TabIndex = 12;
            // 
            // chartGpuYuk
            // 
            chartArea4.Name = "main";
            this.chartGpuYuk.ChartAreas.Add(chartArea4);
            this.chartGpuYuk.Location = new System.Drawing.Point(21, 150);
            this.chartGpuYuk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartGpuYuk.Name = "chartGpuYuk";
            this.chartGpuYuk.Size = new System.Drawing.Size(365, 134);
            this.chartGpuYuk.TabIndex = 13;
            // 
            // chartRam
            // 
            chartArea5.Name = "main";
            this.chartRam.ChartAreas.Add(chartArea5);
            this.chartRam.Location = new System.Drawing.Point(402, 150);
            this.chartRam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartRam.Name = "chartRam";
            this.chartRam.Size = new System.Drawing.Size(358, 134);
            this.chartRam.TabIndex = 14;
            // 
            // dgvLoglar
            // 
            this.dgvLoglar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoglar.Location = new System.Drawing.Point(21, 337);
            this.dgvLoglar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLoglar.Name = "dgvLoglar";
            this.dgvLoglar.RowHeadersWidth = 51;
            this.dgvLoglar.RowTemplate.Height = 26;
            this.dgvLoglar.Size = new System.Drawing.Size(739, 215);
            this.dgvLoglar.TabIndex = 0;
            // 
            // lblOrtCpu
            // 
            this.lblOrtCpu.AutoSize = true;
            this.lblOrtCpu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrtCpu.Location = new System.Drawing.Point(127, 302);
            this.lblOrtCpu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrtCpu.Name = "lblOrtCpu";
            this.lblOrtCpu.Size = new System.Drawing.Size(22, 15);
            this.lblOrtCpu.TabIndex = 1;
            this.lblOrtCpu.Text = "---";
            // 
            // lblOrtRam
            // 
            this.lblOrtRam.AutoSize = true;
            this.lblOrtRam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrtRam.Location = new System.Drawing.Point(368, 302);
            this.lblOrtRam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOrtRam.Name = "lblOrtRam";
            this.lblOrtRam.Size = new System.Drawing.Size(22, 15);
            this.lblOrtRam.TabIndex = 2;
            this.lblOrtRam.Text = "---";
            // 
            // cmbZamanSecimi
            // 
            this.cmbZamanSecimi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbZamanSecimi.FormattingEnabled = true;
            this.cmbZamanSecimi.Items.AddRange(new object[] {
            "5 Dakika",
            "15 Dakika",
            "30 Dakika"});
            this.cmbZamanSecimi.Location = new System.Drawing.Point(21, 299);
            this.cmbZamanSecimi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbZamanSecimi.Name = "cmbZamanSecimi";
            this.cmbZamanSecimi.Size = new System.Drawing.Size(92, 23);
            this.cmbZamanSecimi.TabIndex = 3;
            this.cmbZamanSecimi.SelectedIndexChanged += new System.EventHandler(this.cmbZamanSecimi_SelectedIndexChanged);
            // 
            // timerCanliAkis
            // 
            this.timerCanliAkis.Tick += new System.EventHandler(this.timerCanliAkis_Tick);
            // 
            // btnExcelAktar
            // 
            this.btnExcelAktar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnExcelAktar.Location = new System.Drawing.Point(560, 295);
            this.btnExcelAktar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExcelAktar.Name = "btnExcelAktar";
            this.btnExcelAktar.Size = new System.Drawing.Size(200, 27);
            this.btnExcelAktar.TabIndex = 4;
            this.btnExcelAktar.Text = "📥  Excel / CSV Olarak Aktar";
            this.btnExcelAktar.UseVisualStyleBackColor = true;
            this.btnExcelAktar.Click += new System.EventHandler(this.btnExcelAktar_Click);
            // 
            // FrmGrafikler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 563);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmGrafikler";
            this.Text = "Grafikler ve Loglar";
            this.Load += new System.EventHandler(this.FrmGrafikler_Load);
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