using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PortalApiGusApiRegonData.Data;
using PortalApiGusApiRegonData.Models.DaneSzukajPodmioty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplicationNetCoreDev.Controllers.PortalApiGusApiRegonDataControler
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/PortalApiGus/[controller]")]
    [ApiController]
    public class DaneSzukajPodmiotyApiController : ControllerBase
    {
        /// <summary>
        /// Context do bazy danych as PortalApiGusApiRegonDataDbContext
        /// </summary>
        private readonly PortalApiGusApiRegonDataDbContext _context;

        /// <summary>
        /// Action Descriptor Collection Provider
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _provider;

        /// <summary>
        /// log4net
        /// </summary>
        private static readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context">Context do bazy danych as PortalApiGusApiRegonDataDbContext</param>
        public DaneSzukajPodmiotyApiController(PortalApiGusApiRegonDataDbContext context, IActionDescriptorCollectionProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        /// <summary>
        /// Pobierz dane akcji dotyczące tego kontrolera
        /// </summary>
        /// <returns>Lista zawierająca dane akcji dotyczące tego kontrolera</returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Route
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Route")]
        public ActionResult<object> GetRoute()
        {
            var o = _provider.ActionDescriptors.Items.ToList().Where(w => w.RouteValues["Controller"] == ControllerContext.ActionDescriptor.ControllerName.ToString()).Select(x => new
            {
                RouteId = x.Id,
                RouteController = x.RouteValues["Controller"],
                RouteAction = x.RouteValues["Action"],
                RouteUrlAction = Url.Action(x.RouteValues["Action"], x.RouteValues["Controller"]),
                RouteUrlAbsoluteAction = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Url.Action(x.RouteValues["Action"], x.RouteValues["Controller"])),
            }).ToList();
            if (null != o && o.Count > 0)
            {
                return o;
            }
            return NotFound();
        }

        /// <summary>
        /// Pobierz dane akcji dotyczące tego kontrolera dla kendo grid
        /// </summary>
        /// <returns>Lista zawierająca dane akcji dotyczące tego kontrolera</returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/RouteKendoGird
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("RouteKendoGird")]
        public ActionResult<object> GetRouteKendoGird()
        {
            try
            {
                var o = _provider.ActionDescriptors.Items.ToList().Where(w => w.RouteValues["Controller"] == ControllerContext.ActionDescriptor.ControllerName.ToString()).Select(x => new
                {
                    RouteId = x.Id,
                    RouteController = x.RouteValues["Controller"],
                    RouteAction = x.RouteValues["Action"],
                    RouteUrlAction = Url.Action(x.RouteValues["Action"], x.RouteValues["Controller"]),
                    RouteUrlAbsoluteAction = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Url.Action(x.RouteValues["Action"], x.RouteValues["Controller"])),
                }).ToList();
                if (null != o && o.Count > 0)
                {
                    return new { Total = o.Count, Data = o };
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound();
            }
        }

        /// <summary>
        /// Pobierz dane wyszukanych podmiotów z bazy danych
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi
        /// </summary>
        /// <returns>List<DaneSzukajPodmioty> lub NotFound()</returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyAsync()
        {
            try
            {
                List<DaneSzukajPodmioty> daneSzukajPodmioty = await _context.DaneSzukajPodmioty.ToListAsync();
                if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                {
                    return daneSzukajPodmioty;
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound();
            }
        }

        /// <summary>
        /// Pobierz dane wyszukanych podmiotów z bazy danych
        /// Get: api/PortalApiGus/DaneSzukajPodmiotyApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// </summary>
        /// <param name="sort">Parametr Kendo Grid sort AS string lub brak <null></param>
        /// <param name="page">Parametr Kendo Grid page AS int lub brak <null></param>
        /// <param name="pageSize">Parametr Kendo Grid pageSize AS int lub brak <null></param>
        /// <param name="group">Parametr Kendo Grid group AS string lub brak <null></param>
        /// <param name="filter">Parametr Kendo Grid filter AS string lub brak <null></param>
        /// <returns>>object { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty } AS Json for Kendo Grid</returns>
        //Get: api/PortalApiGus/DaneSzukajPodmiotyApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("KendoGrid")]
        public async Task<ActionResult<object>> GetDaneSzukajPodmiotyKendoGridAsync([FromQuery] string sort = null, [FromQuery] int? page = null, [FromQuery] int? pageSize = null, [FromQuery] string group = null, [FromQuery] string filter = null)
        {
            try
            {
                List<DaneSzukajPodmioty> daneSzukajPodmioty = await _context.DaneSzukajPodmioty.ToListAsync();
                if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                {
                    return new { Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty };
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound();
            }
        }

        /// <summary>
        /// Pobierz dane podmiotu według nip z parametrów URL
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Nip/nip AS <string>
        /// </summary>
        /// <param name="nip">NIP znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>Lista podmiotów według NIP AS IEnumerable<DaneSzukajPodmioty></returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Nip/nip AS <string>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Nip/{nip?}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyNipAsync(string nip, string pKluczUzytkownika = null)
        {
            try
            {
                if (null != nip)
                {
                    Regex digitsOnly = new Regex(@"[^\d]");
                    nip = digitsOnly.Replace(nip, string.Empty);
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNip(pKluczUzytkownika, nip);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                    else
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNip(nip);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound();
            }
        }

        /// <summary>
        /// Pobierz dane podmiotu według nip z parametrów GET
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Nip/?nip=nip AS <string>
        /// </summary>
        /// <param name="nip">NIP znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>Lista podmiotów według NIP AS IEnumerable<DaneSzukajPodmioty></returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Nip/?nip=nip AS <string>
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
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound();
            }
        }

        /// <summary>
        /// Pobierz dane podmiotów według nip z parametrów URL
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/GridNip/nip AS <string>/pKluczUzytkownika AS <string> lub <null>
        /// </summary>
        /// <param name="nip">NIP znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>object { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty } AS Json for Kendo Grid</returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/GridNip/nip AS <string>/pKluczUzytkownika AS <string> lub <null>
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("GridNip/{nip?}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<object>> GetDaneSzukajPodmiotyGridNipAsync(string nip, string pKluczUzytkownika = null)
        {
            try
            {
                if (null != nip)
                {
                    Regex digitsOnly = new Regex(@"[^\d]");
                    nip = digitsOnly.Replace(nip, string.Empty);
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNip(pKluczUzytkownika, nip);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return new { Nip = nip, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty };
                        }
                    }
                    else
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByNip(nip);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return new { Nip = nip, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty };
                        }
                    }
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound();
            }
        }

        /// <summary>
        /// Pobierz dane podmiotów według regon z parametrów URL
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Regon/regon AS <string>/pKluczUzytkownika AS <string> lub <null>
        /// </summary>
        /// <param name="regon">Regon 9 lub 14 znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>Lista podmiotów według regon AS IEnumerable<DaneSzukajPodmioty></returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Regon/regon AS <string>/pKluczUzytkownika AS <string> lub <null>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Regon/{regon?}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyRegonAsync(string regon, string pKluczUzytkownika = null)
        {
            try
            {
                Regex digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 9)
                {
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9zn(pKluczUzytkownika, regon);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                    else
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9zn(regon);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                }
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 14)
                {
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14zn(pKluczUzytkownika, regon);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                    else
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14zn(regon);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Pobierz dane podmiotów według regon z parametrów GET
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Regon?regon=regon AS <string>&pKluczUzytkownika=pKluczUzytkownika AS <string> lub <null>
        /// </summary>
        /// <param name="regon">Regon 9 lub 14 znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>Lista podmiotów według regon AS IEnumerable<DaneSzukajPodmioty></returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/Regon?regon=regon AS <string>&pKluczUzytkownika=pKluczUzytkownika AS <string> lub <null>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Regon")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyFromQueryRegonAsync([FromQuery] string regon, [FromQuery] string pKluczUzytkownika = null)
        {
            try
            {
                Regex digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 9)
                {
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9zn(pKluczUzytkownika, regon);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                    else
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9zn(regon);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                }
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 14)
                {
                    if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14zn(pKluczUzytkownika, regon);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                    else
                    {
                        List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14zn(regon);
                        if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                        {
                            return daneSzukajPodmioty;
                        }
                    }
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Pobierz dane podmiotów według regon z parametrów GET
        /// GET: api/PortalApiGus/DaneSzukajPodmiotyApi/GridRegon/regon AS <string>/pKluczUzytkownika AS <string> lub <null>
        /// </summary>
        /// <param name="regon">Regon 9 lub 14 znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>object { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty } AS Json for Kendo Grid</returns>
        // GET: api/PortalApiGus/DaneSzukajPodmiotyApi/GridRegon/regon AS <string>/pKluczUzytkownika AS <string> lub <null>
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("GridRegon/{regon?}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<object>> GetDaneSzukajPodmiotyGridRegonAsync(string regon, string pKluczUzytkownika = null)
        {
            try
            {
                if (null != regon)
                {
                    Regex digitsOnly = new Regex(@"[^\d]");
                    regon = digitsOnly.Replace(regon, string.Empty);
                    if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 9)
                    {
                        if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                        {
                            List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9zn(pKluczUzytkownika, regon);
                            if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                            {
                                return new { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty };
                            }
                        }
                        else
                        {
                            List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony9zn(regon);
                            if (null != daneSzukajPodmioty && daneSzukajPodmioty.Count > 0)
                            {
                                return new { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty };
                            }
                        }
                    }
                    if (null != regon && !string.IsNullOrWhiteSpace(regon) && regon.Length == 14)
                    {
                        if (null != pKluczUzytkownika && !string.IsNullOrWhiteSpace(pKluczUzytkownika))
                        {
                            List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14zn(pKluczUzytkownika, regon);
                            return new { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty };
                        }
                        else
                        {
                            List<DaneSzukajPodmioty> daneSzukajPodmioty = await PortalApiGusApiRegonData.DaneSzukajPodmioty.DaneSzukajPodmiotyAsyncByRegony14zn(regon);
                            return new { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty };
                        }
                    }
                }
                return NotFound();
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return NotFound();
            }
        }
    }
}