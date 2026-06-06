# ⚡ RealTimeSysTracker (Hardware Monitor)

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white) ![SQLite](https://img.shields.io/badge/sqlite-%2307405e.svg?style=for-the-badge&logo=sqlite&logoColor=white) ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)


**RealTimeSys Tracker**, sistemin hayati donanım bileşenlerini (CPU, GPU, RAM) işletim sistemi seviyesinde gerçek zamanlı olarak izleyen, kayda değer eşik aşımlarında akıllı alarmlar üreten ve bu verileri geçmişe dönük analizler için yerel veritabanında loglayan gelişmiş bir masaüstü izleme yazılımıdır. 

Sadece bir arayüz uygulaması olmanın ötesinde; arka plan servis mimarisi, asenkron okuma işlemleri ve bellek optimizasyonu göz önünde bulundurularak tasarlanmıştır.

---

## 🚀 Detaylı Özellikler

### 📊 1. Gerçek Zamanlı Donanım Telemetrisi
Açık kaynaklı `LibreHardwareMonitor` ve `PawnIO` sürücüleri kullanılarak donanım sensörlerine doğrudan erişim sağlanır:
* **İşlemci (CPU):** Anlık çekirdek sıcaklıkları (°C) ve genel kullanım yükü (%).
* **Ekran Kartı (GPU):** Çekirdek sıcaklığı, render yükü ve VRAM (Video RAM) tüketim kapasitesi.
* **Bellek (RAM):** Yüzdelik kullanım ve GB cinsinden anlık tüketim/kapasite oranları.

### 🔔 2. Akıllı Alarm ve Kural Motoru
Kullanıcıların kendi donanım sınırlarını belirleyebileceği dinamik bir kural motoru entegre edilmiştir.
* Kullanıcı; CPU Sıcaklığı, GPU Yükü veya RAM kullanımı gibi metrikler için spesifik eşik değerleri (Örn: `CPU > 85°C`) belirleyebilir.
* Belirlenen kurallar ihlal edildiğinde, **Windows Toast Notifications** üzerinden kullanıcı uyarılır.
* Spam bildirimleri engellemek için her alarma özel "Kalan Bildirim Hakkı" ve "Zaman Aşımı" mekanizmaları kodlanmıştır.

### 🕵️ 3. Kusursuz Arka Plan Mimarisi
Bir izleme aracının sürekli ekranda kalmaması gerektiği prensibiyle profesyonel bir Windows Yaşam Döngüsü kurgulanmıştır.
* **Registry Entegrasyonu:** Uygulama, `SOFTWARE\Microsoft\Windows\CurrentVersion\Run` dizinine kendini `-startup` gizli parametresiyle yazar.
* **SetVisibleCore Override:** Windows otomatik başlattığında form ekranda saliselik bile görünmeden doğrudan `NotifyIcon` olarak başlatılır.

### 📈 4. Veri Loglama ve Görselleştirme
Anlık veriler uçucu değildir; analiz edilebilir formatlarda saklanır.
* **MSChart Entegrasyonu:** Geçmişe dönük sistem performans logları, özel bir ekranda çizgisel grafikler halinde görselleştirilir.
* **CSV / Excel Dışa Aktarım:** Veritabanında biriken loglar, saniye hassasiyetli zaman damgalarıyla (`dd.MM.yyyy HH:mm:ss`) bozunmaya uğramadan Excel tabanlı CSV formatında dışa aktarılabilir.

---

## 🧠 Yazılım Mimarisi ve Mühendislik Yaklaşımı

Proje geliştirilirken UI kilitlenmelerini engellemek ve performansı artırmak için çeşitli mimari kararlar alınmıştır:

* **Dual-Timer (Çift Zamanlayıcı) Mimarisi:** 
  Sensörlerden veri okuma (`timer1`) ve veritabanına log yazma (`timer2`) işlemleri birbirinden ayrılmıştır. Ayrıca grafik çizimleri sadece ilgili form açıldığında tetiklenen bağımsız bir (`timerCanliAkis`) zamanlayıcı ile yönetilerek boşta (idle) kaynak tüketimi sıfıra indirilmiştir.
* **Asenkron Programlama:** 
  Donanım okuma döngüleri `Task.Run` blokları içerisine alınarak ana UI iş parçacığırahatlatılmış, uygulamanın donması engellenmiştir.
* **Serverless Local DB:** 
  Kullanıcı verileri ve loglar için harici bir sunucu kurulumu gerektirmeyen, doğrudan proje içerisinde barınan **SQLite** veritabanı kullanılmıştır.

---

## ⚙️ Kurulum Talimatları

1. **Repoyu Klonlayın:**
```bash
   git clone [https://github.com/KULLANICI_ADINIZ/RealTimeSysTracker.git](https://github.com/KULLANICI_ADINIZ/RealTimeSysTracker.git)
```
2. **Çözümü Açın:**

`HardwareMonitor.slnx` dosyasını Visual Studio ile açın.

3. **Derleme:**

Projeyi `Release` modunda ve `x64` mimarisinde derleyin (SQLite ve sensör kütüphanelerinin doğru çalışması için bu adım kritiktir).

4. **Bağımlılıklar:**

Uygulama ilk açıldığında `PawnIO` sürücüsünü otomatik tespit eder. Sistemde yoksa kullanıcı onayı ile `winget` üzerinden sessiz kurulum gerçekleştirir.
