using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace YOLO
{
    class Program
    {
        public static string NewCookie()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 22; i++)
            {
                stringBuilder.Append(valid[random.Next(valid.Length)]);
            }

            return stringBuilder.ToString();
        }
        public static void Main(string[] args)
        {
            string UserName = Environment.UserName;
            Console.WriteLine($"Hello, {UserName}!");
            Thread.Sleep(5000);
            Console.WriteLine("YOLO Spammer by trump");
            Thread.Sleep(1000);
            Console.WriteLine("First off, what is the YOLO's ID?");
            string ID = Console.ReadLine();
            Console.WriteLine("Got it! What question is the YOLO asking? (Honest Opinions, etc.)");
            string question = Console.ReadLine();
            Thread.Sleep(1000);

            while (true)
            {
                SendYolo(ID, question);
            }
        }
        public static void SendYolo(string ID, string question)
        {
            System.Net.Http.HttpClient client = new HttpClient();

            string cookie = NewCookie();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("cookie", $"popshow-temp-id={cookie}");
            client.DefaultRequestHeaders.Add("origin", "https://onyolo.com");
            client.DefaultRequestHeaders.Add("referer", $"https://onyolo.com/m/{ID}");
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.61 Safari/537.36");

            Dictionary<string, string> paramaters = new Dictionary<string, string>();

            paramaters.Add("text", "Adelis is my gf");
            paramaters.Add("cookie", cookie);
            paramaters.Add("wording", question);

            StringContent send = new StringContent(JsonConvert.SerializeObject(paramaters), Encoding.UTF8, "application/json");

            client.PostAsync(new Uri($"http://onyolo.com/{ID}/message"), send);

            Console.WriteLine("Successfully sent a message!");
        }
    }
}
