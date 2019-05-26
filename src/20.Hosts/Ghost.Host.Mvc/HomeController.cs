using Microsoft.AspNetCore.Mvc;

namespace Ghost.Host.Mvc
{
    class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}