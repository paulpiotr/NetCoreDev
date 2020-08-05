﻿using System;
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
        private static readonly log4net.ILog _log4net = Log4netLogger.Log4netLogger.GetLog4netInstance(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AdvertisingCampaignController(AdvertisingCampaignContext context)
        {
            _context = context;
        }
        // GET: AdvertisingCampaign
        public IActionResult Index()
        {
            try
            {
                return View(AdvertisingCampaign.AdvertisingCampaign.Index());
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return RedirectToAction("Index", "Error", new { Exception = e });
            }
        }
        // GET: AdvertisingCampaign/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                AdvertisingCampaign.Models.AdvertisingCampaign advertisingCampaign = await AdvertisingCampaign.AdvertisingCampaign.FindAsync(id);
                if (advertisingCampaign == null)
                {
                    return RedirectToAction("Index", "Error");
                }
                return View(advertisingCampaign);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return RedirectToAction("Index", "Error", new { Exception = e });
            }
        }
        // GET: AdvertisingCampaign/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return RedirectToAction("Index", "Error", new { Exception = e });
            }
        }
        // POST: AdvertisingCampaign/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,PricePerClick,NumberOfClicks")] AdvertisingCampaign.Models.AdvertisingCampaign advertisingCampaign)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    advertisingCampaign = await AdvertisingCampaign.AdvertisingCampaign.CreateAsync(advertisingCampaign);
                    if (null != advertisingCampaign)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("Index", "Error");
                    }
                }
                return View(advertisingCampaign);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return RedirectToAction("Index", "Error", new { Exception = e });
            }
        }
        /// <summary>
        /// GET: AdvertisingCampaign/Edit/5 Advertising Campaign Edit
        /// </summary>
        /// <param name="id">Advertising Campaign Id</param>
        /// <returns></returns>
        // GET: AdvertisingCampaign/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                AdvertisingCampaign.Models.AdvertisingCampaign advertisingCampaign = await AdvertisingCampaign.AdvertisingCampaign.FindAsync(id);
                if (advertisingCampaign == null)
                {
                    return NotFound();
                }
                return View(advertisingCampaign);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return RedirectToAction("Index", "Error", new { Exception = e });
            }
        }
        /// <summary>
        /// POST: AdvertisingCampaign/Edit/5 Advertising Campaign Edit
        /// </summary>
        /// <param name="id">Advertising Campaig Id</param>
        /// <param name="advertisingCampaign">Advertising Campaig Model</param>
        /// <returns></returns>
        // POST: AdvertisingCampaign/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PricePerClick,NumberOfClicks")] AdvertisingCampaign.Models.AdvertisingCampaign advertisingCampaign)
        {
            try
            {
                if (id != advertisingCampaign.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    advertisingCampaign = await AdvertisingCampaign.AdvertisingCampaign.UpdateAsync(id, advertisingCampaign);
                    if (null != advertisingCampaign)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("Index", "Error");
                    }
                }
                return View(advertisingCampaign);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return RedirectToAction("Index", "Error", new { Exception = e });
            }
        }
        /// <summary>
        /// GET: AdvertisingCampaign/Delete/5 Delete Advertising Campaign
        /// </summary>
        /// <param name="id">Advertising Campaign Id</param>
        /// <returns></returns>
        // GET: AdvertisingCampaign/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                AdvertisingCampaign.Models.AdvertisingCampaign advertisingCampaign = await AdvertisingCampaign.AdvertisingCampaign.FindAsync(id);
                if (advertisingCampaign == null)
                {
                    return NotFound();
                }
                return View(advertisingCampaign);
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return RedirectToAction("Index", "Error", new { Exception = e });
            }
        }
        /// <summary>
        /// POST: AdvertisingCampaign/Delete/5 Advertising Campaign Delete
        /// </summary>
        /// <param name="id">Advertising Campaign Id</param>
        /// <returns></returns>
        // POST: AdvertisingCampaign/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                AdvertisingCampaign.Models.AdvertisingCampaign advertisingCampaign = await AdvertisingCampaign.AdvertisingCampaign.FindAsync(id);
                if (null != advertisingCampaign)
                {
                    advertisingCampaign = await AdvertisingCampaign.AdvertisingCampaign.DeleteAsync(id, advertisingCampaign);
                    if (null != advertisingCampaign)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction("Index", "Error");
            }
            catch (Exception e)
            {
                _log4net.Error(string.Format("{0}, {1}", e.Message, e.StackTrace), e);
                return RedirectToAction("Index", "Error", new { Exception = e });
            }
        }
    }
}
