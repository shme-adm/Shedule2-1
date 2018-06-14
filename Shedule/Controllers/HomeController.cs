using Shedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shedule.Controllers
{
    public class HomeController : Controller
    {
        //ShedulerContext db = new ShedulerContext();

        public ActionResult Index()
        {
            return View("Index");
        }
        
        public ActionResult Shedule()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        public ActionResult Reports()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        public ActionResult Subjects()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        public ActionResult TypeOfClasses()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        public ActionResult Cabinets()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        public ActionResult Groups()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        public ActionResult Offices()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        public ActionResult Users()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        public ActionResult Teachers()
        {
            ViewBag.Message = "Ведутся работы";

            return View();
        }
        
    }
}