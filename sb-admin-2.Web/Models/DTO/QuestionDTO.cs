using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Models.DTO
{
    public class QuestionDTO
    {
        public Int32 C_id { get; set; }
        public string Studentnum { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}