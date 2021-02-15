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
using Microsoft.Extensions.DependencyInjection;
using NetAppCommon;
using NetAppCommon.Models;
using Vies.Core.Database.Models;
using Vies.Core.Database.Repositories;
using Vies.Core.Models;
using Vies.Core.Services;

#endregion

namespace WebApplicationNetCoreDev.Controllers.EuropeanCommission.TaxationAndCustomsUnion
{
    #region public class ViesApiController : ControllerBase

    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/EuropeanCommission/TaxationAndCustomsUnion/[controller]")]
    [ApiController]
    public class ViesApiController : ControllerBase
    {
        #region private readonly AppSettings _appSettings

        /// <summary>
        ///     Vies.Core.Database.Models.AppSettings
        /// </summary>
        private readonly AppSettings _appSettings = new();

        #endregion

        #region private readonly log4net.ILog log4net

        /// <summary>
        ///     log4net
        /// </summary>
        private readonly ILog _log4Net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        #region private readonly IActionDescriptorCollectionProvider _provider

        /// <summary>
        ///     Action Descriptor Collection Provider
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _provider;

        #endregion

        #region private readonly IServiceScopeFactory _serviceScopeFactory

        /// <summary>
        ///     private readonly IServiceScopeFactory _serviceScopeFactory
        /// </summary>
        private readonly IServiceScopeFactory _serviceScopeFactory;

        #endregion

        #region public ViesApiController(IActionDescriptorCollectionProvider provider, IServiceScopeFactory serviceScopeFactory)

        /// <summary>
        ///     Konstruktor
        ///     Constructor
        /// </summary>
        /// <param name="provider">
        ///     IActionDescriptorCollectionProvider provider
        /// </param>
        /// <param name="serviceScopeFactory">
        ///     IServiceScopeFactory serviceScopeFactory
        /// </param>
        public ViesApiController(IActionDescriptorCollectionProvider provider, IServiceScopeFactory serviceScopeFactory)
        {
            _provider = provider;
            _serviceScopeFactory = serviceScopeFactory;
        }

        #endregion

        #region public async Task<ActionResult<List<ControllerRoutingActions>>> GetRouteAsync()

        /// <summary>
        ///     Pobierz listę akcji (tras) dostępnych dla kontrolera
        ///     Get the list of actions (routes) available for the controller
        /// </summary>
        /// <returns>
        ///     Lista dostępnych tras
        ///     List of available routes
        /// </returns>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Route")]
        public async Task<ActionResult<List<ControllerRoutingActions>>> GetRouteAsync()
        {
            try
            {
                List<ControllerRoutingActions> controllerRoutingActionsList =
                    await ControllerRoute.GetRouteActionAsync(_provider,
                        ControllerContext.ActionDescriptor.ControllerName, Url, this);
                if (null != controllerRoutingActionsList && controllerRoutingActionsList.Count > 0)
                {
                    return controllerRoutingActionsList;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => _log4Net.Error($"{e.Message}, {e.StackTrace}.", e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGridAsync()

        /// <summary>
        ///     Pobierz listę akcji (tras) dostępnych dla kontrolera (do widoku Kendo Grid)
        ///     Download the list of actions (routes) available for the controller (to the Kendo Grid view)
        /// </summary>
        /// <returns>
        ///     Lista dostępnych tras
        ///     List of available routes
        /// </returns>
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("RouteKendoGrid")]
        public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGridAsync()
        {
            try
            {
                KendoGrid<List<ControllerRoutingActions>> kendoGrid =
                    await ControllerRoute.GetRouteActionForKendoGridAsync(_provider,
                        ControllerContext.ActionDescriptor.ControllerName, Url, this);
                if (null != kendoGrid && kendoGrid.Data.Count > 0)
                {
                    return kendoGrid;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => _log4Net.Error($"{e.Message}, {e.StackTrace}.", e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<CheckVat>> GetCheckVatAsync

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckVat/{countryCode}/{vatNumber}")]
        public async Task<ActionResult<CheckVat>> GetCheckVatAsync(string countryCode, string vatNumber)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(countryCode) && !string.IsNullOrWhiteSpace(vatNumber))
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    vatNumber = digitsOnly.Replace(vatNumber, string.Empty);
                    CheckVat checkVat = _appSettings.CacheLifeTime > 0
                        ? await CheckVatRepository.GetInstance(_serviceScopeFactory)
                            .FindByCountryCodeAndVatNumberAsync(countryCode, vatNumber,
                                (int)_appSettings.CacheLifeTime) ?? await CheckVatRepository
                            .GetInstance(_serviceScopeFactory)
                            .SaveAsync(await ViesService.GetInstance().CheckVatAsync(countryCode, vatNumber))
                        : await CheckVatRepository.GetInstance(_serviceScopeFactory)
                            .SaveAsync(await ViesService.GetInstance().CheckVatAsync(countryCode, vatNumber));
                    return checkVat;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => _log4Net.Error($"{e.Message}, {e.StackTrace}.", e));
            }

            return NotFound(new {countryCode, vatNumber});
        }

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<CheckVat>>>> GetCheckVatKendoGridAsync

        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("CheckVatKendoGrid/{countryCode}/{vatNumber}")]
        public async Task<ActionResult<KendoGrid<List<CheckVat>>>> GetCheckVatKendoGridAsync(string countryCode,
            string vatNumber)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(countryCode) && !string.IsNullOrWhiteSpace(vatNumber))
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    vatNumber = digitsOnly.Replace(vatNumber, string.Empty);
                    CheckVat checkVat = _appSettings.CacheLifeTime > 0
                        ? await CheckVatRepository.GetInstance(_serviceScopeFactory)
                            .FindByCountryCodeAndVatNumberAsync(countryCode, vatNumber,
                                (int)_appSettings.CacheLifeTime) ?? await CheckVatRepository
                            .GetInstance(_serviceScopeFactory)
                            .SaveAsync(await ViesService.GetInstance().CheckVatAsync(countryCode, vatNumber))
                        : await CheckVatRepository.GetInstance(_serviceScopeFactory)
                            .SaveAsync(await ViesService.GetInstance().CheckVatAsync(countryCode, vatNumber));
                    return new KendoGrid<List<CheckVat>> {Total = 1, Data = new List<CheckVat> {checkVat}};
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => _log4Net.Error($"{e.Message}, {e.StackTrace}.", e));
            }

