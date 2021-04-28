#region using

using System;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Vies.Core.Database.Data;
using Vies.Core.Database.Models;

#endregion

namespace WebApplicationNetCoreDev.Controllers.EuropeanCommission.TaxationAndCustomsUnion
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("EuropeanCommission/TaxationAndCustomsUnion/[controller]/[action]")]
    public class ViesController : Controller
    {
        #region private readonly ViesCoreDatabaseContext _context

        /// <summary>
        ///     Instancja do klasy ustawień Vies.Core.Database.Models.ViesCoreDatabaseContext
        ///     Instance to the Vies.Core.Database.Models.ViesCoreDatabaseContext settings class
        /// </summary>
        private readonly ViesCoreDatabaseContext _context;

        #endregion

        #region private log4net.ILog _log4Net

        /// <summary>
        ///     private readonly ILog _log4Net
        ///     private readonly ILog _log4Net
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        #region public ViesController(IServiceScopeFactory serviceScopeFactory)

        /// <summary>
        ///     Konstruktor
        ///     Constgruktor
        /// </summary>
        /// <param name="serviceScopeFactory">
        ///     IServiceScopeFactory serviceScopeFactory
        ///     IServiceScopeFactory serviceScopeFactory
        /// </param>
        public ViesController(IServiceScopeFactory serviceScopeFactory)
        {
            IServiceScope serviceScope = serviceScopeFactory.CreateScope();
            ViesCoreDatabaseContext context = serviceScope.ServiceProvider.GetService<ViesCoreDatabaseContext>();
            _context = context;
        }

        #endregion

        #region public IActionResult Index()

        /// <summary>
        ///     Index - wyszukiwanie podmiotów
        ///     Index - searching for entities
        /// </summary>
        /// <returns>
        ///     Akcja kontrolera jako IActionResult
        ///     Controller action as IActionResult
        /// </returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public IActionResult Index()
        {
            ViewData["ConnectionString"] = _context?.GetConnectionString();
            return View();
        }

        #endregion

        #region public IActionResult CheckVatApprox()

        /// <summary>
        ///     Sprawdź repozytorium wartości VAT - wyszukiwanie podmiotów
        ///     Check the repository of VAT values - search for entities
        /// </summary>
        /// <returns>
        ///     Akcja kontrolera jako IActionResult
        ///     Controller action as IActionResult
        /// </returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public IActionResult CheckVatApprox()
        {
            ViewData["ConnectionString"] = _context?.GetConnectionString();
            return View();
        }

        #endregion

        #region public IActionResult Settings()

        /// <summary>
        ///     Wyświetl formularz edycji ustawień
        ///     Display the settings edit form
        /// </summary>
        /// <returns>
        ///     Akcja kontrolera jako IActionResult
        ///     Controller action as IActionResult
        /// </returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public IActionResult Settings()
        {
            try
            {
                return base.View(new AppSettings());
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            return NotFound();
        }

        #endregion

        #region public async Task<IActionResult> SettingsAsync

        /// <summary>
        ///     Zapisz ustawienia
        ///     Save the settings
        /// </summary>
        /// <param name="model">
        ///     Model danych jako AppSettings
        ///     Data model as AppSettings
        /// </param>
        /// <returns>
        ///     Akcja kontrolera jako IActionResult
        ///     Controller action as IActionResult
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> SettingsAsync(
            [Bind("CacheLifeTime", "ConnectionString", "CheckForConnection", "CheckAndMigrate",
                "UseGlobalDatabaseConnectionSettings" /*, "RequesterCountryCode", "RequesterVatNumber"*/)]
            AppSettings model)
        {
            try
            {
                if (ModelState.IsValid && null != model.AppSettingsRepository)
                {
                    if (model.CheckAndMigrate)
                    {
                        model.LastMigrateDateTime = DateTime.MinValue;
                    }

                    if (model.UseGlobalDatabaseConnectionSettings)
                    {
                        model.ConnectionString = NetAppCommon.AppSettings.Models.AppSettings.GetAppSettingsModel()
                            .GetConnectionString();
                    }

                    await model.AppSettingsRepository.MergeAndSaveAsync(model);
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
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
                return NotFound(e);
            }

            return View(model);
        }

        #endregion

        #region public IActionResult Route()

        /// <summary>
        ///     Pobierz akcje routingu kontrolera
        ///     Get controller routing actions
        /// </summary>
        /// <returns>
        ///     Akcja kontrolera jako IActionResult
        ///     Controller action as IActionResult
        /// </returns>
        public IActionResult Route()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _log4Net.Error($"\n{e.GetType()}\n{e.InnerException?.GetType()}\n{e.Message}\n{e.StackTrace}\n", e);
            }

            return NotFound();
        }

        #endregion
    }
}
