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
            //ViewBag.Subjects = db.Subjects;
            var s = db.Subjects_groups.Include(u=>u.Subjects);
            ViewBag.Subjects_groups = s;
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
        public ActionResult Create(Subjects_groups subjects_groups)
        {
            db.Subjects_groups.Add(subjects_groups);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create_subject()
        {
            //SelectList buildings = new SelectList(db.Buildings, "Id", "Name");
            //ViewBag.Buildings = buildings;
            //ViewBag.Message = ""
            return PartialView("Create_subject");
        }

        [HttpPost]
        public ActionResult Create_subject(Subjects subjects)
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
            var subjects_groups = db.Subjects_groups.Find(id);
            if (subjects_groups != null)
            {
                // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                //ViewBag.Buildings = buildings;
                return PartialView("Edit", subjects_groups);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(Subjects_groups subjects_groups)
        {
            db.Entry(subjects_groups).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var subjects_groups = db.Subjects_groups.Find(id);
            if (subjects_groups != null)
            {
                return PartialView("Delete", subjects_groups);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            var subjects_groups = db.Subjects_groups.Find(id);

            if (subjects_groups != null)
            {
                db.Subjects_groups.Remove(subjects_groups);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}