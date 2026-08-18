# ⚙️ VideoCodec - Core Video Processing Engine (.NET 8)

Bu depo, video yükleme mimarisinin mutfak kısmını oluşturan, video dönüştürme ve kodlama (encoding/decoding) işlemlerini yürüten **çekirdek motor (core engine)** projesidir.

## 🚀 Özellikler & Görevler

* **Yüksek Performanslı İşleme:** Ham veya farklı formatlardaki video dosyalarını optimize ederek işler.
* **Bağımsız Katman:** API veya kuyruk mekanizmalarından bağımsız, saf iş mantığı (Business Logic) ve algoritma barındırır.
* **Genişletilebilir Yapı:** İleride farklı video codec bileşenleri (H.264, H.265 vb.) eklenebilecek şekilde temiz kod prensiplerine (SOLID) uygun tasarlanmıştır.

## 🧩 Sistemdeki Rolü

Bu kütüphane, ana sistemdeki Worker Service tarafından referans alınarak arka planda dönen asenkron video sıkıştırma ve simülasyon süreçlerinin asıl matematiksel ve algoritmik iş yükünü sırtlanır.

---

## 🔗 Ana Sistem & Mimari
**Not:** Bu motorun; RabbitMQ, Docker ve Worker Service kullanılarak asenkron bir mimariyle nasıl entegre edildiğini görmek için ana proje olan [VideoProcessing Asenkron Mimarisi](https://github.com/yusufkayiss/VideoProcessing) reposuna göz atabilirsiniz.
