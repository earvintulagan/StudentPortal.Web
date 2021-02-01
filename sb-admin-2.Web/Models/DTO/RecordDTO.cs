﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Models.DTO
{
    public class RecordDTO
    {
        public int StudentId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Sex { get; set; }
        public DateTime DOB { get; set; }
        public string Contact_number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Studentnum { get; set; }

        public string Password { get; set; }

    }
}