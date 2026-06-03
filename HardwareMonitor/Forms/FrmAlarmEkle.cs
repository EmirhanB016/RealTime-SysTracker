using HardwareMonitor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareMonitor.Forms
{
    public partial class FrmAlarmEkle : Form
    {
        public AlarmKurali YeniKural { get; private set; }

        List<AlarmKurali> alarmKurallari = new List<AlarmKurali>();
        Stack<AlarmKurali> silinenAlarmlar = new Stack<AlarmKurali>();

        private static readonly Color ClrBackground = Color.FromArgb(18, 18, 28);
        private static readonly Color ClrCard = Color.FromArgb(26, 26, 42);
        private static readonly Color ClrBorder = Color.FromArgb(52, 52, 82);
        private static readonly Color ClrText = Color.FromArgb(218, 218, 235);
        private static readonly Color ClrButton = Color.FromArgb(38, 68, 138);

        Dictionary<string, int> varsayilanSinirlar = new Dictionary<string, int>()
        {
            { "İşlemci Sıcaklığı (°C)", 80 },
            { "İşlemci Yükü (%)", 85 },
            { "Ekran Kartı Sıcaklığı (°C)", 75 },
            { "RAM Kullanımı (%)", 80 },
            { "Ekran Kartı Yükü (%)", 85 },
            { "VRAM Kullanımı (MB)", 0 }
        };

        public FrmAlarmEkle()
        {
            InitializeComponent();
            KaranlikTemaUygula();

            alarmKurallari = VeritabaniYoneticisi.AlarmlariGetir();
            AlarmlariListele();
        }

        private void KaranlikTemaUygula()
        {
            this.BackColor = ClrBackground;
            this.ForeColor = ClrText;

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = ClrButton;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(68, 108, 215);
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Cursor = Cursors.Hand;
                }
            }

            if (this.Controls.ContainsKey("txtArama"))
            {
                TextBox ara = (TextBox)this.Controls["txtArama"];
                ara.BackColor = Color.FromArgb(30, 30, 48);
                ara.ForeColor = ClrText;
                ara.BorderStyle = BorderStyle.FixedSingle;
            }

            DgvTemaUygula(dgvAlarmlar);
        }

        private void DgvTemaUygula(DataGridView dgv)
        {
            dgv.BackgroundColor = ClrBackground;
            dgv.GridColor = ClrBorder;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.BackColor = ClrCard;
            dgv.DefaultCellStyle.ForeColor = ClrText;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 82, 168);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11f);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(22, 22, 36);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = ClrText;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 28, 48);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(155, 185, 255);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(28, 28, 48);
            dgv.ColumnHeadersHeight = 42;
        }

        private void cmbDonanim_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenDonanim = cmbDonanim.Text;
            if (varsayilanSinirlar.ContainsKey(secilenDonanim))
            {
                txtSinirDeger.Text = varsayilanSinirlar[secilenDonanim].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e) 
        {
            if (string.IsNullOrWhiteSpace(cmbDonanim.Text) || string.IsNullOrWhiteSpace(txtSinirDeger.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            YeniKural = new AlarmKurali
            {
                Id = Guid.NewGuid(),
                HedefDonanim = cmbDonanim.Text,
                SinirDeger = Convert.ToDouble(txtSinirDeger.Text),
                KalanBildirimHakki = (int)numBildirimSayisi.Value,
                AktifMi = true
            };

            alarmKurallari.Add(YeniKural);
            VeritabaniYoneticisi.AlarmEkle(YeniKural);
            AlarmlariListele();
        }
        private void AlarmlariListele()
        {
            dgvAlarmlar.DataSource = null;
            dgvAlarmlar.DataSource = alarmKurallari;
            dgvAlarmlar.ReadOnly = true;
            dgvAlarmlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvAlarmlar.Columns["Id"] != null) dgvAlarmlar.Columns["Id"].Visible = false;
            if (dgvAlarmlar.Columns["HedefDonanim"] != null) dgvAlarmlar.Columns["HedefDonanim"].HeaderText = "Hedef Donanım";
            if (dgvAlarmlar.Columns["SinirDeger"] != null) dgvAlarmlar.Columns["SinirDeger"].HeaderText = "Sınır Değer";
            if (dgvAlarmlar.Columns["AktifMi"] != null) dgvAlarmlar.Columns["AktifMi"].HeaderText = "Aktif mi?";
            if (dgvAlarmlar.Columns["KalanBildirimHakki"] != null) dgvAlarmlar.Columns["KalanBildirimHakki"].HeaderText = "Kalan Bildirim";

            dgvAlarmlar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dgvAlarmlar.Columns)
                col.DefaultCellStyle.Alignment = col.Name == "HedefDonanim"
                    ? DataGridViewContentAlignment.MiddleLeft
                    : DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvAlarmlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var k = (AlarmKurali)dgvAlarmlar.Rows[e.RowIndex].DataBoundItem;
            k.AktifMi = !k.AktifMi;
            VeritabaniYoneticisi.AlarmGuncelle(k);
            AlarmlariListele();
            MessageBox.Show($"'{k.HedefDonanim}' alarmı güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            string ara = txtArama.Text.ToLower();
            dgvAlarmlar.DataSource = null;
            dgvAlarmlar.DataSource = alarmKurallari.Where(k => k.HedefDonanim.ToLower().Contains(ara)).ToList();

            // Sütun isimlerini tekrar düzenle
            if (dgvAlarmlar.Columns["Id"] != null) dgvAlarmlar.Columns["Id"].Visible = false;
            if (dgvAlarmlar.Columns["HedefDonanim"] != null) dgvAlarmlar.Columns["HedefDonanim"].HeaderText = "Hedef Donanım";
            if (dgvAlarmlar.Columns["SinirDeger"] != null) dgvAlarmlar.Columns["SinirDeger"].HeaderText = "Sınır Değer";
            if (dgvAlarmlar.Columns["AktifMi"] != null) dgvAlarmlar.Columns["AktifMi"].HeaderText = "Aktif mi?";
            if (dgvAlarmlar.Columns["KalanBildirimHakki"] != null) dgvAlarmlar.Columns["KalanBildirimHakki"].HeaderText = "Kalan Bildirim";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAlarmlar.CurrentRow != null)
            {
                var k = (AlarmKurali)dgvAlarmlar.CurrentRow.DataBoundItem;
                silinenAlarmlar.Push(k);
                alarmKurallari.Remove(k);
                VeritabaniYoneticisi.AlarmSil(k.Id.ToString());
                AlarmlariListele();
            }
            else MessageBox.Show("Lütfen silmek için tablodan bir alarm seçin.");
        }

        private void btnGeriAl_Click(object sender, EventArgs e)
        {
            if (silinenAlarmlar.Count > 0)
            {
                var geriAlinan = silinenAlarmlar.Pop();
                alarmKurallari.Add(geriAlinan);
                VeritabaniYoneticisi.AlarmEkle(geriAlinan);
                AlarmlariListele();
            }
            else MessageBox.Show("Geri alınacak silinmiş bir alarm bulunmuyor.");
        }

        private void dgvAlarmlar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAlarmlar.ClearSelection();
        }
    }
}