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
        public ActionResult Index()
        {
            ViewBag.Message = "Предметы";
            ViewBag.Subjects = db.Subjects;
            ViewBag.Subjects_groups = db.Subjects_groups;
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
        public ActionResult Create(Subjects subjects)
        {
            db.Subjects.Add(subjects);
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
            var subjects = db.Subjects.Find(id);
            if (subjects != null)
            {
                // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                //ViewBag.Buildings = buildings;
                return PartialView("Edit", subjects);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(Subjects subjects)
        {
            db.Entry(subjects).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var subjects = db.Subjects.Find(id);
            if (subjects != null)
            {
                return PartialView("Delete", subjects);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            var subjects = db.Subjects.Find(id);

            if (subjects != null)
            {
                db.Subjects.Remove(subjects);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}