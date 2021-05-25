using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CourseViewModel
    {
        public int CurriculumID { get; set; }
        public int PersonLimit { get; set; }
        public DateTime AnnouncementDate { get; set; }
    }
}