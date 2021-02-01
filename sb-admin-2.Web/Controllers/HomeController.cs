using sb_admin_2.Web.Models.DTO;
using sb_admin_2.Web.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sb_admin_2.Web.Controllers
{
    public class HomeController : Controller
    {
        RegistrationEntities db = new RegistrationEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MissionandVission()
        {
            return View();
        }

        public ActionResult CoreValues()
        {
            return View();
        }

        

        public ActionResult UniversityHymn()
        {
            return View();
        }

       

       

        public ActionResult DownloadableForms()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult QCU()
        {
            return View();
        }

        public ActionResult StudentLogin()
        {
            return View();
        }


        public ActionResult Campus()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("AdminLogin");
        }

        public ActionResult TranscriptOfRecord()
        {
            return View();
        }

        public ActionResult UniversityCalendar()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult Concern()
        {
            return View();
        }

        public ActionResult Infractions()
        {
            return View();
        }
        public ActionResult LoginAdmin(string username, string password)
        {



            if (ModelState.IsValid)
            {

                

                var data = db.Admin_Acc.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {

                    return RedirectToAction("Concern", "Home", new { area = "Concern" });
                }
                else
                {

                    return RedirectToAction("AdminLogin");
                }
            }
            return View();
        }

        public JsonResult GetEvents()
        {
            using (RegistrationEntities dc = new RegistrationEntities())
            {
                var events = dc.Calendars.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Calendar e)
        {
            var status = false;
            using (RegistrationEntities dc = new RegistrationEntities())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Calendars.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Calendars.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (RegistrationEntities dc = new RegistrationEntities())
            {
                var v = dc.Calendars.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Calendars.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            RegistrationEntities entities = new RegistrationEntities();
            List<Member> members = (from account in entities.Members
                                      select account).ToList();
            return Json(members);
        }

        public JsonResult StudentInfraction()
        {
            RegistrationEntities entities = new RegistrationEntities();
            List<Infraction> inf = (from account in entities.Infractions
                                    select account).ToList();
            return Json(inf);
        }

        public JsonResult getQuestion()
        {
            RegistrationEntities entities = new RegistrationEntities();
            List<Concern> concern = (from account in entities.Concerns
                                    select account).ToList();
            return Json(concern);
        }

        DataTableRepository dataTBrepository = new DataTableRepository();
        public ActionResult getRecords(string category, string keyword)
        {
            List<RecordDTO> records = dataTBrepository.records(category, keyword);
            return Json(new { data = records });
        }


        /*Login for student*/
        public ActionResult LoginStudent(string studentnum, string password)
        {

            

            if (ModelState.IsValid)
            {
                var inf = db.Infractions.Where(s => s.Studentnum.Equals(studentnum)).ToList();
                var data = db.Members.Where(s => s.Studentnum.Equals(studentnum) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["Lastname"] = data.FirstOrDefault().Lastname;
                    Session["Firstname"] = data.FirstOrDefault().Firstname;
                    Session["Middlename"] = data.FirstOrDefault().Middlename;
                    Session["Gender"] = data.FirstOrDefault().Sex;
                    Session["Address"] = data.FirstOrDefault().Address;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Studentnum"] = data.FirstOrDefault().Studentnum;
                    Session["StudentId"] = data.FirstOrDefault().StudentId;

                    Session["Library"] = inf.FirstOrDefault().Library;
                    Session["L_inf"] = inf.FirstOrDefault().L_inf;
                    Session["Health"] = inf.FirstOrDefault().Health;
                    Session["H_inf"] = inf.FirstOrDefault().H_inf;
                    Session["Osas"] = inf.FirstOrDefault().Osas;
                    Session["O_inf"] = inf.FirstOrDefault().O_inf;
                    Session["Registrar"] = inf.FirstOrDefault().Registrar;
                    Session["R_inf"] = inf.FirstOrDefault().R_inf;
                    Session["Studentnum"] = data.FirstOrDefault().Studentnum;
                    Session["Infr_Id"] = inf.FirstOrDefault().Infr_Id;



                    return RedirectToAction("StudentPortal", "Student", new { area = "StudentPortal" });
                }
                else
                {
                    
                    return RedirectToAction("StudentLogin");
                }
            }
            return View();
        }



       




    }
}