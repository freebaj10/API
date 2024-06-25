using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace StockTicker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the stock ticker:");
            string ticker = Console.ReadLine();

            string apiKey = "cpqjlshr01qo647no9r0cpqjlshr01qo647no9rg";
            string apiUrl = $"https://finnhub.io/api/v1/quote?symbol={ticker}&token={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var StockInfo = JsonSerializer.Deserialize<StockInfo>(json);
                    Console.WriteLine($"Current Price: {StockInfo.c}");
                }
                else
                {
                    Console.WriteLine("Error fetching data");
                }
            }
        }
    }

    public class StockInfo
    {
        public float c { get; set; }
        public float h { get; set; }
        public float l { get; set; }
        public float o { get; set; }
        public float pc { get; set; }
    }
}