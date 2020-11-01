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
            string responseBody = await httpClient.GetStringAsync(url);

            Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            RegexOptions.IgnoreCase);
            MatchCollection emailMatches = emailRegex.Matches(responseBody);

            foreach(Match m in emailMatches)
            {
                Console.WriteLine(m);
            }
        }
    }
}
