# 📑 NetCoreAI Project 16 - PDF Content Analyzer & Summarizer

Bu proje, **.NET Console Application** kullanarak bir PDF dosyasının içeriğini çıkarır ve **OpenAI Chat Completions API** üzerinden Türkçe özet/analiz üretir.  
Kullanıcıdan PDF dosyası yolu alınır, içerik `PdfPig` kütüphanesi ile okunur ve OpenAI API’ye gönderilerek Türkçe özet döndürülür.  

---

## 🛠️ Kullanılan Teknolojiler
- .NET 8 / 9 Console Application  
- [UglyToad.PdfPig](https://github.com/UglyToad/PdfPig) (PDF metin okuma)  
- OpenAI API (Chat Completions - `gpt-3.5-turbo`)  
- HttpClient (API isteği için)  
- Newtonsoft.Json (JSON serialize/deserialize)  

---

## 📂 Proje Yapısı
- `Program.cs` → Ana uygulama  
  - `ExtractTextFromPdf()` → PDF’ten tüm sayfaları okuyup metin çıkarır  
  - `AnalyzedWithAI()` → OpenAI API’ye gönderir, Türkçe özet/analiz döndürür  

---

## ⚙️ Kurulum ve Çalıştırma
1. Repo’yu klonla:
   git clone https://github.com/kullaniciadiniz/NetCoreAI_Project_16_PdfAnalyzer.git
   cd NetCoreAI_Project_16_PdfAnalyzer
NuGet paketlerini yükle:
dotnet add package UglyToad.PdfPig
dotnet add package Newtonsoft.Json
Program.cs içinde kendi OpenAI API anahtarını ekle:
private static readonly string apiKey = "YOUR_API_KEY";

Konsol uygulamasını çalıştır:
dotnet run
Konsolda PDF yolu gir:
Pdf dosyası yolunu giriniz:
> C:\Users\monster\Desktop\makale.pdf

Pdf Analizi AI tarafından yapılıyor...

AI Analizi(Pdf İçeriği):
Bu PDF yapay zeka teknolojisinin tarihsel gelişimini ve kullanım alanlarını özetlemektedir...

✨ Özellikler
✔️ PDF’ten metin çıkarma (PdfPig ile)

✔️ OpenAI API ile Türkçe özet/analiz

✔️ Konsolda çıktı gösterimi

✔️ Hata durumlarını ekrana yazdırma﻿
