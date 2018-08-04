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
            var autoMakes = _context.AutomobileMakes.ToList();
            var autoModels = _context.AutomobileModels.ToList();
            var details = _context.Details.ToList();

            var viewModel = new AutomobileFormViewModel()
            {
                Countries = countries,
                AutomobileMakes = autoMakes,
                AutomobileModels = autoModels,
                Details = details,
                AutomobileDetails = new List<AutomobileDetail>()
            };

            foreach (var detail in details)
            {
                var automobileDetail = new AutomobileDetail();
                viewModel.AutomobileDetails.Add(automobileDetail);
            }               

            return View("AutomobileForm", viewModel);
        }

        //If the ID of the car is empty => add it to the db, else update the existing record
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Automobile automobile, List<AutomobileDetail> automobileDetails)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AutomobileFormViewModel(automobile)
                {
                    Countries = _context.Countries.ToList(),
                    AutomobileMakes = _context.AutomobileMakes.ToList(),
                    AutomobileModels = _context.AutomobileModels.ToList(),
                    Details = _context.Details.ToList(),
                    AutomobileDetails = automobileDetails
                };

                return View("AutomobileForm", viewModel);
            }

            if (automobile.Id == 0)
            {
                automobile.DateImported = DateTime.Now;
                _context.Automobiles.Add(automobile);
                _context.SaveChanges();

                List<Detail> details = _context.Details.ToList();
                List<Automobile> automobiles = _context.Automobiles.ToList();


                if (details.Any())
                {
                    for(int i = 0; i < details.Count(); i++)
                    {
                        automobileDetails[i].DetailId = details[i].Id;
                        automobileDetails[i].AutomobileId = automobiles.Last().Id;
                        _context.AutomobileDetails.Add(automobileDetails[i]);
                    }

                }
            }
            else
            {
                var automobileInDb = _context.Automobiles.Single(c => c.Id == automobile.Id);
                automobileInDb.Name = automobile.Name;
                automobileInDb.ReleaseDate = automobile.ReleaseDate;
                automobileInDb.CountryId = automobile.CountryId;
                automobileInDb.NuberInStock = automobile.NuberInStock;
                automobileInDb.AutomobileMakeId = automobile.AutomobileMakeId;
                automobileInDb.AutomobileModelId = automobile.AutomobileModelId;
                automobileInDb.Engine = automobile.Engine;
                automobileInDb.Color = automobile.Color;
                automobileInDb.Transmission = automobile.Transmission;
                automobileInDb.Miles = automobile.Miles;

                if (automobileDetails.Any())
                {                
                    //we take all automobileDetails correcponding to the current automobile, then set their Vaues  
                    //to the new Values coming from the view in the list automobileDetails
                    IEnumerable<AutomobileDetail> automobileDetailsInDb = _context.AutomobileDetails.ToList().Where(c => c.AutomobileId == automobile.Id);
                    List<AutomobileDetail> automobileDetailsOld = automobileDetails.FindAll(c => c.AutomobileId != null);
                    int n = 0;

                    foreach (var automobileDetail in automobileDetailsInDb)
                    {
                        automobileDetail.DetailValue = automobileDetailsOld[n].DetailValue;
                        n++;
                    }

                    if(automobileDetails.Any(c => c.AutomobileId == null))
                    {                    
                        //there are new automobileDetails wich should be created for first time
                        //we set their AutomobileId to the Id of the returned from the view automobile
                        List<AutomobileDetail> automobileDetailsNew = automobileDetails.FindAll(c => c.AutomobileId == null);
                        List<Detail> detailsInDb = _context.Details.ToList();

                        foreach(var automobileDetail in automobileDetailsNew)
                        {
                            automobileDetail.AutomobileId = automobile.Id;
                        }

                        // we find the diference between all details and these which should be added in automobileDetails table
                        // then in a loop set their detailsId and finally Add() them to the table in the DB
                        int dif = detailsInDb.Count() - automobileDetailsNew.Count();
                        int detailCount = detailsInDb.Count();

                        for (int i = 0; i < dif; i++)
                        {
                            automobileDetailsNew[i].DetailId = detailsInDb[detailCount - dif + i].Id;
                            _context.AutomobileDetails.Add(automobileDetailsNew[i]);
                        }

                    }

                }

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Automobiles");
        }

        // GET: Automobiles
        public ActionResult Index()
        {
            var automobile = _context.Automobiles.Include(c => c.Country).Include(c => c.AutomobileMake).Include(c => c.AutomobileModel).ToList();

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

            IEnumerable<AutomobileDetail> automobileDetailsInDb = _context.AutomobileDetails.ToList().Where(c => c.AutomobileId == id);
            var detailsInDb = _context.Details.ToList();
            List<AutomobileDetail> automobileDetails = new List<AutomobileDetail>();

            foreach (var automobileDetail in automobileDetailsInDb)
            {            
                automobileDetails.Add(automobileDetail);                
            }

            var viewModel = new AutomobileFormViewModel(automobile)
            {
                Countries = _context.Countries.ToList(),
                AutomobileMakes = _context.AutomobileMakes.ToList(),
                AutomobileModels = _context.AutomobileModels.ToList(),
                Details = detailsInDb,
                AutomobileDetails = automobileDetails
            };

            if(detailsInDb.Count() > automobileDetailsInDb.Count())
            {
                int dif = detailsInDb.Count() - automobileDetailsInDb.Count();
                int i = 1;

                while (i <= dif)
                {
                    viewModel.AutomobileDetails.Add(new AutomobileDetail());
                    i++;
                }
            }

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