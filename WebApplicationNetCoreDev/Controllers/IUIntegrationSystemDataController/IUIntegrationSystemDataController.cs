using System;
using System.Reflection;
using IUIntegrationSystemData.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNetCoreDev.Controllers.IUIntegrationSystemDataControler
{
    #region public class IUIntegrationSystemDataController : Controller
    /// <summary>
    /// Kontroler systemu integracji ICASA UNIMOT
    /// ICASA UNIMOT integration system controller
    /// </summary>
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("IUIntegrationSystemData/[controller]/[action]")]
    public class IUIntegrationSystemDataController : Controller
    {

        #region private static readonly log4net.ILog log4net
        /// <summary>
        /// Log4 Net Logger
        /// </summary>
        private static readonly log4net.ILog log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region private readonly IUIntegrationSystemDataDbContext _context
        /// <summary>
        /// Kontekst do bazy danych jako IUIntegrationSystemDataDbContext
        /// Database context as IUIntegrationSystemDataDbContext
        /// </summary>
        private readonly IUIntegrationSystemDataDbContext _context;
        #endregion

        #region public IUIntegrationSystemDataController...
        /// <summary>
        /// Kontroler z parametrem kontekstu bazy danych
        /// Controller with the database context parameter
        /// </summary>
        /// <param name="context">
        /// Kontekst do bazy danych jako IUIntegrationSystemDataDbContext
        /// Database context as IUIntegrationSystemDataDbContext
        /// </param>
        public IUIntegrationSystemDataController(IUIntegrationSystemDataDbContext context)
        {
            _context = context;
        }
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("\n{0}\n{1}\n{2}\n{3}\n", e.GetType(), e.InnerException?.GetType(), e.Message, e.StackTrace), e);
            }
            return NotFound();
        }

        #region public IActionResult Settings()
        // GET: IUIntegrationSystemData/Settings
        /// <summary>
        /// GET: IUIntegrationSystemData/Settings
        /// To do opis
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
                return View(new IUIntegrationSystemData.Models.AppSettings());
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("\n{0}\n{1}\n{2}\n{3}\n", e.GetType(), e.InnerException?.GetType(), e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public IActionResult Settings...
        /// POST: IUIntegrationSystemData/Settings
        /// <summary>
        /// POST: IUIntegrationSystemData/Settings
        /// To do opis
        /// </summary>
        /// <param name="model">
        /// Model danych jako IUIntegrationSystemData.Models.AppSettings
        /// Data model as IUIntegrationSystemData.Models.AppSettings
        /// </param>
        /// <returns>
        /// IActionResult
        /// IActionResult
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async System.Threading.Tasks.Task<IActionResult> SettingsAsync([Bind("ConnectionString, CheskForConnection, CheckForUpdateAndMigrate")] IUIntegrationSystemData.Models.AppSettings model)
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
                                IUIntegrationSystemDataDbContext IUIntegrationSystemDataDbContext = await NetAppCommon.DatabaseMssql.CreateInstancesForDatabaseContextClassAsync<IUIntegrationSystemDataDbContext>();
                                await IUIntegrationSystemDataDbContext.CheckForUpdateAndMigrateAsync();
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
    }
    #endregion
}
