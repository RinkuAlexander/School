using School.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace School.Controllers
{
    public class LoginController : Controller
    {
        private SqlConnection con;
        private string Connection()
        {

            string constr = ConfigurationManager.ConnectionStrings["myconn"].ToString();
            con = new SqlConnection(constr);
            return constr;
        }

        public ActionResult Login()
        {
            Session["UserLogin"] = "false";
            Session["AdminLogin"] = "false";
            //return RedirectToAction("MyLogin");
            return View("Login");
        }

        //Post: User/ Login 
        [HttpPost]
        public ActionResult Login(Login objstu)
        {
            Connection();
            // SqlCommand com = new SqlCommand("[dbo].[UserLogin]");
            string s = "select * from tbl_Login where Username=@Username and Password=@Password";
            SqlCommand com = new SqlCommand(s, con);
            con.Open();
            //com.CommandType = CommandType.StoredProcedure;
            //com.CommandText = "[dbo].[UserLogin]";
            com.Parameters.AddWithValue("@Username", objstu.Username);
            com.Parameters.AddWithValue("@Password", objstu.Password);
            SqlDataReader rdr = com.ExecuteReader();
            if (rdr.Read())
            {
                if (objstu.Username == "Admin")
                {
                    Session["AdminLogin"] = "true";
                    return RedirectToAction("AdminPage");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(objstu.Username, true);
                    Session["Username"] = objstu.Username.ToString();
                    Session["UserLogin"] = "true";

                    return RedirectToAction("UserPage");
                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Username or Password is incorrect')</script>";
                Session["MyLogin"] = "false";
            }
            con.Close();
            return View();
        }
        //Get: 
        public ActionResult AdminPage()
        {
            return View();
        }

        //Get: 
        public ActionResult UserPage()
        {
            return View();
        }
    }
    
}