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
using NorthWindDemo.Models;

namespace NorthWindDemo.Controllers
{
    public class CatagoriesController : ApiController
    {
        private NorthwindEntities1 db = new NorthwindEntities1();

        // GET: api/Catagories
        public IQueryable<Catagory> GetCatagory()
        {
            return db.Catagory;
        }

        // GET: api/Catagories/5
        [ResponseType(typeof(Catagory))]
        public IHttpActionResult GetCatagory(int id)
        {
            Catagory catagory = db.Catagory.Find(id);
            if (catagory == null)
            {
                return NotFound();
            }

            return Ok(catagory);
        }

        // PUT: api/Catagories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCatagory(int id, Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catagory.CategoryID)
            {
                return BadRequest();
            }

            db.Entry(catagory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatagoryExists(id))
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

        // POST: api/Catagories
        [ResponseType(typeof(Catagory))]
        public IHttpActionResult PostCatagory(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catagory.Add(catagory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CatagoryExists(catagory.CategoryID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = catagory.CategoryID }, catagory);
        }

        // DELETE: api/Catagories/5
        [ResponseType(typeof(Catagory))]
        public IHttpActionResult DeleteCatagory(int id)
        {
            Catagory catagory = db.Catagory.Find(id);
            if (catagory == null)
            {
                return NotFound();
            }

            db.Catagory.Remove(catagory);
            db.SaveChanges();

            return Ok(catagory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatagoryExists(int id)
        {
            return db.Catagory.Count(e => e.CategoryID == id) > 0;
        }
    }
}