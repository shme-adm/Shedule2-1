using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shedule.Models;
using System.Data.Entity;

namespace Shedule.Controllers
{
    public class CalendarActionResponseModel
    {
        public String Status;
        public Int64 Source_id;
        public Int64 Target_id;

        public CalendarActionResponseModel(String status, Int64 source_id, Int64 target_id)
        {
            Status = status;
            Source_id = source_id;
            Target_id = target_id;
        }
    }
    
    public class typesOfClasses
    {
        public string key;
        public string name;
        
        //public typesOfClasses(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}
    }

    

    public class CalendarController : Controller
    {

        ShedulerContext db = new ShedulerContext();
        
        //public override IdhtmlxConnector CreateConnector(HttpContext context)

        
        // GET: Calendar
        public ActionResult Index()
        {

            //var typeList = new List<typesOfClasses>();
            //var tt = new List<TypeOfClasses>(db.TypeOfClasses);
            //int i = 1; 
            //foreach (var items in tt){
            //    var ii = i++;

            //    var temp = new typesOfClasses { key = ii.ToString(), name = items.Name };
            //    typeList.Add(temp);                
            //}

            //ViewData["types"] = typeList;   


            var typeList = new List<object>();
            foreach (var item in db.TypeOfClasses)
            {
                typeList.Add(new { key = item.Id, label = item.Name });
            }

            var groupList = new List<object>();
            foreach (var item in db.Groups)
            {
                groupList.Add(new { key = item.Id, label = item.Name });
            }

            var teacherList = new List<object>();
            foreach (var item in db.Teachers)
            {
                teacherList.Add(new { key = item.Id, label = item.Name });
            }

            var cabinetList = new List<object>();
            foreach (var item in db.Cabinets)
            {
                cabinetList.Add(new { key = item.Id, label = item.Name });
            }

            var subjectList = new List<object>();
            foreach (var item in db.Subjects)
            {
                subjectList.Add(new { key = item.Id, label = item.Name });
            }
            //var typeList = new List<object>();
            //foreach (var item in db.TypeOfClasses)
            //{
            //    typeList.Add(new { key = item.Id, label = item.Name });
            //}
            
            ViewBag.typeList = typeList;
            ViewBag.groupList = groupList;
            ViewBag.teacherList = teacherList;

            ViewBag.cabinetList = cabinetList;
            ViewBag.subjectList = subjectList;
            //ViewBag.teacherList = teacherList;
            return View();
        }

        public ActionResult Types()
        {

            var typesForLoad = db.TypeOfClasses.ToList();
            return View(typesForLoad);
        }

        public ActionResult Data()
        {
           
            var eventsForLoad = db.Events.ToList();
            return View(eventsForLoad);
        }

        public ActionResult Save(Events changedEvent, FormCollection actionValues)
        {
            //ViewBag.Type = new SelectList(db.TypeOfClasses.OrderBy(t => t.Name), "Id", "Name");
            //ViewBag.Subjects_groups = new SelectList(db.Subjects_groups.OrderBy(sg => sg.Name), "Id", "Name");
            String action_type = actionValues["!nativeeditor_status"];
            Int64 source_id = Int64.Parse(actionValues["id"]);
            Int64 target_id = source_id;


            
            try
            {
                switch (action_type)
                {
                    case "inserted":
                        db.Events.Add(changedEvent);
                        break;
                    case "deleted":
                        changedEvent = db.Events.SingleOrDefault(ev => ev.id == source_id);
                        db.Events.Remove(changedEvent);
                        break;
                    default: // "updated"
                        changedEvent = db.Events.SingleOrDefault(ev => ev.id == source_id);
                        UpdateModel(changedEvent);
                        break;
                }
                db.SaveChanges();
                target_id = changedEvent.id;
            }
            catch
            {
                action_type = "error";
            }

            return View(new CalendarActionResponseModel(action_type, source_id, target_id));
        }


    }
}