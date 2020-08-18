using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalApiGusApiRegonData.Data;
using PortalApiGusApiRegonData.Models.DaneSzukajPodmioty;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplicationNetCoreDev.Controllers.PortalApiGusApiRegonDataControler
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DaneSzukajPodmiotyApiController : ControllerBase
    {
        /// <summary>
        /// Context do bazy danych as PortalApiGusApiRegonDataDbContext
        /// </summary>
        private readonly PortalApiGusApiRegonDataDbContext _context;

        /// <summary>
        /// log4net
        /// </summary>
        private static readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context">Context do bazy danych as PortalApiGusApiRegonDataDbContext</param>
        public DaneSzukajPodmiotyApiController(PortalApiGusApiRegonDataDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Pobierz dane wyszukanych podmiotów z bazy danych
        /// GET: api/DaneSzukajPodmiotyApi
        /// </summary>
        /// <returns>List<DaneSzukajPodmioty> lub NotFound()</returns>
        // GET: api/DaneSzukajPodmiotyApi
        [AllowAnonymous]
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
        /// Get: api/DaneSzukajPodmiotyApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// </summary>
        /// <param name="sort">Parametr Kendo Grid sort AS string lub brak <null></param>
        /// <param name="page">Parametr Kendo Grid page AS int lub brak <null></param>
        /// <param name="pageSize">Parametr Kendo Grid pageSize AS int lub brak <null></param>
        /// <param name="group">Parametr Kendo Grid group AS string lub brak <null></param>
        /// <param name="filter">Parametr Kendo Grid filter AS string lub brak <null></param>
        /// <returns>>object { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty } AS Json for Kendo Grid</returns>
        //Get: api/DaneSzukajPodmiotyApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        [AllowAnonymous]
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
        /// GET: api/DaneSzukajPodmiotyApi/Nip/nip AS <string>
        /// </summary>
        /// <param name="nip">NIP znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>Lista podmiotów według NIP AS IEnumerable<DaneSzukajPodmioty></returns>
        // GET: api/DaneSzukajPodmiotyApi/Nip/nip AS <string>
        [AllowAnonymous]
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
        /// GET: api/DaneSzukajPodmiotyApi/Nip/?nip=nip AS <string>
        /// </summary>
        /// <param name="nip">NIP znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>Lista podmiotów według NIP AS IEnumerable<DaneSzukajPodmioty></returns>
        // GET: api/DaneSzukajPodmiotyApi/Nip/?nip=nip AS <string>
        [AllowAnonymous]
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
        /// GET: api/DaneSzukajPodmiotyApi/GridNip/nip AS <string>/pKluczUzytkownika AS <string> lub <null>
        /// </summary>
        /// <param name="nip">NIP znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>object { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty } AS Json for Kendo Grid</returns>
        // GET: api/DaneSzukajPodmiotyApi/GridNip/nip AS <string>/pKluczUzytkownika AS <string> lub <null>
        [AllowAnonymous]
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
        /// GET: api/DaneSzukajPodmiotyApi/Regon/regon AS <string>/pKluczUzytkownika AS <string> lub <null>
        /// </summary>
        /// <param name="regon">Regon 9 lub 14 znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>Lista podmiotów według regon AS IEnumerable<DaneSzukajPodmioty></returns>
        // GET: api/DaneSzukajPodmiotyApi/Regon/regon AS <string>/pKluczUzytkownika AS <string> lub <null>
        [AllowAnonymous]
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
        /// GET: api/DaneSzukajPodmiotyApi/Regon?regon=regon AS <string>&pKluczUzytkownika=pKluczUzytkownika AS <string> lub <null>
        /// </summary>
        /// <param name="regon">Regon 9 lub 14 znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>Lista podmiotów według regon AS IEnumerable<DaneSzukajPodmioty></returns>
        // GET: api/DaneSzukajPodmiotyApi/Regon?regon=regon AS <string>&pKluczUzytkownika=pKluczUzytkownika AS <string> lub <null>
        [AllowAnonymous]
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
        /// GET: api/DaneSzukajPodmiotyApi/GridRegon/regon AS <string>/pKluczUzytkownika AS <string> lub <null>
        /// </summary>
        /// <param name="regon">Regon 9 lub 14 znaków AS String</param>
        /// <param name="pKluczUzytkownika">Opcjonalnie klucz użytkownika API AS String</param>
        /// <returns>object { Regon = regon, Total = daneSzukajPodmioty.Count, Data = daneSzukajPodmioty } AS Json for Kendo Grid</returns>
        // GET: api/DaneSzukajPodmiotyApi/GridRegon/regon AS <string>/pKluczUzytkownika AS <string> lub <null>
        [AllowAnonymous]
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