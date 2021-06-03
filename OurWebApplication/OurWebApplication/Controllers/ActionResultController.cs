using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Microsoft;
using System.Net.Http.Headers;
using OurWebApplication.EF;
using OurWebApplication.Models;
using System.Threading.Tasks;
using System.Threading;


namespace OurWebApplication.Controllers
{
    public class MyResult : IHttpActionResult
    {
        public string value { get; set; }
        public HttpRequestMessage request { get; set; }
        public MyResult(string v, HttpRequestMessage r)
        {
            value = v;
            request = r;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(value + " - my result"),
                RequestMessage = request
            };
            return Task.FromResult(response);
        }
    }
    public class ActionResultController : ApiController
    {
        [Route("void")]
        [HttpGet]  //return type - void
        public void ReturnNothing(){}

        [Route("listNumbers")]
        [HttpGet]  //return type - Primitive/complex
        public List<int> Numbers()
        {
            return new List<int>() { 1, 2, 3 };
        }

        [Route("httpRespMsg")]
        [HttpGet]  //return type - HttpResponseMessage
        public HttpResponseMessage get()
        {
                var numers = new List<int>() { 1, 2, 3 };
                var response = Request.CreateResponse(HttpStatusCode.OK, numers);

                response.Headers.CacheControl = new CacheControlHeaderValue()
                {
                    MaxAge = TimeSpan.FromMinutes(5)
                };
                return response;
        }
        

        [Route("getok")]
        [HttpGet] //return type - IHttpActionResult
        public IHttpActionResult GetOK()
        {
            return Ok(123);
        }
        [Route("get404")]
        [HttpGet] //return type - IHttpActionResult
        public IHttpActionResult GetFoundnt()
        {
            return NotFound();
        }
        [Route("getbadreq")]
        [HttpGet] //return type - IHttpActionResult
        public IHttpActionResult GetBadReq()
        {
            return BadRequest();
        }
        [Route("getunauth")]
        [HttpGet] //return type - IHttpActionResult
        public IHttpActionResult GetUnauth()
        {
            return Unauthorized();
        }
        [Route("getjson")]
        [HttpGet] //return type - IHttpActionResult
        public IHttpActionResult GetJson()
        {
            return Json(123);
        }
        [Route("myresult")]
        [HttpGet] //return type - Custom Result Type
        public IHttpActionResult MyResult()
        {
            return new MyResult("test", Request);
        }
        [Route("getall")]
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            using (LearningCenterContext db = new LearningCenterContext())
            {
                return db.Users.Select(i => new UserDTO
                {
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Email = i.Email,
                    IDNumber = i.IDNumber,
                    Password = i.Password,
                    PhoneNumber = i.PhoneNumber
                }).ToList();
            }
        }

        //public class ActionResult Index()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:51292/Api/User");
        //        var responseTask = client.GetAsync("User");
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<UserDTO>>();
        //            readTask = readTask.Result;
        //        }
        //    return     
        //    }

        //}
    }
}
