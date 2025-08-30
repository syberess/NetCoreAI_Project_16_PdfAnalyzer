﻿using System.Text;
using Newtonsoft.Json;
using UglyToad.PdfPig;


class Program
{
    private static readonly string apiKey = "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";

    static async Task Main(string[] args)
    {
        Console.WriteLine("Pdf dosyası yolunu giriniz:");
        string pdfPath = Console.ReadLine();
        Console.WriteLine("Pdf Analizi AI tarafından yapılıyor...");
        Console.WriteLine();
        string pdfText = ExtractTextFromPdf(pdfPath);
        await AnalyzedWithAI(pdfText, "Pdf İçeriği");

        static string ExtractTextFromPdf(string filePath)
        {
            StringBuilder text = new StringBuilder();
            using(PdfDocument pdf = PdfDocument.Open(filePath))
            {
                foreach(var page in pdf.GetPages())
                {
                    text.AppendLine(page.Text); //satır satır okuma işlemi yapacak

                }
            }
            return text.ToString();
        }

        static async Task AnalyzedWithAI(string text, string sourceType)
        {
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new {role="system",content="Sen bir yapay zeka asistanısın. Kullanıcının gönderdiği metni analiz eder ve Türkçe olarak özetlersin. Yanıtlarını sadece Türkçe ver!"},
                        new{role="user",content=$"Analyze and summarize the following {sourceType}:\n\n{text}"}
                    }

                };

                string json  = JsonConvert.SerializeObject(requestBody);
                HttpContent content = new StringContent(json,Encoding.UTF8,"applicationjson");

                HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                string responseJson = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<dynamic>(responseJson);
                    Console.WriteLine($"\n AI Analizi({sourceType}): \n{result.choices[0].message.content}");
                }
                else
                {
                    Console.WriteLine("Hata: " + responseJson);
                }
            }
        }
    }
}