using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class ClerkController : Controller
    {
        // GET: Clerk
        CourtEntities Cobj = new CourtEntities();
        public ActionResult ClerkIndex(Clerk obj5)
        {
            return View(obj5);
        }

        public ActionResult ClerkAdd(Clerk obj)
        {
            Clerk obj1 = new Clerk();
            if (ModelState.IsValid)
            {
                obj1.Clerk_ID = obj.Clerk_ID;
                obj1.name_clerk = obj.name_clerk;
                obj1.age_clerk = obj.age_clerk;
                obj1.DOB_Clerk = obj.DOB_Clerk;
                obj1.Address_Clerk = obj.Address_Clerk;
                obj1.Records_made = obj.Records_made;

                if (obj1.Clerk_ID == 0)

                {
                    Cobj.Clerks.Add(obj1);
                    Cobj.SaveChanges();
                }

                else
                {
                    Cobj.Entry(obj1).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }
                
            }

            ModelState.Clear();
            return View("ClerkIndex");

        }

        public ActionResult ClerkList()
        {
            var res = Cobj.Clerks.ToList();
            return View(res);
        }

        public ActionResult Delete_Clerk(int del)
        {
            var res = Cobj.Clerks.Where(x => x.Clerk_ID == del).First();
            Cobj.Clerks.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.Clerks.ToList();

            return View("ClerkList", list);
        }
    }
}