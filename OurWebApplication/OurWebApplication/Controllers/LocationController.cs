using OurWebApplication.EF;
using OurWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OurWebApplication.Controllers
{
    public class LocationController : ApiController
    {
        // GET api/values
        public IEnumerable<LocationViewModel> Get()
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Locations.Select(i => new LocationViewModel
                {
                    Name = i.Name,
                    Latitude = i.Latitude,
                    Longtitude = i.Longtitude
                }).ToList();
            }
        }

        // GET api/values/5
        public LocationViewModel Get(string nm)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Locations.Where(i => i.Name.Equals(nm)).Select(i => new LocationViewModel
                {
                    Name = i.Name,
                    Longtitude = i.Longtitude,
                    Latitude = i.Latitude
                }).FirstOrDefault();
            }
        }

        // POST api/values
        public void Post([FromBody] LocationViewModel l)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Locations.Any(i => i.Name.Equals(l.Name)))
                    throw new Exception($"ადგილმდებარეობა სახელით {l.Name} ვერ მოიძებნა!");

                Location location = new Location
                {
                    Name = l.Name,
                    Longtitude = l.Longtitude,
                    Latitude = l.Latitude
                };
                db.Locations.Add(location);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        public void Put(string nm, [FromBody] LocationViewModel l)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Locations.Any(i => i.Name.Equals(nm)))
                    throw new Exception($"ადგილმდებარეობა სახელით {nm} ვერ მოიძებნა!");
                var r = db.Locations.Where(i => i.Name.Equals(nm)).First();

                r.Name = l.Name;
                r.Longtitude = l.Longtitude;
                r.Latitude = l.Latitude;
                r.ParentID = l.ParentID;

                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(string nm)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Locations.Any(i => i.Name.Equals(nm)))
                    throw new Exception($"ადგილმდებარეობა სახელით {nm} ვერ მოიძებნა!");


                var r = db.Locations.Where(i => i.Name.Equals(nm)).First();

                db.Locations.Remove(r);
                db.SaveChanges();
            }
        }
    }
}
