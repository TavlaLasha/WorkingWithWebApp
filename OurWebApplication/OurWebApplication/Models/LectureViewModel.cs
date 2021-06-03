using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurWebApplication.Models
{
    public class LectureViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Degree { get; set; }
        public bool Status { get; set; }
    }
}