using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NetAppCommon.Models;
using PortalApiGusApiRegonData.Data;
using PortalApiGusApiRegonData.Models.DaneSzukajPodmioty;

namespace WebApplicationNetCoreDev.Controllers.PortalApiGusApiRegonDataControler
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/PortalApiGus/[controller]")]
    [ApiController]
    public class DaneSzukajPodmiotyApiController : ControllerBase
    {
        #region private readonly PortalApiGusApiRegonDataDbContext _context
        /// <summary>
        /// Context do bazy danych as PortalApiGusApiRegonDataDbContext
        /// </summary>
        private readonly PortalApiGusApiRegonDataDbContext _context;
        #endregion

        #region private readonly IActionDescriptorCollectionProvider _provider
        /// <summary>
        /// Action Descriptor Collection Provider
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _provider;
        #endregion

        #region private readonly log4net.ILog log4net
        /// <summary>
        /// Log4 Net Logger
        /// </summary>
        private readonly log4net.ILog log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);
        #endregion

        #region public DaneSzukajPodmiotyApiController...
        /// <summary>
        /// Konstruktor
        /// Constructor
        /// </summary>
        /// <param name="context">
        /// Context do bazy danych as PortalApiGusApiRegonDataDbContext
        /// Context to the database as PortalApiGusApiRegonDataDbContext
        /// </param>
        public DaneSzukajPodmiotyApiController(PortalApiGusApiRegonDataDbContext context, IActionDescriptorCollectionProvider provider)
        {
            _context = context;
            _provider = provider;
        }
        #endregion

        #region public async Task<ActionResult<List<ControllerRoutingActions>>> GetRouteAsync()
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("Route")]
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Route
        /// Pobierz listę akcji (tras) dostępnych dla kontrolera i zwróć listę
        /// Get the list of actions (routes) available for the controller and return the list
        /// </summary>
        /// <returns>
        /// Lista akcji (tras) dostępnych dla kontrolera jako lista obiektów ControllerRoutingActions
        /// List of actions (routes) available to the controller as a list of ControllerRoutingActions objects
        /// </returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Route
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Route")]
        public async Task<ActionResult<List<ControllerRoutingActions>>> GetRouteAsync()
        {
            try
            {
                return await NetAppCommon.ControllerRoute.GetRouteActionAsync(_provider, ControllerContext.ActionDescriptor.ControllerName.ToString(), Url, this);
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
                return NotFound();
            }
        }
        #endregion

        #region public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGridAsync()
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Cookies")]
        /// [HttpGet("RouteKendoGrid")]
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/RouteKendoGrid
        /// Pobierz listę akcji (tras) dostępnych dla kontrolera i zwróć listę dla widoku KendoGrid
        /// Get the list of actions (routes) available for the controller and return the list for the Kendo view
        /// </summary>
        /// <returns>
        /// Lista dostępnych tras routingu jako List dla KendoGrid
        /// List of available routing routes as List for KendoGrid
        /// </returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/RouteKendoGrid
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("RouteKendoGrid")]
        public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGridAsync()
        {
            try
            {
                return await NetAppCommon.ControllerRoute.GetRouteActionForKendoGridAsync(_provider, ControllerContext.ActionDescriptor.ControllerName.ToString(), Url, this);
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
                return NotFound();
            }
        }
        #endregion

        #region public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyAsync()
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet]
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi
        /// Pobierz dane wyszukanych podmiotów z bazy danych
        /// Get data of found entities from the database
        /// </summary>
        /// <returns>List<DaneSzukajPodmioty> lub NotFound()</returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyAsync()
        {
            try
            {
                return await _context.DaneSzukajPodmioty.ToListAsync();
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<KendoGrid<List<DaneSzukajPodmioty>>>> GetDaneSzukajPodmiotyKendoGridAsync...
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Cookies")]
        /// [HttpGet("KendoGrid")]
        /// Get: api/PortalApiGus/DaneSzukajPodmiotyApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// Pobierz dane wyszukanych podmiotów z bazy danych
        /// Get data of found entities from the database
        /// </summary>
        /// <param name="sort">Parametr Kendo KendoGrid sort jako string lub null</param>
        /// <param name="page">Parametr Kendo KendoGrid page AS int lub null</param>
        /// <param name="pageSize">Parametr Kendo KendoGrid pageSize AS int lub null</param>
        /// <param name="group">Parametr Kendo KendoGrid group jako string lub null</param>
        /// <param name="filter">Parametr Kendo KendoGrid filter jako string lub null</param>
        /// <returns>
        /// Lista podmiotów jako lista obiektów DaneSzukajPodmioty dla widoku KendoGrid lub status NotFound
        /// Entity list as a list of Data Objects Search Entities for a KendoGrid view or NotFound status
        /// </returns>
        //Get: api/PortalApiGus/DaneSzukajPodmiotyApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("KendoGrid")]
        public async Task<ActionResult<KendoGrid<List<DaneSzukajPodmioty>>>> GetDaneSzukajPodmiotyKendoGridAsync([FromQuery] string sort = null, [FromQuery] int? page = null, [FromQuery] int? pageSize = null, [FromQuery] string group = null, [FromQuery] string filter = null)
        {
            try
            {
                List<DaneSzukajPodmioty> daneSzukajPodmioty = await _context.DaneSzukajPodmioty.ToListAsync();
                if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                {
                    return new KendoGrid<List<DaneSzukajPodmioty>> { Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty };
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyNipAsync...
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("Nip/{nip}/{pKluczUzytkownika?}")]
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Nip/{nip}/{pKluczUzytkownika?}
        /// Pobierz dane podmiotu według nip z parametrów URL
        /// Get entity data by nip from URL parameters
        /// </summary>
        /// <param name="nip">
        /// NIP jako string
        /// Tax ID NIP as a string
        /// </param>
        /// <param name="pKluczUzytkownika">
        /// Opcjonalnie klucz użytkownika API jako string
        /// Optional API user key as string
        /// </param>
        /// <returns>
        /// Lista podmiotów według NIP jako lista obiektów DaneSzukajPodmioty
        /// List of DaneSzukajPodmioty according to NIP as a list of data objects
        /// </returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Nip/{nip}/{pKluczUzytkownika?}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Nip/{nip}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyNipAsync(string nip, string pKluczUzytkownika = null)
        {
            try
            {
                if (null != nip)
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    nip = digitsOnly.Replace(nip, string.Empty);
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNipAsync(pKluczUzytkownika, nip);
                    }
                    else
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNipAsync(nip);
                    }
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyFromQueryNipAsync...
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("Nip")]
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Nip/?nip={nip}&pKluczUzytkownika={pKluczUzytkownika?}
        /// Pobierz dane podmiotu według nip z parametrów GET
        /// Get entity data by tax identification number from GET parameters
        /// </summary>
        /// <param name="nip">
        /// NIP jako string
        /// Tax ID NIP as a string
        /// </param>
        /// <param name="pKluczUzytkownika">
        /// Opcjonalnie klucz użytkownika API jako string
        /// Optional API user key as string
        /// </param>
        /// <returns>
        /// Lista podmiotów według NIP jako lista obiektów DaneSzukajPodmioty
        /// List of DaneSzukajPodmioty according to NIP as a list of data objects
        /// </returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Nip/?nip={nip}&pKluczUzytkownika={pKluczUzytkownika?}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Nip")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyFromQueryNipAsync([FromQuery] string nip, [FromQuery] string pKluczUzytkownika = null)
        {
            try
            {
                return await GetDaneSzukajPodmiotyNipAsync(nip, pKluczUzytkownika);
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<KendoGrid<List<DaneSzukajPodmioty>>>> GetDaneSzukajPodmiotyKendoGridNipAsync...
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Cookies")]
        /// [HttpGet("KendoGridNip/{nip}/{pKluczUzytkownika?}")]
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/KendoGridNip/{nip}/{pKluczUzytkownika}
        /// Pobierz dane podmiotów według nip dla KendoGrid
        /// Get entity data by tax identification number for KendoGrid
        /// </summary>
        /// <param name="nip">
        /// NIP jako string
        /// Tax ID NIP as a string
        /// </param>
        /// <param name="pKluczUzytkownika">
        /// Opcjonalnie klucz użytkownika API jako string lub null
        /// Optional API user key as string or null
        /// </param>
        /// <returns>
        /// Lista podmiotów jako lista obiektów DaneSzukajPodmioty dla widoku KendoGrid lub status NotFound
        /// Entity list as a list of Data Objects Search Entities for a KendoGrid view or NotFound status
        /// </returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/KendoGridNip/{nip}/{pKluczUzytkownika}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("KendoGridNip/{nip}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<KendoGrid<List<DaneSzukajPodmioty>>>> GetDaneSzukajPodmiotyKendoGridNipAsync(string nip, string pKluczUzytkownika = null)
        {
            try
            {
                if (null != nip)
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    nip = digitsOnly.Replace(nip, string.Empty);
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNipAsync(pKluczUzytkownika, nip);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return new KendoGrid<List<DaneSzukajPodmioty>>
                            {
                                Total = daneSzukajPodmioty.Count,
                                Data = daneSzukajPodmioty
                            };
                        }
                    }
                    else
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNipAsync(nip);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return new KendoGrid<List<DaneSzukajPodmioty>>
                            {
                                Total = daneSzukajPodmioty.Count,
                                Data = daneSzukajPodmioty
                            };
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyRegonAsync...
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("Regon/{regon}/{pKluczUzytkownika?}")]
        /// Pobierz dane podmiotów według regon
        /// Get data of entities by region
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Regon/{regon}/{pKluczUzytkownika?}
        /// </summary>
        /// <param name="regon">
        /// Regon 9 lub 14 znaków jako string
        /// Regon 9 or 14 characters as a string
        /// </param>
        /// <param name="pKluczUzytkownika">
        /// Opcjonalnie klucz użytkownika API jako string
        /// Optional API user key as string
        /// </param>
        /// <returns>
        /// Lista podmiotów według regon jako lista obiektów DaneSzukajPodmioty
        /// List of entities by region as a list of DaneSzukajPodmioty
        /// </returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Regon/{regon}/{pKluczUzytkownika?}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Regon/{regon}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyRegonAsync(string regon, string pKluczUzytkownika = null)
        {
            try
            {
                var digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 9)
                {
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9znAsync(pKluczUzytkownika, regon);
                    }
                    else
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9znAsync(regon);
                    }
                }
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 14)
                {
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14znAsync(pKluczUzytkownika, regon);
                    }
                    else
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14znAsync(regon);
                    }
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyFromQueryRegonAsync...
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("Regon")]
        /// Pobierz dane podmiotów według regon z parametrów zapytania GET
        /// Get data of entities by region from GET query parameters
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Regon?regon={regon}&pKluczUzytkownika={pKluczUzytkownika}
        /// </summary>
        /// <param name="regon">
        /// Regon 9 lub 14 znaków jako string
        /// Regon 9 or 14 characters as a string
        /// </param>
        /// <param name="pKluczUzytkownika">
        /// Opcjonalnie klucz użytkownika API jako string
        /// Optional API user key as string
        /// </param>
        /// <returns>
        /// Lista podmiotów według regon jako lista obiektów DaneSzukajPodmioty
        /// List of entities by region as a list of DaneSzukajPodmioty
        /// </returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Regon?regon={regon}&pKluczUzytkownika={pKluczUzytkownika}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Regon")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyFromQueryRegonAsync([FromQuery] string regon, [FromQuery] string pKluczUzytkownika = null)
        {
            try
            {
                var digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 9)
                {
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9znAsync(pKluczUzytkownika, regon);
                    }
                    else
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9znAsync(regon);
                    }
                }
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 14)
                {
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14znAsync(pKluczUzytkownika, regon);
                    }
                    else
                    {
                        return await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14znAsync(regon);
                    }
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<KendoGrid<List<DaneSzukajPodmioty>>>> GetDaneSzukajPodmiotyKendoGridRegonAsync...
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Cookies")]
        /// [HttpGet("KendoGridRegon/{regon}/{pKluczUzytkownika?}")]
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/KendoGridRegon/{regon}/{pKluczUzytkownika?}
        /// Pobierz dane podmiotów według regon dla widoku KendoGridGrid
        /// Get entity data by region for the KendoGrid view
        /// </summary>
        /// <param name="regon">
        /// Regon 9 lub 14 znaków jako string
        /// Regon 9 or 14 characters as a string
        /// </param>
        /// <param name="pKluczUzytkownika">
        /// Opcjonalnie klucz użytkownika API jako string
        /// Optional API user key as string
        /// </param>
        /// <returns>
        /// Lista podmiotów jako lista obiektów DaneSzukajPodmioty dla widoku KendoGrid lub status NotFound
        /// Entity list as a list of Data Objects Search Entities for a KendoGrid view or NotFound status
        /// </returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/KendoGridRegon/{regon}/{pKluczUzytkownika?}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("KendoGridRegon/{regon}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<KendoGrid<List<DaneSzukajPodmioty>>>> GetDaneSzukajPodmiotyKendoGridRegonAsync(string regon, string pKluczUzytkownika = null)
        {
            try
            {
                if (null != regon)
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    regon = digitsOnly.Replace(regon, string.Empty);
                    if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 9)
                    {
                        if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                        {
                            List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9znAsync(pKluczUzytkownika, regon);
                            return new KendoGrid<List<DaneSzukajPodmioty>>
                            {
                                Total = daneSzukajPodmioty.Count,
                                Data = daneSzukajPodmioty
                            };
                        }
                        else
                        {
                            List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9znAsync(regon);
                            return new KendoGrid<List<DaneSzukajPodmioty>>
                            {
                                Total = daneSzukajPodmioty.Count,
                                Data = daneSzukajPodmioty
                            };
                        }
                    }
                    if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 14)
                    {
                        if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                        {
                            List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14znAsync(pKluczUzytkownika, regon);
                            return new KendoGrid<List<DaneSzukajPodmioty>>
                            {
                                Total = daneSzukajPodmioty.Count,
                                Data = daneSzukajPodmioty
                            };
                        }
                        else
                        {
                            List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14znAsync(regon);
                            return new KendoGrid<List<DaneSzukajPodmioty>>
                            {
                                Total = daneSzukajPodmioty.Count,
                                Data = daneSzukajPodmioty
                            };
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }
            return NotFound();
        }
        #endregion
    }
}