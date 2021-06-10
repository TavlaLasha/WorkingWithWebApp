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
    public class SubjectController : ApiController
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
        public SubjectViewModel Get(string code)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Subjects.Where(i => i.Code.Equals(code)).Select(i => new SubjectViewModel
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
        public void Put(string code, [FromBody]SubjectViewModel s)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Subjects.Any(i => i.Code.Equals(code)))
                    throw new Exception($"Es sagani am {code} -it ver moidzebna");

                var r = db.Subjects.Where(i => i.Code.Equals(code)).First();
                r.Name = s.Name;
                r.Description = s.Description;
                r.Code = s.Code;
                r.Credits = s.Credits;
                r.Hours = s.Hours;
                db.SaveChanges();

            }
        }

        // DELETE api/values/5
        public void Delete(string code)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Subjects.Any(i => i.Code.Equals(code)))
                    throw new Exception($"Es sagani am {code} -it ver moidzebna");

                var r = db.Subjects.Where(i => i.Code.Equals(code)).First();
                db.Subjects.Remove(r);
                db.SaveChanges();

            }
        }
    }
}
