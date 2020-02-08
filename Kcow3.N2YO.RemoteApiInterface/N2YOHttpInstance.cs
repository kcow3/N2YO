using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kcow3.N2YO.RemoteApiInterface
{
    public sealed class N2YOHttpInstance
    {
        private N2YOHttpInstance() { client = new HttpClient(); }
        private HttpClient client = null;
        private readonly string baseUrl = "https://www.n2yo.com/rest/v1/";

        public static N2YOHttpInstance instance = null;
        public static readonly object _lock = new object();

        public static N2YOHttpInstance GetInstance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new N2YOHttpInstance();
                    }
                    return instance;
                }
            }
        }

        public async Task<HttpResponseMessage> TestTleCall(string apiKey, string method)
        {
            return await client.GetAsync($"{baseUrl}{method}&apiKey={apiKey}");
        }

        public async Task<T> PerformGetAndConvertToObj<T>(string apiKey, string method)
        {
            try
            {
                var result = await client.GetAsync($"{baseUrl}{method}&apiKey={apiKey}");

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
                }

                return (T)Activator.CreateInstance(typeof(T));
            }
            catch (Exception e)
            {
                //to-do: logging (e)
                return (T)Activator.CreateInstance(typeof(T));
            }
        }
    }
}
