using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication.EF
{
    public partial class CDBModel : DbContext
    {
        public CDBModel()
            : base("name=CDBModel")
        {
        }

        public virtual DbSet<Cours> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
