using System;
using System.Data;
using System.Windows.Forms;

namespace HardwareMonitor
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            cmbZamanSecimi.SelectedIndex = 0;
            VerileriFiltreleVeHesapla(5);
        }

        private void cmbZamanSecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilenDakika = 5;

            if (cmbZamanSecimi.Text == "15 Dakika") secilenDakika = 15;
            else if (cmbZamanSecimi.Text == "30 Dakika") secilenDakika = 30;

            VerileriFiltreleVeHesapla(secilenDakika);
        }

        private void VerileriFiltreleVeHesapla(int dakika)
        {
            DataTable logTablosu = VeritabaniYoneticisi.ZamanFiltreliLoglariGetir(dakika);
            dgvLoglar.DataSource = logTablosu;

            TabloFormatla();

            if (logTablosu.Rows.Count > 0)
            {
                double toplamCpuSicaklik = 0;
                double toplamRamKullanimi = 0;

                foreach (DataRow satir in logTablosu.Rows)
                {
                    toplamCpuSicaklik += Convert.ToDouble(satir["CpuSicaklik"]);
                    toplamRamKullanimi += Convert.ToDouble(satir["RamKullanimi"]);
                }

                double ortCpu = toplamCpuSicaklik / logTablosu.Rows.Count;
                double ortRam = toplamRamKullanimi / logTablosu.Rows.Count;

                lblOrtCpu.Text = $"Son {dakika} Dk. Ortalama CPU Sıcaklığı: {Math.Round(ortCpu, 1)} °C";
                lblOrtRam.Text = $"Son {dakika} Dk. Ortalama RAM Kullanımı: %{Math.Round(ortRam, 1)}";
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

            if (dgvLoglar.Columns["Id"] != null) dgvLoglar.Columns["Id"].Visible = false;

            if (dgvLoglar.Columns["TarihSaat"] != null)
                dgvLoglar.Columns["TarihSaat"].HeaderText = "Kayıt Zamanı";

            if (dgvLoglar.Columns["CpuSicaklik"] != null)
                dgvLoglar.Columns["CpuSicaklik"].HeaderText = "İşlemci Sıc. (°C)";

            if (dgvLoglar.Columns["CpuYuk"] != null)
                dgvLoglar.Columns["CpuYuk"].HeaderText = "İşlemci Yükü (%)";

            if (dgvLoglar.Columns["GpuSicaklik"] != null)
                dgvLoglar.Columns["GpuSicaklik"].HeaderText = "Ekran Kartı Sıc. (°C)";

            if (dgvLoglar.Columns["RamKullanimi"] != null)
                dgvLoglar.Columns["RamKullanimi"].HeaderText = "RAM Kullanımı (%)";

            foreach (DataGridViewColumn sutun in dgvLoglar.Columns)
            {
                sutun.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}