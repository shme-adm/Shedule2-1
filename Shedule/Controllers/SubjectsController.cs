﻿using System;
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
            var s = db.Subjects_groups.Include(sg=>sg.Subjects);
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

            SelectList subjects_groups = new SelectList(db.Subjects_groups, "Id", "Name");
           // var subjects_groups = db.Subjects_groups.Find(id);
            ViewBag.Subjects_groups = subjects_groups;
            //SelectList buildings = new SelectList(db.Buildings, "Id", "Name");
            //ViewBag.Buildings = buildings;
            //ViewBag.Message = ""
            //if (id == null)
            //{
            //    return HttpNotFound();
            //}
            //var subjects_groups = db.Subjects_groups.Find(id);
            //if (subjects_groups != null)
            //{
            // SelectList buildings = new SelectList(db.Buildings, "Id", "Name", cabinet.BuildingsId);
            //ViewBag.Buildings = buildings;
            return PartialView("Create_subject"/*, subjects_groups*/);
            //}
            //return RedirectToAction("Index");
            //return PartialView("Create_subject");
        }

        [HttpPost]
        public ActionResult Create_subject(Subjects subjects/*, Subjects_groups subjects_groups*/)
        {
            //subjects.Subjects_groupsId = subjects_groups.Id;
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

        [HttpGet]
        public ActionResult Edit_subject(int? id)
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
                return PartialView("Edit_subject", subjects);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit_subject(Subjects subjects)
        {
            db.Entry(subjects).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete_subject(int id)
        {
            var subjects = db.Subjects.Find(id);
            if (subjects != null)
            {
                return PartialView("Delete_subject", subjects);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete_subject")]
        public ActionResult DeleteRecord_subject(int id)
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