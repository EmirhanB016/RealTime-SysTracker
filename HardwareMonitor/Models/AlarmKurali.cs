using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareMonitor.Models
{
    public class AlarmKurali
    {
        public Guid Id { get; set; } 
        public string HedefDonanim { get; set; } 
        public double SinirDeger { get; set; } 
        public bool AktifMi { get; set; } 

        public AlarmKurali()
        {
            Id = Guid.NewGuid();
            AktifMi = true; 
        }
    }
}
