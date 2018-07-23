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
    public class SpecialityController : Controller
    {
        // GET: Speciality
        ShedulerContext db = new ShedulerContext();       
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.Message = "Отделения";
            var ss = db.Speciality;

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

            var s = db.Speciality.OrderBy(l => l.Name).Include(l => l.Speciality_item);

            int pageNumber = (page ?? 1);
           
            return View(s.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Copy()
        {
            ViewBag.Subjects_groups = new SelectList(db.Subjects_groups, "Id", "Name");
            ViewBag.Subjects = new SelectList(db.Subjects, "Id", "Name");

            return PartialView("Copy");
        }

        [HttpPost]
        public ActionResult Copy(Subjects_groups subjects_groups)
        {
            var Id = subjects_groups.Id;
            var s = db.Subjects_groups.FirstOrDefault(l=>l.Id == Id);
            var items = new List<Subjects>(db.Subjects.Where(l=>l.Subjects_groupsId == Id));    
           
            var Speciality = new Speciality()
            {
                Name = s.Name                
            };

            foreach (var item in items)
            {
                db.Speciality_item.Add(new Speciality_item { Name = item.Name, Hours = 0, SpecialityId = Speciality.Id });
            }            
            db.Speciality.Add(Speciality);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Copy_item()
        {
            ViewBag.Subjects_groups = new SelectList(db.Subjects_groups, "Id", "Name");

            return PartialView("Copy");
        }

        [HttpPost]
        public ActionResult Copy_item(Subjects_groups subjects_groups)
        {
            var Id = subjects_groups.Id;
            var s = db.Subjects_groups.FirstOrDefault(l => l.Id == Id);
            var items = new List<Subjects>(db.Subjects.Where(l => l.Subjects_groupsId == Id));

            var Speciality = new Speciality()
            {
                Name = s.Name
            };

            foreach (var item in items)
            {
                db.Speciality_item.Add(new Speciality_item { Name = item.Name, Hours = 0, SpecialityId = Speciality.Id });
            }
            db.Speciality.Add(Speciality);
            db.SaveChanges();

            return RedirectToAction("Index");
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
        public ActionResult Create(Speciality Speciality)
        {
            db.Speciality.Add(Speciality);
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
            var Speciality = db.Speciality.Find(id);
            if (Speciality != null)
            {
                // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                //ViewBag.Buildings = buildings;
                return PartialView("Edit", Speciality);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(Speciality Speciality)
        {
            db.Entry(Speciality).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var Speciality = db.Speciality.Find(id);
            
            if (Speciality != null)
            {
                return PartialView("Delete", Speciality);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            var Speciality = db.Speciality.Find(id);
            var Speciality_item = db.Speciality_item.Where(l => l.SpecialityId == id).FirstOrDefault();///поправить удаление циклов скопированных из предметов
            if (Speciality != null)
            {   if (Speciality_item != null)
                {
                    db.Speciality_item.Remove(Speciality_item);
                    db.SaveChanges();
                }
                db.Speciality.Remove(Speciality);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create_item(int id)
        {
            int selectedIndex = 1;
            ViewBag.Subjects_groups = new SelectList(db.Subjects_groups, "Id", "Name", selectedIndex);
            ViewBag.Subjects = new SelectList(db.Subjects.Where(c => c.Subjects_groupsId == selectedIndex), "Id", "Name");
            ViewBag.Speciality = new SelectList(db.Speciality.Where(s => s.Id == id), "Id", "Name");
            return PartialView("Create_item"/*, subjects_groups*/);
        }

        [HttpPost]
        public ActionResult Create_item(Speciality_item Speciality_item/*, Subjects_groups subjects_groups*/)
        {
            //subjects.Subjects_groupsId = subjects_groups.Id;
            db.Speciality_item.Add(Speciality_item);
            //db.Subjects.Add();
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult GetItems(int id)
        {
            return PartialView(db.Subjects.Where(c => c.Subjects_groupsId == id).ToList());
        }


        [HttpGet]
        public ActionResult Edit_item(int? id)
        {
            SelectList Speciality = new SelectList(db.Speciality, "Id", "Name");
            ViewBag.Speciality = Speciality;
            if (id == null)
            {
                return HttpNotFound();
            }
            var Speciality_item = db.Speciality_item.Find(id);
            if (Speciality_item != null)
            {
                // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
                //ViewBag.Buildings = buildings;
                return PartialView("Edit_item", Speciality_item);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit_item(Speciality_item Speciality_item)
        {
            db.Entry(Speciality_item).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete_item(int id)
        {
            var Speciality_item = db.Speciality_item.Find(id);
            if (Speciality_item != null)
            {
                return PartialView("Delete_item", Speciality_item);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete_item")]
        public ActionResult DeleteRecord_item(int id)
        {
            var Speciality_item = db.Speciality_item.Find(id);

            if (Speciality_item != null)
            {
                db.Speciality_item.Remove(Speciality_item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}