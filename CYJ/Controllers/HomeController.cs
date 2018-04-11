using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CYJ.Models;

namespace CYJ.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private cyjEntities2 db = new cyjEntities2();
        public HomeController()
        {
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {

            return View();
        }
    
        public ActionResult Added()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult ServiceDelivery()
        {
            return View();
        }

     
        public ActionResult CorpMemberExperience()
        {
            return View();
        }
        public ActionResult ExternalAffairs()
        {
            return View();
        }
        public ActionResult Revenue()
        {
            return View();
        }
        public ActionResult OpEx()
        {
            return View();
        }
        public ActionResult RAD()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Observer")]
        public ActionResult Index()
        {
            return View(db.ABOUTs.ToList());
        }

        public JsonResult GetEvents()
        {
            using (cyjEntities2 dc = new cyjEntities2())
            {
                var events = dc.CALENDAREVENTS.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public JsonResult SaveEvent(CALENDAREVENT e)
        {
            var status = false;
            using (cyjEntities2 dc = new cyjEntities2())
            {
                if (e.eventID > 0)
                {
                //Update the event
                var v = dc.CALENDAREVENTS.Where(a => a.eventID == e.eventID).FirstOrDefault();
                if (v != null)
                {
                v.eventHeader = e.eventHeader;
                v.eventDescription = e.eventDescription;
                v.eventStart = e.eventStart;
                v.eventEnd = e.eventEnd;
          
                    }
                }
                else
                {
                    dc.CALENDAREVENTS.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (cyjEntities2 dc = new cyjEntities2())
            {
                var v = dc.CALENDAREVENTS.Where(a => a.eventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.CALENDAREVENTS.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}