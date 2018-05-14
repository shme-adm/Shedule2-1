using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shedule.Models;
using System.Data.Entity;

namespace Shedule.Controllers
{
    public class TypeOfClassesController : Controller
    {
        ShedulerContext db = new ShedulerContext();
        // GET: Subjects
        public ActionResult Index()
        {
            ViewBag.Message = "Справочник 'Типы занятий'";
            ViewBag.TypeOfClasses = db.TypeOfClasses;
            return View();
        }
    }
}