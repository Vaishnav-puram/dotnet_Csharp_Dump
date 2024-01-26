using Microsoft.AspNetCore.Mvc;

namespace BundlingMinification.Controllers
{
    public class JSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
