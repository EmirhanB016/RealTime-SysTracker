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
        public FrmAlarmEkle()
        {
            InitializeComponent();
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
                HedefDonanim = cmbDonanim.Text,
                SinirDeger = Convert.ToDouble(txtSinirDeger.Text)
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
