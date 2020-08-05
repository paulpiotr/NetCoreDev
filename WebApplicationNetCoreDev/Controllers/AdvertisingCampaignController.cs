using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvertisingCampaign.Models;

namespace WebApplicationNetCoreDev.Controllers
{
    public class AdvertisingCampaignController : Controller
    {
        private readonly AdvertisingCampaignContext _context;

        public AdvertisingCampaignController(AdvertisingCampaignContext context)
        {
            _context = context;
        }

        // GET: AdvertisingCampaign
        public IActionResult Index()
        {
            //AdvertisingCampaign.AdvertisingCampaign.Index();
            //return View(await _context.AdvertisingCampaign.ToListAsync());
            return View(AdvertisingCampaign.AdvertisingCampaign.Index());
        }

        // GET: AdvertisingCampaign/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisingCampaign = await _context.AdvertisingCampaign
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisingCampaign == null)
            {
                return NotFound();
            }

            return View(advertisingCampaign);
        }

        // GET: AdvertisingCampaign/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdvertisingCampaign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,PricePerClick,NumberOfClicks,TotalCost,Created")] AdvertisingCampaign.Models.AdvertisingCampaign advertisingCampaign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertisingCampaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advertisingCampaign);
        }

        // GET: AdvertisingCampaign/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisingCampaign = await _context.AdvertisingCampaign.FindAsync(id);
            if (advertisingCampaign == null)
            {
                return NotFound();
            }
            return View(advertisingCampaign);
        }

        // POST: AdvertisingCampaign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PricePerClick,NumberOfClicks,TotalCost,Created")] AdvertisingCampaign.Models.AdvertisingCampaign advertisingCampaign)
        {
            if (id != advertisingCampaign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertisingCampaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisingCampaignExists(advertisingCampaign.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(advertisingCampaign);
        }

        // GET: AdvertisingCampaign/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisingCampaign = await _context.AdvertisingCampaign
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertisingCampaign == null)
            {
                return NotFound();
            }

            return View(advertisingCampaign);
        }

        // POST: AdvertisingCampaign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisingCampaign = await _context.AdvertisingCampaign.FindAsync(id);
            _context.AdvertisingCampaign.Remove(advertisingCampaign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertisingCampaignExists(int id)
        {
            return _context.AdvertisingCampaign.Any(e => e.Id == id);
        }
    }
}
