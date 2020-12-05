using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using WebconIntegrationSystem.Repositories.BPSMainAtt;
using WebconIntegrationSystem.Models.BPSMainAtt;
using System.Threading.Tasks;

namespace WebApplicationNetCoreDev.Controllers.WebconIntegrationSystemController.BPSMainAtt
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("WebconIntegrationSystem/[controller]/[action]")]
    public class BPSMainAttController : Controller
    {
        #region private static readonly log4net.ILog log4net
        /// <summary>
        /// Log4 Net Logger
        /// </summary>
        private static readonly log4net.ILog log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
                return View(new AppSettings());
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("\n{0}\n{1}\n{2}\n{3}\n", e.GetType(), e.InnerException?.GetType(), e.Message, e.StackTrace), e);
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
        public async Task<IActionResult> SettingsAsync([Bind("ConnectionString")] AppSettings model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        await AppSettingsRepository.GetInstance().SaveAsync(model);
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

    }
}
