#region using

using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetAppCommon.AppSettings.Models;
using PortalApiGusApiRegonData.Data;
using PortalApiGusApiRegonData.Models;

#endregion

namespace WebApplicationNetCoreDev.Controllers.PortalApiGusApiRegonDataControler
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("PortalApiGus/[controller]/[action]")]
    public class DaneSzukajPodmiotyController : Controller
    {
        private readonly PortalApiGusApiRegonDataDbContext _context;

        #region private readonly log4net.ILog log4net

        /// <summary>
        ///     Log4 Net Logger
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        public DaneSzukajPodmiotyController(PortalApiGusApiRegonDataDbContext context)
        {
            _context = context;
        }

        // GET: DaneSzukajPodmioty
        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "User")]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        #region public IActionResult Settings()

        // GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Settings
        /// <summary>
        ///     GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Settings
        ///     Pokaż lub edytuj ustawienia aplikacji WykazPodatnikowVat
        ///     View or edit the settings of the WykazPodatnikowVat
        /// </summary>
        /// <returns>
        ///     IActionResult
        ///     IActionResult
        /// </returns>
        [HttpGet]
        public IActionResult Settings()
        {
            try
            {
                return View(new AppSettings());
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            return NotFound();
        }

        #endregion

        #region public IActionResult Settings...

        /// <summary>
        ///     POST: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Settings
        ///     Zapisz ustawienia aplikacji WykazPodatnikowVat
        ///     Save the settings of the WykazPodatnikowVat
        /// </summary>
        /// <param name="model">
        ///     Model danych jako ApiWykazuPodatnikowVatData.Models.AppSettings
        ///     Data model as ApiWykazuPodatnikowVatData.Models.AppSettings
        /// </param>
        /// <returns>
        ///     IActionResult
        ///     IActionResult
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> SettingsAsync(
            [Bind("PortalApiGusKey", "CacheLifeTime", "ConnectionString", "CheckForConnection", "CheckAndMigrate",
                "UseGlobalDatabaseConnectionSettings")]
            AppSettings model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.CheckAndMigrate)
                    {
                        model.LastMigrateDateTime = DateTime.MinValue;
                    }

                    if (model.UseGlobalDatabaseConnectionSettings)
                    {
                        model.ConnectionString = AppSettingsModel.GetInstance().GetConnectionString();
                    }

                    await model.AppSettingsRepository.MergeAndSaveAsync(model);
                    var url = string.Format("{0}://{1}{2}", HttpContext.Request.Scheme, HttpContext.Request.Host,
                        Url.Action("RedirectAfterStatus", "Home"));
                    var content = new WebClient().DownloadString(url);
                    await Task.Run(() =>
                    {
                        Program.Shutdown();
                    });
                    return new ContentResult
                    {
                        ContentType = "text/html", StatusCode = (int)HttpStatusCode.OK, Content = content
                    };
                }
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                return NotFound(e);
            }

            return View(model);
        }

        #endregion

        // GET: DaneSzukajPodmioty/Route
        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "User")]
        public IActionResult Route()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
