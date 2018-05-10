using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shedule.Models;
using System.Data.Entity;

namespace Shedule.Controllers
{
    public class DirectoriesController : Controller
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
           // return View("Cities");//поправить вывод после добавления нового элемента
            return RedirectToAction("Cities");
        }

        public ActionResult Delete(int id)
        {
            var city = db.Cities.Find(id);
            if (city != null)
            {
                return PartialView("Delete", city);
            }
            return View("Cities");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            var city = db.Cities.Find(id);

            if (city != null)
            {
                db.Cities.Remove(city);
                db.SaveChanges();
            }
            return RedirectToAction("Cities");
        }

        public ActionResult Edit(int id)
        {
            var city = db.Cities.Find(id);
            if (city != null)
            {
                return PartialView("Edit", city);
            }
            return View("Cities");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cities city)
        {
            db.Entry(city).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Cities");
        }

        public ActionResult Units()
        {
            ViewBag.Message = "Справочник 'Подразделения'";
            
            var units = db.Units.Include(u => u.Cities);
            ViewBag.Units = units;
            return View();
        }

        [HttpGet]
        public ActionResult CreateUnit()
        {
            SelectList cities = new SelectList(db.Cities,"Id","Name");
            ViewBag.Cities = cities;
            return View();
        }

        [HttpPost]
        public ActionResult CreateUnit(Units units)
        {
            db.Units.Add(units);
            db.SaveChanges();

            return RedirectToAction("Units");
        }
    }
}