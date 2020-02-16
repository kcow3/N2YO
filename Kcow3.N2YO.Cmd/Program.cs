using Kcow3.N2YO.Cmd.Services;
using Kcow3.N2YO.RemoteApiInterface;
using Kcow3.N2YO.StaticData;
using Kcow3.N2YO.TransData.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            var tle = await N2YOHttpInstance.GetInstance.PerformGetAndConvertToObj<TleResult>(secretService.GetApiKey(), Constants.BuildTleRequest(25544));

            var satellitePositions = await N2YOHttpInstance.GetInstance.PerformGetAndConvertToObj<SatellitePositionsResult>(secretService.GetApiKey(), Constants.BuildSatellitePositionsRequest(25544, secretService.GetObserverLat(), secretService.GetObserverLng(), 1379, 30));

            var getVisualPasses = await N2YOHttpInstance.GetInstance.PerformGetAndConvertToObj<VisualPassesResult>(secretService.GetApiKey(), Constants.BuildVisualPassesRequest(25544, secretService.GetObserverLat(), secretService.GetObserverLng(), 1379, 10, 30));

            var getRadioPasses = await N2YOHttpInstance.GetInstance.PerformGetAndConvertToObj<RadioPassesResult>(secretService.GetApiKey(), Constants.BuildRadioPassesRequest(25544, secretService.GetObserverLat(), secretService.GetObserverLng(), 1379, 10, 30));

            Console.WriteLine("");
        }
    }
}
