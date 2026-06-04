using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareMonitor
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                string masaustu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                System.IO.File.WriteAllText(masaustu + "\\BaslangicHatasi.txt", ex.ToString());
            }
        }
    }
}
