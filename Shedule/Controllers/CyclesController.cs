﻿using System;
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
            
            var cycle = db.Cycles.OrderBy(l => l.Name).Include(l=>l.Cycles_item);           

            int pageNumber = (page ?? 1);
           
            return View(cycle.ToPagedList(pageNumber, pageSize));
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
           
            var cycles = new Cycles()
            {
                Name = s.Name                
            };

            foreach (var item in items)
            {
                db.Cycles_item.Add(new Cycles_item { Name = item.Name, Hours = 0, CyclesId = cycles.Id });
            }            
            db.Cycles.Add(cycles);
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

            var cycles = new Cycles()
            {
                Name = s.Name
            };

            foreach (var item in items)
            {
                db.Cycles_item.Add(new Cycles_item { Name = item.Name, Hours = 0, CyclesId = cycles.Id });
            }
            db.Cycles.Add(cycles);
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
            var cycles_item = db.Cycles_item.Where(l => l.CyclesId == id).FirstOrDefault();///поправить удаление циклов скопированных из предметов
            if (cycles != null)
            {   if (cycles_item != null)
                {
                    db.Cycles_item.Remove(cycles_item);
                    db.SaveChanges();
                }
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