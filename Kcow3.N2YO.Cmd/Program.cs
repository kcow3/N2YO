using Kcow3.N2YO.Cmd.Models;
using Kcow3.N2YO.Cmd.Services;
using Kcow3.N2YO.RemoteApiInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

            var res = await N2YOHttpInstance.GetInstance.TestTleCall(secretService.GetApiKey());

            if (res.IsSuccessStatusCode)
            {
                var tle = JsonConvert.DeserializeObject<TleResult>(await res.Content.ReadAsStringAsync());
            }
        }
    }
}
