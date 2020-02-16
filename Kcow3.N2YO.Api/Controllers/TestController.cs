using Kcow3.N2YO.RemoteApiInterface;
using Kcow3.N2YO.StaticData;
using Kcow3.N2YO.TransData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Kcow3.N2YO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        public async Task<string> Get()
        {
            var getVisualPasses = await N2YOHttpInstance.GetInstance.PerformGetAndConvertToObj<VisualPassesResult>("7NZGL7-ERLA8R-5GX5X3-4ATT", Constants.BuildVisualPassesRequest(25544, -25.696, 28.223, 1379, 10, 30));
            return JsonConvert.SerializeObject(getVisualPasses);
        }

        [HttpGet("GetSatInfo")]
        public async Task<string> Get(string Test, string Yeet)
        {
            var getVisualPasses = await N2YOHttpInstance.GetInstance.PerformGetAndConvertToObj<VisualPassesResult>("7NZGL7-ERLA8R-5GX5X3-4ATT", Constants.BuildVisualPassesRequest(25544, -25.696, 28.223, 1379, 10, 30));
            return JsonConvert.SerializeObject(getVisualPasses);
        }
    }
}