using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shedule.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
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
        public ActionResult Shedule()
        {
            ViewBag.Message = "Здесь будет расписание";

            return View();
        }
        public ActionResult Reports()
        {
            ViewBag.Message = "Здесь будут отчеты";

            return View();
        }
        public ActionResult Subjects()
        {
            ViewBag.Message = "Здесь будет справочник по предметам";

            return View();
        }
        public ActionResult TypeOfClasses()
        {
            ViewBag.Message = "Здесь будет справочник по типам занятий";

            return View();
        }
        public ActionResult Cabinets()
        {
            ViewBag.Message = "Здесь будет спрвочник по кабинетам";

            return View();
        }
        public ActionResult Groups()
        {
            ViewBag.Message = "Здесь будет справочник по группам";

            return View();
        }
        public ActionResult Offices()
        {
            ViewBag.Message = "Здесь будет справочник по отделениям";

            return View();
        }
        public ActionResult Users()
        {
            ViewBag.Message = "Здесь будет справочник по пользователям";

            return View();
        }
        public ActionResult Teachers()
        {
            ViewBag.Message = "Здесь будет справочник по преподавателям";

            return View();
        }
    }
}