using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using AutoSeller.Models;
using AutoSeller.ViewModel;


namespace AutoSeller.Controllers
{
    public class FileModelsController : Controller
    {
        private ApplicationDbContext _context;

        public FileModelsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: FileModels
        public ActionResult UploadFiles(ImagesFormViewModel imageModel)
        {
            return View(imageModel);
        }

        [HttpPost]
        public ActionResult UploadFiles(int automobileId, HttpPostedFileBase[] files)
        {
            bool success = false;

            //Ensure model state is valid
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null && automobileId != 0)
                    {
                        //variables used by returning of message for pass/fail upload
                        int counter = files.Count();

                        if (Path.GetExtension(file.FileName).ToLower() == ".jpg" ||
                             Path.GetExtension(file.FileName).ToLower() == ".png" ||
                             Path.GetExtension(file.FileName).ToLower() == ".gif" ||
                             Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                        {
                            var InputFileName = Path.GetFileName(file.FileName);
                            var ServerSavePath = Path.Combine(Server.MapPath("~/Content/Images/") + InputFileName);
                            //Save file to server folder  
                            file.SaveAs(ServerSavePath);

                            //add the images (their path and automobileId relation) to the DB
                            var image = new FileModel()
                            {
                                ImagePath = "~/Content/Images/" + InputFileName,
                                AutomobileId = automobileId

                            };

                            _context.FileModels.Add(image);
                        }
                        else
                        {
                            counter--;
                        }

                        //assigning file uploaded status to ViewBag for showing message to user.
                        if(counter != files.Count())
                        {
                            ViewBag.UploadStatus = "There are files which are not images." + System.Environment.NewLine
                                + counter + " files uploaded successfully.";
                            
                        }
                        else
                        {
                            success = true;
                            ViewBag.UploadStatus = counter + " files uploaded successfully.";
                        }
                    }
                }
                _context.SaveChanges();                
            }

            //return to the UploadFiles with information for the pass/fail upload
            IEnumerable<FileModel> filesInDb = _context.FileModels.ToList().Where(c => c.AutomobileId == automobileId);

            var imageModel = new ImagesFormViewModel()
            {
                AutomobileId = automobileId,
                FileModels = filesInDb,
                Success = success
            };

            return View(imageModel);
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            var imageModel = new FileModel();

            imageModel = _context.FileModels.Where(c => c.Id == id).FirstOrDefault();

            return View(imageModel);
        }
    }
}