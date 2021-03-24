using CourtroomProject.COURTER;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourtroomProject.Controllers
{
    public class JudgeController : Controller
    {
        // GET: Judge
        CourtEntities Cobj = new CourtEntities();
        public ActionResult JudgeIndex(Judge obj5)
        {
            return View(obj5);
        }

        [HttpPost]
        public ActionResult JudgeAdd(Judge objj) 
        {
            Judge obj1 = new Judge();

            if (ModelState.IsValid) 
            {
                obj1.Judge_ID = objj.Judge_ID;
                obj1.name_judge = objj.name_judge;
                obj1.age_judge = objj.age_judge;
                obj1.rank_judge = objj.rank_judge;
                obj1.YearsInservice = objj.YearsInservice;

                if (obj1.Judge_ID == 0)
                {
                    Cobj.Judges.Add(obj1);
                    Cobj.SaveChanges();
                }
                else 
                {
                    Cobj.Entry(obj1).State = EntityState.Modified;
                    Cobj.SaveChanges();
                }

            }
            ModelState.Clear();
            return View("JudgeIndex");
        }

        public ActionResult JudgeList() 
        {
            var res = Cobj.Judges.ToList();
            return View(res);
        }

        public ActionResult Delete_Judge(int del)
        {
            var res = Cobj.Judges.Where(x => x.Judge_ID == del).First();
            Cobj.Judges.Remove(res);
            Cobj.SaveChanges();

            var list = Cobj.Judges.ToList();

            return View("JudgeList", list);
        }

    }
}