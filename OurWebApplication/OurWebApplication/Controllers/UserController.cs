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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
