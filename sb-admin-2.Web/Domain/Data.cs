using sb_admin_2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin_2.Web.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
           
            menu.Add(new Navbar { Id = 2, nameOption = "Manage Notifications", imageClass = "fa fa-bar-chart-o fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 5, nameOption = "University Calendar ", controller = "Admin", action = "UniversityCalendar", status = true, isParent = false, parentId = 2 });
            
            
            menu.Add(new Navbar { Id = 11, nameOption = "Records", controller = "Home", action = "Forms", imageClass = "fa fa-edit fa-fw", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 12, nameOption = "List of Students", controller = "Home", action = "TranscriptOfRecord", status = false, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 13, nameOption = "Infractions ", controller = "Home", action = "Infractions", status = false, isParent = false, parentId = 11 });

            
            
            return menu.ToList();
        }
    }
}