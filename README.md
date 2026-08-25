# ⚙️ VideoCodec - Core Video Processing Engine (.NET 8)

High-performance video encoding, decoding, and processing core library built with .NET 8.

---

## 🌐 English

### 🚀 Overview
A high-performance core engine designed for video encoding, decoding, and format optimization within a distributed architecture. Built with pure business logic and clean design principles.

### 🛠 Tech Stack
- **Framework**: .NET 8 (C#)
- **Architecture**: SOLID Principles, Clean Code
- **Processing**: Multi-threaded & Asynchronous Core Logic

### ✨ Key Features & Responsibilities
- **High-Performance Processing**: Efficiently optimizes and converts raw or various video formats.
- **Decoupled Engine**: Completely isolated from APIs or message broker infrastructure, encapsulating pure business logic.
- **Extensible Design**: Fully compliant with SOLID principles to easily integrate future video codecs (e.g., H.264, H.265).
- **Core System Integration**: Handles heavy computational and algorithmic workloads, consumed directly by background Worker Services.

### 🔗 System Architecture & Related Projects
> 💡 **Note**: To see how this core engine integrates into a distributed asynchronous architecture using **RabbitMQ, Docker, and Worker Services**, visit the main project repository: [VideoProcessing Architecture](https://github.com/yusufkayiss/VideoProcessing).

---

## 📍 Türkçe

### 🚀 Genel Bakış
Dağıtık mimariler için tasarlanmış, video dönüştürme ve kodlama (encoding/decoding) işlemlerini yürüten .NET 8 tabanlı **çekirdek motor (core engine)** kütüphanesi.

### 🛠 Teknolojiler
- **Framework**: .NET 8 (C#)
- **Mimari**: SOLID Prensipleri, Temiz Kod
- **İşlem Tipi**: Çok İzlekli (Multi-threaded) & Asenkron İş Mantığı

### ✨ Özellikler & Görevler
- **Yüksek Performanslı İşleme**: Ham veya farklı formatlardaki video dosyalarını optimize ederek işler.
- **Bağımsız Katman**: API veya kuyruk mekanizmalarından bağımsız, saf iş mantığı (Business Logic) ve algoritmaları barındırır.
- **Genişletilebilir Yapı**: İleride farklı video codec bileşenleri (H.264, H.265 vb.) eklenebilecek şekilde temiz kod prensiplerine (SOLID) uygun tasarlanmıştır.
- **Sistemdeki Rolü**: Ana sistemdeki Worker Service tarafından tüketilerek arka plandaki asenkron video sıkıştırma ve işleme süreçlerinin matematiksel/algoritmik yükünü sırtlanır.

### 🔗 Ana Sistem & Mimari
> 💡 **Not**: Bu motorun RabbitMQ, Docker ve Worker Service kullanılarak asenkron bir mimariyle nasıl entegre edildiğini görmek için ana proje olan [VideoProcessing Asenkron Mimarisi](https://github.com/yusufkayiss/VideoProcessing) reposuna göz atabilirsiniz.
