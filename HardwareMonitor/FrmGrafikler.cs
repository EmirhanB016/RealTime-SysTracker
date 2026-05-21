using System;
using System.Data;
using System.IO;
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
            cmbZamanSecimi.SelectedIndex = 0; // Varsayılan olarak ilk sıradakini seç

            // Canlı akış motorunu çalıştırıyoruz (Her 2 saniyede bir ekranı yenileyecek)
            timerCanliAkis.Interval = 2000;
            timerCanliAkis.Start();

            // Beklemeden ilk verileri getirmesi için manuel tetikliyoruz
            timerCanliAkis_Tick(null, null);
        }

        private void timerCanliAkis_Tick(object sender, EventArgs e)
        {
            // --- 1. GÖREV: TABLOYU CANLI OLARAK AKITMAK ---
            // Sadece son 20 satırı ekranda kaydırarak gösterir
            DataTable canliTablo = VeritabaniYoneticisi.CanliLoglariGetir(20);
            dgvLoglar.DataSource = canliTablo;
            TabloFormatla();

            // Tablo doldukça otomatik olarak en alt satıra (en güncel veriye) kaydırır
            if (dgvLoglar.Rows.Count > 0)
            {
                dgvLoglar.FirstDisplayedScrollingRowIndex = dgvLoglar.Rows.Count - 1;
            }

            // --- 2. GÖREV: SEÇİLEN ZAMANA GÖRE ORTALAMALARI GÜNCELLEMEK ---
            int secilenDakika = 5;
            if (cmbZamanSecimi.Text == "15 Dakika") secilenDakika = 15;
            else if (cmbZamanSecimi.Text == "30 Dakika") secilenDakika = 30;

            OrtalamalariHesapla(secilenDakika);
        }

        private void cmbZamanSecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kullanıcı süreyi değiştirdiği an, 2 saniye beklememesi için anında güncelliyoruz
            timerCanliAkis_Tick(null, null);
        }

        private void OrtalamalariHesapla(int dakika)
        {
            // Tabloyu hiç etkilemeden, sadece hesaplama için veritabanından arka planda veri çekiyoruz
            DataTable hesapTablosu = VeritabaniYoneticisi.ZamanFiltreliLoglariGetir(dakika);

            if (hesapTablosu.Rows.Count > 0)
            {
                double toplamCpu = 0;
                double toplamRam = 0;

                foreach (DataRow satir in hesapTablosu.Rows)
                {
                    toplamCpu += Convert.ToDouble(satir["CpuSicaklik"]);
                    toplamRam += Convert.ToDouble(satir["RamKullanimi"]);
                }

                double ortCpu = toplamCpu / hesapTablosu.Rows.Count;
                double ortRam = toplamRam / hesapTablosu.Rows.Count;

                lblOrtCpu.Text = $"Son {dakika} Dk. Ortalama CPU Sıc: {Math.Round(ortCpu, 1)} °C";
                lblOrtRam.Text = $"Son {dakika} Dk. Ortalama RAM: %{Math.Round(ortRam, 1)}";
            }
            else
            {
                lblOrtCpu.Text = $"Son {dakika} dakikaya ait kayıtlı veri bulunamadı.";
                lblOrtRam.Text = "";
            }
        }

        private void TabloFormatla()
        {
            // Sütunların genişliğini ve hizalamalarını ayarlayan kısım aynen kalıyor
            dgvLoglar.ReadOnly = true;
            dgvLoglar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoglar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvLoglar.Columns["Id"] != null) dgvLoglar.Columns["Id"].Visible = false;

            if (dgvLoglar.Columns["TarihSaat"] != null) dgvLoglar.Columns["TarihSaat"].HeaderText = "Kayıt Zamanı";
            if (dgvLoglar.Columns["CpuSicaklik"] != null) dgvLoglar.Columns["CpuSicaklik"].HeaderText = "İşlemci Sıc. (°C)";
            if (dgvLoglar.Columns["CpuYuk"] != null) dgvLoglar.Columns["CpuYuk"].HeaderText = "İşlemci Yükü (%)";
            if (dgvLoglar.Columns["GpuSicaklik"] != null) dgvLoglar.Columns["GpuSicaklik"].HeaderText = "Ekran Kartı Sıc. (°C)";
            if (dgvLoglar.Columns["RamKullanimi"] != null) dgvLoglar.Columns["RamKullanimi"].HeaderText = "RAM Kullanımı (%)";

            foreach (DataGridViewColumn sutun in dgvLoglar.Columns)
            {
                sutun.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void btnExcelAktar_Click(object sender, EventArgs e)
        {
            if (dgvLoglar.Rows.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak herhangi bir veri bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel CSV Dosyası (*.csv)|*.csv";
            sfd.Title = "Performans Loglarını Kaydet";
            sfd.FileName = $"Sistem_Performans_Loglari_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        string[] basliklar = { "Kayıt Zamanı", "İşlemci Sıcaklığı (°C)", "İşlemci Yükü (%)", "Ekran Kartı Sıcaklığı (°C)", "RAM Kullanımı (%)" };
                        sw.WriteLine(string.Join(";", basliklar));

                        foreach (DataGridViewRow satir in dgvLoglar.Rows)
                        {
                            if (!satir.IsNewRow)
                            {
                                string zaman = "";
                                if (satir.Cells["TarihSaat"].Value != null)
                                {
                                    if (DateTime.TryParse(satir.Cells["TarihSaat"].Value.ToString(), out DateTime gercekTarih))
                                    {
                                        zaman = gercekTarih.ToString("dd.MM.yyyy HH:mm:ss");
                                    }
                                    else
                                    {
                                        zaman = satir.Cells["TarihSaat"].Value.ToString();
                                    }
                                }

                                string cpuSic = satir.Cells["CpuSicaklik"].Value?.ToString() ?? "";
                                string cpuYuk = satir.Cells["CpuYuk"].Value?.ToString() ?? "";
                                string gpuSic = satir.Cells["GpuSicaklik"].Value?.ToString() ?? "";
                                string ram = satir.Cells["RamKullanimi"].Value?.ToString() ?? "";

                                string[] satirVerisi = { zaman, cpuSic, cpuYuk, gpuSic, ram };

                                sw.WriteLine(string.Join(";", satirVerisi));
                            }
                        }
                    }

                    MessageBox.Show("Performans logları başarıyla Excel/CSV formatında dışa aktarıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dosya kaydedilirken teknik bir hata oluştu:\n{ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}