using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using HardwareMonitor.Models;

namespace HardwareMonitor
{
    public class VeritabaniYoneticisi
    {
        private static string veritabanıAdi = "hardware_monitor.db";
        public static string baglantiDizesi;

        public static void VeritabaniIlkles()
        {
            string klasorYolu = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HardwareMonitor");
            string dbYolu = Path.Combine(klasorYolu, "hardware_monitor.db");

            baglantiDizesi = $"Data Source={dbYolu};Version=3;";

            if (!Directory.Exists(klasorYolu))
                Directory.CreateDirectory(klasorYolu);

            if (!File.Exists(dbYolu))
                SQLiteConnection.CreateFile(dbYolu);

            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();

                // Ana log tablosu
                string tabloSorgusu = @"CREATE TABLE IF NOT EXISTS PerformansLoglari (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TarihSaat DATETIME,
                    CpuSicaklik INTEGER,
                    CpuYuk INTEGER,
                    GpuSicaklik INTEGER,
                    RamKullanimi INTEGER)";

                using (var komut = new SQLiteCommand(tabloSorgusu, baglanti))
                    komut.ExecuteNonQuery();

                // Mevcut veritabanına GpuYuk sütunu ekle (yoksa)
                try
                {
                    using (var komut = new SQLiteCommand(
                        "ALTER TABLE PerformansLoglari ADD COLUMN GpuYuk INTEGER DEFAULT 0", baglanti))
                        komut.ExecuteNonQuery();
                }
                catch { /* Sütun zaten varsa hata fırlatır, görmezden gel */ }

                // Alarm tablosu
                string alarmTabloSorgusu = @"CREATE TABLE IF NOT EXISTS Alarmlar (
                    Id TEXT PRIMARY KEY,
                    HedefDonanim TEXT,
                    SinirDeger INTEGER,
                    AktifMi INTEGER,
                    KalanBildirimHakki INTEGER)";

                using (var komut2 = new SQLiteCommand(alarmTabloSorgusu, baglanti))
                    komut2.ExecuteNonQuery();
            }
        }

        public static List<AlarmKurali> AlarmlariGetir()
        {
            var list = new List<AlarmKurali>();
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                using (var komut = new SQLiteCommand("SELECT * FROM Alarmlar", baglanti))
                using (var okuyucu = komut.ExecuteReader())
                {
                    while (okuyucu.Read())
                    {
                        list.Add(new AlarmKurali
                        {
                            Id                 = Guid.Parse(okuyucu["Id"].ToString()),
                            HedefDonanim       = okuyucu["HedefDonanim"].ToString(),
                            SinirDeger         = Convert.ToDouble(okuyucu["SinirDeger"]),
                            AktifMi            = Convert.ToInt32(okuyucu["AktifMi"]) == 1,
                            KalanBildirimHakki = Convert.ToInt32(okuyucu["KalanBildirimHakki"])
                        });
                    }
                }
            }
            return list;
        }

        public static void AlarmEkle(AlarmKurali kural)
        {
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                string sql = @"INSERT INTO Alarmlar (Id, HedefDonanim, SinirDeger, AktifMi, KalanBildirimHakki)
                               VALUES (@Id, @HedefDonanim, @SinirDeger, @AktifMi, @KalanBildirimHakki)";
                using (var komut = new SQLiteCommand(sql, baglanti))
                {
                    komut.Parameters.AddWithValue("@Id",                 kural.Id.ToString());
                    komut.Parameters.AddWithValue("@HedefDonanim",       kural.HedefDonanim);
                    komut.Parameters.AddWithValue("@SinirDeger",         kural.SinirDeger);
                    komut.Parameters.AddWithValue("@AktifMi",            kural.AktifMi ? 1 : 0);
                    komut.Parameters.AddWithValue("@KalanBildirimHakki", kural.KalanBildirimHakki);
                    komut.ExecuteNonQuery();
                }
            }
        }

        public static void AlarmSil(string id)
        {
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                using (var komut = new SQLiteCommand("DELETE FROM Alarmlar WHERE Id = @Id", baglanti))
                {
                    komut.Parameters.AddWithValue("@Id", id);
                    komut.ExecuteNonQuery();
                }
            }
        }

        public static void AlarmGuncelle(AlarmKurali kural)
        {
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                string sql = "UPDATE Alarmlar SET AktifMi = @AktifMi, KalanBildirimHakki = @KalanBildirimHakki WHERE Id = @Id";
                using (var komut = new SQLiteCommand(sql, baglanti))
                {
                    komut.Parameters.AddWithValue("@Id",                 kural.Id);
                    komut.Parameters.AddWithValue("@AktifMi",            kural.AktifMi ? 1 : 0);
                    komut.Parameters.AddWithValue("@KalanBildirimHakki", kural.KalanBildirimHakki);
                    komut.ExecuteNonQuery();
                }
            }
        }

        // GpuYuk parametresi eklendi
        public static void LogEkle(int cpuSicaklik, int cpuYuk, int gpuSicaklik, int ramKullanimi, int gpuYuk = 0)
        {
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                string sql = @"INSERT INTO PerformansLoglari
                    (TarihSaat, CpuSicaklik, CpuYuk, GpuSicaklik, RamKullanimi, GpuYuk)
                    VALUES (@TarihSaat, @CpuSicaklik, @CpuYuk, @GpuSicaklik, @RamKullanimi, @GpuYuk)";

                using (var komut = new SQLiteCommand(sql, baglanti))
                {
                    komut.Parameters.AddWithValue("@TarihSaat",    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    komut.Parameters.AddWithValue("@CpuSicaklik",  cpuSicaklik);
                    komut.Parameters.AddWithValue("@CpuYuk",       cpuYuk);
                    komut.Parameters.AddWithValue("@GpuSicaklik",  gpuSicaklik);
                    komut.Parameters.AddWithValue("@RamKullanimi", ramKullanimi);
                    komut.Parameters.AddWithValue("@GpuYuk",       gpuYuk);
                    komut.ExecuteNonQuery();
                }
            }
        }

        public static System.Data.DataTable LoglariGetir()
        {
            var tablo = new System.Data.DataTable();
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                using (var komut = new SQLiteCommand(
                    "SELECT * FROM PerformansLoglari ORDER BY Id DESC LIMIT 50", baglanti))
                using (var okuyucu = komut.ExecuteReader())
                    tablo.Load(okuyucu);
            }
            return tablo;
        }

        public static System.Data.DataTable ZamanFiltreliLoglariGetir(int dakika)
        {
            var tablo = new System.Data.DataTable();
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                string filtreZamani = DateTime.Now.AddMinutes(-dakika).ToString("yyyy-MM-dd HH:mm:ss");
                string sorgu = "SELECT * FROM PerformansLoglari WHERE TarihSaat >= @FiltreZamani ORDER BY Id ASC";
                using (var komut = new SQLiteCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@FiltreZamani", filtreZamani);
                    using (var okuyucu = komut.ExecuteReader())
                        tablo.Load(okuyucu);
                }
            }
            return tablo;
        }

        public static System.Data.DataTable CanliLoglariGetir(int satirSayisi = 20)
        {
            var tablo = new System.Data.DataTable();
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                string sorgu = $@"SELECT * FROM (
                    SELECT * FROM PerformansLoglari ORDER BY Id DESC LIMIT {satirSayisi}
                ) ORDER BY Id ASC";
                using (var komut = new SQLiteCommand(sorgu, baglanti))
                using (var okuyucu = komut.ExecuteReader())
                    tablo.Load(okuyucu);
            }
            return tablo;
        }
    }
}