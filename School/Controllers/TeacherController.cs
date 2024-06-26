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
    public class TeacherController : Controller
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
        public ActionResult AddTeacherDetails()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddTeacherDetails(Teacher thrreg)
        {
            if (ModelState.IsValid)
            {
                TeacherMang obj = new TeacherMang();
                string result = obj.AddTeacherDetails(thrreg);
                TempData["result1"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowTeacherDetails");

            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View(thrreg);
            }
        }

        [HttpGet]
        public ActionResult ShowTeacherDetails(string ID)
        {
            
            TeacherMang obj = new TeacherMang();
            var teachers = obj.GetTeacherDetails(ID);
            return View(teachers);
        }
    }
}