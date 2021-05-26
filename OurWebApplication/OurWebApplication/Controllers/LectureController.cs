using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OurWebApplication.Models;
using OurWebApplication.EF;

namespace OurWebApplication.Controllers
{
    public class LectureController : ApiController
    {
        // GET api/values
        public IEnumerable<LectureViewModel> Get()
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Lecturers.Select(i => new LectureViewModel
                {
                    LastName = i.LastName,
                    FirstName = i.FirstName,
                    IDNumber = i.IDNumber,
                    BirthDate = i.BirthDate,
                    Degree = i.Degree,
                    Status = i.Status

                }).ToList();
            }
        }

        // POST api/values
        public void Post([FromBody] LectureViewModel lec)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                Lecturer lecturer = new Lecturer
                {
                    LastName = lec.LastName,
                    FirstName = lec.FirstName,
                    IDNumber = lec.IDNumber,
                    BirthDate = lec.BirthDate,
                    Degree = lec.Degree,
                    Status = lec.Status

                };
                db.Lecturers.Add(lecturer);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        public void Put(String ln, [FromBody] LectureViewModel lec)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Lecturers.Any(i => i.LastName.Equals(ln)))
                    throw new Exception($"ვერ მოიძებნა{ln}");

                var r = db.Lecturers.Where(i => i.LastName.Equals(ln)).First();

                r.LastName = lec.LastName;
                r.FirstName = lec.FirstName;
                r.IDNumber = lec.IDNumber;
                r.BirthDate = lec.BirthDate;
                r.Degree = lec.Degree;
                r.Status = lec.Status;
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(String ln)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Lecturers.Any(i => i.LastName.Equals(ln)))
                    throw new Exception($"ვერ მოიძებნა{ln}");

                var r = db.Lecturers.Where(i => i.LastName.Equals(ln)).First();
                db.Lecturers.Remove(r);

                db.SaveChanges();
            }
        }
    }
}
