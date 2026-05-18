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
        private static string baglantiDizesi = $"Data Source={veritabanıAdi};Version=3;";

        public static void VeritabaniIlkles()
        {
            if (!File.Exists(veritabanıAdi))
            {
                SQLiteConnection.CreateFile(veritabanıAdi);
            }

            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();

                string tabloOlusturSQL = @"
                    CREATE TABLE IF NOT EXISTS Alarmlar (
                        Id TEXT PRIMARY KEY,
                        HedefDonanim TEXT NOT NULL,
                        SinirDeger REAL NOT NULL,
                        AktifMi INTEGER NOT NULL,
                        KalanBildirimHakki INTEGER NOT NULL
                    );";

                using (var komut = new SQLiteCommand(tabloOlusturSQL, baglanti))
                {
                    komut.ExecuteNonQuery();
                }

                string logTablosuSQL = @"
                    CREATE TABLE IF NOT EXISTS PerformansLoglari (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        TarihSaat TEXT NOT NULL,
                        CpuSicaklik INTEGER,
                        CpuYuk INTEGER,
                        GpuSicaklik INTEGER,
                        RamKullanimi INTEGER
                    );";

                using (var komut2 = new SQLiteCommand(logTablosuSQL, baglanti))
                {
                    komut2.ExecuteNonQuery();
                }
            }
        }

        public static List<AlarmKurali> AlarmlariGetir()
        {
            var list = new List<AlarmKurali>();

            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                string sorgu = "SELECT * FROM Alarmlar";

                using (var komut = new SQLiteCommand(sorgu, baglanti))
                using (var okuyucu = komut.ExecuteReader())
                {
                    while (okuyucu.Read())
                    {
                        list.Add(new AlarmKurali
                        {
                            Id = Guid.Parse(okuyucu["Id"].ToString()),
                            HedefDonanim = okuyucu["HedefDonanim"].ToString(),
                            SinirDeger = Convert.ToDouble(okuyucu["SinirDeger"]),
                            AktifMi = Convert.ToInt32(okuyucu["AktifMi"]) == 1,
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
                    komut.Parameters.AddWithValue("@Id", kural.Id.ToString());
                    komut.Parameters.AddWithValue("@HedefDonanim", kural.HedefDonanim);
                    komut.Parameters.AddWithValue("@SinirDeger", kural.SinirDeger);
                    komut.Parameters.AddWithValue("@AktifMi", kural.AktifMi ? 1 : 0);
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
                string sql = "DELETE FROM Alarmlar WHERE Id = @Id";

                using (var komut = new SQLiteCommand(sql, baglanti))
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
                    komut.Parameters.AddWithValue("@Id", kural.Id);
                    komut.Parameters.AddWithValue("@AktifMi", kural.AktifMi ? 1 : 0);
                    komut.Parameters.AddWithValue("@KalanBildirimHakki", kural.KalanBildirimHakki);

                    komut.ExecuteNonQuery();
                }
            }
        }

        public static void LogEkle(int cpuSicaklik, int cpuYuk, int gpuSicaklik, int ramKullanimi)
        {
            using (var baglanti = new SQLiteConnection(baglantiDizesi))
            {
                baglanti.Open();
                string sql = @"INSERT INTO PerformansLoglari (TarihSaat, CpuSicaklik, CpuYuk, GpuSicaklik, RamKullanimi) 
                               VALUES (@TarihSaat, @CpuSicaklik, @CpuYuk, @GpuSicaklik, @RamKullanimi)";

                using (var komut = new SQLiteCommand(sql, baglanti))
                {
                    komut.Parameters.AddWithValue("@TarihSaat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    komut.Parameters.AddWithValue("@CpuSicaklik", cpuSicaklik);
                    komut.Parameters.AddWithValue("@CpuYuk", cpuYuk);
                    komut.Parameters.AddWithValue("@GpuSicaklik", gpuSicaklik);
                    komut.Parameters.AddWithValue("@RamKullanimi", ramKullanimi);

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
                string sorgu = "SELECT * FROM PerformansLoglari ORDER BY Id DESC LIMIT 50";

                using (var komut = new SQLiteCommand(sorgu, baglanti))
                using (var okuyucu = komut.ExecuteReader())
                {
                    tablo.Load(okuyucu);
                }
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

                string sorgu = "SELECT * FROM PerformansLoglari WHERE TarihSaat >= @FiltreZamani ORDER BY Id DESC";

                using (var komut = new SQLiteCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@FiltreZamani", filtreZamani);
                    using (var okuyucu = komut.ExecuteReader())
                    {
                        tablo.Load(okuyucu);
                    }
                }
            }
            return tablo;
        }
    }
}