using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebconIntegrationSystem.Models.BPSMainAtt;
using WebconIntegrationSystem.Repositories.BPSMainAtt;

namespace WebApplicationNetCoreDev.Controllers.WebconIntegrationSystemController.BPSMainAtt
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("WebconIntegrationSystem/[controller]/[action]")]
    public class BPSMainAttController : Controller
    {
        #region private readonly log4net.ILog log4net
        /// <summary>
        /// Log4 Net Logger
        /// </summary>
        private readonly log4net.ILog log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);
        #endregion

        #region public IActionResult Index()
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region public IActionResult Settings()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Settings()
        {
            try
            {
                return View(new AppSettings());
            }
            catch (Exception e)
            {
                log4net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
            return NotFound();
        }
        #endregion

        #region public async Task<IActionResult> SettingsAsync
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> SettingsAsync([Bind("ConnectionString", "CheckForConnection")] AppSettings model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await AppSettingsRepository.GetInstance().SaveAsync(model);
                    return Redirect(nameof(Settings));
                }
            }
            catch (Exception e)
            {
                log4net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                return NotFound(e);
            }
            return View(model);
        }
        #endregion

        #region public IActionResult Route()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Route()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                log4net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }
            return NotFound();
        }
        #endregion
    }
}
