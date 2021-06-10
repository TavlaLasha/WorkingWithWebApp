using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OurWebApplication.EF;
using OurWebApplication.Models;

namespace OurWebApplication.Controllers
{
    public class CurriculumViewModelsController : ApiController
    {
        private LearningCenterContext db = new LearningCenterContext();

        // GET: api/CurriculumViewModels
        public IQueryable<CurriculumViewModel> GetCurriculumViewModels()
        {
            return db.CurriculumViewModels;
        }

        // GET: api/CurriculumViewModels/5
        [ResponseType(typeof(CurriculumViewModel))]
        public IHttpActionResult GetCurriculumViewModel(int id)
        {
            CurriculumViewModel curriculumViewModel = db.CurriculumViewModels.Find(id);
            if (curriculumViewModel == null)
            {
                return NotFound();
            }

            return Ok(curriculumViewModel);
        }

        // PUT: api/CurriculumViewModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurriculumViewModel(int id, CurriculumViewModel curriculumViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curriculumViewModel.ID)
            {
                return BadRequest();
            }

            db.Entry(curriculumViewModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurriculumViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CurriculumViewModels
        [ResponseType(typeof(CurriculumViewModel))]
        public IHttpActionResult PostCurriculumViewModel(CurriculumViewModel curriculumViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CurriculumViewModels.Add(curriculumViewModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = curriculumViewModel.ID }, curriculumViewModel);
        }

        // DELETE: api/CurriculumViewModels/5
        [ResponseType(typeof(CurriculumViewModel))]
        public IHttpActionResult DeleteCurriculumViewModel(int id)
        {
            CurriculumViewModel curriculumViewModel = db.CurriculumViewModels.Find(id);
            if (curriculumViewModel == null)
            {
                return NotFound();
            }

            db.CurriculumViewModels.Remove(curriculumViewModel);
            db.SaveChanges();

            return Ok(curriculumViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurriculumViewModelExists(int id)
        {
            return db.CurriculumViewModels.Count(e => e.ID == id) > 0;
        }
    }
}