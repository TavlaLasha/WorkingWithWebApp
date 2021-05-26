using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication.EF;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<CourseViewModel> Get()
        {
            using (CDBModel db = new CDBModel())
            {
                return db.Courses.Select(i => new CourseViewModel
                {
                    CurriculumID = i.CurriculumID,
                    PersonLimit = i.PersonLimit,
                    AnnouncementDate = i.AnnouncementDate
                }).ToList();
            }
        }


        // POST api/values
        public void Post([FromBody] CourseViewModel cou)
        {
            using (CDBModel db = new CDBModel())
            {
                Cours cours = new Cours
                {
                    CurriculumID = cou.CurriculumID,
                    PersonLimit = cou.PersonLimit,
                    AnnouncementDate = cou.AnnouncementDate
                };
                db.Courses.Add(cours);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] CourseViewModel cou)
        {
            using (CDBModel db = new CDBModel())
            {
                if (!db.Courses.Any(i => i.CurriculumID.Equals(id)))
                    throw new Exception($"ვერ მოიძებნა{id}");

                var r = db.Courses.Where(i => i.CurriculumID.Equals(id)).First();

                r.CurriculumID = cou.CurriculumID;
                r.PersonLimit = cou.PersonLimit;
                r.AnnouncementDate = cou.AnnouncementDate;
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (CDBModel db = new CDBModel())
            {
                if (!db.Courses.Any(i => i.CurriculumID.Equals(id)))
                    throw new Exception($"ვერ მოიძებნა{id}");

                var r = db.Courses.Where(i => i.CurriculumID.Equals(id)).First();
                db.Courses.Remove(r);
                db.SaveChanges();
            }
        }
    }
}
