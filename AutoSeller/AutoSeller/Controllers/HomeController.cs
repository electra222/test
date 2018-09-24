using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSeller.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AutoSeller.ViewModel;
using static AutoSeller.ViewModel.HomeWelcomeFormViewModel;
// contains Include()
using System.Data.Entity;
using System.Web.Script.Serialization;
using System.IO;



namespace AutoSeller.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       /* public ActionResult Index()
        {
            return View();
        }*/

        [AllowAnonymous]
        public ActionResult About()
        {
            AutoSeller.ViewModel.AboutViewForm.AboutText = _context.AspNetParameters.SingleOrDefault(c => c.Id == 2) != null ? _context.AspNetParameters.SingleOrDefault(c => c.Id == 2).Name : "About";

            if (User.IsInRole(RoleName.CanManageAutomobiles))
                return View("AboutAdmin");
            else
                return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Index(int? MakeId, int? ModelId, int? year)
        {
            var automobiles = _context.Automobiles.Where(c => c.StatusId == 1).Include(c => c.Country).Include(c => c.AutomobileMake).Include(c => c.AutomobileModel).Include(c => c.Engine).ToList();

            var images = _context.FileModels.ToList();
            List<AutomobileModel> modelByMake = new List<AutomobileModel>();

            if (MakeId != null)
            {
                automobiles = automobiles.Where(c => c.AutomobileMakeId == MakeId).ToList();
                modelByMake = _context.AutomobileModels.Where(c => c.AutomobileMakeId == MakeId).ToList();
            }

            if (ModelId != null)
            {
                automobiles = automobiles.Where(c => c.AutomobileModelId == ModelId).ToList();
            }

            if (year != null)
            {
                automobiles = automobiles.Where(c => c.ReleaseDate.ToString().Contains(year.ToString())).ToList();
            }

            List<IEnumerable<Automobile>> AutomobileLists = new List<IEnumerable<Automobile>>();
            int index = 0;
            var size = automobiles.Count();

            while (index < size)
            {
                int count = size - index >= 4 ? 4 : (size - index); 
                IEnumerable<Automobile> automobiles2 = automobiles.GetRange(index, count);
                AutomobileLists.Add(automobiles2);
                index = index + count;                
            }

            var viewModel = new HomeFormViewModel()
            {
                HomeWelcomeFormViewModel = new HomeWelcomeFormViewModel(),
                AutomobileList = AutomobileLists,
                MakeId = MakeId,
                ModelId = ModelId,
                AutomobileMakeList = _context.AutomobileMakes.ToList(),
                AutomobileModelList = modelByMake,
                FileModel = images
            };

            WelcomeText = _context.AspNetParameters.SingleOrDefault(c => c.Id == 1).Name;

            if (User.IsInRole(RoleName.CanManageAutomobiles))
                return View("IndexAdmin", viewModel);
            else
                return View("Index", viewModel);
        }

        [AllowAnonymous]
        public ActionResult ViewAutomobileDetails(int id)
        {
            var automobileInDB = _context.Automobiles.SingleOrDefault(c => c.Id == id);
            if(automobileInDB.Counter != null && User.IsInRole(RoleName.CanManageAutomobiles))
            {
                automobileInDB.Counter = automobileInDB.Counter.Value + 1;
            }
            else if (User.IsInRole(RoleName.CanManageAutomobiles))
            {
                automobileInDB.Counter = 1;
            }

            _context.SaveChanges();


            var automobiles = _context.Automobiles.Where(c => c.Id == id).Include(c => c.Country).Include(c => c.AutomobileMake).Include(c => c.AutomobileModel).Include(c => c.Engine);
            var automobile = automobiles.SingleOrDefault(c => c.Id == id);
            //increasing the counter/number of views of the current automobile

            if (automobile == null)
                return HttpNotFound();

            IEnumerable<AutomobileDetail> automobileDetailsInDb = _context.AutomobileDetails.ToList().Where(c => c.AutomobileId == id);
            var detailsInDb = _context.Details.ToList();
            List<AutomobileDetail> automobileDetails = new List<AutomobileDetail>();

            foreach (var automobileDetail in automobileDetailsInDb)
            {
                automobileDetails.Add(automobileDetail);
            }

            var images = _context.FileModels.Where(m => m.AutomobileId == id).ToList();

            var viewModel = new RandomAutomobileViewModel()
            {
                Automobile = automobile,
                FileModel = images,
                Details = detailsInDb,              
                AutomobileDetails = automobileDetails
            };

            if (detailsInDb.Count() > automobileDetailsInDb.Count())
            {
                int dif = detailsInDb.Count() - automobileDetailsInDb.Count();
                int i = 1;

                while (i <= dif)
                {
                    viewModel.AutomobileDetails.Add(new AutomobileDetail());
                    i++;
                }
            }

            return View("~/Views/Automobiles/ViewAutomobile.cshtml", viewModel);
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
        public ActionResult EditWelcomeForm()
        {
            var parameterInDb = _context.AspNetParameters.SingleOrDefault(c => c.Id == 1);
            if(parameterInDb != null)
            {
                AutoSeller.ViewModel.HomeWelcomeFormViewModel.WelcomeText = parameterInDb.Name;
            }
            else
            {
                AutoSeller.ViewModel.HomeWelcomeFormViewModel.WelcomeText = "Welcome!";
            }

            var text = AutoSeller.ViewModel.HomeWelcomeFormViewModel.WelcomeText;
            var welcomeForm = new HomeWelcomeFormViewModel
            {
                DynamicText = text
            };            

            return View(welcomeForm);
        }

        // this action saves the changes made over the welcome text
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageAutomobiles)]
        public ActionResult EditWelcomeForm(string DynamicText)
        {
            if(DynamicText != null)
            {
                var parameterInDb = _context.AspNetParameters.SingleOrDefault(c => c.Id == 1);
                if (parameterInDb == null)
                {
                    parameterInDb = new AspNetParameter();
                    parameterInDb.Name = DynamicText;
                    _context.AspNetParameters.Add(parameterInDb);
                }
                else
                {
                    parameterInDb.Name = DynamicText;
                }
                _context.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            //Ensure model state is valid (a file is chosen - validation appears if upload is clicked without file)
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                                 Path.GetExtension(file.FileName).ToLower() == ".png" ||
                                 Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                                 Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Content/Images/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        AutoSeller.ViewModel.HomeWelcomeFormViewModel.ImagePath = "~/Content/Images/" + InputFileName;
                        ViewBag.UploadStatus = "Successfully uploaded image.";
                    }
                }
            }
            //redirect back to EditWelcome form so that to be able to edit the welcome text before closing the edit form
            return View("EditWelcomeForm");

        }

        [Authorize(Roles = RoleName.CanManageAutomobiles)]
        public ActionResult EditAbout()
        {
            var parameterInDb = _context.AspNetParameters.SingleOrDefault(c => c.Id == 2);
            if (parameterInDb != null)
            {
                AutoSeller.ViewModel.AboutViewForm.AboutText = parameterInDb.Name;
            }
            else
            {
                AutoSeller.ViewModel.AboutViewForm.AboutText = "No information!";
            }

            var text = AutoSeller.ViewModel.AboutViewForm.AboutText;
            var aboutForm = new AboutViewForm
            {
                DynamicText = text
            };

            return View(aboutForm);
        }

        // this action saves the changes made over the about text
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageAutomobiles)]
        public ActionResult EditAbout(string DynamicText)
        {
            if (DynamicText != null)
            {
                var parameterInDb = _context.AspNetParameters.SingleOrDefault(c => c.Id == 2);
                if (parameterInDb == null)
                {
                    parameterInDb = new AspNetParameter();
                    parameterInDb.Name = DynamicText;
                    _context.AspNetParameters.Add(parameterInDb);
                }
                else
                {
                    parameterInDb.Name = DynamicText;
                }
                _context.SaveChanges();
            }

            return RedirectToAction("About");
        }
    }
}