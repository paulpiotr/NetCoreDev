using ApiWykazuPodatnikowVatData.Data;
using ApiWykazuPodatnikowVatData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NetAppCommon.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplicationNetCoreDev.Controllers.ApiWykazuPodatnikowVatDataController
{
    #region public class WykazPodatnikowVatApiController : ControllerBase
    /// <summary>
    /// Api wykazu podatników VAT
    /// </summary>
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/[controller]")]
    [ApiController]
    public class WykazPodatnikowVatApiController : ControllerBase
    {

        #region private static readonly log4net.ILog log4net
        /// <summary>
        /// log4net
        /// </summary>
        private static readonly log4net.ILog log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region private readonly ApiWykazuPodatnikowVatDataDbContext _context;
        /// <summary>
        /// Kontekst bazy danych _context jako ApiWykazuPodatnikowVatDataDbContext
        /// The context of the database _context as ApiWykazuPodatnikowVatDataDbContext
        /// </summary>
        private readonly ApiWykazuPodatnikowVatDataDbContext _context;
        #endregion

        #region private readonly IActionDescriptorCollectionProvider _provider;
        /// <summary>
        /// Dostawca kolekcji deskryptorów akcji _provider jako IActionDescriptorCollectionProvider
        /// The _provider action descriptor collection provider as IActionDescriptorCollectionProvider
        /// </summary>
        private readonly IActionDescriptorCollectionProvider _provider;
        #endregion

        #region public WykazPodatnikowVatApiController...
        /// <summary>
        /// Konstruktor klasy z parametrem context jako ApiWykazuPodatnikowVatDataDbContext
        /// A class constructor with the context parameter as ApiTatDataDbContext
        /// </summary>
        /// <param name="context">
        /// Kontekst bazy danych _context jako ApiWykazuPodatnikowVatDataDbContext
        /// The context of the database _context as ApiWykazuPodatnikowVatDataDbContext
        /// </param>
        /// <param name="provider">
        /// Dostawca kolekcji deskryptorów akcji _provider jako IActionDescriptorCollectionProvider
        /// The _provider action descriptor collection provider as IActionDescriptorCollectionProvider
        /// </param>
        public WykazPodatnikowVatApiController(ApiWykazuPodatnikowVatDataDbContext context, IActionDescriptorCollectionProvider provider)
        {
            _context = context;
            _provider = provider;
        }
        #endregion

        #region public async Task<ActionResult<object>> GetEntityKendoGridAsync
        /// Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// <summary>
        /// Pobierz dane wyszukanych podmiotów z bazy danych
        /// Get data of found entities from the database
        /// [Authorize(AuthenticationSchemes = "Cookies")]
        /// [HttpGet("KendoGrid")]
        /// Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// </summary>
        /// <param name="sort">
        /// Parametr Kendo Grid sort jako string lub null
        /// Kendo Grid sort parameter as string or null
        /// </param>
        /// <param name="page">
        /// Parametr Kendo Grid page AS int lub null
        /// Kendo Grid page AS int or null
        /// </param>
        /// <param name="pageSize">
        /// Parametr Kendo Grid pageSize AS int lub null
        /// Kendo Grid pageSize AS int or null
        /// </param>
        /// <param name="group">
        /// Parametr Kendo Grid group jako string lub null
        /// Kendo Grid group parameter as string or null
        /// </param>
        /// <param name="filter">
        /// Parametr Kendo Grid filter jako string lub null
        /// Kendo Grid filter parameter as string or null
        /// </param>
        /// <returns>
        /// NetAppCommon.Models.KendoGrid
        /// object { Total = Ilość rekordów jako int, Data = Wyszukane dane jako lista obiektów ApiWykazuPodatnikowVatData.Models.Entity } jako Json dla Kendo Grid
        /// object { Total = Number of records as int, Data = Data retrieved as a list of ApiWykazuPodatnikowVatData.Models.Entity } as Json for Kendo Grid
        /// </returns>
        // Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("EntityKendoGrid")]
        public async Task<ActionResult<KendoGrid<List<Entity>>>> GetEntityKendoGridAsync([FromQuery] string sort = null, [FromQuery] int? page = null, [FromQuery] int? pageSize = null, [FromQuery] string group = null, [FromQuery] string filter = null)
        {
            try
            {
                List<Entity> entityList = await _context.Entity.Include(i => i.EntityAccountNumber).ToListAsync();
                if (null != entityList && entityList.Count > 0)
                {
                    return new KendoGrid<List<Entity>> { Total = entityList.Count, Data = entityList };
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
        /// Pobierz dane sprawdzonych podmiotów z bazy danych
        /// Get data of found entities from the database
        /// [Authorize(AuthenticationSchemes = "Cookies")]
        /// [HttpGet("KendoGrid")]
        /// Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        /// </summary>
        /// <param name="sort">
        /// Parametr Kendo Grid sort jako string lub null
        /// Kendo Grid sort parameter as string or null
        /// </param>
        /// <param name="page">
        /// Parametr Kendo Grid page AS int lub null
        /// Kendo Grid page AS int or null
        /// </param>
        /// <param name="pageSize">
        /// Parametr Kendo Grid pageSize AS int lub null
        /// Kendo Grid pageSize AS int or null
        /// </param>
        /// <param name="group">
        /// Parametr Kendo Grid group jako string lub null
        /// Kendo Grid group parameter as string or null
        /// </param>
        /// <param name="filter">
        /// Parametr Kendo Grid filter jako string lub null
        /// Kendo Grid filter parameter as string or null
        /// </param>
        /// <returns>
        /// NetAppCommon.Models.KendoGrid
        /// object { Total = Ilość rekordów jako int, Data = Wyszukane dane jako lista obiektów ApiWykazuPodatnikowVatData.Models.EntityCheck } jako Json dla Kendo Grid
        /// object { Total = Number of records as int, Data = Data retrieved as a list of ApiWykazuPodatnikowVatData.Models.EntityCheck } as Json for Kendo Grid
        /// </returns>
        // Get: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/KendoGrid?sort=&page=1&pageSize=100&group=&filter=
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("EntityCheckKendoGrid")]
        public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetEntityCheckKendoGridAsync([FromQuery] string sort = null, [FromQuery] int? page = null, [FromQuery] int? pageSize = null, [FromQuery] string group = null, [FromQuery] string filter = null)
        {
            try
            {
                List<EntityCheck> entityCheckList = await _context.EntityCheck.ToListAsync();
                if (null != entityCheckList && entityCheckList.Count > 0)
                {
                    return new KendoGrid<List<EntityCheck>> { Total = entityCheckList.Count, Data = entityCheckList };
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
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/Route
        /// Pobierz listę akcji (tras) dostępnych dla kontrolera i zwróć listę
        /// Get the list of actions (routes) available for the controller and return the list
        /// </summary>
        /// <returns>
        /// Lista akcji (tras) dostępnych dla kontrolera jako lista obiektów ControllerRoutingActions
        /// List of actions (routes) available to the controller as a list of ControllerRoutingActions objects
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/Route
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("Route")]
        public async Task<ActionResult<List<ControllerRoutingActions>>> GetRouteAsync()
        {
            try
            {
                List<ControllerRoutingActions> controllerRoutingActionsList = await NetAppCommon.ControllerRoute.GetRouteActionAsync(_provider, ControllerContext.ActionDescriptor.ControllerName.ToString(), Url, this);
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

        #region public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGirdAsync()
        /// <summary>
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/RouteKendoGird
        /// Pobierz listę akcji (tras) dostępnych dla kontrolera i zwróć listę dla widoku Kendo
        /// Get the list of actions (routes) available for the controller and return the list for the Kendo view
        /// </summary>
        /// <returns>
        /// Lista dostępnych tras routingu jako List dla KendoGrid
        /// List of available routing routes as List for KendoGrid
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/RouteKendoGird
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("RouteKendoGird")]
        public async Task<ActionResult<KendoGrid<List<ControllerRoutingActions>>>> GetRouteKendoGirdAsync()
        {
            try
            {
                KendoGrid<List<ControllerRoutingActions>> kendoGrid = await NetAppCommon.ControllerRoute.GetRouteActionForKendoGridAsync(_provider, ControllerContext.ActionDescriptor.ControllerName.ToString(), Url, this);
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

        #region public async Task<ActionResult<Entity>> GetFindByNipAsync(string nip)
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("FindByNip/{nip}")]
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNip/{nip}
        /// Wyszukaj podmioty według numeru NIP
        /// Search entities by tax identification number NIP
        /// </summary>
        /// <param name="nip">
        /// Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        /// NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <returns>
        /// Podmiot jako obiekt Entity lub status NotFound
        /// Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNip/{nip}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByNip/{nip}")]
        public async Task<ActionResult<Entity>> GetFindByNipAsync(string nip)
        {
            try
            {
                Entity entity = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByNipAsync(nip);
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

        #region public async Task<ActionResult<Entity>> GetFindByNipFromQueryAsync([FromQuery] string nip)
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("FindByNip?nip={nip}")]
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNip?nip={nip}
        /// Wyszukaj podmioty według numeru NIP
        /// Search entities by tax identification number NIP
        /// </summary>
        /// <param name="nip">
        /// Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        /// NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <returns>
        /// Podmiot jako obiekt Entity lub status NotFound
        /// Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNip?nip={nip}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByNip")]
        public async Task<ActionResult<Entity>> GetFindByNipFromQueryAsync([FromQuery] string nip)
        {
            return await GetFindByNipAsync(nip);
        }
        #endregion

        #region public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByNipKendoGirdAsync(string nip)
        /// <summary>
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNipKendoGird/{nip}
        /// Wyszukaj podmioty według numeru NIP dla widoku KendoGrid
        /// Search entities by tax identification number NIP for the KendoGrid view
        /// </summary>
        /// <returns>
        /// Lista znalezionych podmiotów dla widoku KendoGrid
        /// List of entities found for the KendoGrid view
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByNipKendoGird/{nip}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("FindByNipKendoGird/{nip}")]
        public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByNipKendoGirdAsync(string nip)
        {
            try
            {
                Entity entity = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByNipAsync(nip);
                if (null != entity)
                {
                    return new KendoGrid<List<Entity>>()
                    {
                        Total = 1,
                        Data = new List<Entity>() { entity }
                    };
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<Entity>> GetFindByRegonAsync(string regon)
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("FindByRegon/{regon}")]
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegon/{regon}
        /// Wyszukaj podmioty według numeru REGON
        /// Search entities by REGON number
        /// </summary>
        /// <param name="regon">
        /// Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string [^\d{9}$|^\d{14}$]
        /// REGON identification number assigned by the National Register of Entities of National Economy as string [^\d{9}$|^\d{14}$]
        /// </param>
        /// <returns>
        /// Podmiot jako obiekt Entity lub status NotFound
        /// Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegon/{regon}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByRegon/{regon}")]
        public async Task<ActionResult<Entity>> GetFindByRegonAsync(string regon)
        {
            try
            {
                Entity entity = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByRegonAsync(regon);
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

        #region public async Task<ActionResult<Entity>> GetFindByRegonFromQueryAsync([FromQuery] string regon)
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("FindByRegon?regon={regon}")]
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegon?regon={regon}
        /// Wyszukaj podmioty według numeru REGON
        /// Search entities by REGON number
        /// </summary>
        /// <param name="regon">
        /// Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string [^\d{9}$|^\d{14}$]
        /// REGON identification number assigned by the National Register of Entities of National Economy as string [^\d{9}$|^\d{14}$]
        /// </param>
        /// <returns>
        /// Podmiot jako obiekt Entity lub status NotFound
        /// Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegon?regon={regon}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByRegon")]
        public async Task<ActionResult<Entity>> GetFindByRegonFromQueryAsync([FromQuery] string regon)
        {
            return await GetFindByRegonAsync(regon);
        }
        #endregion

        #region public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByRegonKendoGirdAsync(string regon)
        /// <summary>
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegonKendoGird/{regon}
        /// Wyszukaj podmioty według numeru REGON dla widoku KendoGrid
        /// Search entities by REGON number for the KendoGrid view
        /// </summary>
        /// <param name="regon">
        /// Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string [^\d{9}$|^\d{14}$]
        /// REGON identification number assigned by the National Register of Entities of National Economy as string [^\d{9}$|^\d{14}$]
        /// </param>
        /// <returns>
        /// Lista znalezionych podmiotów dla widoku KendoGrid
        /// List of entities found for the KendoGrid view
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByRegonKendoGird/{regon}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("FindByRegonKendoGird/{regon}")]
        public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByRegonKendoGirdAsync(string regon)
        {
            try
            {
                Regex digitsOnly = new Regex(@"[^\d]");
                regon = digitsOnly.Replace(regon, string.Empty);
                if (null != regon && !string.IsNullOrWhiteSpace(regon) && (regon.Length == 9 || regon.Length == 14))
                {
                    Entity entity = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByRegonAsync(regon);
                    if (null != entity)
                    {
                        return new KendoGrid<List<Entity>>()
                        {
                            Total = 1,
                            Data = new List<Entity>() { entity }
                        };
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

        #region public async Task<ActionResult<Entity>> GetFindByBankAccountAsync(string bankAccount)
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("FindByBankAccount/{bankAccount}")]
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccount/{bankAccount}
        /// Wyszukaj podmioty według numeru rachunku bankowego NRB
        /// Search for entities by NRB bank account number
        /// </summary>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Lista podmiotów jako lista obiektów Entity lub status NotFound
        /// Entity list as a list of Entity objects or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccount/{bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByBankAccount/{bankAccount}")]
        public async Task<ActionResult<List<Entity>>> GetFindByBankAccountAsync(string bankAccount)
        {
            try
            {
                List<Entity> entityList = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByBankAccountAsync(bankAccount);
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

        #region public async Task<ActionResult<Entity>> GetFindByBankAccountFromQueryAsync([FromQuery] string bankAccount)
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("FindByBankAccount?bankAccount={bankAccount}")]
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccount?bankAccount={bankAccount}
        /// Wyszukaj podmioty według numeru rachunku bankowego NRB
        /// Search for entities by NRB bank account number
        /// </summary>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Podmiot jako obiekt Entity lub status NotFound
        /// Entity as an Entity object or NotFound status
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccount?bankAccount={bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("FindByBankAccount")]
        public async Task<ActionResult<List<Entity>>> GetFindByBankAccountFromQueryAsync([FromQuery] string bankAccount)
        {
            return await GetFindByBankAccountAsync(bankAccount);
        }
        #endregion

        #region public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByBankAccountKendoGirdAsync(string bankAccount)
        /// <summary>
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccountKendoGird/{bankAccount}
        /// Wyszukaj podmioty według numeru rachunku bankowego NRB dla widoku KendoGrid
        /// Search for entities by NRB bank account number for the KendoGrid view
        /// </summary>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Lista znalezionych podmiotów dla widoku KendoGrid
        /// List of entities found for the KendoGrid view
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/FindByBankAccountKendoGird/{bankAccount}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("FindByBankAccountKendoGird/{bankAccount}")]
        public async Task<ActionResult<KendoGrid<List<Entity>>>> GetFindByBankAccountKendoGirdAsync(string bankAccount)
        {
            try
            {
                List<Entity> entityList = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiFindByBankAccountAsync(bankAccount);
                if (null != entityList && entityList.Count > 0)
                {
                    return new KendoGrid<List<Entity>>()
                    {
                        Total = entityList.Count,
                        Data = entityList
                    };
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipAsync(string nip, string bankAccount)
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("CheckBankAccountByNip/{nip}/{bankAccount}")]
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNipAsync/{nip}/{bankAccount}
        /// Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        /// Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="nip">
        /// Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        /// NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        /// Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNipAsync/{nip}/{bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckBankAccountByNipAsync/{nip}/{bankAccount}")]
        public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipAsync(string nip, string bankAccount)
        {
            try
            {
                EntityCheck entityCheck = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync(nip, bankAccount);
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

        #region public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetCheckBankAccountByNipKendoGirdAsync(string nip, string bankAccount)
        /// <summary>
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNipKendoGird/{nip}/{bankAccount}
        /// [Authorize(AuthenticationSchemes = "Cookies")]
        /// [HttpGet("CheckBankAccountByNipKendoGird/{bankAccount}")]
        /// Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        /// Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="nip">
        /// Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        /// NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        /// Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNipKendoGird/{nip}/{bankAccount}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("CheckBankAccountByNipKendoGird/{nip}/{bankAccount}")]
        public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetCheckBankAccountByNipKendoGirdAsync(string nip, string bankAccount)
        {
            try
            {
                EntityCheck entityCheck = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiCheckBankAccountByNipAsync(nip, bankAccount);
                if (null != entityCheck)
                {
                    return new KendoGrid<List<EntityCheck>>()
                    {
                        Total = 1,
                        Data = new List<EntityCheck> { entityCheck }
                    };
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipFromQueryAsync([FromQuery] string nip, [FromQuery] string bankAccount)
        /// <summary>
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNip?nip={nip}&bankAccount={bankAccount}
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("CheckBankAccountByNip")]
        /// Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        /// Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="nip">
        /// Numer identyfikacji podatkowej NIP jako string [^\d{10}$]
        /// NIP tax identification number as string [^\d{10}$]
        /// </param>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        /// Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByNip?nip={nip}&bankAccount={bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckBankAccountByNip")]
        public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipFromQueryAsync([FromQuery] string nip, [FromQuery] string bankAccount)
        {
            return await GetCheckBankAccountByNipAsync(nip, bankAccount);
        }
        #endregion

        #region public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByNipAsync(string nip, string bankAccount)
        /// <summary>
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("CheckBankAccountByRegon/{regon}/{bankAccount}")]
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegonAsync/{regon}/{bankAccount}
        /// Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        /// Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="regon">
        /// Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string [^\d{9}$|^\d{14}$]
        /// REGON identification number assigned by the National Register of Entities of National Economy as string [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        /// Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegonAsync/{regon}/{bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckBankAccountByRegonAsync/{regon}/{bankAccount}")]
        public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByRegonAsync(string regon, string bankAccount)
        {
            try
            {
                EntityCheck entityCheck = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync(regon, bankAccount);
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

        #region public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetCheckBankAccountByRegonKendoGirdAsync(string regon, string bankAccount)
        /// <summary>
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegonKendoGird/{regon}/{bankAccount}
        /// [Authorize(AuthenticationSchemes = "Cookies")]
        /// [HttpGet("CheckBankAccountByRegonKendoGird/{bankAccount}")]
        /// Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        /// Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="regon">
        /// Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string [^\d{9}$|^\d{14}$]
        /// REGON identification number assigned by the National Register of Entities of National Economy as string [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        /// Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegonKendoGird/{regon}/{bankAccount}
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet("CheckBankAccountByRegonKendoGird/{regon}/{bankAccount}")]
        public async Task<ActionResult<KendoGrid<List<EntityCheck>>>> GetCheckBankAccountByRegonKendoGirdAsync(string regon, string bankAccount)
        {
            try
            {
                EntityCheck entityCheck = await ApiWykazuPodatnikowVatData.ApiWykazuPodatnikowVatData.ApiCheckBankAccountByRegonAsync(regon, bankAccount);
                if (null != entityCheck)
                {
                    return new KendoGrid<List<EntityCheck>>()
                    {
                        Total = 1,
                        Data = new List<EntityCheck> { entityCheck }
                    };
                }
            }
            catch (Exception e)
            {
                await Task.Run(() => log4net.Error(string.Format("{0}, {1}.", e.Message, e.StackTrace), e));
            }
            return NotFound();
        }
        #endregion

        #region public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByRegonFromQueryAsync([FromQuery] string regon, [FromQuery] string bankAccount)
        /// <summary>
        /// GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegon?regon={regon}&bankAccount={bankAccount}
        /// [Authorize(AuthenticationSchemes = "Bearer")]
        /// [HttpGet("CheckBankAccountByRegon")]
        /// Sprawdź, czy dany rachunek jest przypisany do podmiotu według numeru NIP i numeru rachunku bankowego NRB
        /// Check if a given account is assigned to the entity according to the NIP number and NRB bank account number
        /// </summary>
        /// <param name="regon">
        /// Numer identyfikacyjny REGON przypisany przez Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej jako string [^\d{9}$|^\d{14}$]
        /// REGON identification number assigned by the National Register of Entities of National Economy as string [^\d{9}$|^\d{14}$]
        /// </param>
        /// <param name="bankAccount">
        /// Numer rachunku bankowego (26 znaków) w formacie NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// Bank account number (26 characters) in the format NRB (kkAAAAAAAABBBBBBBBBBBBBBBB)
        /// </param>
        /// <returns>
        /// Odpowiedź, czy dany rachunek jest przypisany do podmiotu jako EntityCheck
        /// Reply whether the account is assigned to the subject as EntityCheck
        /// </returns>
        // GET: api/SerwisRzeczypospolitejPolskiej/MinisterstwoFinansow/KrajowaAdministracjaSkarbowa/WykazPodatnikowVatApi/CheckBankAccountByRegon?regon={regon}&bankAccount={bankAccount}
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("CheckBankAccountByRegon")]
        public async Task<ActionResult<EntityCheck>> GetCheckBankAccountByRegonFromQueryAsync([FromQuery] string regon, [FromQuery] string bankAccount)
        {
            return await GetCheckBankAccountByRegonAsync(regon, bankAccount);
        }
        #endregion
    }
    #endregion
}