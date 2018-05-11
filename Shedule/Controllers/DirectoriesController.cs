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
            
            var unit = db.Units.Include(u => u.Cities);
            ViewBag.Units = unit;
            return View();
        }

        [HttpGet]
        public ActionResult CreateUnits()
        {
            SelectList cities = new SelectList(db.Cities,"Id","Name");
            ViewBag.Cities = cities;
            return PartialView("CreateUnits");
        }

        [HttpPost]
        public ActionResult CreateUnits(Units unit)
        {
            db.Units.Add(unit);
            db.SaveChanges();

            return RedirectToAction("Units");
        }

        [HttpGet]
        public ActionResult EditUnits(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var unit = db.Units.Find(id);
            if (unit != null)
            {
                SelectList cities = new SelectList(db.Cities, "Id", "Name", unit.CitiesId);
                ViewBag.Cities = cities;
                return PartialView("EditUnits",unit);
            }
            return RedirectToAction("Units");
            
        }

        [HttpPost]
        public ActionResult EditUnits(Units units)
        {
            db.Entry(units).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Units");
        }

        public ActionResult DeleteUnits(int id)
        {
            var unit = db.Units.Find(id);
            if (unit != null)
            {
                return PartialView("DeleteUnits", unit);
            }
            return View("Units");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteUnits")]
        public ActionResult DeleteRecordUnits(int id)
        {
            var unit = db.Units.Find(id);

            if (unit != null)
            {
                db.Units.Remove(unit);
                db.SaveChanges();
            }
            return RedirectToAction("Units");
        }
    }
}