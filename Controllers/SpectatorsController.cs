using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class SpectatorsController : Controller
    {
        // GET: Spectators
        CourtEntities Cobj = new CourtEntities();

        
        public ActionResult SpectatorIndex(spectator spec_obj) //Action Method
        {
            return View(spec_obj);
        }

        [HttpPost]
        public ActionResult SpectatorAdd(spectator obj1) //Action Method
        {
                 spectator objs = new spectator();
            if (ModelState.IsValid)
            {
                
                objs.Spec_ID = obj1.Spec_ID;
                objs.Name_spec = obj1.Name_spec;
                objs.Age = obj1.Age;
                objs.DOB_Spec = obj1.DOB_Spec;
                objs.address_spec = obj1.address_spec;

                if (obj1.Spec_ID == 0)
                {
                    Cobj.spectators.Add(objs);
                    Cobj.SaveChanges();
                    
                }
                else 
                {
                    Cobj.Entry(objs).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }
                
            }
            ModelState.Clear();
            return View("SpectatorIndex");
        }


        public ActionResult SpectatorList() 
        {
            var res = Cobj.spectators.ToList();

            return View(res);

        }

        public ActionResult Delete_Spec(int del) 
        {
            var res = Cobj.spectators.Where(x => x.Spec_ID == del).First();
                Cobj.spectators.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.spectators.ToList();

            return View("SpectatorList",list);
        }

    }
}