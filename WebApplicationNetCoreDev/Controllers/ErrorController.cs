#region using

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace WebApplicationNetCoreDev.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class ErrorController : Controller
    {
        public IActionResult Index() => View();
    }
}
