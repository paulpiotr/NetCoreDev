using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNetCoreDev.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
