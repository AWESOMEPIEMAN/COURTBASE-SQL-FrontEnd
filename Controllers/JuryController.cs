using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class JuryController : Controller
    {
        // GET: Jury
        CourtEntities Cobj = new CourtEntities();
        public ActionResult JuryIndex(Jury obj5)
        {
            return View(obj5);
        }

        public ActionResult JuryAdd(Jury objj)
        {
            Jury obj1 = new Jury();
            if (ModelState.IsValid)
            {
                obj1.Member_ID = objj.Member_ID;
                obj1.Name_jury = objj.Name_jury;
                obj1.age = objj.age;
                obj1.DOB_Jury = objj.DOB_Jury;
                obj1.address_jury = objj.address_jury;

                if (obj1.Member_ID == 0)
                {
                    Cobj.Juries.Add(obj1);
                    Cobj.SaveChanges();

                }
                else
                {
                    Cobj.Entry(obj1).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }

            }
            ModelState.Clear();
            return View("JuryIndex");
        }

        public ActionResult JuryList()
        {
            var res = Cobj.Juries.ToList();
            return View(res);
        }

        public ActionResult Delete_Jury(int del)
        {
            
                var res = Cobj.Juries.Where(x => x.Member_ID== del).First();
                Cobj.Juries.Remove(res);
                Cobj.SaveChanges();

                var list = Cobj.Juries.ToList();

                return View("JuryList", list);
            
        }

    }
}
