using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cse_just.Controllers
{
    public class HomeController : Controller
    {
        private csejustEntities db = new csejustEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string email, string password)
        {
            try
            {
                if (email != null && password != null)
                {
                    var finduser = db.users.Where(u => u.email_address == email && u.password == password).ToList();
                    if (finduser.Count() == 1)
                    {
                        Session["user_id"] = finduser[0].user_id;
                        Session["usertype_id"] = finduser[0].usertype_id;
                        Session["first_name"] = finduser[0].first_name;
                        Session["last_name"] = finduser[0].last_name;
                        Session["birth_date"] = finduser[0].birth_date;
                        Session["contact_no"] = finduser[0].contact_no;
                        Session["email_address"] = finduser[0].email_address;
                        Session["password"] = finduser[0].password;
                        Session["current_address"] = finduser[0].current_address;
                        Session["permanent_address"] = finduser[0].permanent_address;
                        Session["gender"] = finduser[0].gender;
                        Session["blood_group"] = finduser[0].blood_group;
                        Session["religion"] = finduser[0].religion;
                        Session["nationality"] = finduser[0].nationality;
                        Session["profile_pic"] = finduser[0].profile_pic;


                        string url = string.Empty;
                        if (finduser[0].usertype_id == 1)
                        {
                            return RedirectToAction("About");
                        }

                        else if (finduser[0].usertype_id == 2)
                        {
                            return RedirectToAction("Contact");
                        }
                        else
                        {
                            url = "About";
                        }

                        return RedirectToAction(url);
                    }

                    else
                    {

                        Session["user_id"] = string.Empty;
                        Session["usertype_id"] = string.Empty;
                        Session["first_name"] = string.Empty;
                        Session["last_name"] = string.Empty;
                        Session["birth_date"] = string.Empty;
                        Session["contact_no"] = string.Empty;
                        Session["email_address"] = string.Empty;
                        Session["password"] = string.Empty;
                        Session["current_address"] = string.Empty;
                        Session["permanent_address"] = string.Empty;
                        Session["gender"] = string.Empty;
                        Session["blood_group"] = string.Empty;
                        Session["religion"] = string.Empty;
                        Session["nationality"] = string.Empty;
                        Session["profile_pic"] = string.Empty;
                        ViewBag.message = "User Name or Password is incorrect!";
                    }

                }

                else
                {

                    Session["user_id"] = string.Empty;
                    Session["usertype_id"] = string.Empty;
                    Session["first_name"] = string.Empty;
                    Session["last_name"] = string.Empty;
                    Session["birth_date"] = string.Empty;
                    Session["contact_no"] = string.Empty;
                    Session["email_address"] = string.Empty;
                    Session["password"] = string.Empty;
                    Session["current_address"] = string.Empty;
                    Session["permanent_address"] = string.Empty;
                    Session["gender"] = string.Empty;
                    Session["blood_group"] = string.Empty;
                    Session["religion"] = string.Empty;
                    Session["nationality"] = string.Empty;
                    Session["profile_pic"] = string.Empty;
                    ViewBag.message = "Some unexpected occur please try again!";
                }

            }

            catch (Exception ex)
            {
                Session["user_id"] = string.Empty;
                Session["usertype_id"] = string.Empty;
                Session["first_name"] = string.Empty;
                Session["last_name"] = string.Empty;
                Session["birth_date"] = string.Empty;
                Session["contact_no"] = string.Empty;
                Session["email_address"] = string.Empty;
                Session["password"] = string.Empty;
                Session["current_address"] = string.Empty;
                Session["permanent_address"] = string.Empty;
                Session["gender"] = string.Empty;
                Session["blood_group"] = string.Empty;
                Session["religion"] = string.Empty;
                Session["nationality"] = string.Empty;
                Session["profile_pic"] = string.Empty;
                ViewBag.message = "Some unexpected occur please try again!";

            }

            return View("Login");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to Jashore University Of Science & Technology Arena";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Welcome to Jashore University Of Science & Technology Arena";

            return View();
        }


        public ActionResult Logout()
        {
            Session["user_id"] = string.Empty;
            Session["usertype_id"] = string.Empty;
            Session["first_name"] = string.Empty;
            Session["last_name"] = string.Empty;
            Session["birth_date"] = string.Empty;
            Session["contact_no"] = string.Empty;
            Session["email_address"] = string.Empty;
            Session["password"] = string.Empty;
            Session["current_address"] = string.Empty;
            Session["permanent_address"] = string.Empty;
            Session["gender"] = string.Empty;
            Session["blood_group"] = string.Empty;
            Session["religion"] = string.Empty;
            Session["nationality"] = string.Empty;
            Session["profile_pic"] = string.Empty;
            return RedirectToAction("Login");
        }
    }
}