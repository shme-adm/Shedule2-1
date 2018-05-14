using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shedule.Models;
using System.Data.Entity;

namespace Shedule.Controllers
{
    public class SubjectsController : Controller
    {
        ShedulerContext db = new ShedulerContext();
        // GET: Subjects
        public ActionResult Subjects()
        {
            ViewBag.Message = "Справочник 'Предметы'";
            ViewBag.Subjects = db.Subjects;
            return View();
        }
    }
}