using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class SheriffController : Controller
    {
        CourtEntities Cobj = new CourtEntities();
        // GET: Sheriff
        public ActionResult SheriffIndex(Sheriff obj2)
        {
          

            return View(obj2);
        }

        [HttpPost]
        public ActionResult SheriffAdd(Sheriff obj1)
        {
            Sheriff Addobj = new Sheriff();

            if (ModelState.IsValid)
            {
                Addobj.Sheriff_ID = obj1.Sheriff_ID;
                Addobj.DOB_Sheriff = obj1.DOB_Sheriff;
                Addobj.Address_sheriff = obj1.Address_sheriff;

                if (obj1.Sheriff_ID == 0)
                {
                    Cobj.Sheriffs.Add(Addobj);
                    Cobj.SaveChanges();

                }
                else
                {
                    Cobj.Entry(Addobj).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }

            }


            ModelState.Clear();
      
            return View("SheriffIndex");
        }
     
        
        public ActionResult SheriffList()
    {
            var res = Cobj.Sheriffs.ToList();
            return View(res);        
    }

        public ActionResult Delete_Sheriff(int del)
        {
            var res = Cobj.Sheriffs.Where(x => x.Sheriff_ID == del).First();
            Cobj.Sheriffs.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.Sheriffs.ToList();

            return View("SheriffList", list);
        }

        
    }

    
}