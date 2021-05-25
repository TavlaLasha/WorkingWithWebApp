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
    public class UserController : ApiController
    {
        // GET api/values
        public IEnumerable<UserDTO> Get()
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Users.Select(i => new UserDTO
                {
                    ID = i.ID,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Email = i.Email,
                    IDNumber = i.IDNumber,
                    Password = i.Password,
                    PhoneNumber = i.PhoneNumber
                }).ToList();
            }
        }

        // GET api/values/5
        public UserDTO Get(int id)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Users.Where(i => i.ID.Equals(id)).Select( i => new UserDTO
                {
                    ID = i.ID,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Email = i.Email,
                    IDNumber = i.IDNumber,
                    Password = i.Password,
                    PhoneNumber = i.PhoneNumber
                }).FirstOrDefault();
            }
        }

        // POST api/values
        public void Post([FromBody]UserDTO u)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                User udt = new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    IDNumber = u.IDNumber,
                    Password = u.Password,
                    PhoneNumber = u.PhoneNumber
                };
                db.Users.Add(udt);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        public void Put(string IDNumber, [FromBody]UserDTO u)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Users.Any(i => i.IDNumber.Equals(IDNumber)))
                    throw new Exception($"User with ID Number {IDNumber} not found!");

                var udt = db.Users.Where(i => i.IDNumber.Equals(IDNumber)).First();

                udt.FirstName = u.FirstName;
                udt.LastName = u.LastName;
                udt.Email = u.Email;
                udt.IDNumber = u.IDNumber;
                udt.Password = u.Password;
                udt.PhoneNumber = u.PhoneNumber;
                
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(string IDNumber)
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                if (!db.Users.Any(i => i.IDNumber.Equals(IDNumber)))
                    throw new Exception($"User with ID Number {IDNumber} not found!");

                var udt = db.Users.Where(i => i.IDNumber.Equals(IDNumber)).First();
                db.Users.Remove(udt);
                db.SaveChanges();
            }
        }
    }
}
