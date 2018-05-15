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
            ViewBag.Message = "Типы занятий";
            ViewBag.TypeOfClasses = db.TypeOfClasses;
            ViewBag.Subjects = db.Subjects;
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            //SelectList buildings = new SelectList(db.Buildings, "Id", "Name");
            //ViewBag.Buildings = buildings;
            //ViewBag.Message = ""
            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(TypeOfClasses typeOfClasses)
        {
            db.TypeOfClasses.Add(typeOfClasses);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var typeOfClasses = db.TypeOfClasses.Find(id);
            if (typeOfClasses != null)
            {
                // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                //ViewBag.Buildings = buildings;
                return PartialView("Edit", typeOfClasses);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(TypeOfClasses typeOfClasses)
        {
            db.Entry(typeOfClasses).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var typeOfClasses = db.TypeOfClasses.Find(id);
            if (typeOfClasses != null)
            {
                return PartialView("Delete", typeOfClasses);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            var typeOfClasses = db.TypeOfClasses.Find(id);

            if (typeOfClasses != null)
            {
                db.TypeOfClasses.Remove(typeOfClasses);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}