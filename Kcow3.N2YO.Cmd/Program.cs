using Kcow3.N2YO.Cmd.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Kcow3.N2YO.Cmd.Services;

namespace Kcow3.N2YO.Cmd
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static HttpClient client = new HttpClient();
     
        static async Task Main(string[] args)
        {
            #region SecretSetup
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder();

            builder
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (isDevelopment)
            {
                builder.AddUserSecrets<Program>();
            }

            Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            services
                .Configure<Secret>(Configuration.GetSection("Secrets"))
                .AddOptions()
                .AddSingleton<ISecretService, SecretService>()
                .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();
            var secretService = serviceProvider.GetService<ISecretService>();
            #endregion

            //Console.WriteLine($"Key: {secretService.GetApiKey()}");
            
            var req = await client.GetAsync($"https://www.n2yo.com/rest/v1/satellite/tle/25544&apiKey={secretService.GetApiKey()}");

            HttpResponseMessage response = await client.GetAsync($"https://www.n2yo.com/rest/v1/satellite/tle/25544&apiKey={secretService.GetApiKey()}");

            if (response.IsSuccessStatusCode)
            {
                var tle = JsonConvert.DeserializeObject<TleResult>(await req.Content.ReadAsStringAsync());
            }
        }
    }
}
