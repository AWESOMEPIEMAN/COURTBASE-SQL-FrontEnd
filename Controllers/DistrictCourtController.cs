using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class DistrictCourtController : Controller
    {
        // GET: DistrictCourt
        CourtEntities Cobj = new CourtEntities();
        public ActionResult DistrictCourtIndex(DistrictCourt obj5)
        {
            return View(obj5);
        }
        [HttpPost]
        public ActionResult DistrictCourtAdd(DistrictCourt objd)
        {
            DistrictCourt obj1 = new DistrictCourt();

            if (ModelState.IsValid)
            {
                obj1.ID_DC = objd.ID_DC;
                obj1.District = objd.District;
                obj1.address = objd.address;
                obj1.Phone_no_dc = objd.Phone_no_dc;
                obj1.Email = objd.Email;

                if (obj1.ID_DC == 0)
                {
                    Cobj.DistrictCourts.Add(obj1);
                    Cobj.SaveChanges();
                }
                else 
                {
                    Cobj.Entry(obj1).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }
            }

            ModelState.Clear();
            return View("DistrictCourtIndex");


        }

        public ActionResult DistrictCourtList() 
        {
            var res = Cobj.DistrictCourts.ToList();
            return View(res);
        }

        public ActionResult Delete_DC(int del)
        {
            var res = Cobj.DistrictCourts.Where(x => x.ID_DC == del).First();
            Cobj.DistrictCourts.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.DistrictCourts.ToList();

            return View("DistrictCourtList", list);
        }

    }
}