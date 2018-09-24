using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// contains Include()
using System.Data.Entity;
using AutoSeller.Models;


namespace AutoSeller.Controllers
{
    public class AutomobileDetailsController : Controller
    {
        private ApplicationDbContext _context;

        public AutomobileDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: AutomobileDetails
        [Authorize(Roles = RoleName.CanManageAutomobiles)]
        public ActionResult Index()
        {
            var detail = _context.AutomobileDetails.Include(c => c.Automobile).Include(c => c.Detail).ToList();

            return View(detail);
        }


    }
}