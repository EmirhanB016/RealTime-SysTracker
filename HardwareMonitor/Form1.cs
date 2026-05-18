using HardwareMonitor.Models;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareMonitor
{
    public partial class Form1 : Form
    {
        Queue<int> islemciSicaklikKuyrugu = new Queue<int>();
        List<AlarmKurali> alarmKurallari = new List<AlarmKurali>();
        Stack<AlarmKurali> silinenAlarmlar = new Stack<AlarmKurali>();
        Dictionary<string, string> donanimSozlugu = new Dictionary<string, string>();
        DateTime sonBildirimZamani = DateTime.MinValue;
        Computer bilgisayar;
        private bool ilkKucultme = true;

        public Form1()
        {
            InitializeComponent();

            VeritabaniYoneticisi.VeritabaniIlkles();
            alarmKurallari = VeritabaniYoneticisi.AlarmlariGetir();
            AlarmlariListele();

            timer1.Interval = 1000;
            timer1.Start();

            timer2.Interval = 1000;
            timer2.Start();

            bilgisayar = new Computer
            {
                IsCpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsGpuEnabled = true,         
                IsControllerEnabled = true   
            };
            bilgisayar.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAlarmEkle_Click(object sender, EventArgs e)
        {
            HardwareMonitor.Forms.FrmAlarmEkle frmEkle = new HardwareMonitor.Forms.FrmAlarmEkle();

            if (frmEkle.ShowDialog() == DialogResult.OK)
            {
                alarmKurallari.Add(frmEkle.YeniKural);
                VeritabaniYoneticisi.AlarmEkle(frmEkle.YeniKural);
                AlarmlariListele();
            }
        }

        private void AlarmlariListele()
        {
            dgvAlarmlar.DataSource = null;
            dgvAlarmlar.DataSource = alarmKurallari;

            dgvAlarmlar.ReadOnly = true;
            dgvAlarmlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvAlarmlar.Columns["Id"] != null)
            {
                dgvAlarmlar.Columns["Id"].Visible = false;
            }

            if (dgvAlarmlar.Columns["HedefDonanim"] != null)
                dgvAlarmlar.Columns["HedefDonanim"].HeaderText = "Hedef Donanım";

            if (dgvAlarmlar.Columns["SinirDeger"] != null)
                dgvAlarmlar.Columns["SinirDeger"].HeaderText = "Sınır Değer";

            if (dgvAlarmlar.Columns["AktifMi"] != null)
                dgvAlarmlar.Columns["AktifMi"].HeaderText = "Aktif mi?";

            if (dgvAlarmlar.Columns["KalanBildirimHakki"] != null)
                dgvAlarmlar.Columns["KalanBildirimHakki"].HeaderText = "Kalan Bildirim";

            dgvAlarmlar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvAlarmlar.Columns["AktifMi"] != null)
                dgvAlarmlar.Columns["AktifMi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvAlarmlar.Columns["SinirDeger"] != null)
                dgvAlarmlar.Columns["SinirDeger"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvAlarmlar.Columns["KalanBildirimHakki"] != null)
                dgvAlarmlar.Columns["KalanBildirimHakki"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvAlarmlar.Columns["HedefDonanim"] != null)
                dgvAlarmlar.Columns["HedefDonanim"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAlarmlar.CurrentRow != null)
            {
                var seciliKural = (AlarmKurali)dgvAlarmlar.CurrentRow.DataBoundItem;
                silinenAlarmlar.Push(seciliKural);
                alarmKurallari.Remove(seciliKural);
                VeritabaniYoneticisi.AlarmSil(seciliKural.Id.ToString());
                AlarmlariListele();
            }
            else
            {
                MessageBox.Show("Lütfen silmek için tablodan bir alarm seçin.");
            }
        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            if (silinenAlarmlar.Count > 0)
            {
                var kurtarilanKural = silinenAlarmlar.Pop();

                alarmKurallari.Add(kurtarilanKural);
                AlarmlariListele();
            }
            else
            {
                MessageBox.Show("Geri alınacak silinmiş bir alarm bulunmuyor.");
            }
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            string arananKelime = txtArama.Text.ToLower();

            var filtrelenmisListe = alarmKurallari
                .Where(kural => kural.HedefDonanim.ToLower().Contains(arananKelime))
                .ToList();

            dgvAlarmlar.DataSource = null;
            dgvAlarmlar.DataSource = filtrelenmisListe;
        }

        private void dgvAlarmlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var seciliKural = (AlarmKurali)dgvAlarmlar.Rows[e.RowIndex].DataBoundItem;
            seciliKural.AktifMi = !seciliKural.AktifMi;
            VeritabaniYoneticisi.AlarmGuncelle(seciliKural);
            AlarmlariListele();
            MessageBox.Show($"'{seciliKural.HedefDonanim}' alarmı güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                systemNotification.Visible = true;

                if (ilkKucultme)
                {
                    systemNotification.ShowBalloonTip(2000, "Sistem İzleyici", "Uygulama arka planda çalışmaya ve log tutmaya devam ediyor.", ToolTipIcon.Info);
                    ilkKucultme = false; 
                }
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            int anlikCpuSicaklik = 0;
            int anlikCpuYuk = 0;
            int anlikGpuSicaklik = 0;
            int anlikRamKullanimi = 0;

            await Task.Run(() =>
            {
                foreach (IHardware donanim in bilgisayar.Hardware)
                {
                    donanim.Update();

                    if (donanim.HardwareType == HardwareType.Cpu)
                    {
                        foreach (ISensor sensor in donanim.Sensors)
                        {
                            string isim = sensor.Name.ToUpper();

                            if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                            {
                                if (isim.Contains("PACKAGE") || isim.Contains("CORE") || isim.Contains("TCTL/TDIE"))
                                {
                                    int okunan = (int)sensor.Value.Value;
                                    if (okunan > anlikCpuSicaklik && okunan < 115)
                                    {
                                        anlikCpuSicaklik = okunan;
                                    }
                                }
                            }

                            if (sensor.SensorType == SensorType.Load && sensor.Value.HasValue)
                            {
                                if (isim.Contains("TOTAL"))
                                {
                                    anlikCpuYuk = (int)sensor.Value.Value;
                                }
                            }
                        }
                    }

                    if (donanim.HardwareType == HardwareType.GpuAmd || donanim.HardwareType == HardwareType.GpuNvidia)
                    {
                        foreach (ISensor sensor in donanim.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                            {
                                int okunanGpu = (int)sensor.Value.Value;
                                string isim = sensor.Name.ToUpper();

                                if (anlikCpuSicaklik == 0)
                                {
                                    anlikCpuSicaklik = okunanGpu;
                                }

                                if (isim.Contains("CORE") || isim.Contains("GPU"))
                                {
                                    if (okunanGpu > anlikGpuSicaklik && okunanGpu < 115)
                                    {
                                        anlikGpuSicaklik = okunanGpu;
                                    }
                                }
                            }
                        }
                    }

                    if (donanim.HardwareType == HardwareType.Memory)
                    {
                        foreach (ISensor sensor in donanim.Sensors)
                        {
                            if (sensor.SensorType == SensorType.Load && sensor.Value.HasValue)
                            {
                                anlikRamKullanimi = (int)sensor.Value.Value;
                            }
                        }
                    }

                }
            });
            lblCpu.Text = $"{anlikCpuSicaklik} °C";
            if (anlikCpuSicaklik >= 80) lblCpu.ForeColor = Color.Red;
            else if (anlikCpuSicaklik >= 65) lblCpu.ForeColor = Color.DarkOrange;
            else lblCpu.ForeColor = Color.Green;

            lblCpuYuk.Text = $"%{anlikCpuYuk}";
            if (anlikCpuYuk >= 85) lblCpuYuk.ForeColor = Color.Red;
            else if (anlikCpuYuk >= 50) lblCpuYuk.ForeColor = Color.DarkOrange;
            else lblCpuYuk.ForeColor = Color.Green;

            lblGpuSicaklik.Text = $"{anlikGpuSicaklik} °C";
            if (anlikGpuSicaklik >= 80) lblGpuSicaklik.ForeColor = Color.Red;
            else if (anlikGpuSicaklik >= 65) lblGpuSicaklik.ForeColor = Color.DarkOrange;
            else lblGpuSicaklik.ForeColor = Color.Green;

            lblRam.Text = $"%{anlikRamKullanimi}";
            if (anlikRamKullanimi >= 80) lblRam.ForeColor = Color.Red;
            else if (anlikRamKullanimi >= 60) lblRam.ForeColor = Color.DarkOrange;
            else lblRam.ForeColor = Color.Green;

            foreach (var alarm in alarmKurallari)
            {
                bool alarmTetiklendiMi = false;
                string bildirimMesaji = "";

                switch (alarm.HedefDonanim)
                {
                    case "İşlemci Sıcaklığı (°C)":
                        if (anlikCpuSicaklik >= alarm.SinirDeger) { alarmTetiklendiMi = true; bildirimMesaji = $"Kritik CPU Sıcaklığı: {anlikCpuSicaklik}°C"; }
                        break;
                    case "İşlemci Yükü (%)":
                        if (anlikCpuYuk >= alarm.SinirDeger) { alarmTetiklendiMi = true; bildirimMesaji = $"Yüksek CPU Yükü: %{anlikCpuYuk}"; }
                        break;
                    case "Ekran Kartı Sıcaklığı (°C)":
                        if (anlikGpuSicaklik >= alarm.SinirDeger) { alarmTetiklendiMi = true; bildirimMesaji = $"Kritik GPU Sıcaklığı: {anlikGpuSicaklik}°C"; }
                        break;
                    case "RAM Kullanımı (%)":
                        if (anlikRamKullanimi >= alarm.SinirDeger) { alarmTetiklendiMi = true; bildirimMesaji = $"Yüksek RAM Kullanımı: %{anlikRamKullanimi}"; }
                        break;
                }

                if (alarmTetiklendiMi && alarm.KalanBildirimHakki > 0)
                {
                    if ((DateTime.Now - sonBildirimZamani).TotalSeconds >= 15)
                    {
                        systemNotification.Icon = SystemIcons.Warning;
                        systemNotification.Visible = true;
                        systemNotification.BalloonTipTitle = "SİSTEM ALARMI!";
                        systemNotification.BalloonTipText = bildirimMesaji;
                        systemNotification.BalloonTipIcon = ToolTipIcon.Warning;

                        systemNotification.ShowBalloonTip(3000);

                        sonBildirimZamani = DateTime.Now;

                        alarm.KalanBildirimHakki--;
                    }
                    break;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int anlikCpuSicaklik, anlikCpuYuk, anlikGpuSicaklik, anlikRam;

            bool cpuS = int.TryParse(lblCpu.Text.Replace(" °C", "").Trim(), out anlikCpuSicaklik);
            bool cpuY = int.TryParse(lblCpuYuk.Text.Replace("%", "").Trim(), out anlikCpuYuk);
            bool gpuS = int.TryParse(lblGpuSicaklik.Text.Replace(" °C", "").Trim(), out anlikGpuSicaklik);
            bool ramK = int.TryParse(lblRam.Text.Replace("%", "").Trim(), out anlikRam);

            if (cpuS && cpuY && gpuS && ramK)
            {
                VeritabaniYoneticisi.LogEkle(anlikCpuSicaklik, anlikCpuYuk, anlikGpuSicaklik, anlikRam);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGrafikler frmGrafik = new FrmGrafikler();
            frmGrafik.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void systemNotification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
