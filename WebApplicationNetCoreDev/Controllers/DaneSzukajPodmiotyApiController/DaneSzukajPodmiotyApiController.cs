#region using

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NetAppCommon.Extensions.Caching.Distributed;
using NetAppCommon.Logging;
using PortalApiGus.ApiRegon.Core.Models.DaneSzukajPodmioty;
using PortalApiGus.ApiRegon.DataBase.Data;

#endregion

namespace WebApplicationNetCoreDev.Controllers.DaneSzukajPodmiotyApiController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/PortalApiGus/[controller]")]
    [ApiController]
    public class DaneSzukajPodmiotyApiController : PortalApiGus.ApiRegon.WebApiRazor.Areas.PortalApiGusApi.Controllers.
        DaneSzukajPodmiotyApiController
    {
        #region private readonly ICommonDistributedCache _cache

#pragma warning disable 169
        private readonly ICommonDistributedCache _cache;
#pragma warning restore 169

        #endregion

        #region private readonly DataBaseContext _context

        /// <summary>
        ///     Context do bazy danych as DataBaseContext
        /// </summary>
        private readonly DataBaseContext _context;

        #endregion

        #region private readonly log4net.ILog log4net

        /// <summary>
        ///     private readonly ILog _log4Net
        /// </summary>
        private readonly ILog _log4Net =
            Log4NetLogger.GetLog4NetInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        #region private readonly IActionDescriptorCollectionProvider _provider

        /// <summary>
        ///     Action Descriptor Collection Provider
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _provider;

        #endregion

        #region public DaneSzukajPodmiotyApiController...

        /// <summary>
        ///     Konstruktor
        ///     Constructor
        /// </summary>
        /// <param name="context">
        ///     Kontekst do bazy danych as DataBaseContext
        ///     Database context as DataBaseContext
        /// </param>
        /// <param name="provider">
        ///     Dostawca kolekcji deskryptorów akcji jako IActionDescriptorCollectionProvider
        ///     Action descriptor collection provider as IActionDescriptorCollectionProvider
        /// </param>
        /// <param name="cache">
        ///     Wspólna rozproszona pamięć podręczna jako ICommonDistributedCache
        ///     Common Distributed Cache as ICommonDistributedCache
        /// </param>
        public DaneSzukajPodmiotyApiController(DataBaseContext context,
            IActionDescriptorCollectionProvider provider /*, ICommonDistributedCache cache*/) : base(context,
            provider)
        {
            _context = context;
            _provider = provider;
            //_cache = cache;
        }

        #endregion

        #region public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyNipAsyn...

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Nip/{nip}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyNipAsync(string nip,
            string pKluczUzytkownika = null)
        {
            try
            {
                if (null != nip)
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    nip = digitsOnly.Replace(nip, string.Empty);
                    ActionResult<DaneSzukajPodmiotyResult> daneSzukajPodmiotyResult =
                        await FindByNipAsResultAsync(nip, false, 0, pKluczUzytkownika);
                    return daneSzukajPodmiotyResult?.Value.Data;
                }
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }

                return StatusCode(500, e);
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyRegonAsyn...

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Regon/{regon}/{pKluczUzytkownika?}")]
        public async Task<ActionResult<IEnumerable<DaneSzukajPodmioty>>> GetDaneSzukajPodmiotyRegonAsync(string regon,
            string pKluczUzytkownika = null)
        {
            try
            {
                if (null != regon)
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    regon = digitsOnly.Replace(regon, string.Empty);
                    ActionResult<DaneSzukajPodmiotyResult> daneSzukajPodmiotyResult =
                        await FindByRegonAsResultAsync(regon, false, 0, pKluczUzytkownika);
                    return daneSzukajPodmiotyResult?.Value.Data;
                }
            }
            catch (Exception e)
            {
                _log4Net.Error(e);
                if (null != e.InnerException)
                {
                    _log4Net.Error(e.InnerException);
                }

                return StatusCode(500, e);
            }

            return NotFound();
        }

        #endregion
    }
}
