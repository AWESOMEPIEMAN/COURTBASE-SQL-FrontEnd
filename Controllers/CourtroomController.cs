using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class CourtroomController : Controller
    {
        // GET: Courtroom
        CourtEntities Cobj = new CourtEntities();
        public ActionResult CourtroomIndex(courtroom obj5)
        {
            return View(obj5);
        }
        [HttpPost]
        public ActionResult CourtroomAdd(courtroom objc)
        {

            courtroom obj1 = new courtroom();

            if (ModelState.IsValid) 
            {
                obj1.Room_ID = objc.Room_ID;
                obj1.location_cr = objc.location_cr;
                obj1.Phone_no_cr = objc.Phone_no_cr;
                obj1.case_t = objc.case_t;

                if (obj1.Room_ID == 0)

                {
                    Cobj.courtrooms.Add(obj1);
                    Cobj.SaveChanges();
                }

                else 
                {
                    Cobj.Entry(obj1).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }

            }
            ModelState.Clear();
            return View("CourtroomIndex");
        }

        public ActionResult CourtroomList() 
        {
            var res = Cobj.courtrooms.ToList();
            return View(res);
        }

        public ActionResult Delete_CR(int del)
        {
            var res = Cobj.courtrooms.Where(x => x.Room_ID == del).First();
            Cobj.courtrooms.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.courtrooms.ToList();

            return View("CourtroomList", list);
        }

    }
}