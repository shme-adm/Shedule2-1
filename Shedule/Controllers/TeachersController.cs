using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shedule.Models;
using System.Data.Entity;

namespace Shedule.Controllers
{
    public class TeachersController : Controller
    {
        ShedulerContext db = new ShedulerContext();
        // GET: Teachers
        public ActionResult Index()
        {
            ViewBag.Message = "Преподаватели";
            ViewBag.Teachers = db.Teachers;
           // var s = db.Subjects_groups.Include(sg => sg.Subjects);
            //ViewBag.Subjects_groups = s;
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
        public ActionResult Create(Teachers teachers)
        {
            db.Teachers.Add(teachers);
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
            var teachers = db.Teachers.Find(id);
            if (teachers != null)
            {
                // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                //ViewBag.Buildings = buildings;
                return PartialView("Edit", teachers);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(Teachers teachers)
        {
            db.Entry(teachers).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var teachers = db.Teachers.Find(id);
            if (teachers != null)
            {
                return PartialView("Delete", teachers);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            var teachers = db.Teachers.Find(id);

            if (teachers != null)
            {
                db.Teachers.Remove(teachers);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}