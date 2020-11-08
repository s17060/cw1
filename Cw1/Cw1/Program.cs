using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Enter URL:");
            string url = Console.ReadLine();

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();
                Regex emailRegex = new Regex("[a-x0-9]+@[a-z.]+",
                RegexOptions.IgnoreCase);
                MatchCollection emailMatches = emailRegex.Matches(html);

                foreach (Match m in emailMatches)
                {
                    Console.WriteLine(m);
                }
            }

            
        }
    }
}
