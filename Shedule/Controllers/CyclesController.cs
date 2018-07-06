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
            var cycle = db.Cycles.OrderBy(l => l.Name).Include(l=>l.Cycles_item);
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

        [HttpGet]
        public ActionResult Create_item(int id)
        {
            ViewBag.Cycles = new SelectList(db.Cycles.Where(s => s.Id == id), "Id", "Name");
            return PartialView("Create_item"/*, subjects_groups*/);
        }

        [HttpPost]
        public ActionResult Create_item(Cycles_item cycles_item/*, Subjects_groups subjects_groups*/)
        {
            //subjects.Subjects_groupsId = subjects_groups.Id;
            db.Cycles_item.Add(cycles_item);
            //db.Subjects.Add();
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit_item(int? id)
        {
            SelectList cycles = new SelectList(db.Cycles, "Id", "Name");
            ViewBag.Cycles = cycles;
            if (id == null)
            {
                return HttpNotFound();
            }
            var cycles_item = db.Cycles_item.Find(id);
            if (cycles_item != null)
            {
                // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                //ViewBag.Buildings = buildings;
                return PartialView("Edit_item", cycles_item);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit_item(Cycles_item cycles_item)
        {
            db.Entry(cycles_item).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete_item(int id)
        {
            var cycles_item = db.Cycles_item.Find(id);
            if (cycles_item != null)
            {
                return PartialView("Delete_item", cycles_item);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete_item")]
        public ActionResult DeleteRecord_item(int id)
        {
            var cycles_item = db.Cycles_item.Find(id);

            if (cycles_item != null)
            {
                db.Cycles_item.Remove(cycles_item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}