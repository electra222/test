using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AutoSeller.Models;

namespace AutoSeller.Controllers
{
    public class DetailsController : Controller
    {
        private ApplicationDbContext _context;

        public DetailsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Details
        public ActionResult Index()
        {
            var detail = _context.Details.ToList();

            return View(detail);
        }

        public ActionResult New()
        {
            var detail = new Detail();

            return View("DetailForm", detail);
        }

        public ActionResult Edit(int id)
        {
            var detail = _context.Details.SingleOrDefault(c => c.Id == id);

            if (detail == null)
                return HttpNotFound();
            
            return View("DetailForm", detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Detail detail)
        {
            if (!ModelState.IsValid)
            {                
                return View("AutomobileForm", detail);
            }

            if (detail.Id == 0)
            {
                _context.Details.Add(detail);
            }
            else
            {
                var detailInDb = _context.Details.Single(c => c.Id == detail.Id);
                detailInDb.Name = detail.Name;                
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Details");
        }
    }
}