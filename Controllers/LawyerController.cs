using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class LawyerController : Controller
    {
        // GET: Lawyer
        CourtEntities Cobj = new CourtEntities();
        public ActionResult LawyerIndex(lawyer obj5)
        {
            return View(obj5);
        }

        public ActionResult LawyerAdd(lawyer objl) 
        {
            lawyer obj1 = new lawyer();

            if (ModelState.IsValid) 
            {
                obj1.Lawyer_ID = objl.Lawyer_ID;
                obj1.name_lawyer = objl.name_lawyer;
                obj1.client = objl.client;

                if (obj1.Lawyer_ID == 0)
                {
                    Cobj.lawyers.Add(obj1);
                    Cobj.SaveChanges();
                }
                else 
                {
                    Cobj.Entry(obj1).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }
            }

            ModelState.Clear();
            return View("LawyerIndex");
        }

        public ActionResult LawyerList() 
        {
            var res = Cobj.lawyers.ToList();
            return View(res);
        }

        public ActionResult Delete_Law(int del)
        {
            var res = Cobj.lawyers.Where(x => x.Lawyer_ID == del).First();
            Cobj.lawyers.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.lawyers.ToList();

            return View("LawyerList", list);
        }

    }
}