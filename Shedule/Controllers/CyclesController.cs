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

            var cycle = db.Cycles.OrderBy(l => l.Name);     

            int pageNumber = (page ?? 1);
           
            return View(cycle.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Copy(int? id)
        {
            ViewBag.Subjects_groups = new SelectList(db.Subjects_groups, "Id", "Name");
            ViewBag.Subjects = new SelectList(db.Subjects, "Id", "Name");

            return PartialView("Copy");
        }

        [HttpPost]
        public ActionResult Copy(Cycles cycles)
        {
            var id_cycle = cycles.Id;
            var id_subject_group = Int32.Parse(Request.Form["Subjects_groups"]);
            var items = new List<Subjects>(db.Subjects.Where(l => l.Subjects_groupsId == id_subject_group));
            

            foreach (var item in items)
            {
                db.Cycles_item.Add(new Cycles_item { Name = item.Name, Hours = 0, CyclesId = id_cycle });
            }          
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Copy(int? id)
        //{
        //    ViewBag.Subjects_groups = new SelectList(db.Subjects_groups, "Id", "Name");
        //    ViewBag.Subjects = new SelectList(db.Subjects, "Id", "Name");

        //    return PartialView("Copy");
        //}

        //[HttpPost]
        //public ActionResult Copy(Subjects_groups subjects_groups)
        //{
        //    var Id = subjects_groups.Id;
        //    var s = db.Subjects_groups.FirstOrDefault(l => l.Id == Id);
        //    var items = new List<Subjects>(db.Subjects.Where(l => l.Subjects_groupsId == Id));

        //    var cycles = new Cycles()
        //    {
        //        Name = s.Name
        //    };

        //    foreach (var item in items)
        //    {
        //        db.Cycles_item.Add(new Cycles_item { Name = item.Name, Hours = 0, CyclesId = cycles.Id });
        //    }
        //    db.Cycles.Add(cycles);
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        

        [HttpGet]
        public ActionResult Create()
        {            
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        //public ActionResult DeleteRecord(int id)
        //{
        //    var cycles = db.Cycles.Find(id);
        //    var cycles_item = db.Cycles_item.Where(l => l.CyclesId == id).FirstOrDefault();///поправить удаление циклов скопированных из предметов
        //    if (cycles != null)
        //    {   if (cycles_item != null)
        //        {
        //            db.Cycles_item.Remove(cycles_item);
        //            db.SaveChanges();
        //        }
        //        db.Cycles.Remove(cycles);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Create_item(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var cycles = db.Cycles.Find(id);
            if (cycles != null)
            {
                int selectedIndex = db.Subjects_groups.Min(c=>c.Id);

                var sb = new SelectList(db.Subjects_groups.OrderBy(l => l.Name), "Id", "Name", selectedIndex);
                ViewBag.Subjects_groups = sb;

                var ss = new SelectList(db.Subjects.Where(c => c.Subjects_groupsId == selectedIndex), "Id", "Name");
                ViewBag.Subjects = ss;

                return PartialView("Create_item");
            }
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult Create_item(Cycles cycles)
        {

            var id_cycle = cycles.Id;
            var id_subject = db.Subjects.Find(Int32.Parse(Request.Form["Subject"]));
            db.Cycles_item.Add(new Cycles_item { Name = id_subject.Name, Hours = 0, CyclesId=id_cycle});
            db.SaveChanges();   
            

            return RedirectToAction("Index");
        }

        public ActionResult GetItems(int id)
        {
            return PartialView(db.Subjects.Where(c => c.Subjects_groupsId == id).ToList());
        }


        //[HttpGet]
        //public ActionResult Edit_item(int? id)
        //{
        //    SelectList cycles = new SelectList(db.Cycles, "Id", "Name");
        //    ViewBag.Cycles = cycles;
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var cycles_item = db.Cycles_item.Find(id);
        //    if (cycles_item != null)
        //    {
        //        // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
        //        //ViewBag.Buildings = buildings;
        //        return PartialView("Edit_item", cycles_item);
        //    }
        //    return RedirectToAction("Index");

        //}

        //[HttpPost]
        //public ActionResult Edit_item(Cycles_item cycles_item)
        //{
        //    db.Entry(cycles_item).State = EntityState.Modified;
        //    db.SaveChanges();

        //    return RedirectToAction("Index");
        //}

        //public ActionResult Delete_item(int id)
        //{
        //    var cycles_item = db.Cycles_item.Find(id);
        //    if (cycles_item != null)
        //    {
        //        return PartialView("Delete_item", cycles_item);
        //    }
        //    return View("Index");
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete_item")]
        //public ActionResult DeleteRecord_item(int id)
        //{
        //    var cycles_item = db.Cycles_item.Find(id);

        //    if (cycles_item != null)
        //    {
        //        db.Cycles_item.Remove(cycles_item);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}