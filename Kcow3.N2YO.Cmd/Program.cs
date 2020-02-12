using Kcow3.N2YO.Cmd.Models;
using Kcow3.N2YO.Cmd.Services;
using Kcow3.N2YO.RemoteApiInterface;
using Kcow3.N2YO.StaticData;
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

            // TLE
            var tle = await N2YOHttpInstance.GetInstance.PerformGetAndConvertToObj<TleResult>(secretService.GetApiKey(), Constants.BuildTleRequest(25544));
            Console.WriteLine(tle.Tle);
            Console.WriteLine($"{tle.Info.SatId}  {tle.Info.SatName}");

            // Get Satellite positions
            var satellitePositions = await N2YOHttpInstance.GetInstance.PerformGetAndConvertToObj<SatellitePositionsResult>(secretService.GetApiKey(), Constants.BuildSatellitePositionsRequest(25544, 41.702, -76.014,0,2));

            //var getVisualPasses = 

            //var getRadioPasses = 


        }
    }
}
