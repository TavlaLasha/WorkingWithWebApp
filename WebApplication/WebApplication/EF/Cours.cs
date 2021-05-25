namespace WebApplication.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Cours
    {
        public int ID { get; set; }

        public int CurriculumID { get; set; }

        public int PersonLimit { get; set; }

        [Column(TypeName = "date")]
        public DateTime AnnouncementDate { get; set; }
    }
}
