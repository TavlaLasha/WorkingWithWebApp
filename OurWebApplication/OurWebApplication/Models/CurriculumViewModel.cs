using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurWebApplication.Models
{
    public class CurriculumViewModel
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public int LecturerID { get; set; }
        public byte[] Syllabus { get; set; }
    }
}