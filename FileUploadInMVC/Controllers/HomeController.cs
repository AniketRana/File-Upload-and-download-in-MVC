using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FileUploadInMVC.Models;

namespace FileUploadInMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee emp)  //HttpPostedFileBase File
        {
            if (emp.File == null)
            {
                return View();
            }
            string path = Server.MapPath("~/App_Data/File");
            string Filename = Path.GetFileName(emp.File.FileName);
            string FullPath = Path.Combine(path, Filename);
            emp.File.SaveAs(FullPath);
            return View();
        }

        public FileResult Download()
        {
            string path = Server.MapPath("~/App_Data/File");
            string Filename = Path.GetFileName("FinideasLogo.png");
            string FullPath = Path.Combine(path, Filename);
            return File(FullPath,"Image/png", "FinideasLogo.png");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}