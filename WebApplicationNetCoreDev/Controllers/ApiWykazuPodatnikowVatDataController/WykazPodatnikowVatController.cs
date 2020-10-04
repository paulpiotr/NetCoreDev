using ApiWykazuPodatnikowVatData.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace WebApplicationNetCoreDev.Controllers.ApiWykazuPodatnikowVatDataController
{
    #region public class WykazPodatnikowVatController : Controller
    /// <summary>
    /// Kontroler Wykaz Podatników Vat, serwis https://wl-api.mf.gov.pl/
    /// Controller List of VAT taxpayers, website https://wl-api.mf.gov.pl/
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

        #region public IActionResult Index()
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
        public IActionResult Index()
        {
            try
            {
                return View(/*await _context.Entity.Include(i => i.EntityAccountNumber).ToListAsync()*/);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public IActionResult Search()
        // GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Search
        /// <summary>
        /// GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Search
        /// Wyszukaj podmioty gospodarcze według parametrów NIP lub REGON lub Numer rachunku bankowego NRB w serwisie https://wl-api.mf.gov.pl/
        /// Search for economic entities according to the NIP or REGON parameters or the NRB bank account number on the website https://wl-api.mf.gov.pl/
        /// </summary>
        /// <returns>
        /// IActionResult
        /// IActionResult
        /// </returns>
        public IActionResult Search()
        {
            try
            {
                return View(/*await _context.Entity.Include(i => i.EntityAccountNumber).ToListAsync()*/);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public IActionResult Check()
        // GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Check
        /// <summary>
        /// GET: SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVat/Check
        /// Sprawdź podmiot gospodarczy według parametru NIP i Numeru rachunku bankowego NRB lub według parametru REGON i Numeru rachunku bankowego NRB w serwisie https://wl-api.mf.gov.pl/
        /// Check the economic entity according to the NIP parameter and the NRB bank account number or the REGON parameter and the NRB bank account number on the website https://wl-api.mf.gov.pl/
        /// </summary>
        /// <returns>
        /// IActionResult
        /// IActionResult
        /// </returns>
        public IActionResult Check()
        {
            try
            {
                return View(/*await _context.EntityCheck.ToListAsync()*/);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

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
        public IActionResult Settings()
        {
            try
            {
                return View(/*await _context.Entity.ToListAsync()*/);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public IActionResult Route()
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
        public IActionResult Route()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion
    }
    #endregion
}
