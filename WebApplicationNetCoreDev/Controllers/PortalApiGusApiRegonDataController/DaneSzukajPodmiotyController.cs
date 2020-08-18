using Microsoft.AspNetCore.Mvc;
using PortalApiGusApiRegonData.Data;
using System;

namespace WebApplicationNetCoreDev.Controllers.PortalApiGusApiRegonDataControler
{
    public class DaneSzukajPodmiotyController : Controller
    {
        private readonly PortalApiGusApiRegonDataDbContext _context;

        public DaneSzukajPodmiotyController(PortalApiGusApiRegonDataDbContext context)
        {
            _context = context;
        }

        // GET: DaneSzukajPodmioty
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
    }
}
