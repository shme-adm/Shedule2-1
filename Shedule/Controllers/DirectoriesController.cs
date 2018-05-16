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
            ViewBag.Message = "Города";
            ViewBag.Cities = db.Cities;
            return View();
        }

        //[HttpGet]
        public ActionResult Create()
        {
            //ViewBag.Message = "Справочник 'Города'";
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

            //var col = city.Units.Count();

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
            ViewBag.Message = "Подразделения";

            var unit = db.Units.Include(u => u.Cities);
            ViewBag.Units = unit;
            return View();
        }

        [HttpGet]
        public ActionResult CreateUnits()
        {
            SelectList cities = new SelectList(db.Cities, "Id", "Name");
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
            if (id == null)
            {
                return HttpNotFound();
            }
            var unit = db.Units.Find(id);
            if (unit != null)
            {
                SelectList cities = new SelectList(db.Cities, "Id", "Name", unit.CitiesId);
                ViewBag.Cities = cities;
                return PartialView("EditUnits", unit);
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
        //++++++++Buildings-Start++++++++++++
        public ActionResult Buildings()
        {
            ViewBag.Message = "Здания";

            var building = db.Buildings.Include(b => b.Cities).Include(b => b.Units);
            ViewBag.Buildings = building;
            return View();
        }

        [HttpGet]
        public ActionResult CreateBuildings()
        {
            SelectList cities = new SelectList(db.Cities, "Id", "Name");
            SelectList units = new SelectList(db.Units, "Id", "Name");
            ViewBag.Cities = cities;
            ViewBag.Units = units;
            return PartialView("CreateBuildings");
        }

        [HttpPost]
        public ActionResult CreateBuildings(Buildings building)
        {
            db.Buildings.Add(building);
            db.SaveChanges();

            return RedirectToAction("Buildings");
        }

        [HttpGet]
        public ActionResult EditBuildings(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var building = db.Buildings.Find(id);
            if (building != null)
            {
                SelectList cities = new SelectList(db.Cities, "Id", "Name", building.CitiesId);
                SelectList units = new SelectList(db.Units, "Id", "Name", building.UnitsId);
                ViewBag.Cities = cities;
                ViewBag.Units = units;
                return PartialView("EditBuildings", building);
            }
            return RedirectToAction("Buildings");

        }

        [HttpPost]
        public ActionResult EditBuildings(Buildings buildings)
        {
            db.Entry(buildings).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Buildings");
        }

        public ActionResult DeleteBuildings(int id)
        {
            var building = db.Buildings.Find(id);
            if (building != null)
            {
                return PartialView("DeleteBuildings", building);
            }
            return View("Buildings");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteBuildings")]
        public ActionResult DeleteRecordBuildings(int id)
        {
            var building = db.Buildings.Find(id);

            if (building != null)
            {
                db.Buildings.Remove(building);
                db.SaveChanges();
            }
            return RedirectToAction("Buildings");

            //++++++++Buildings-End++++++++++++
        }

        //+++++++++++Cabinets-Start+++++++++++++
        public ActionResult Cabinets()
        {
            ViewBag.Message = "Кабинеты";

            var cabinet = db.Cabinets.Include(b => b.Buildings);
            ViewBag.Cabinets = cabinet;
            return View();
        }

        [HttpGet]
        public ActionResult CreateCabinets()
        {
            SelectList buildings = new SelectList(db.Buildings, "Id", "Name");
            ViewBag.Buildings = buildings;
            return PartialView("CreateCabinets");
        }

        [HttpPost]
        public ActionResult CreateCabinets(Cabinets cabinet)
        {
            db.Cabinets.Add(cabinet);
            db.SaveChanges();

            return RedirectToAction("Cabinets");
        }

        [HttpGet]
        public ActionResult EditCabinets(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var cabinet = db.Cabinets.Find(id);
            if (cabinet != null)
            {
                SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                ViewBag.Buildings = buildings;
                return PartialView("EditCabinets", cabinet);
            }
            return RedirectToAction("Cabinets");

        }

        [HttpPost]
        public ActionResult EditCabinets(Cabinets cabinets)
        {
            db.Entry(cabinets).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Cabinets");
        }

        public ActionResult DeleteCabinets(int id)
        {
            var cabinet = db.Cabinets.Find(id);
            if (cabinet != null)
            {
                return PartialView("DeleteCabinets", cabinet);
            }
            return View("Cabinets");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteCabinets")]
        public ActionResult DeleteRecordCabinets(int id)
        {
            var cabinet = db.Cabinets.Find(id);

            if (cabinet != null)
            {
                db.Cabinets.Remove(cabinet);
                db.SaveChanges();
            }
            return RedirectToAction("Cabinets");
            //+++++++++++Cabinets-End+++++++++++++++
        }
    }
}