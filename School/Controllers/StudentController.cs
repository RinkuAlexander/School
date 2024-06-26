using School.Models;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        private SqlConnection con;
        private string Connection()
        {

            string constr = ConfigurationManager.ConnectionStrings["myconn"].ToString();
            con = new SqlConnection(constr);
            return constr;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddStudentDetails()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddStudentDetails(Student stureg)
        {
            if (ModelState.IsValid)
            {
                StudentMang obj = new StudentMang();
               string result = obj.AddStudentDetails(stureg);
                TempData["result1"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowStudentDetails");

            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View(stureg);
            }
        }

        [HttpGet]
        public ActionResult ShowStudentDetails(string ID)
        {
            
            StudentMang obj = new StudentMang();
            var students = obj.GetStudentDetails(ID);
            return View(students);
        }
    }
}