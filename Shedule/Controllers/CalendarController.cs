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

    public class CalendarController : Controller
    {

        ShedulerContext db = new ShedulerContext();

        
        // GET: Calendar
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Data()
        {
            var eventsForLoad = db.Events;
            return View(eventsForLoad);
        }

        public ActionResult Save(Events changedEvent, FormCollection actionValues)
        {
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