using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class HighCourtController : Controller
    {
        // GET: HighCourt
        CourtEntities Cobj = new CourtEntities();
        public ActionResult HighCourtIndex(HighCourt obj5)
        {
            return View(obj5);
        }

        [HttpPost]

        public ActionResult HighCourtAdd(HighCourt objh)
        {
            HighCourt obj1 = new HighCourt();

            if (ModelState.IsValid)
            {
                obj1.ID = objh.ID;
                obj1.ChiefJustice = objh.ChiefJustice;
                obj1.address = objh.address;
                obj1.Phoneno = objh.Phoneno;
                obj1.email = objh.email;

                if (obj1.ID == 0)

                {
                    Cobj.HighCourts.Add(obj1);
                    Cobj.SaveChanges();
                }
                else 
                {
                    Cobj.Entry(obj1).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }

            }
            ModelState.Clear();
            return View("HighCourtIndex");
        }

        public ActionResult HighCourtList()
        {
            var res = Cobj.HighCourts.ToList();
            return View(res);
        }


        public ActionResult Delete_HC(int del)
        {
            var res = Cobj.HighCourts.Where(x => x.ID == del).First();
            Cobj.HighCourts.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.HighCourts.ToList();

            return View("HighCourtList", list);
        }
    }
}