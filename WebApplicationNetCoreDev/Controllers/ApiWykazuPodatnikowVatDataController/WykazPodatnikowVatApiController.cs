#region using

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApiWykazuPodatnikowVatData.Data;
using ApiWykazuPodatnikowVatData.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NetAppCommon;
using NetAppCommon.Models;
using Z.EntityFramework.Plus;

#endregion

namespace WebApplicationNetCoreDev.Controllers.ApiWykazuPodatnikowVatDataController
{
    #region public class WykazPodatnikowVatApiController : ControllerBase

    /// <summary>
    ///     Api wykazu podatników VAT
    /// </summary>
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/[controller]")]
    [ApiController]
    public class WykazPodatnikowVatApiController : ControllerBase
    {
        #region private readonly ApiWykazuPodatnikowVatDataDbContext apiWykazuPodatnikowVatDataDbContext;

        /// <summary>
        ///     Kontekst bazy danych apiWykazuPodatnikowVatDataDbContext jako ApiWykazuPodatnikowVatDataDbContext
        ///     The apiWykazuPodatnikowVatDataDbContext of the database apiWykazuPodatnikowVatDataDbContext as
        ///     ApiWykazuPodatnikowVatDataDbContext
        /// </summary>
        private readonly ApiWykazuPodatnikowVatDataDbContext _apiWykazuPodatnikowVatDataDbContext;

        #endregion

        #region private readonly IActionDescriptorCollectionProvider actionDescriptorCollectionProvider;

        /// <summary>
        ///     Dostawca kolekcji deskryptorów akcji actionDescriptorCollectionProvider jako IActionDescriptorCollectionProvider
        ///     The actionDescriptorCollectionProvider action descriptor collection actionDescriptorCollectionProvider as
        ///     IActionDescriptorCollectionProvider
        /// </summary>
        private readonly IActionDescriptorCollectionProvider actionDescriptorCollectionProvider;

        #endregion

        #region private readonly ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData apiWykazuPodatnikowVatData;

        /// <summary>
        ///     Obiekt instancji ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData
        ///     Instance object of the ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData
        /// </summary>
        private readonly ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData apiWykazuPodatnikowVatData;

        #endregion

        #region private readonly log4net.ILog log4net

        /// <summary>
        ///     log4net
        /// </summary>
        private readonly ILog log4net =
            Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod()?.DeclaringType);

        #endregion

        #region public WykazPodatnikowVatApiController...

        /// <summary>
        ///     Konstruktor klasy z parametrem apiWykazuPodatnikowVatDataDbContext jako ApiWykazuPodatnikowVatDataDbContext
        ///     A class constructor with the apiWykazuPodatnikowVatDataDbContext parameter as ApiTatDataDbContext
        /// </summary>
        /// <param name="apiWykazuPodatnikowVatDataDbContext">
        ///     Kontekst bazy danych apiWykazuPodatnikowVatDataDbContext jako ApiWykazuPodatnikowVatDataDbContext
        ///     The apiWykazuPodatnikowVatDataDbContext of the database apiWykazuPodatnikowVatDataDbContext as
        ///     ApiWykazuPodatnikowVatDataDbContext
        /// </param>
        /// <param name="actionDescriptorCollectionProvider">
        ///     Dostawca kolekcji deskryptorów akcji actionDescriptorCollectionProvider jako IActionDescriptorCollectionProvider
        ///     The actionDescriptorCollectionProvider action descriptor collection actionDescriptorCollectionProvider as
        ///     IActionDescriptorCollectionProvider
        /// </param>
        public WykazPodatnikowVatApiController(ApiWykazuPodatnikowVatDataDbContext apiWykazuPodatnikowVatDataDbContext,
            IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _apiWykazuPodatnikowVatDataDbContext = apiWykazuPodatnikowVatDataDbContext;
            this.actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
            apiWykazuPodatnikowVatData =
                new ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData(apiWykazuPodatnikowVatDataDbContext);
        }

        #endregion

        #region public async Task<ActionResult<object>> GetEntityKendoGridAsync

