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
//---------вывод расписания
        public ActionResult Index()
        {
//---------формирование данных для выпадающих списков
            var typeList = new List<object>();
            foreach (var item in db.TypeOfClasses.OrderBy(t=>t.Name))
            {
                typeList.Add(new { key = item.Id, label = item.Name });
            }

            var groupsList = new List<object>();
            foreach (var item in db.Groups.OrderBy(g=>g.Name))
            {
                groupsList.Add(new { key = item.Id, label = item.Name });
            }

            var teacherList = new List<object>();
            foreach (var item in db.Teachers.OrderBy(t=>t.Surname))
            {
                teacherList.Add(new { key = item.Id, label = item.Surname + " " + item.Name + " " + item.Middlename});
            }

            var cabinetList = new List<object>();
            foreach (var item in db.Cabinets.OrderBy(c=>c.Name))
            {
                cabinetList.Add(new { key = item.Id, label = item.Name });
            }

            var subjectList = new List<object>();
            foreach (var item in db.Subjects.OrderBy(s=>s.Name))
            {
                subjectList.Add(new { key = item.Id, label = item.Name });
            }
            var unitList = new List<object>();
            foreach (var item in db.Units.OrderBy(u=>u.Name))
            {
                unitList.Add(new { key = item.Id, label = item.Name });
            }

            ViewBag.typeList = typeList;
            ViewBag.groupsList = groupsList;
            ViewBag.teacherList = teacherList;

            ViewBag.cabinetList = cabinetList;
            ViewBag.subjectList = subjectList;
            ViewBag.unitList = unitList;
            return View();
        }
 //--------Загрузка данных из БД      
        public ActionResult Data()
        {
           
            var eventsForLoad = db.Events.ToList();
            return View(eventsForLoad);
        }
//---------Сохранение данных календаря в БД
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
                        db.Events.Add(changedEvent);//---запись
                        break;
                    case "deleted":
                        changedEvent = db.Events.SingleOrDefault(ev => ev.id == source_id);
                        db.Events.Remove(changedEvent);//---удаление
                        break;
                    default: // "updated"
                        changedEvent = db.Events.SingleOrDefault(ev => ev.id == source_id);
                        UpdateModel(changedEvent);//---по умолчанию обновить отображение
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