using System;
using System.Collections.Generic;
// contains Include()
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSeller.Models;
using AutoSeller.ViewModel;

namespace AutoSeller.Controllers
{
    public class AutomobilesController : Controller
    {
        private ApplicationDbContext _context;

        public AutomobilesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var countries = _context.Countries.ToList();
            var viewModel = new AutomobileFormViewModel
            {
                Countries = countries
            };

            return View("AutomobileForm", viewModel);
        }

        //If the ID of the car is empty => add it to the db, else update the existing record
        [HttpPost]
        public ActionResult Save(Automobile automobile)
        {
            if(automobile.Id ==0)
            _context.Automobiles.Add(automobile);
            else
            {
                var automobileInDb = _context.Automobiles.Single(c => c.Id == automobile.Id);
                automobileInDb.Name = automobile.Name;
                automobileInDb.ReleaseDate = automobile.ReleaseDate;
                automobileInDb.CountryId = automobile.CountryId;
                automobileInDb.NuberInStock = automobile.NuberInStock;     
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Automobiles");
        }

        // GET: Automobiles
        public ActionResult Index()
        {
            var automobile = _context.Automobiles.Include(c => c.Country).ToList();

            return View(automobile);
        }

        // GET: Automobiles/Random
        public ActionResult Random()
        {
            var automobile = new Automobile() { Name = "Audi" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }
            };

            var viewModel = new RandomAutomobileViewModel
            {
                Automobile = automobile,
                Customers = customers

            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var automobile = _context.Automobiles.SingleOrDefault(c => c.Id == id);

            if (automobile == null)
                return HttpNotFound();

            var viewModel = new AutomobileFormViewModel
            {
                Automobile = automobile,
                Countries = _context.Countries.ToList()
            };

            return View("AutomobileForm", viewModel);

        }

        public ActionResult Details(int id)
        {
            var automobile = _context.Automobiles.Include(c => c.Country).SingleOrDefault(element => element.Id == id);
            return View(automobile);
        }

        /*  public ActionResult Index(int? pageIndex, string sortBy)
          {
              if (!pageIndex.HasValue)
                  pageIndex = 1;
              if (String.IsNullOrWhiteSpace(sortBy))
                  sortBy = "Name";
              return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
          }

          [Route("automobiles/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
          public ActionResult ByReleaseDate(int year, int month)
          {
              return Content(year + "/" + month);
          }*/

        public IEnumerable<Automobile> GetAutomobiles()
        {
            var automobiles = new List<Automobile>
            {
                new Automobile {Id = 1, Name = "Audi" },
                new Automobile {Id = 2, Name = "Aston Martin" }

            };

            return automobiles;
        }
    }
}