        /// Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// <summary>
        ///     Pobierz dane wyszukanych podmiotów z bazy danych
        ///     Get data of found entities from the database
        ///     [Authorize(AuthenticationSchemes = "Cookies")]
        ///     [HttpGet("KendoGrid")]
        ///     Get:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=
        ///     &page=1&pageSize=100&group=&filter=
        /// </summary>
        /// <param name="sort">
        ///     Parametr Kendo Grid sort jako string lub null
        ///     Kendo Grid sort parameter as string or null
        /// </param>
        /// <param name="page">
        ///     Parametr Kendo Grid page AS int lub null
        ///     Kendo Grid page AS int or null
        /// </param>
        /// <param name="pageSize">
        ///     Parametr Kendo Grid pageSize AS int lub null
        ///     Kendo Grid pageSize AS int or null
        /// </param>
        /// <param name="group">
        ///     Parametr Kendo Grid group jako string lub null
        ///     Kendo Grid group parameter as string or null
        /// </param>
        /// <param name="filter">
        ///     Parametr Kendo Grid filter jako string lub null
        ///     Kendo Grid filter parameter as string or null
        /// </param>
        /// <returns>
        ///     NetAppCommon.Models.KendoGrid
        ///     object { Total = Ilość rekordów jako int, Data = Wyszukane dane jako lista obiektów
        ///     ApiWykazuPodatnikowVatData.Models.Entity } jako Json dla Kendo Grid
        ///     object { Total = Number of records as int, Data = Data retrieved as a list of
        ///     ApiWykazuPodatnikowVatData.Models.Entity } as Json for Kendo Grid
        /// </returns>
        // Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("EntityKendoGrid")]
        public async Task<ActionResult<KendoGrid<List<Entity>>>> GetEntityKendoGridAsync([FromQuery] string sort = null,
            [FromQuery] int? page = null, [FromQuery] int? pageSize = null, [FromQuery] string group = null,
            [FromQuery] string filter = null)
        {
            try
            {
                List<Entity> entityList = await _apiWykazuPodatnikowVatDataDbContext.Entity
                    .IncludeOptimized(w => w.EntityAccountNumber).IncludeOptimized(w => w.AuthorizedClerk)
                    .IncludeOptimized(w => w.Partner).IncludeOptimized(w => w.Representative)
                    .IncludeOptimized(w => w.RequestAndResponseHistory)
                    .IncludeOptimized(w => w.RequestAndResponseHistory).ToListAsync();
                if (null != entityList && entityList.Count > 0)
                {
                    return new KendoGrid<List<Entity>> {Total = entityList.Count, Data = entityList};
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<object>> GetEntityCheckKendoGridAsync

        /// Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// <summary>
        ///     Pobierz dane sprawdzonych podmiotów z bazy danych
        ///     Get data of found entities from the database
        ///     [Authorize(AuthenticationSchemes = "Cookies")]
        ///     [HttpGet("KendoGrid")]
        ///     Get:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=
        ///     &page=1&pageSize=100&group=&filter=
        /// </summary>
        /// <param name="sort">
        ///     Parametr Kendo Grid sort jako string lub null
        ///     Kendo Grid sort parameter as string or null
        /// </param>
        /// <param name="page">
        ///     Parametr Kendo Grid page AS int lub null
        ///     Kendo Grid page AS int or null
        /// </param>
        /// <param name="pageSize">
        ///     Parametr Kendo Grid pageSize AS int lub null
        ///     Kendo Grid pageSize AS int or null
        /// </param>
        /// <param name="group">
        ///     Parametr Kendo Grid group jako string lub null
        ///     Kendo Grid group parameter as string or null
        /// </param>
        /// <param name="filter">
        ///     Parametr Kendo Grid filter jako string lub null
        ///     Kendo Grid filter parameter as string or null
        /// </param>
        /// <returns>
        ///     NetAppCommon.Models.KendoGrid
        ///     object { Total = Ilość rekordów jako int, Data = Wyszukane dane jako lista obiektów
        ///     ApiWykazuPodatnikowVatData.Models.EntityCheck } jako Json dla Kendo Grid
        ///     object { Total = Number of records as int, Data = Data retrieved as a list of
        ///     ApiWykazuPodatnikowVatData.Models.EntityCheck } as Json for Kendo Grid
        /// </returns>
        // Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("EntityCheckKendoGrid")]
        public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetEntityCheckKendoGridAsync(
            [FromQuery] string sort = null, [FromQuery] int? page = null, [FromQuery] int? pageSize = null,
            [FromQuery] string group = null, [FromQuery] string filter = null)
        {
            try
            {
                List<EntityCheck> entityCheckList = await _apiWykazuPodatnikowVatDataDbContext.EntityCheck
                    .IncludeOptimized(w => w.RequestAndResponseHistory).ToListAsync();
                if (null != entityCheckList && entityCheckList.Count > 0)
                {
                    return new KendoGrid<List<EntityCheck>> {Total = entityCheckList.Count, Data = entityCheckList};
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<object>> GetRequestAndResponseHistoryKendoGridAsync

        /// Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// <summary>
        ///     Pobierz dane sprawdzonych podmiotów z bazy danych
        ///     Get data of found entities from the database
        ///     [Authorize(AuthenticationSchemes = "Cookies")]
        ///     [HttpGet("KendoGrid")]
        ///     Get:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=
        ///     &page=1&pageSize=100&group=&filter=
        /// </summary>
        /// <param name="sort">
        ///     Parametr Kendo Grid sort jako string lub null
        ///     Kendo Grid sort parameter as string or null
        /// </param>
        /// <param name="page">
        ///     Parametr Kendo Grid page AS int lub null
        ///     Kendo Grid page AS int or null
        /// </param>
        /// <param name="pageSize">
        ///     Parametr Kendo Grid pageSize AS int lub null
        ///     Kendo Grid pageSize AS int or null
        /// </param>
        /// <param name="group">
        ///     Parametr Kendo Grid group jako string lub null
        ///     Kendo Grid group parameter as string or null
        /// </param>
        /// <param name="filter">
        ///     Parametr Kendo Grid filter jako string lub null
        ///     Kendo Grid filter parameter as string or null
        /// </param>
        /// <returns>
        ///     NetAppCommon.Models.KendoGrid
        ///     object { Total = Ilość rekordów jako int, Data = Wyszukane dane jako lista obiektów
        ///     ApiWykazuPodatnikowVatData.Models.RequestAndResponseHistory } jako Json dla Kendo Grid
        ///     object { Total = Number of records as int, Data = Data retrieved as a list of
        ///     ApiWykazuPodatnikowVatData.Models.RequestAndResponseHistory } as Json for Kendo Grid
        /// </returns>
        // Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("RequestAndResponseHistoryKendoGrid")]
        public async Task<ActionResult<KendoGrid<List<RequestAndResponseHistory>>>>
            GetRequestAndResponseHistoryKendoGridAsync([FromQuery] string sort = null, [FromQuery] int? page = null,
                [FromQuery] int? pageSize = null, [FromQuery] string group = null, [FromQuery] string filter = null)
        {
            try
            {
                List<RequestAndResponseHistory> RequestAndResponseHistoryList =
                    await _apiWykazuPodatnikowVatDataDbContext.RequestAndResponseHistory.IncludeOptimized(w => w.Entity)
                        .IncludeOptimized(w => w.EntityCheck).ToListAsync();
                if (null != RequestAndResponseHistoryList && RequestAndResponseHistoryList.Count > 0)
                {
                    return new KendoGrid<List<RequestAndResponseHistory>>
                    {
                        Total = RequestAndResponseHistoryList.Count, Data = RequestAndResponseHistoryList
                    };
                }
            }
            catch (Exception e)
            {
                log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<List<ControllerRoutingActions>>> GetRouteAsync()

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/Route
        ///     Pobierz listę akcji (tras) dostępnych dla kontrolera i zwróć listę
        ///     Get the list of actions (routes) available for the controller and return the list
        /// </summary>
        /// <returns>
        ///     Lista akcji (tras) dostępnych dla kontrolera jako lista obiektów ControllerRoutingActions
        ///     List of actions (routes) available to the controller as a list of ControllerRoutingActions objects
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/Route
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Route")]
        public async Task<ActionResult<List<ControllerRoutingActions>>> GetRouteAsync()
        {
            try
            {
                List<ControllerRoutingActions> controllerRoutingActionsList =
                    await ControllerRoute.GetRouteActionAsync(actionDescriptorCollectionProvider,
                        ControllerContext.ActionDescriptor.ControllerName, Url, this);
                if (null != controllerRoutingActionsList && controllerRoutingActionsList.Count > 0)
                {
                    return controllerRoutingActionsList;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGridAsync()

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/RouteKendoGrid
        ///     Pobierz listę akcji (tras) dostępnych dla kontrolera i zwróć listę dla widoku Kendo
        ///     Get the list of actions (routes) available for the controller and return the list for the Kendo view
        /// </summary>
        /// <returns>
        ///     Lista dostępnych tras routingu jako List dla KendoGrid
        ///     List of available routing routes as List for KendoGrid
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/RouteKendoGrid
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("RouteKendoGrid")]
        public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGridAsync()
        {
            try
            {
                KendoGrid<List<ControllerRoutingActions>> kendoGrid =
                    await ControllerRoute.GetRouteActionForKendoGridAsync(actionDescriptorCollectionProvider,
                        ControllerContext.ActionDescriptor.ControllerName, Url, this);
                if (null != kendoGrid && kendoGrid.Data.Count > 0)
                {
                    return kendoGrid;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<Entity>> GetFindByNipAsync(string nip, DateTime? dateOfChecking)

        /// <summary>
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("FindByNip/{nip}")]
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNip/{nip}/{dateOfChecking?}
        ///     Wyszukaj podmioty według numeru NIP
        ///     Search entities by tax identification number NIP
        /// </summary>
        /// <param name="nip">
        ///     Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        ///     NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Podmiot jako obiekt Entity lub status NotFound
        ///     Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNip/{nip}/{dateOfChecking?}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByNip/{nip}/{dateOfChecking?}")]
        public async Task<ActionResult<Entity>> GetFindByNipAsync(string nip, DateTime? dateOfChecking)
        {
            try
            {
                Entity entity = await apiWykazuPodatnikowVatData.ApiFindByNipAsync(nip, dateOfChecking ?? DateTime.Now);
                if (null != entity)
                {
                    return entity;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<Entity>> GetFindByNipFromQueryAsync([FromQuery] string nip, [FromQuery] DateTime? dateOfChecking)

        /// <summary>
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("FindByNip?nip={nip}")]
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNip?nip={nip}
        ///     Wyszukaj podmioty według numeru NIP
        ///     Search entities by tax identification number NIP
        /// </summary>
        /// <param name="nip">
        ///     Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        ///     NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Podmiot jako obiekt Entity lub status NotFound
        ///     Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNip?nip={nip}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByNip")]
        public async Task<ActionResult<Entity>> GetFindByNipFromQueryAsync([FromQuery] string nip,
            [FromQuery] DateTime? dateOfChecking) => await GetFindByNipAsync(nip, dateOfChecking ?? DateTime.Now);

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByNipKendoGridAsync(string nip, DateTime? dateOfChecking)

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNipKendoGrid/{nip}
        ///     Wyszukaj podmioty według numeru NIP dla widoku KendoGrid
        ///     Search entities by tax identification number NIP for the KendoGrid view
        /// </summary>
        /// <param name="nip">
        ///     Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        ///     NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Lista znalezionych podmiotów dla widoku KendoGrid
        ///     List of entities found for the KendoGrid view
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNipKendoGrid/{nip}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("FindByNipKendoGrid/{nip}/{dateOfChecking?}")]
        public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByNipKendoGridAsync(string nip,
            DateTime? dateOfChecking)
        {
            try
            {
                Entity entity = await apiWykazuPodatnikowVatData.ApiFindByNipAsync(nip, dateOfChecking ?? DateTime.Now);
                if (null != entity)
                {
                    return new KendoGrid<List<Entity>> {Total = 1, Data = new List<Entity> {entity}};
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<Entity>> GetFindByRegonAsync(string regon, DateTime? dateOfChecking)

        /// <summary>
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("FindByRegon/{regon}")]
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegon/{regon}
        ///     Wyszukaj podmioty według numeru REGON
        ///     Search entities by REGON number
        /// </summary>
        /// <param name="regon">
        ///     Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string
        ///     [^\d{9}$|^\d{14}$]
        ///     REGON identification number assigned by the National Register of Entities of National Economy as string
        ///     [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Podmiot jako obiekt Entity lub status NotFound
        ///     Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegon/{regon}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByRegon/{regon}/{dateOfChecking?}")]
        public async Task<ActionResult<Entity>> GetFindByRegonAsync(string regon, DateTime? dateOfChecking)
        {
            try
            {
                var digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && (regon.Length == 9 || regon.Length == 14))
                {
                    Entity entity =
                        await apiWykazuPodatnikowVatData.ApiFindByRegonAsync(regon, dateOfChecking ?? DateTime.Now);
                    if (null != entity)
                    {
                        return entity;
                    }
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<Entity>> GetFindByRegonFromQueryAsync([FromQuery] string regon, DateTime? dateOfChecking)

        /// <summary>
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("FindByRegon?regon={regon}")]
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegon?regon={regon}
        ///     Wyszukaj podmioty według numeru REGON
        ///     Search entities by REGON number
        /// </summary>
        /// <param name="regon">
        ///     Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string
        ///     [^\d{9}$|^\d{14}$]
        ///     REGON identification number assigned by the National Register of Entities of National Economy as string
        ///     [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Podmiot jako obiekt Entity lub status NotFound
        ///     Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegon?regon={regon}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByRegon")]
        public async Task<ActionResult<Entity>> GetFindByRegonFromQueryAsync([FromQuery] string regon,
            DateTime? dateOfChecking) => await GetFindByRegonAsync(regon, dateOfChecking ?? DateTime.Now);

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByRegonKendoGridAsync(string regon, DateTime? dateOfChecking)

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegonKendoGrid/{regon}
        ///     Wyszukaj podmioty według numeru REGON dla widoku KendoGrid
        ///     Search entities by REGON number for the KendoGrid view
        /// </summary>
        /// <param name="regon">
        ///     Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string
        ///     [^\d{9}$|^\d{14}$]
        ///     REGON identification number assigned by the National Register of Entities of National Economy as string
        ///     [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Lista znalezionych podmiotów dla widoku KendoGrid
        ///     List of entities found for the KendoGrid view
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegonKendoGrid/{regon}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("FindByRegonKendoGrid/{regon}/{dateOfChecking?}")]
        public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByRegonKendoGridAsync(string regon,
            DateTime? dateOfChecking)
        {
            try
            {
                var digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && (regon.Length == 9 || regon.Length == 14))
                {
                    Entity entity =
                        await apiWykazuPodatnikowVatData.ApiFindByRegonAsync(regon, dateOfChecking ?? DateTime.Now);
                    if (null != entity)
                    {
                        return new KendoGrid<List<Entity>> {Total = 1, Data = new List<Entity> {entity}};
                    }
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<List<Entity>>> GetFindByBankAccountAsync(string bankAccount, DateTime? dateOfChecking)

        /// <summary>
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("FindByBankAccount/{bankAccount}")]
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccount/{bankAccount}
        ///     Wyszukaj podmioty według numeru rachunku bankowego NRB
        ///     Search for entities by NRB bank account number
        /// </summary>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Lista podmiotów jako lista obiektów Entity lub status NotFound
        ///     Entity list as a list of Entity objects or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccount/{bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByBankAccount/{bankAccount}/{dateOfChecking?}")]
        public async Task<ActionResult<List<Entity>>> GetFindByBankAccountAsync(string bankAccount,
            DateTime? dateOfChecking)
        {
            try
            {
                List<Entity> entityList =
                    await apiWykazuPodatnikowVatData.ApiFindByBankAccountAsync(bankAccount,
                        dateOfChecking ?? DateTime.Now);
                if (null != entityList && entityList.Count > 0)
                {
                    return entityList;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<List<Entity>>> GetFindByBankAccountFromQueryAsync([FromQuery] string bankAccount, [FromQuery] DateTime? dateOfChecking)

        /// <summary>
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("FindByBankAccount?bankAccount={bankAccount}")]
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccount?bankAccount={bankAccount}
        ///     Wyszukaj podmioty według numeru rachunku bankowego NRB
        ///     Search for entities by NRB bank account number
        /// </summary>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Podmiot jako obiekt Entity lub status NotFound
        ///     Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccount?bankAccount={bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByBankAccount")]
        public async Task<ActionResult<List<Entity>>> GetFindByBankAccountFromQueryAsync([FromQuery] string bankAccount,
            [FromQuery] DateTime? dateOfChecking) =>
            await GetFindByBankAccountAsync(bankAccount, dateOfChecking ?? DateTime.Now);

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByBankAccountKendoGridAsync(string bankAccount, DateTime? dateOfChecking)

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccountKendoGrid/{bankAccount}
        ///     Wyszukaj podmioty według numeru rachunku bankowego NRB dla widoku KendoGrid
        ///     Search for entities by NRB bank account number for the KendoGrid view
        /// </summary>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Lista znalezionych podmiotów dla widoku KendoGrid
        ///     List of entities found for the KendoGrid view
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccountKendoGrid/{bankAccount}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("FindByBankAccountKendoGrid/{bankAccount}/{dateOfChecking?}")]
        public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByBankAccountKendoGridAsync(string bankAccount,
            DateTime? dateOfChecking)
        {
            try
            {
                List<Entity> entityList =
                    await apiWykazuPodatnikowVatData.ApiFindByBankAccountAsync(bankAccount,
                        dateOfChecking ?? DateTime.Now);
                if (null != entityList && entityList.Count > 0)
                {
                    return new KendoGrid<List<Entity>> {Total = entityList.Count, Data = entityList};
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipAsync(string nip, string bankAccount, DateTime? dateOfChecking)

        /// <summary>
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("CheckBankAccountByNip/{nip}/{bankAccount}")]
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNipAsync/{nip}/{bankAccount}
        ///     Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        ///     Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="nip">
        ///     Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        ///     NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        ///     Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNipAsync/{nip}/{bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckBankAccountByNip/{nip}/{bankAccount}/{dateOfChecking?}")]
        public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipAsync(string nip, string bankAccount,
            DateTime? dateOfChecking)
        {
            try
            {
                EntityCheck entityCheck =
                    await apiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync(nip, bankAccount,
                        dateOfChecking ?? DateTime.Now);
                if (null != entityCheck)
                {
                    return entityCheck;
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetCheckBankAccountByNipKendoGridAsync...

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNipKendoGrid/{nip}/{bankAccount}
        ///     [Authorize(AuthenticationSchemes = "Cookies")]
        ///     [HttpGet("CheckBankAccountByNipKendoGrid/{bankAccount}")]
        ///     Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        ///     Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="nip">
        ///     Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        ///     NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        ///     Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNipKendoGrid/{nip}/{bankAccount}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("CheckBankAccountByNipKendoGrid/{nip}/{bankAccount}/{dateOfChecking?}")]
        public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetCheckBankAccountByNipKendoGridAsync(string nip,
            string bankAccount, DateTime? dateOfChecking)
        {
            try
            {
                EntityCheck entityCheck =
                    await apiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync(nip, bankAccount,
                        dateOfChecking ?? DateTime.Now);
                if (null != entityCheck)
                {
                    return new KendoGrid<List<EntityCheck>> {Total = 1, Data = new List<EntityCheck> {entityCheck}};
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipFromQueryAsync...

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNip?nip={nip}
        ///     &bankAccount={bankAccount}
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("CheckBankAccountByNip")]
        ///     Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        ///     Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="nip">
        ///     Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        ///     NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        ///     Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNip?nip={nip}&bankAccount={bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckBankAccountByNip")]
        public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipFromQueryAsync([FromQuery] string nip,
            [FromQuery] string bankAccount, [FromQuery] DateTime? dateOfChecking) =>
            await GetCheckBankAccountByNipAsync(nip, bankAccount, dateOfChecking ?? DateTime.Now);

        #endregion

        #region public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByRegonAsync...

        /// <summary>
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("CheckBankAccountByRegon/{regon}/{bankAccount}")]
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegonAsync/{regon}/{bankAccount}
        ///     Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        ///     Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="regon">
        ///     Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string
        ///     [^\d{9}$|^\d{14}$]
        ///     REGON identification number assigned by the National Register of Entities of National Economy as string
        ///     [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        ///     Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegonAsync/{regon}/{bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckBankAccountByRegon/{regon}/{bankAccount}/{dateOfChecking?}")]
        public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByRegonAsync(string regon, string bankAccount,
            DateTime? dateOfChecking)
        {
            try
            {
                var digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && (regon.Length == 9 || regon.Length == 14))
                {
                    EntityCheck entityCheck =
                        await apiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync(regon, bankAccount,
                            dateOfChecking ?? DateTime.Now);
                    if (null != entityCheck)
                    {
                        return entityCheck;
                    }
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetCheckBankAccountByRegonKendoGridAsync...

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegonKendoGrid/{regon}/{bankAccount}/{dateOfChecking?}
        ///     [Authorize(AuthenticationSchemes = "Cookies")]
        ///     [HttpGet("CheckBankAccountByRegonKendoGrid/{bankAccount}")]
        ///     Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        ///     Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="regon">
        ///     Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string
        ///     [^\d{9}$|^\d{14}$]
        ///     REGON identification number assigned by the National Register of Entities of National Economy as string
        ///     [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <param name="dateOfChecking">
        ///     Określ datę sprawdzenia danych w dniu jako DateTime lub brak (null - domyśnie data bieżąca)
        ///     Specify the date of checking the data on the date as DateTime or none (null - current date by default)
        /// </param>
        /// <returns>
        ///     Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        ///     Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegonKendoGrid/{regon}/{bankAccount}/{dateOfChecking?}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("CheckBankAccountByRegonKendoGrid/{regon}/{bankAccount}/{dateOfChecking?}")]
        public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetCheckBankAccountByRegonKendoGridAsync(
            string regon, string bankAccount, DateTime? dateOfChecking)
        {
            try
            {
                var digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && (regon.Length == 9 || regon.Length == 14))
                {
                    EntityCheck entityCheck =
                        await apiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync(regon, bankAccount,
                            dateOfChecking ?? DateTime.Now);
                    if (null != entityCheck)
                    {
                        return new KendoGrid<List<EntityCheck>> {Total = 1, Data = new List<EntityCheck> {entityCheck}};
                    }
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }

            return NotFound();
        }

        #endregion

        #region public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByRegonFromQueryAsync...

        /// <summary>
        ///     GET:
        ///     api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegon?regon={regon}
        ///     &bankAccount={bankAccount}
        ///     [Authorize(AuthenticationSchemes = "Bearer")]
        ///     [HttpGet("CheckBankAccountByRegon")]
        ///     Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        ///     Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="regon">
        ///     Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string
        ///     [^\d{9}$|^\d{14}$]
        ///     REGON identification number assigned by the National Register of Entities of National Economy as string
        ///     [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="bankAccount">
        ///     Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        ///     Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        ///     Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        ///     Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegon?regon={regon}&bankAccount={bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckBankAccountByRegon")]
        public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByRegonFromQueryAsync([FromQuery] string regon,
            [FromQuery] string bankAccount, [FromQuery] DateTime? dateOfChecking) =>
            await GetCheckBankAccountByRegonAsync(regon, bankAccount, dateOfChecking ?? DateTime.Now);

        #endregion
    }

    #endregion
}
