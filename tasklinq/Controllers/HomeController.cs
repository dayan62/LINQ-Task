using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tasklinq.Models;

namespace tasklinq.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        TeacherDetailDataContext tec = new TeacherDetailDataContext();
        public ActionResult Index()
        {
            var list = new List<string> { "Permanent","Temporary","Intern"};
            ViewBag.list = list;
            var list1 = new List<string> { "State", "National","International" };
            ViewBag.list1 = list1;

            var data = tec.Teachers.ToList();
            return View(data);
            //(tec.Teachers.Where(x => x.Name.Contains(searching) || searching == null));

        }
        [HttpPost]
        public ActionResult Index(string Searchtxt)
        {


            var data = tec.Teachers.ToList();
            if(Searchtxt!=null)
            {
                data=tec.Teachers.Where(x=>x.Name.Contains(Searchtxt)).ToList();
            }
            return View(data);
            //(tec.Teachers.Where(x => x.Name.Contains(searching) || searching == null));

        }



        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var databyid = tec.Teachers.Single(x => x.Id == id);
            return View(databyid);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            var list = new List<string>() { "Permanent ", "Temporary" };
            ViewBag.list = list;
            var list1 = new List<string>() { "State ", "National","International" };
            ViewBag.list1 = list1;
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Teacher collection)
        {
            try
            {
                // TODO: Add insert logic here
                tec.Teachers.InsertOnSubmit(collection);
                tec.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var databyid = tec.Teachers.Single(x => x.Id == id);
            return View(databyid);
           // return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Teacher collection)
        {
            try
            {
                // TODO: Add update logic here
                Teacher tec1 = tec.Teachers.Single(x => x.Id == id);
                tec1.Name=collection.Name;
                tec1.Qualification=collection.Qualification;
                tec1.YearofAppointment=collection.YearofAppointment;
                tec1.NatureOfAppointment=collection.NatureOfAppointment; 
                tec1.DepartmentName=collection.DepartmentName;
                tec1.Award=collection.Award;

                tec1.PanCardNumber=collection.PanCardNumber;
                tec.SubmitChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var databyid = tec.Teachers.Single(x => x.Id == id);
            return View(databyid);
           // return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var data = tec.Teachers.Single(x => x.Id == id);
                tec.Teachers.DeleteOnSubmit(data);
                tec.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
