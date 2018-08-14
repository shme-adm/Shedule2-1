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
    public class GroupsController : Controller
    {
        ShedulerContext db = new ShedulerContext();
        // GET: Groups
        public ActionResult Index()
        {
            var groups = db.Groups.OrderBy(l => l.Name).Include(l =>l.Cycles).Include(l=>l.City);
            ViewBag.Groups = groups;
            ViewBag.Message = "Группы";
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var items = new List<int>();
            for (int i=0; i<5; i++)
            {
                items.Add(i);
            }
            SelectList quantity = new SelectList(items);
            SelectList cycles = new SelectList(db.Cycles, "Id", "Name");
            SelectList cities = new SelectList(db.Cities, "Id", "Name");

            ViewBag.Quantity = quantity;
            ViewBag.Cycles = cycles;
            ViewBag.Cities = cities;
            
            return PartialView("Create");
        }

        [HttpPost]
        public ActionResult Create(Groups groups)
        {
            
            db.Groups.Add(groups);
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
            var items = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                items.Add(i);
            }
            var groups = db.Groups.Find(id);
            SelectList quantity = new SelectList(items);
            SelectList cycles = new SelectList(db.Cycles, "Id", "Name");
            SelectList cities = new SelectList(db.Cities, "Id", "Name");

            ViewBag.Quantity = quantity;
            ViewBag.Cycles = cycles;
            ViewBag.Cities = cities;
            if (groups != null)
            {                
                return PartialView("Edit", groups);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(Groups groups)
        {
            db.Entry(groups).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var groups = db.Groups.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (groups != null)
            {
                return PartialView("Delete", groups);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int? id)
        {
            var groups = db.Groups.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (groups != null)
            {
                db.Groups.Remove(groups);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}