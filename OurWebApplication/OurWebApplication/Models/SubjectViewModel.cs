using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurWebApplication.Models
{
    public class SubjectViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }
        public int? Hours { get; set; }
    }
}