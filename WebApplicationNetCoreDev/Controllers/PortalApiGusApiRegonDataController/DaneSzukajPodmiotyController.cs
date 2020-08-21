using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalApiGusApiRegonData.Data;
using System;

namespace WebApplicationNetCoreDev.Controllers.PortalApiGusApiRegonDataControler
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("PortalApiGus/[controller]/[action]")]
    public class DaneSzukajPodmiotyController : Controller
    {
        private readonly PortalApiGusApiRegonDataDbContext _context;

        public DaneSzukajPodmiotyController(PortalApiGusApiRegonDataDbContext context)
        {
            _context = context;
        }

        // GET: DaneSzukajPodmioty
        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "User")]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        // GET: DaneSzukajPodmioty/Settings
        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "User")]
        public IActionResult Settings()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        // GET: DaneSzukajPodmioty/Route
        [Authorize(AuthenticationSchemes = "Cookies", Policy = null, Roles = "User")]
        public IActionResult Route()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
