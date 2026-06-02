using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HardwareMonitor
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
            GrafikleriAyarla();
            KaranlikTemaUygula();
        }

        // ── Tema ──
        private void KaranlikTemaUygula()
        {
            this.BackColor = Color.FromArgb(18, 18, 28);

            // Arka plan ve label renkleri
            lblOrtCpu.ForeColor    = Color.FromArgb(160, 190, 255);
            lblOrtRam.ForeColor    = Color.FromArgb(160, 190, 255);
            lblOrtCpu.BackColor    = Color.Transparent;
            lblOrtRam.BackColor    = Color.Transparent;

            // ComboBox
            cmbZamanSecimi.BackColor = Color.FromArgb(30, 30, 48);
            cmbZamanSecimi.ForeColor = Color.FromArgb(220, 220, 235);
            cmbZamanSecimi.FlatStyle = FlatStyle.Flat;

            // Buton
            btnExcelAktar.FlatStyle = FlatStyle.Flat;
            btnExcelAktar.BackColor = Color.FromArgb(38, 68, 138);
            btnExcelAktar.ForeColor = Color.White;
            btnExcelAktar.FlatAppearance.BorderColor     = Color.FromArgb(68, 108, 215);
            btnExcelAktar.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 88, 175);
            btnExcelAktar.Cursor = Cursors.Hand;

            // DataGridView
            dgvLoglar.BackgroundColor = Color.FromArgb(18, 18, 28);
            dgvLoglar.GridColor       = Color.FromArgb(45, 45, 70);
            dgvLoglar.BorderStyle     = BorderStyle.None;
            dgvLoglar.EnableHeadersVisualStyles = false;
            dgvLoglar.RowHeadersVisible = false;
            dgvLoglar.SelectionMode   = DataGridViewSelectionMode.FullRowSelect;
            dgvLoglar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvLoglar.DefaultCellStyle.BackColor        = Color.FromArgb(26, 26, 40);
            dgvLoglar.DefaultCellStyle.ForeColor        = Color.FromArgb(220, 220, 235);
            dgvLoglar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 82, 168);
            dgvLoglar.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvLoglar.DefaultCellStyle.Font             = new Font("Segoe UI", 9f);

            dgvLoglar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(22, 22, 35);
            dgvLoglar.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(220, 220, 235);

            dgvLoglar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 48);
            dgvLoglar.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(155, 185, 255);
            dgvLoglar.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvLoglar.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(28, 28, 48);
            dgvLoglar.ColumnHeadersHeight = 34;
        }

        // ── Grafik kurulumu ──
        private void GrafikleriAyarla()
        {
            AyarlaGrafik(chartCpuSicaklik, "CPU Sıcaklığı (°C)",  Color.OrangeRed,         0, 100);
            AyarlaGrafik(chartCpuYuk,      "CPU Yükü (%)",         Color.DodgerBlue,        0, 100);
            AyarlaGrafik(chartGpuSicaklik, "GPU Sıcaklığı (°C)",  Color.MediumSpringGreen, 0, 100);
            AyarlaGrafik(chartGpuYuk,      "GPU Yükü (%)",         Color.Cyan,              0, 100);
            AyarlaGrafik(chartRam,         "RAM Kullanımı (%)",    Color.MediumPurple,      0, 100);
        }

        private void AyarlaGrafik(Chart chart, string baslik, Color renk, double yMin, double yMax)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();
            chart.Legends.Clear();

            var alan = new ChartArea("main");
            alan.BackColor                  = Color.FromArgb(26, 26, 40);
            alan.AxisX.LineColor            = Color.FromArgb(60, 60, 85);
            alan.AxisY.LineColor            = Color.FromArgb(60, 60, 85);
            alan.AxisX.MajorGrid.LineColor  = Color.FromArgb(35, 35, 55);
            alan.AxisY.MajorGrid.LineColor  = Color.FromArgb(35, 35, 55);
            alan.AxisX.LabelStyle.ForeColor = Color.FromArgb(140, 140, 170);
            alan.AxisY.LabelStyle.ForeColor = Color.FromArgb(140, 140, 170);
            alan.AxisX.LabelStyle.Font      = new Font("Segoe UI", 7f);
            alan.AxisY.LabelStyle.Font      = new Font("Segoe UI", 7f);
            alan.AxisX.Interval             = 5;
            alan.AxisY.Minimum              = yMin;
            alan.AxisY.Maximum              = yMax;
            alan.AxisY.Interval             = 20;
            alan.AxisX.IsLabelAutoFit       = false;
            alan.AxisX.LabelStyle.Angle     = -35;
            alan.BorderColor                = Color.FromArgb(45, 45, 70);
            alan.BorderDashStyle            = ChartDashStyle.Solid;
            alan.BorderWidth                = 1;
            chart.ChartAreas.Add(alan);

            var title = new Title(baslik);
            title.ForeColor = Color.FromArgb(200, 210, 240);
            title.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            title.Docking   = Docking.Top;
            chart.Titles.Add(title);

            var seri = new Series("veri");
            seri.ChartType   = SeriesChartType.Line;
            seri.Color       = renk;
            seri.BorderWidth = 2;
            seri.XValueType  = ChartValueType.String;
            seri.MarkerStyle = MarkerStyle.None;
            chart.Series.Add(seri);

            chart.BackColor           = Color.FromArgb(18, 18, 28);
            chart.BorderlineColor     = Color.FromArgb(45, 45, 70);
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth     = 1;
        }

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            cmbZamanSecimi.SelectedIndex = 0;
            timerCanliAkis.Interval = 2000;
            timerCanliAkis.Start();
            timerCanliAkis_Tick(null, null);
        }

        private void timerCanliAkis_Tick(object sender, EventArgs e)
        {
            DataTable grafikVerisi = VeritabaniYoneticisi.CanliLoglariGetir(60);
            GrafikleriGuncelle(grafikVerisi);

            DataTable canliTablo = VeritabaniYoneticisi.CanliLoglariGetir(20);
            dgvLoglar.DataSource = canliTablo;
            TabloFormatla();

            if (dgvLoglar.Rows.Count > 0)
                dgvLoglar.FirstDisplayedScrollingRowIndex = dgvLoglar.Rows.Count - 1;

            int secilenDakika = 5;
            if (cmbZamanSecimi.Text == "15 Dakika") secilenDakika = 15;
            else if (cmbZamanSecimi.Text == "30 Dakika") secilenDakika = 30;
            OrtalamalariHesapla(secilenDakika);
        }

        private void GrafikleriGuncelle(DataTable veri)
        {
            chartCpuSicaklik.Series["veri"].Points.Clear();
            chartCpuYuk.Series["veri"].Points.Clear();
            chartGpuSicaklik.Series["veri"].Points.Clear();
            chartGpuYuk.Series["veri"].Points.Clear();
            chartRam.Series["veri"].Points.Clear();

            foreach (DataRow satir in veri.Rows)
            {
                string zaman = "";
                if (satir["TarihSaat"] != System.DBNull.Value &&
                    DateTime.TryParse(satir["TarihSaat"].ToString(), out DateTime dt))
                    zaman = dt.ToString("HH:mm:ss");

                double cpuSic = satir["CpuSicaklik"]  != System.DBNull.Value ? Convert.ToDouble(satir["CpuSicaklik"])  : 0;
                double cpuYuk = satir["CpuYuk"]        != System.DBNull.Value ? Convert.ToDouble(satir["CpuYuk"])       : 0;
                double gpuSic = satir["GpuSicaklik"]   != System.DBNull.Value ? Convert.ToDouble(satir["GpuSicaklik"])  : 0;
                double ram    = satir["RamKullanimi"]   != System.DBNull.Value ? Convert.ToDouble(satir["RamKullanimi"]) : 0;

                double gpuYuk = 0;
                if (veri.Columns.Contains("GpuYuk") && satir["GpuYuk"] != System.DBNull.Value)
                    gpuYuk = Convert.ToDouble(satir["GpuYuk"]);

                chartCpuSicaklik.Series["veri"].Points.AddXY(zaman, cpuSic);
                chartCpuYuk.Series["veri"].Points.AddXY(zaman, cpuYuk);
                chartGpuSicaklik.Series["veri"].Points.AddXY(zaman, gpuSic);
                chartGpuYuk.Series["veri"].Points.AddXY(zaman, gpuYuk);
                chartRam.Series["veri"].Points.AddXY(zaman, ram);
            }
        }

        private void cmbZamanSecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerCanliAkis_Tick(null, null);
        }

        private void OrtalamalariHesapla(int dakika)
        {
            DataTable hesapTablosu = VeritabaniYoneticisi.ZamanFiltreliLoglariGetir(dakika);
            if (hesapTablosu.Rows.Count > 0)
            {
                double toplamCpu = 0, toplamRam = 0;
                foreach (DataRow satir in hesapTablosu.Rows)
                {
                    toplamCpu += Convert.ToDouble(satir["CpuSicaklik"]);
                    toplamRam += Convert.ToDouble(satir["RamKullanimi"]);
                }
                lblOrtCpu.Text = $"Son {dakika} Dk. Ort. CPU Sıc: {Math.Round(toplamCpu / hesapTablosu.Rows.Count, 1)} °C";
                lblOrtRam.Text = $"Son {dakika} Dk. Ort. RAM: %{Math.Round(toplamRam / hesapTablosu.Rows.Count, 1)}";
            }
            else
            {
                lblOrtCpu.Text = $"Son {dakika} dakikaya ait kayıtlı veri bulunamadı.";
                lblOrtRam.Text = "";
            }
        }

        private void TabloFormatla()
        {
            dgvLoglar.ReadOnly = true;
            dgvLoglar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoglar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvLoglar.Columns["Id"] != null)          dgvLoglar.Columns["Id"].Visible = false;
            if (dgvLoglar.Columns["TarihSaat"] != null)   dgvLoglar.Columns["TarihSaat"].HeaderText = "Kayıt Zamanı";
            if (dgvLoglar.Columns["CpuSicaklik"] != null) dgvLoglar.Columns["CpuSicaklik"].HeaderText = "CPU Sıc. (°C)";
            if (dgvLoglar.Columns["CpuYuk"] != null)      dgvLoglar.Columns["CpuYuk"].HeaderText = "CPU Yükü (%)";
            if (dgvLoglar.Columns["GpuSicaklik"] != null) dgvLoglar.Columns["GpuSicaklik"].HeaderText = "GPU Sıc. (°C)";
            if (dgvLoglar.Columns["GpuYuk"] != null)      dgvLoglar.Columns["GpuYuk"].HeaderText = "GPU Yükü (%)";
            if (dgvLoglar.Columns["RamKullanimi"] != null) dgvLoglar.Columns["RamKullanimi"].HeaderText = "RAM (%)";

            foreach (DataGridViewColumn sutun in dgvLoglar.Columns)
                sutun.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            if (dgvLoglar.Rows.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak veri bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter   = "Excel CSV Dosyası (*.csv)|*.csv",
                Title    = "Performans Loglarını Kaydet",
                FileName = $"Sistem_Performans_Loglari_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("Kayıt Zamanı;CPU Sıc. (°C);CPU Yükü (%);GPU Sıc. (°C);GPU Yükü (%);RAM (%)");
                        foreach (DataGridViewRow satir in dgvLoglar.Rows)
                        {
                            if (satir.IsNewRow) continue;
                            string zaman = "";
                            if (satir.Cells["TarihSaat"].Value != null &&
                                DateTime.TryParse(satir.Cells["TarihSaat"].Value.ToString(), out DateTime dt))
                                zaman = dt.ToString("dd.MM.yyyy HH:mm:ss");

                            string cpuSic = satir.Cells["CpuSicaklik"].Value?.ToString() ?? "";
                            string cpuYuk = satir.Cells["CpuYuk"].Value?.ToString() ?? "";
                            string gpuSic = satir.Cells["GpuSicaklik"].Value?.ToString() ?? "";
                            string gpuYuk = satir.Cells["GpuYuk"]?.Value?.ToString() ?? "";
                            string ram    = satir.Cells["RamKullanimi"].Value?.ToString() ?? "";
                            sw.WriteLine($"{zaman};{cpuSic};{cpuYuk};{gpuSic};{gpuYuk};{ram}");
                        }
                    }
                    MessageBox.Show("Loglar başarıyla dışa aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}