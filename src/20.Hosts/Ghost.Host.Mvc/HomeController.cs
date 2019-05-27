using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Ghost.Host.Mvc
{
    class HomeController : Controller
    {
        

        [EnableCors("AllowOrigin")]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}