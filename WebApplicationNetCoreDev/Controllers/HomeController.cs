#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using NetAppCommon;
using NetAppCommon.Models;
using WebApplicationNetCoreDev.Models;

#endregion

#region namespace

namespace WebApplicationNetCoreDev.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class HomeController : Controller
    {
        #region private log4net.ILog _log4Net

        /// <summary>
        ///     private readonly ILog _log4Net
        ///     private readonly ILog _log4Net
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        #region private readonly ILogger<HomeController> _logger

        private readonly ILogger<HomeController> _logger;

        #endregion

        #region private readonly IActionDescriptorCollectionProvider _provider

        /// <summary>
        ///     Action Descriptor Collection Provider
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _provider;

        #endregion

        #region public HomeController...

        public HomeController(ILogger<HomeController> logger, IActionDescriptorCollectionProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        #endregion

        #region public async Task<IActionResult> RedirectAndRestartAsync...

        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "Administrator")]
        [ActionName(nameof(RedirectAndRestartAsync))]
        public async Task<IActionResult> RedirectAndRestartAsync()
        {
            try
            {
                var url =
                    $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{Url.Action("RedirectAfterStatus", "Home", new {ReturnUrl = HttpContext.Request.Query["ReturnUrl"]})}";
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
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }

                return StatusCode(500, e);
            }
        }

        #endregion

        #region public IActionResult RedirectAndRestartAsync...

        [AllowAnonymous]
        public IActionResult
            RedirectAfterStatus() => View();

        #endregion

        #region public IActionResult Index...

        [AllowAnonymous]
        public IActionResult Index() => View();

        #endregion

        #region public async Task<IActionResult> RouteAsync

        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "Administrator")]
        public async Task<IActionResult> RouteAsync()
        {
            try
            {
                KendoGrid<List<ControllerRoutingActions>> controllerRoutingActionsList =
                    await ControllerRoute.GetRouteActionForKendoGridAsync(_provider, Url);
                return View(controllerRoutingActionsList as IEnumerable<KendoGrid<ControllerRoutingActions>>);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        #endregion

        #region public IActionResult Error()

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

        #endregion
    }
}

#endregion
