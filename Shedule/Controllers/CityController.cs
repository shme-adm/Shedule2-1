using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shedule.Models;

namespace Shedule.Controllers
{
    public class CityController : Controller
    {
        ShedulerContext db = new ShedulerContext();
        // GET: City
        public ActionResult Cities()
        {
            ViewBag.Message = "Справочник 'Города'";
            ViewBag.Cities = db.Cities;
            return View();
        }

        //[HttpGet]
        public ActionResult Create()
        {
            ViewBag.Message = "Справочник 'Города'";
            //ViewBag.Cities = db.Cities;
            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(Cities city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
            }
            //ViewBag.Cities = db.Cities;
            //return View(city);//поправить вывод после добавления нового элемента
            return RedirectToAction("Index");
        }
    }
}