using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class PlaintiffController : Controller
    {
        // GET: Plaintiff
        CourtEntities Cobj = new CourtEntities();
        public ActionResult PlaintiffIndex( Plaintiff obj1)
        {

            return View(obj1);
        }

        [HttpPost]
        public ActionResult PlaintiffAdd(Plaintiff obj) 
        {
            Plaintiff pobj = new Plaintiff();

            if (ModelState.IsValid)
            {
                pobj.Plaintiff_ID = obj.Plaintiff_ID;
                pobj.name_plain = obj.name_plain;
                pobj.age_plain = obj.age_plain;
                pobj.DOB_plain = obj.DOB_plain;

                if (pobj.Plaintiff_ID == 0)
                {

                    Cobj.Plaintiffs.Add(pobj);
                    Cobj.SaveChanges();
                }
                else 
                {
                    Cobj.Entry(pobj).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }

            }
            ModelState.Clear();

            return View("PlaintiffIndex");
        }

        public ActionResult PlaintiffList()
        {
            var res = Cobj.Plaintiffs.ToList();
            return View(res);
        }

        public ActionResult Delete_Plain(int del)
        {
            var res = Cobj.Plaintiffs.Where(x => x.Plaintiff_ID == del).First();
            Cobj.Plaintiffs.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.Plaintiffs.ToList();

            return View("PlaintiffList", list);
        }

    }
}