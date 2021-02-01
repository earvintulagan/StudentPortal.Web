using sb_admin_2.Web.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Models.Repository
{
    public class DataTableRepository
    {

        RegistrationEntities db = new RegistrationEntities();

        public List<RecordDTO> records(string category, string keyword)
        {

            List<RecordDTO> records = new List<RecordDTO>();
            List<Member> members = new List<Member>();

            if (!string.IsNullOrEmpty(category))
            {
                if (category == "First Name")
                {
                    members = db.Members.Where(a => a.Firstname.Contains(keyword)).ToList();
                }
                else if (category == "Last Name")
                {
                    members = db.Members.Where(a => a.Lastname.Contains(keyword)).ToList();
                }
                else if (category == "Email")
                {
                    members = db.Members.Where(a => a.Email.Contains(keyword)).ToList();
                }

            }
            else
            {
                members = db.Members.ToList();
            }


            //looping of details
            foreach (Member mem in members)
            {
                RecordDTO r = new RecordDTO();

                r.StudentId = mem.StudentId;
                r.Firstname = mem.Firstname;
                r.Lastname = mem.Lastname;
                r.Email = mem.Email;
                r.Address = mem.Address;
                r.Email = mem.Email;

                records.Add(r);
            }


            return records;
        }






        public List<RecordDTO> Records1()
        {

            List<RecordDTO> records = new List<RecordDTO>();
            List<Member> members = db.Members.ToList();



            //looping of details
            foreach (Member member in members)
            {
                RecordDTO r = new RecordDTO();

                r.StudentId = member.StudentId;
                r.Firstname = member.Firstname;
                r.Lastname = member.Lastname;
                r.Email = member.Email;
                r.Address = member.Address;
                r.Email = member.Email;



                records.Add(r);
            }


            return records;
        }

    }
}