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

        public async Task<HttpResponseMessage> TestTleCall(string apiKey)
        {
           return await client.GetAsync($"https://www.n2yo.com/rest/v1/satellite/tle/25544&apiKey={apiKey}");
        }
    }
}
