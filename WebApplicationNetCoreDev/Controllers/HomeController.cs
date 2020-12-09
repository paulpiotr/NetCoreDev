using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationNetCoreDev.Models;

namespace WebApplicationNetCoreDev.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index([FromQuery] string UserName, [FromQuery] string ReturnUrl)
        {
            return View();
        }
        //[Authorize(Roles = "Administrator")]
        //[Authorize(Policy = "Administrator")]
        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "User")]
        public IActionResult Privacy()
        {
            return View();
        }
        //[Authorize(Roles = "Administrator")]
        //[Authorize(Policy = "Administrator")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
