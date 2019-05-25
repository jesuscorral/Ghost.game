using Ghost.Host.Mvc.Attributes;
using Ghost.Service.Interface.Request;
using Ghost.Service.Interface.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ghost.Host.Mvc
{
    [Produces("application/json")]
    public class GhostController : Controller
    {
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CheckWordResponse))]
        [GhostRoute("checkWord")]
        public async Task<IActionResult> CheckWord([FromBody] CheckWordRequest request)
        {
            //return this.Json(await this.ghostService.CheckWordAsync(request));

            return this.Json(new CheckWordResponse());
        }
    }
}