using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class FirmController : Controller
    {
        // GET: Firm
        CourtEntities Cobj = new CourtEntities();
        public ActionResult FirmIndex(firm obj5)
        {
            return View(obj5);
        }

        public ActionResult FirmAdd(firm objf)
        {
            firm obj1 = new firm();

            if (ModelState.IsValid)
            {
                obj1.Firm_ID = objf.Firm_ID;
                obj1.name_firm = objf.name_firm;
                obj1.address_firm = objf.address_firm;
                obj1.phone_firm = objf.phone_firm;
                obj1.email_firm = objf.email_firm;
                obj1.StartingYear = objf.StartingYear;

                if (obj1.Firm_ID == 0)
                {
                    Cobj.firms.Add(obj1);
                    Cobj.SaveChanges();
                }
                else
                {
                    Cobj.Entry(obj1).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }
            }
            ModelState.Clear();
            return View("FirmIndex");
        }

        public ActionResult FirmList()
        {
            var res = Cobj.firms.ToList();
            return View(res);
        }

        public ActionResult Delete_Firm(int del)
        {
            var res = Cobj.firms.Where(x => x.Firm_ID == del).First();
            Cobj.firms.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.firms.ToList();

            return View("FirmList", list);
        }


    }
}
            
            
            
            
     
        
        
    


   
