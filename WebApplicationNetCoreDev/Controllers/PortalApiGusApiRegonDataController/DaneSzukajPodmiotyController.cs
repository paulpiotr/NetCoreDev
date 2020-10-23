using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalApiGusApiRegonData.Data;
using System;
using System.Reflection;

namespace WebApplicationNetCoreDev.Controllers.PortalApiGusApiRegonDataControler
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("PortalApiGus/[controller]/[action]")]
    public class DaneSzukajPodmiotyController : Controller
    {

        #region private static readonly log4net.ILog log4net
        /// <summary>
        /// Log4 Net Logger
        /// </summary>
        private static readonly log4net.ILog log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        private readonly PortalApiGusApiRegonDataDbContext _context;

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
        /// GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Settings
        /// Pokaż lub edytuj ustawienia aplikacji WykazPodatnikowVat
        /// View or edit the settings of the WykazPodatnikowVat
        /// </summary>
        /// <returns>
        /// IActionResult
        /// IActionResult
        /// </returns>
        [HttpGet]
        public IActionResult Settings()
        {
            try
            {
                return View(new PortalApiGusApiRegonData.Models.AppSettings());
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public IActionResult Settings...
        /// <summary>
        /// POST: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Settings
        /// Zapisz ustawienia aplikacji WykazPodatnikowVat
        /// Save the settings of the WykazPodatnikowVat
        /// </summary>
        /// <param name="model">
        /// Model danych jako ApiWykazuPodatnikowVatData.Models.AppSettings
        /// Data model as ApiWykazuPodatnikowVatData.Models.AppSettings
        /// </param>
        /// <returns>
        /// IActionResult
        /// IActionResult
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async System.Threading.Tasks.Task<IActionResult> SettingsAsync([Bind("PortalApiGusKey, CacheLifeTime, ConnectionString, CheskForConnection, CheckForUpdateAndMigrate")] PortalApiGusApiRegonData.Models.AppSettings model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        await model.SaveAsync();
                        if (model.CheckForUpdateAndMigrate)
                        {
                            try
                            {
                                PortalApiGusApiRegonDataDbContext portalApiGusApiRegonDataDbContext = await NetAppCommon.DatabaseMssql.CreateInstancesForDatabaseContextClassAsync<PortalApiGusApiRegonDataDbContext>();
                                await portalApiGusApiRegonDataDbContext.CheckForUpdateAndMigrateAsync();
                            }
                            catch (Exception e)
                            {
                                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                    }
                    return Redirect(nameof(Index));
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
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
