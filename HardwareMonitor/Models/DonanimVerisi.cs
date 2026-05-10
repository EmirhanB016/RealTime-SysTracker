using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareMonitor.Models
{
    public class DonanimVerisi
    {
        public string DonanimKodu { get; set; } 
        public string DonanimAdi { get; set; }  
        public double AnlikDeger { get; set; }  
        public DateTime OkumaZamani { get; set; } 

        public DonanimVerisi()
        {
            OkumaZamani = DateTime.Now;
        }
    }
}