            return NotFound(new {countryCode, vatNumber});
        }

        #endregion

        #region MyRegion public async Task<ActionResult<CheckVatApprox>> GetCheckVatApproxAsync

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckVatApprox/{countryCode}/{vatNumber}/{requesterCountryCode?}/{requesterVatNumber?}")]
        public async Task<ActionResult<CheckVatApprox>> GetCheckVatApproxAsync(string countryCode, string vatNumber,
            string requesterCountryCode = null, string requesterVatNumber = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(countryCode) && !string.IsNullOrWhiteSpace(vatNumber))
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    vatNumber = digitsOnly.Replace(vatNumber, string.Empty);
                    requesterCountryCode ??= countryCode;
                    requesterVatNumber ??= vatNumber;
                    CheckVatApprox checkVatApprox = _appSettings.CacheLifeTime > 0
                        ? await CheckVatApproxRepository.GetInstance(_serviceScopeFactory)
                            .FindByCountryCodeAndVatNumberAsync(countryCode, vatNumber,
                                (int)_appSettings.CacheLifeTime) ?? await CheckVatApproxRepository
                            .GetInstance(_serviceScopeFactory).SaveAsync(await ViesService.GetInstance()
                                .CheckVatApproxAsync(countryCode, vatNumber, requesterCountryCode, requesterVatNumber))
                        : await CheckVatApproxRepository.GetInstance(_serviceScopeFactory).SaveAsync(await ViesService
                            .GetInstance()
                            .CheckVatApproxAsync(countryCode, vatNumber, requesterCountryCode, requesterVatNumber));
                    return checkVatApprox;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => _log4Net.Error($"{e.Message}, {e.StackTrace}.", e));
            }

            return NotFound(new {countryCode, vatNumber, requesterCountryCode, requesterVatNumber});
        }

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<CheckVatApprox>>>> GetCheckVatApproxKendoGridAsync

        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("CheckVatApproxKendoGrid/{countryCode}/{vatNumber}/{requesterCountryCode?}/{requesterVatNumber?}")]
        public async Task<ActionResult<KendoGrid<List<CheckVatApprox>>>> GetCheckVatApproxKendoGridAsync(
            string countryCode, string vatNumber, string requesterCountryCode = null, string requesterVatNumber = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(countryCode) && !string.IsNullOrWhiteSpace(vatNumber))
                {
                    var digitsOnly = new Regex(@"[^\d]");
                    vatNumber = digitsOnly.Replace(vatNumber, string.Empty);
                    requesterCountryCode ??= countryCode;
                    requesterVatNumber ??= vatNumber;
                    CheckVatApprox checkVatApprox = _appSettings.CacheLifeTime > 0
                        ? await CheckVatApproxRepository.GetInstance(_serviceScopeFactory)
                            .FindByCountryCodeAndVatNumberAsync(countryCode, vatNumber,
                                (int)_appSettings.CacheLifeTime) ?? await CheckVatApproxRepository
                            .GetInstance(_serviceScopeFactory).SaveAsync(await ViesService.GetInstance()
                                .CheckVatApproxAsync(countryCode, vatNumber, requesterCountryCode, requesterVatNumber))
                        : await CheckVatApproxRepository.GetInstance(_serviceScopeFactory).SaveAsync(await ViesService
                            .GetInstance()
                            .CheckVatApproxAsync(countryCode, vatNumber, requesterCountryCode, requesterVatNumber));
                    return new KendoGrid<List<CheckVatApprox>>
                    {
                        Total = 1, Data = new List<CheckVatApprox> {checkVatApprox}
                    };
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => _log4Net.Error($"{e.Message}, {e.StackTrace}.", e));
            }

            return NotFound(new {countryCode, vatNumber, requesterCountryCode, requesterVatNumber});
        }

        #endregion
    }

    #endregion
}
