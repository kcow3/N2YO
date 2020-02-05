using Kcow3.N2YO.Cmd.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kcow3.N2YO.Cmd
{
    class Program
    {
        static HttpClient client = new HttpClient();
        private static string baseUri = "https://www.n2yo.com/rest/v1/satellite/";
        private static readonly string apiKey = "Key Here";

        static async Task Main(string[] args)
        {
            var req = await client.GetAsync($"https://www.n2yo.com/rest/v1/satellite/tle/25544&apiKey={apiKey}");

            HttpResponseMessage response = await client.GetAsync($"https://www.n2yo.com/rest/v1/satellite/tle/25544&apiKey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                var tle = JsonConvert.DeserializeObject<TleResult>(await req.Content.ReadAsStringAsync());
            }
        }
    }
}
