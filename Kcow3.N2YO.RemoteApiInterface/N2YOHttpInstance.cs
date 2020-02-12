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

        public async Task<T> PerformGetAndConvertToObj<T>(string apiKey, string url)
        {
            try
            {
                var result = await client.GetAsync($"{url}&apiKey={apiKey}");

                if (result.IsSuccessStatusCode)
                {
                    var resultString = await result.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<T>(resultString);
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
