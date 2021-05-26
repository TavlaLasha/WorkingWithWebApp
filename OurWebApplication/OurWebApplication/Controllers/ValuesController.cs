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
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<SubjectViewModel> Get()
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Subjects.Select(i => new SubjectViewModel
                {
                    Name = i.Name,
                    Description = i.Description,
                    Code = i.Code,
                    Credits = i.Credits,
                    Hours = i.Hours
                }).ToList();
            }
        }

        // GET api/values/5
        public SubjectViewModel Get(int id)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Subjects.Where(i => i.ID.Equals(id)).Select(i => new SubjectViewModel
                {
                    Name = i.Name,
                    Description = i.Description,
                    Code = i.Code,
                    Credits = i.Credits,
                    Hours = i.Hours
                }).FirstOrDefault();
            }
        }


        // POST api/values
        public void Post([FromBody] SubjectViewModel c)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {

                Subject subject = new Subject
                {
                    Name = c.Name,
                    Description = c.Description,
                    Code = c.Code,
                    Credits = c.Credits,
                    Hours = c.Hours
                };
                db.Subjects.Add(subject);
                db.SaveChanges();

            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]SubjectViewModel s)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Subjects.Any(i => i.ID.Equals(id)))
                    throw new Exception($"Es sagani am {id} -it ver moidzebna");

                var r = db.Subjects.Where(i => i.ID.Equals(id)).First();
                r.Name = s.Name;
                r.Description = s.Description;
                r.Code = s.Code;
                r.Credits = s.Credits;
                r.Hours = s.Hours;
                db.SaveChanges();

            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Subjects.Any(i => i.ID.Equals(id)))
                    throw new Exception($"Es sagani am {id} -it ver moidzebna");

                var r = db.Subjects.Where(i => i.ID.Equals(id)).First();
                db.Subjects.Remove(r);
                db.SaveChanges();

            }
        }
    }
}
