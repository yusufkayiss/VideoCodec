# Video Format ve Codec Dönüştürücü (.NET 8 WinForms)

Bu proje, .NET 8 ile C# WinForms kullanılarak geliştirilmiş bir video dönüştürücü uygulamasıdır.

## Desteklenen Özellikler

- Video codec dönüşümü: H.264, H.265/HEVC, VP9, AV1
- Video format dönüşümü: MP4, AVI, MKV, MOV, WEBM, FLV
- Video bit hızı (sıkıştırma oranı) ayarı
- Çözünürlük değiştirme: 720p, 1080p, 4K, kaynakla aynı
- Kare hızı değiştirme: 24, 30, 60, kaynakla aynı
- Ses ayırma: MP3, AAC, WAV
- Video sesini ekleme/değiştirme
- Dönüşüm ilerleme yüzdesi ve iptal özelliği
- Sürükle-bırak ile video ekleme
- FFmpeg yoksa uygulama içinden otomatik indirme/kurulum
- Codec ve işlem tipi seçimi `Strategy` tasarım deseni ile yapılandırıldı

## FFmpeg Kurulumu

Uygulama `ffmpeg` komutunu kullanır. FFmpeg kurulu değilse uygulama ilk ihtiyaç anında otomatik indirip kurar.

Elle kurmak isterseniz aşağıdaki yollardan biriyle çalıştırabilirsiniz:

1. FFmpeg'i sistem PATH ortam değişkenine ekleyin.
2. Veya `ffmpeg.exe` dosyasını uygulama çalışma klasörüne kopyalayın:
   - `bin/Debug/net8.0-windows/ffmpeg.exe`
   - ya da `bin/Debug/net8.0-windows/ffmpeg/ffmpeg.exe`

## Çalıştırma

```bash
dotnet build
dotnet run
```

