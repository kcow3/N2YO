using Kcow3.N2YO.Cmd.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Kcow3.N2YO.Cmd
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static HttpClient client = new HttpClient();

        static void Main(string[] args)
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

            //var client = new RestClient("https://localhost:44384/weatherforecast");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("authorization", " eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ik9VUTRNMFpEUXpKRU5FTkJPVUV5TWtOR1FqQTVRVFl4UWtJNE5VTTJORGMyUlRFeU9USTVSQSJ9.eyJpc3MiOiJodHRwczovL2tjb3czLmF1dGgwLmNvbS8iLCJzdWIiOiJlWjd4cDAzaXlmS3ZWbERWYlpLcHFuNFNOb2tMdWlhTEBjbGllbnRzIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzODQvIiwiaWF0IjoxNTgxMDI0MTc1LCJleHAiOjE1ODExMTA1NzUsImF6cCI6ImVaN3hwMDNpeWZLdlZsRFZiWktwcW40U05va0x1aWFMIiwiZ3R5IjoiY2xpZW50LWNyZWRlbnRpYWxzIn0.CqxYxZWE3tioFDdBCEpYzFGn7_XzHdFyyGYYqNXcj1q8koO2ZsGZosKR433VqdKl10G7HKIDce-ekZWpoNUT6X95VqY9twOtMQk7dQqptZp_OQnFQZ3YuhV0qT_IB0ewS_aqLodi0Dq-bRMYg6EIVFwugCpX2wggRcoU7VwBpTATdQ_qeAigVCC43LtIwiJ92pErVAnZxWv1U_IrZyRIkGH4X3WgVg5KL0zPrJwt_DoDYl3kWCnNkfZu-mFgKutFb-jm2Mm1ytHEXe7ZOgoTwyOx4IF4QyJ2Mc8wbtqqy8TDDS_sp9zHnDOD5j3y_9Cd1FY1ooEoIRsoxd8MffHqzQ");
            //IRestResponse response = client.Execute(request);

            ////Console.WriteLine($"Key: {secretService.GetApiKey()}");

            //var req = await client.GetAsync($"https://www.n2yo.com/rest/v1/satellite/tle/25544&apiKey={secretService.GetApiKey()}");

            //HttpResponseMessage response = await client.GetAsync($"https://www.n2yo.com/rest/v1/satellite/tle/25544&apiKey={secretService.GetApiKey()}");

            //if (response.IsSuccessStatusCode)
            //{
            //    var tle = JsonConvert.DeserializeObject<TleResult>(await req.Content.ReadAsStringAsync());
            //}
        }
    }
}
