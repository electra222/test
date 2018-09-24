using System;
using System.Collections.Generic;
// contains Include()
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSeller.Models;
using AutoSeller.ViewModel;
using System.Web.Script.Serialization;

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

        [Authorize(Roles = RoleName.CanManageAutomobiles)]
        public ActionResult New()
        {
            var countries = _context.Countries.ToList();
            var autoMakes = _context.AutomobileMakes.ToList();
            var autoModels = _context.AutomobileModels.ToList();
            var details = _context.Details.ToList();
            var engines = _context.Engines.ToList();

            var viewModel = new AutomobileFormViewModel()
            {
                Countries = countries,
                AutomobileMakes = autoMakes,
                AutomobileModels = autoModels,
                Details = details,
                Engines = engines,
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
                    Engines = _context.Engines.ToList(),
                    AutomobileDetails = automobileDetails
                };

                return View("AutomobileForm", viewModel);
            }

            // create a variable 'automobileId' which will be passed as parameter to the 'UploadFiles' view
            int automobileId;

            // check if we create new automobile or edit existing one
            if (automobile.Id == 0)
            {
                automobile.DateImported = DateTime.Now;
                automobile.StatusId = 1;
                _context.Automobiles.Add(automobile);
                _context.SaveChanges();

                List<Detail> details = _context.Details.ToList();
                //  List<Automobile> automobiles = _context.Automobiles.ToList();
                var automobileLastId = _context.Automobiles.ToList().Last().Id;
               // var automobileLastId1 = _context.Automobiles.Max()
                // automobileId = automobiles.Last().Id;
                automobileId = automobileLastId;


                if (details.Any())
                {
                    for(int i = 0; i < details.Count(); i++)
                    {
                        automobileDetails[i].DetailId = details[i].Id;
                        // automobileDetails[i].AutomobileId = automobiles.Last().Id;
                        automobileDetails[i].AutomobileId = automobileLastId;
                        _context.AutomobileDetails.Add(automobileDetails[i]);
                    }

                }
            }
            else
            {
                automobileId = automobile.Id;

                var automobileInDb = _context.Automobiles.Single(c => c.Id == automobile.Id);
                automobileInDb.ReleaseDate = automobile.ReleaseDate;
                automobileInDb.CountryId = automobile.CountryId;
                automobileInDb.AutomobileMakeId = automobile.AutomobileMakeId;
                automobileInDb.AutomobileModelId = automobile.AutomobileModelId;
                automobileInDb.EngineId = automobile.EngineId;
                automobileInDb.Color = automobile.Color;
                automobileInDb.Transmission = automobile.Transmission;
                automobileInDb.Miles = automobile.Miles;

                if (automobileDetails.Any())
                {                
                    //we take all automobileDetails correcponding to the current automobile, then set their Vaues  
                    //to the new Values coming from the view in the list automobileDetails
                    IEnumerable<AutomobileDetail> automobileDetailsInDb = _context.AutomobileDetails.Where(c => c.AutomobileId == automobile.Id);
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
                      //  int dif = detailsInDb.Count() - automobileDetailsNew.Count();
                        int automobileDetailsNewCount = automobileDetailsNew.Count();
                        int detailCount = detailsInDb.Count();

                        for (int i = 0; i < automobileDetailsNewCount; i++)
                        {
                            automobileDetailsNew[i].DetailId = detailsInDb[detailCount - automobileDetailsNewCount + i].Id;
                            _context.AutomobileDetails.Add(automobileDetailsNew[i]);
                        }

                    }

                }

            }
            _context.SaveChanges();

            //the next lines prepare image model which will be used to call the Uploadfiles view
            IEnumerable<FileModel> filesInDb = _context.FileModels.ToList().Where(c => c.AutomobileId == automobileId);
            
            var imageModel = new ImagesFormViewModel()
            {
                AutomobileId = automobileId,
                FileModels = filesInDb
            };

            // return RedirectToAction("Index", "Automobiles");
            // return RedirectToAction("UploadFiles", "FileModels", automobileId);
            return View("~/Views/FileModels/UploadFiles.cshtml", imageModel);

        }

        // GET: Automobiles
        public ActionResult Index(Automobile Automobile, int? year)
        {            
                //get all automobiles in Active status from the DB
                var automobiles = _context.Automobiles.Where(c => c.StatusId == 1).Include(c => c.Country).Include(c => c.AutomobileMake).Include(c => c.AutomobileModel).Include(c => c.Engine).ToList();

                var images = _context.FileModels.ToList();

                if (Automobile.AutomobileMakeId != 0)
                {
                    automobiles = automobiles.Where(c => c.AutomobileMakeId == Automobile.AutomobileMakeId).ToList();
                }

                if (Automobile.AutomobileModelId != 0)
                {
                    automobiles = automobiles.Where(c => c.AutomobileModelId == Automobile.AutomobileModelId).ToList();
                }

                if (year != 0)
                {
                    automobiles = automobiles.Where(c => c.ReleaseDate.ToString().Contains(year.ToString())).ToList();
                }

            var viewModel = new AutomobileFilterViewModel()
                {
                    AutomobileList = automobiles,
                    Automobile = new Automobile(),
                    AutomobileMakeList = _context.AutomobileMakes.ToList(),
                    AutomobileModelList = _context.AutomobileModels.ToList(),
                    FileModel = images
                };        
         
                return View(viewModel);

        }

        [AllowAnonymous]
        public ActionResult Home(Automobile Automobile, int? year)
        {
            var automobiles = _context.Automobiles.Where(c => c.StatusId == 1).Include(c => c.Country).Include(c => c.AutomobileMake).Include(c => c.AutomobileModel).Include(c => c.Engine).ToList();

            var images = _context.FileModels.ToList();

            if (Automobile.AutomobileMakeId != 0)
            {
                automobiles = automobiles.Where(c => c.AutomobileMakeId == Automobile.AutomobileMakeId).ToList();
            }

            if (Automobile.AutomobileModelId != 0)
            {
                automobiles = automobiles.Where(c => c.AutomobileModelId == Automobile.AutomobileModelId).ToList();
            }

            if (year != null)
            {
                automobiles = automobiles.Where(c => c.ReleaseDate.ToString().Contains(year.ToString())).ToList();
            }

            var viewModel = new AutomobileFilterViewModel()
            {
                AutomobileList = automobiles,
                Automobile = new Automobile(),
                AutomobileMakeList = _context.AutomobileMakes.ToList(),
                AutomobileModelList = _context.AutomobileModels.ToList(),
                FileModel = images
            };

            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult GetModel(String makeId)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            String json = null;
            int makeIdInt;
            if (Int32.TryParse(makeId, out makeIdInt))
            {
                var modelInDb = _context.AutomobileModels.Where(c => c.AutomobileMakeId == makeIdInt).ToList();                
                json = jsonSerialiser.Serialize(modelInDb);
            }
            else
            {
                json = jsonSerialiser.Serialize(new List<String>());
            }
            
            return Content(json, "application/json");
        }


        [Authorize(Roles = RoleName.CanManageAutomobiles)]
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
                Engines = _context.Engines.ToList(),
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var automobileInDb = _context.Automobiles.SingleOrDefault(c => c.Id == id);
            //Status 2 is Deleted. If deleted => the automobile won't be visible in the list with automobiles.
            automobileInDb.StatusId = 2;

            if (automobileInDb == null)
                return HttpNotFound();

            _context.SaveChanges();

            return RedirectToAction("Index", "Automobiles");
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
                new Automobile {Id = 1, Color = "Audi" },
                new Automobile {Id = 2, Color = "Aston Martin" }

            };

            return automobiles;
        }
    }
}