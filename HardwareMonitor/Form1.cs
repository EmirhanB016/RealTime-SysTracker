using HardwareMonitor.Models;
using LibreHardwareMonitor.Hardware;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareMonitor
{
    public partial class Form1 : Form
    {
        List<AlarmKurali> alarmKurallari = new List<AlarmKurali>();
        private Size ilkFormBoyutu;
        private Dictionary<Control, Rectangle> ilkKonumlar = new Dictionary<Control, Rectangle>();
        Queue<int> islemciSicaklikKuyrugu = new Queue<int>();
        Dictionary<string, string> donanimSozlugu = new Dictionary<string, string>();
        DateTime sonBildirimZamani = DateTime.MinValue;
        Computer bilgisayar;
        private bool ilkKucultme = true;
        private Icon orijinalIkon;
        private bool otomatikBaslatildiMi = Environment.GetCommandLineArgs().Contains("-startup");

        private static readonly Color ClrBackground = Color.FromArgb(18, 18, 28);
        private static readonly Color ClrCard       = Color.FromArgb(26, 26, 42);
        private static readonly Color ClrHeader     = Color.FromArgb(13, 13, 22);
        private static readonly Color ClrBorder     = Color.FromArgb(52, 52, 82);
        private static readonly Color ClrText       = Color.FromArgb(218, 218, 235);
        private static readonly Color ClrSubText    = Color.FromArgb(130, 130, 165);
        private static readonly Color ClrButton     = Color.FromArgb(38, 68, 138);
        private static readonly Color ClrButtonBorder = Color.FromArgb(68, 108, 215);

        protected override void SetVisibleCore(bool value)
        {
            if (otomatikBaslatildiMi)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        public Form1()
        {
            InitializeComponent();
            KaranlikTemaUygula();
            ilkFormBoyutu = this.Size;
            systemNotification.Icon = this.Icon;

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (rk.GetValue("RealTimeSysTracker") != null)
            {
                windowsİleBaşlatToolStripMenuItem.Checked = true;
            }

            foreach (Control c in this.Controls)
            {
                ilkKonumlar[c] = new Rectangle(
                    c.Left,
                    c.Top,
                    c.Width,
                    c.Height);
            }

            this.Resize += Form1_Resize;
            orijinalIkon = systemNotification.Icon;

            VeritabaniYoneticisi.VeritabaniIlkles();
            RegistryKey anahtar = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (anahtar.GetValue("HardwareMonitorApp") != null)

            timer1.Interval = 1000;
            timer1.Start();
            timer2.Interval = 1000;
            timer2.Start();

            bilgisayar = new Computer
            {
                IsCpuEnabled = true, IsMemoryEnabled = true,
                IsMotherboardEnabled = true, IsGpuEnabled = true,
                IsControllerEnabled = true
            };
            bilgisayar.Open();

            int ilkTestSicakligi = 0;
            foreach (IHardware d in bilgisayar.Hardware)
            {
                if (d.HardwareType == HardwareType.Cpu)
                {
                    d.Update();
                    foreach (ISensor s in d.Sensors)
                    {
                        if (s.SensorType == SensorType.Temperature && s.Value.HasValue)
                        {
                            ilkTestSicakligi = (int)s.Value.Value;
                        }
                    }
                }
            }

            if (ilkTestSicakligi == 0)
            {
                PawnIoKurulumuBaslat();
            }
            else
            {
                timer1.Start();
            }
        }

        private void PawnIoKurulumuBaslat()
        {
            DialogResult secim = MessageBox.Show(
                "Sıcaklık verilerini okuyabilmek için 'PawnIO' donanım sürücüsüne ihtiyaç var.\n\nSisteminize hiçbir ayar gerektirmeden otomatik olarak indirip kurmamı ister misiniz?",
                "Gerekli Sürücü Tespiti",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (secim == DialogResult.Yes)
            {
                try
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.UseShellExecute = true;
                    proc.FileName = "winget";
                    proc.Arguments = "install PawnIO --accept-package-agreements --accept-source-agreements --silent";
                    proc.Verb = "runas";

                    proc.WindowStyle = ProcessWindowStyle.Hidden;

                    Process kurulumSüreci = Process.Start(proc);

                    kurulumSüreci.WaitForExit();

                    Application.Restart();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Otomatik kurulum başlatılamadı. Lütfen CMD (Yönetici) üzerinden manuel olarak 'winget install PawnIO' komutunu çalıştırın.\n\nHata detayı: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void StyleKart(Panel pnl)
        {
            pnl.BackColor = ClrCard;
        }

        private void StyleButon(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = ClrButton;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderColor     = ClrButtonBorder;
            btn.FlatAppearance.BorderSize      = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 88, 175);
            btn.Cursor = Cursors.Hand;
        }

        private void KartKenarlıkCiz(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(ClrBorder, 1))
                e.Graphics.DrawRectangle(pen, 0, 0, ((Panel)sender).Width - 1, ((Panel)sender).Height - 1);
        }

        private void DgvTemaUygula(DataGridView dgv)
        {
            dgv.BackgroundColor = ClrBackground;
            dgv.GridColor       = ClrBorder;
            dgv.BorderStyle     = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode   = DataGridViewSelectionMode.FullRowSelect;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.BackColor        = ClrCard;
            dgv.DefaultCellStyle.ForeColor        = ClrText;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 82, 168);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font             = new Font("Segoe UI", 9f);
            dgv.DefaultCellStyle.Padding          = new Padding(2);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(22, 22, 36);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = ClrText;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 48);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(155, 185, 255);
            dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(28, 28, 48);
            dgv.ColumnHeadersHeight = 34;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                if (ilkKucultme)
                {
                    systemNotification.ShowBalloonTip(2000, "Sistem İzleyici", "Uygulama arka planda çalışmaya devam ediyor.", ToolTipIcon.Info);
                    ilkKucultme = false;
                }
            }
        }
        private void KaranlikTemaUygula()
        {
            this.BackColor = ClrBackground;

            pnlHeader.BackColor = ClrHeader;
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.BackColor = ClrHeader;

            StyleKart(pnlCpu);
            StyleKart(pnlGpu);
            StyleKart(pnlRam);

            lblCpuBaslik.ForeColor = Color.DodgerBlue;
            lblGpuBaslik.ForeColor = Color.MediumSpringGreen;
            lblRamBaslik.ForeColor = Color.Tomato;

            foreach (var lbl in new[] { label1, label4, label5, labelGpuYuk, labelVram, label2, labelRamGb})
            {
                lbl.ForeColor = ClrSubText;
                lbl.BackColor = Color.Transparent;
            }

            foreach (var lbl in new[] { lblCpu, lblCpuYuk, lblGpuSicaklik, lblGpuYuk, lblRam })
                lbl.ForeColor = Color.MediumSpringGreen;

            lblVram.ForeColor = Color.MediumPurple;
            lblRamGb.ForeColor = ClrSubText;

            // SADECE EKRANDA KALAN BUTONLARI BOYA
            // (button1: Grafikleri Gör, btnAlarmlariYonet: Alarmları Yönet)
            foreach (var btn in new[] { button1, btnAlarmlariYonet })
                StyleButon(btn);

            pnlCpu.Paint += KartKenarlıkCiz;
            pnlGpu.Paint += KartKenarlıkCiz;
            pnlRam.Paint += KartKenarlıkCiz;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            int cpuSic = 0, cpuYuk = 0, gpuSic = 0, gpuYuk = 0, ramYuz = 0;
            float vram = 0, ramGb = 0;

            await Task.Run(() =>
            {
                foreach (IHardware d in bilgisayar.Hardware)
                {
                    d.Update();

                    if (d.HardwareType == HardwareType.Cpu)
                    {
                        foreach (ISensor s in d.Sensors)
                        {
                            string isim = s.Name.ToUpper();

                            if (s.SensorType == SensorType.Temperature && s.Value.HasValue)
                            {
                                int v = (int)s.Value.Value;
                                if (v > cpuSic && v < 115) cpuSic = v;
                            }

                            if (s.SensorType == SensorType.Load && s.Value.HasValue && isim.Contains("TOTAL"))
                            {
                                cpuYuk = (int)s.Value.Value;
                            }
                        }
                    }

                    if (d.HardwareType == HardwareType.Motherboard)
                    {
                        foreach (IHardware sub in d.SubHardware)
                        {
                            sub.Update();
                            foreach (ISensor s in sub.Sensors)
                            {
                                if (s.SensorType == SensorType.Temperature && s.Value.HasValue && s.Name.ToUpper().Contains("CPU"))
                                {
                                    int v = (int)s.Value.Value;
                                    if (v > cpuSic && v < 115) cpuSic = v;
                                }
                            }
                        }
                    }

                    if (d.HardwareType == HardwareType.GpuNvidia || d.HardwareType == HardwareType.GpuAmd)
                    {
                        foreach (ISensor s in d.Sensors)
                        {
                            string isim = s.Name.ToUpper();
                            if (s.SensorType == SensorType.Temperature && s.Value.HasValue)
                            {
                                if (isim == "GPU CORE")
                                {
                                    gpuSic = (int)s.Value.Value;
                                }
                            }

                            if (s.SensorType == SensorType.Load && s.Value.HasValue)
                            {
                                if (isim == "GPU CORE" || isim == "D3D 3D")
                                {
                                    gpuYuk = (int)s.Value.Value;
                                }
                            }

                            if (s.SensorType == SensorType.SmallData && s.Value.HasValue)
                            {
                                if (isim.Contains("GPU MEMORY USED") || isim.Contains("D3D DEDICATED MEMORY USED"))
                                    vram = s.Value.Value;
                            }
                        }
                    }

                    if (d.HardwareType == HardwareType.Memory)
                    {
                        foreach (ISensor s in d.Sensors)
                        {
                            if (s.SensorType == SensorType.Load && s.Value.HasValue)
                                ramYuz = (int)s.Value.Value;

                            if (s.SensorType == SensorType.Data && s.Value.HasValue && s.Name.ToUpper() == "MEMORY USED")
                                ramGb = s.Value.Value;
                        }
                    }
                }
            });

            Color Renk(int v, int kirmizi, int turuncu) =>
                v >= kirmizi ? Color.Tomato : v >= turuncu ? Color.Orange : Color.MediumSpringGreen;

            lblCpu.Text     = cpuSic > 0 ? $"{cpuSic} °C" : "N/A";
            lblCpu.ForeColor = Renk(cpuSic, 80, 65);

            lblCpuYuk.Text     = $"%{cpuYuk}";
            lblCpuYuk.ForeColor = Renk(cpuYuk, 85, 50);

            lblGpuSicaklik.Text     = $"{gpuSic} °C";
            lblGpuSicaklik.ForeColor = Renk(gpuSic, 80, 65);

            lblGpuYuk.Text     = $"%{gpuYuk}";
            lblGpuYuk.ForeColor = Renk(gpuYuk, 85, 50);

            lblVram.Text     = vram > 0 ? $"{vram:F0} MB" : "N/A";
            lblVram.ForeColor = Color.MediumPurple;

            lblRam.Text     = $"%{ramYuz}";
            lblRam.ForeColor = Renk(ramYuz, 80, 60);

            lblRamGb.Text     = ramYuz > 0 && ramGb > 0
                ? $"{ramGb:F1} / {ramGb / (ramYuz / 100f):F1} GB"
                : "N/A";
            lblRamGb.ForeColor = ClrSubText;

            bool alarm = false;
            foreach (var a in alarmKurallari)
            {
                bool t = false; string msg = "";
                switch (a.HedefDonanim)
                {
                    case "İşlemci Sıcaklığı (°C)":    if (cpuSic >= a.SinirDeger) { t = true; msg = $"Kritik CPU Sıcaklığı: {cpuSic}°C"; } break;
                    case "İşlemci Yükü (%)":           if (cpuYuk >= a.SinirDeger) { t = true; msg = $"Yüksek CPU Yükü: %{cpuYuk}"; } break;
                    case "Ekran Kartı Sıcaklığı (°C)": if (gpuSic >= a.SinirDeger) { t = true; msg = $"Kritik GPU Sıcaklığı: {gpuSic}°C"; } break;
                    case "RAM Kullanımı (%)":           if (ramYuz >= a.SinirDeger) { t = true; msg = $"Yüksek RAM Kullanımı: %{ramYuz}"; } break;
                    case "Ekran Kartı Yükü (%)": if (gpuYuk >= a.SinirDeger) { t = true; msg = $"Yüksek GPU Yükü: %{gpuYuk}"; } break;
                    case "VRAM Kullanımı (MB)": if (vram >= a.SinirDeger) { t = true; msg = $"Yüksek VRAM Kullanımı: {vram:F0} MB"; } break;
                }
                if (t) alarm = true;
                if (t && a.KalanBildirimHakki > 0 && (DateTime.Now - sonBildirimZamani).TotalSeconds >= 15)
                {
                    systemNotification.BalloonTipTitle = "SİSTEM ALARMI!";
                    systemNotification.BalloonTipText  = msg;
                    systemNotification.BalloonTipIcon  = ToolTipIcon.Warning;
                    systemNotification.ShowBalloonTip(3000);
                    sonBildirimZamani = DateTime.Now;
                    a.KalanBildirimHakki--;
                    break;
                }
            }
            systemNotification.Icon = alarm ? SystemIcons.Warning : orijinalIkon;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int cpuSic, cpuYuk, gpuSic, ram, gpuYuk;
            bool ok1 = int.TryParse(lblCpu.Text.Replace(" °C", "").Replace("N/A", "0").Trim(), out cpuSic);
            bool ok2 = int.TryParse(lblCpuYuk.Text.Replace("%", "").Trim(), out cpuYuk);
            bool ok3 = int.TryParse(lblGpuSicaklik.Text.Replace(" °C", "").Trim(), out gpuSic);
            bool ok4 = int.TryParse(lblRam.Text.Replace("%", "").Trim(), out ram);
            bool ok5 = int.TryParse(lblGpuYuk.Text.Replace("%", "").Trim(), out gpuYuk);
            if (ok1 && ok2 && ok3 && ok4)
                VeritabaniYoneticisi.LogEkle(cpuSic, cpuYuk, gpuSic, ram, ok5 ? gpuYuk : 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmGrafikler().ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void systemNotification_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            otomatikBaslatildiMi = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            systemNotification.Icon = orijinalIkon;
            this.BringToFront();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float xOran = (float)this.Width / ilkFormBoyutu.Width;
            float yOran = (float)this.Height / ilkFormBoyutu.Height;

            foreach (Control c in this.Controls)
            {
                if (!ilkKonumlar.ContainsKey(c))
                    continue;

                Rectangle r = ilkKonumlar[c];

                c.Left = (int)(r.Left * xOran);
                c.Top = (int)(r.Top * yOran);
                c.Width = (int)(r.Width * xOran);
                c.Height = (int)(r.Height * yOran);

                c.Font = new Font(
                    c.Font.FontFamily,
                    Math.Max(8, 9 * Math.Min(xOran, yOran)),
                    c.Font.Style);
            }
        }

        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(btnAyarlar, new Point(0, btnAyarlar.Height));
        }

        private void windowsIleBaslatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (windowsİleBaşlatToolStripMenuItem.Checked)
            {
                rk.SetValue("RealTimeSysTracker", "\"" + Application.ExecutablePath + "\" -startup");
            }
            else
            {
                rk.DeleteValue("RealTimeSysTracker", false);
            }
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAlarmlariYonet_Click(object sender, EventArgs e)
        {
            new HardwareMonitor.Forms.FrmAlarmEkle().ShowDialog();
            alarmKurallari = VeritabaniYoneticisi.AlarmlariGetir();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void windowsİleBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (windowsİleBaşlatToolStripMenuItem.Checked)
            {
                rk.SetValue("RealTimeSysTracker", "\"" + Application.ExecutablePath + "\" -startup");
            }
            else
            {
                rk.DeleteValue("RealTimeSysTracker", false);
            }
        }
    }
}