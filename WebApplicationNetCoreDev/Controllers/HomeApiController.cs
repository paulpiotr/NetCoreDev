#region using

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NetAppCommon;
using NetAppCommon.Logging;
using NetAppCommon.Models;

#endregion

namespace WebApplicationNetCoreDev.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]/[action]/")]
    [Route("api/Home/[action]/")]
    public class HomeApiController : ControllerBase
    {
        /// <summary>
        ///     private readonly ILog _log4Net
        /// </summary>
        private readonly ILog _log4Net = Log4NetLogger.GetLog4NetInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        /// <summary>
        ///     Action Descriptor Collection Provider
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _provider;

        /// <summary>
        ///     Konstruktor
        ///     Constructor
        /// </summary>
        /// <param name="provider">
        ///     IActionDescriptorCollectionProvider provider
        /// </param>
        public HomeApiController(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        ///     Pobierz listę akcji (tras) dostępnych dla kontrolera
        ///     Get the list of actions (routes) available for the controller
        /// </summary>
        /// <returns>
        ///     Lista dostępnych tras
        ///     List of available routes
        /// </returns>
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<List<ControllerRoutingActions>>> GetRouteAsync()
        {
            try
            {
                List<ControllerRoutingActions> controllerRoutingActionsList =
                    await ControllerRoute.GetRouteActionAsync(_provider, Url);
                if (null != controllerRoutingActionsList && controllerRoutingActionsList.Count > 0)
                {
                    return controllerRoutingActionsList;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() =>
                    _log4Net.Error(
                        $"{Environment.NewLine}{e.GetType()}{Environment.NewLine}{e.InnerException?.GetType()}{Environment.NewLine}{e.Message}{Environment.NewLine}{e.StackTrace}{Environment.NewLine}",
                        e));
                return StatusCode(500, e);
            }

            return NotFound();
        }

        /// <summary>
        ///     Pobierz listę akcji (tras) dostępnych dla kontrolera (do widoku Kendo Grid)
        ///     Download the list of actions (routes) available for the controller (to the Kendo Grid view)
        /// </summary>
        /// <returns>
        ///     Lista dostępnych tras
        ///     List of available routes
        /// </returns>
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGridAsync()
        {
            try
            {
                KendoGrid<List<ControllerRoutingActions>> kendoGrid =
                    await ControllerRoute.GetRouteActionForKendoGridAsync(_provider, Url);
                if (null != kendoGrid && kendoGrid.Data.Count > 0)
                {
                    return kendoGrid;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() =>
                    _log4Net.Error(
                        $"{Environment.NewLine}{e.GetType()}{Environment.NewLine}{e.InnerException?.GetType()}{Environment.NewLine}{e.Message}{Environment.NewLine}{e.StackTrace}{Environment.NewLine}",
                        e));
                return StatusCode(500, e);
            }

            return NotFound();
        }
    }
}
