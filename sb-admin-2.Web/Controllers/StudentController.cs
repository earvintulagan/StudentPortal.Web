using sb_admin_2.Web.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace sb_admin_2.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        RegistrationEntities db = new RegistrationEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentPortal()
        {
            return View();
        }

        public ActionResult SanBartolome()
        {
            return View();
        }

        public ActionResult Batasan()
        {
            return View();
        }

        public ActionResult SanFrancisco()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult UpdateContact()
        {
            return View();
        }

        public ActionResult Comply()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("StudentLogin", "Home", new { area = "StudentLogin" });
        }

        public JsonResult GetEvents()
        {
            using (RegistrationEntities dc = new RegistrationEntities())
            {
                var events = dc.Calendars.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


        }

        public ActionResult UpdAccess(string studentnum, string password)
        {


            if (ModelState.IsValid)
            {



                var data = db.Members.Where(s => s.Studentnum.Equals(studentnum) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Contact_number"] = data.FirstOrDefault().Contact_number;
                    
                    Session["StudentId"] = data.FirstOrDefault().StudentId;



                    return RedirectToAction("UpdateContact");
                }
                else
                {

                    return RedirectToAction("Profile");
                }
            }
            return View();
        }

        public ActionResult getConcern(QuestionDTO data)
        {

            Concern con = new Concern();

            con.Studentnum = data.Studentnum;
            con.Email= data.Email;
            con.Subject = data.Subject;
            con.Content = data.Content;


            db.Concerns.Add(con);
            db.SaveChanges();
            return View("Profile");

        }

        public ActionResult UpdContact(RecordDTO m)
        {
            //Update the event
            
            var checkIfExisting = db.Members.Where(r => r.Studentnum == m.Studentnum).FirstOrDefault();

            if (checkIfExisting != null)
            {
                checkIfExisting.Email = m.Email;
                checkIfExisting.Contact_number = m.Contact_number;
             

                db.SaveChanges();
                
            }




            return View("Profile");

        }
    }
}