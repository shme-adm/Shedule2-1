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
            SelectList cycles = new SelectList(db.Cycles, "Id", "Name");
            SelectList cities = new SelectList(db.Cities, "Id", "Name");
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
    }
}