using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shedule.Models;
using System.Data.Entity;
using PagedList;

namespace Shedule.Controllers
{
    public class CyclesController : Controller
    {
        // GET: Cycles
        ShedulerContext db = new ShedulerContext();
        // GET: Subjects
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.Message = "Циклы";

            ViewBag.CurrentSort = sortOrder;
            int pageSize = 10;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            //ViewBag.Subjects = db.Subjects;
            var cycle = db.Cycles.OrderBy(l => l.Name);
            //subject.OrderBy(sg=>sg.Name);
            // ViewBag.Subjects_groups = subject.OrderBy(s=>s.Name);
            // var ss = subject.OrderBy(sg => sg.Subjects);

            int pageNumber = (page ?? 1);
           // int counter = pageNumber * pageSize;
            // ViewBag.Counter = counter;
            // ViewBag.Subjects_groups.ToPagedList(pageNumber, pageSize);
            return View(cycle.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create(Cycles cycles)
        {
            db.Cycles.Add(cycles);
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
            var cycles = db.Cycles.Find(id);
            if (cycles != null)
            {
                // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                //ViewBag.Buildings = buildings;
                return PartialView("Edit", cycles);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(Cycles cycles)
        {
            db.Entry(cycles).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cycles = db.Cycles.Find(id);
            if (cycles != null)
            {
                return PartialView("Delete", cycles);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            var cycles = db.Cycles.Find(id);

            if (cycles != null)
            {
                db.Cycles.Remove(cycles);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}