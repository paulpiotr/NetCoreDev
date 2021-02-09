#region using

using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationNetCoreDev.Models;

#endregion

namespace WebApplicationNetCoreDev.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class HomeController : Controller
    {
        #region private log4net.ILog _log4Net

        /// <summary>
        ///     Log4 Net Logger
        ///     Log4 Net Logger
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> RedirectAndRestartAsync()
        {
            try
            {
                var url =
                    $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{Url.Action("RedirectAfterStatus", "Home")}";
                var content = new WebClient().DownloadString(url);
                await Task.Run(async () =>
                {
                    Thread.Sleep((int)TimeSpan.FromSeconds(2).TotalMilliseconds);
                    await Task.Yield();
                    Program.Shutdown();
                });
                return Task.Run(async () =>
                {
                    Thread.Sleep((int)TimeSpan.FromSeconds(1).TotalMilliseconds);
                    await Task.Yield();
                    return new ContentResult
                    {
                        ContentType = "text/html", StatusCode = (int)HttpStatusCode.OK, Content = content
                    };
                }).Result;
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                return NotFound(e);
            }
        }

        [AllowAnonymous]
        public IActionResult RedirectAfterStatus() => View();

        [AllowAnonymous]
        public IActionResult Index( /*[FromQuery] string userName, [FromQuery] string returnUrl*/) => View();

        //[Authorize(Roles = "Administrator")]
        //[Authorize(Policy = "Administrator")]
        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "User")]
        public IActionResult Privacy() => View();

        //[Authorize(Roles = "Administrator")]
        //[Authorize(Policy = "Administrator")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
