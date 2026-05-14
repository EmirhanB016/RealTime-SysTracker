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
        Computer bilgisayar;
        public Form1()
        {
            InitializeComponent();

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

                AlarmlariListele();
            }
        }

        private void AlarmlariListele()
        {
            dgvAlarmlar.DataSource = null;
            dgvAlarmlar.DataSource = alarmKurallari;

            dgvAlarmlar.ReadOnly = true;
            dgvAlarmlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAlarmlar.CurrentRow != null)
            {
                var seciliKural = (AlarmKurali)dgvAlarmlar.CurrentRow.DataBoundItem;

                silinenAlarmlar.Push(seciliKural);

                alarmKurallari.Remove(seciliKural);

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

            AlarmlariListele();

            MessageBox.Show($"{seciliKural.HedefDonanim} alarmı güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int anlikCpuSicaklik = 0;
            int anlikRamKullanimi = 0;

            int bulunanEnYuksekSicaklik = 0;

            foreach (IHardware donanim in bilgisayar.Hardware)
            {
                donanim.Update();

                foreach (ISensor sensor in donanim.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
                    {
                        int okunanDeger = (int)sensor.Value.Value;

                        if (okunanDeger > 0 && okunanDeger < 115)
                        {
                            if (okunanDeger > bulunanEnYuksekSicaklik)
                            {
                                bulunanEnYuksekSicaklik = okunanDeger;
                            }
                        }
                    }

                    if (sensor.SensorType == SensorType.Load && sensor.Value.HasValue && donanim.HardwareType == HardwareType.Memory)
                    {
                        anlikRamKullanimi = (int)sensor.Value.Value;
                    }
                }

                foreach (IHardware altDonanim in donanim.SubHardware)
                {
                    altDonanim.Update();
                    foreach (ISensor altSensor in altDonanim.Sensors)
                    {
                        if (altSensor.SensorType == SensorType.Temperature && altSensor.Value.HasValue)
                        {
                            int okunanDeger = (int)altSensor.Value.Value;
                            if (okunanDeger > 0 && okunanDeger < 115)
                            {
                                if (okunanDeger > bulunanEnYuksekSicaklik)
                                {
                                    bulunanEnYuksekSicaklik = okunanDeger;
                                }
                            }
                        }
                    }
                }
            }

            anlikCpuSicaklik = bulunanEnYuksekSicaklik;

            islemciSicaklikKuyrugu.Enqueue(anlikCpuSicaklik);

            if (islemciSicaklikKuyrugu.Count > 10)
            {
                islemciSicaklikKuyrugu.Dequeue();
            }

            int ortalamaSicaklik = (int)islemciSicaklikKuyrugu.Average();

            pbCpu.Value = Math.Min(ortalamaSicaklik, 100);
            pbRam.Value = Math.Min(anlikRamKullanimi, 100);

            lblCpu.Text = $"{ortalamaSicaklik} °C";
            lblRam.Text = $"%{anlikRamKullanimi}";
        }
    }
}
