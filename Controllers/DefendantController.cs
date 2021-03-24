using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class DefendantController : Controller
    {
        // GET: Defendant
        CourtEntities Cobj = new CourtEntities();
        public ActionResult DefendantIndex(Defendant obj5)
        {
            return View(obj5);
        }


        public ActionResult DefendantAdd(Defendant obj2)
        {
            Defendant obj = new Defendant();
            if (ModelState.IsValid)
            {

                obj.Defendant_ID = obj2.Defendant_ID;
                obj.name_defend = obj2.name_defend;
                obj.age_defend = obj2.age_defend;
                obj.DOB_defend = obj2.DOB_defend;

                if (obj.Defendant_ID == 0)
                {
                    Cobj.Defendants.Add(obj);
                    Cobj.SaveChanges();
                }
                else
                {
                    Cobj.Entry(obj).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }
            }
                ModelState.Clear();

                return View("DefendantIndex");
            
        }

        public ActionResult DefendantList()
        {
            var res = Cobj.Defendants.ToList();
            return View(res);
        }


        public ActionResult Delete_Defend(int del) 
        {
            var res = Cobj.Defendants.Where(x => x.Defendant_ID == del).First();
            Cobj.Defendants.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.Defendants.ToList();

            return View("DefendantList", list);
        }
    }
}