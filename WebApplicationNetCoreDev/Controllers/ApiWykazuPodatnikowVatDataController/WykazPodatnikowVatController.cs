using ApiWykazuPodatnikowVatData.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplicationNetCoreDev.Controllers.ApiWykazuPodatnikowVatDataController
{
    #region public class WykazPodatnikowVatController : Controller
    /// <summary>
    /// Kontroler Wykaz Podatników Vat
    /// Controller List of VAT taxpayers
    /// Authorize(AuthenticationSchemes = "Cookies")
    /// Route("SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/[controller]/[action]")
    /// </summary>
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/[controller]/[action]")]
    public class WykazPodatnikowVatController : Controller
    {
        #region private static readonly log4net.ILog _log4net
        /// <summary>
        /// Log4 Net Logger
        /// </summary>
        private static readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region private readonly ApiWykazuPodatnikowVatDataDbContext _context;
        /// <summary>
        /// Kontekst bazy danych _context jako ApiWykazuPodatnikowVatDataDbContext
        /// The context of the database _context as ApiWykazuPodatnikowVatDataDbContext
        /// </summary>
        private readonly ApiWykazuPodatnikowVatDataDbContext _context;
        #endregion

        #region WykazPodatnikowVatController(ApiWykazuPodatnikowVatDataDbContext context)
        /// <summary>
        /// Konstruktor z parametrem kontekstu bazy danych
        /// Constructor with the database context parameter
        /// </summary>
        /// <param name="context">
        /// Kontekst bazy danych jako obiekt ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext
        /// Database context as an ApiWykazuPodatnikowVatData.Data.ApiWykazuPodatnikowVatDataDbContext object
        /// </param>
        public WykazPodatnikowVatController(ApiWykazuPodatnikowVatDataDbContext context)
        {
            _context = context;
        }
        #endregion

        #region public async Task<IActionResult> Index()
        // GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Index
        /// <summary>
        /// GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Index
        /// Lista podmiotów zapisanych w bazie danych jako obiekty ApiWykazuPodatnikowVatData.Models.Entity
        /// List of entities saved in the database as ApiWykazuPodatnikowVatData.Models.Entity objects
        /// </summary>
        /// <returns>
        /// IActionResult
        /// IActionResult
        /// </returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entity.Include(i => i.EntityAccountNumber).ToListAsync());
        }
        #endregion

        #region public async Task<IActionResult> Settings()
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
        public async Task<IActionResult> Settings()
        {
            return View(await _context.Entity.ToListAsync());
        }
        #endregion

        #region public async Task<IActionResult> Route()
        // GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Route
        /// <summary>
        /// GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Route
        /// Pokaż dostępne trasy routingu (metody) Full Rest Api dla kontrolera WykazPodatnikowVat
        /// Show available Full Rest Api routing routes (methods) for the KatalogPodatnikowVat controller
        /// </summary>
        /// <returns>
        /// IActionResult
        /// IActionResult
        /// </returns>
        public async Task<IActionResult> RouteAsync()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                await Task.Run(() => _log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
                return NotFound();
            }
        }
        #endregion
    }
    #endregion
}
