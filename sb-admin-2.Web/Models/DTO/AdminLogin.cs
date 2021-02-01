using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Models.DTO
{
    public class AdminLogin
    {
        public Int32 Ad_id { get; set; }
        public string Username { get; set; }

        public string Password{ get; set; }
    }
}