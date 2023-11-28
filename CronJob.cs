using Quartz;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ss_cron
{
    public class CronJobGet : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            // Your HTTP request logic goes here
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8080/");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("HTTP request successful! (Get)");
                }
                else
                {
                    Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                }
            }
        }
    }

    public class CronJobPost : IJob 
    {
        public async Task Execute(IJobExecutionContext context)
        {
            // Your HTTP request logic goes here
            using (HttpClient client = new HttpClient())
            {
                string jsonPayload = "{\"Name\":\"Diego\",\"LastName\":\"Beltran\"}";

                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:8080/submit", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("HTTP request successful! (Post)");
                }
                else
                {
                    Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
                }
            }
        }
    }
}
