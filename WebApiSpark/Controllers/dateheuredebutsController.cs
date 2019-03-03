using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiSpark.Models;

namespace WebApiSpark.Controllers
{
    public class dateheuredebutsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/dateheuredebuts
        public IQueryable<dateheuredebut> Getdateheuredebut()
        {
            return db.dateheuredebut;
        }

        // GET: api/dateheuredebuts/5
        [ResponseType(typeof(dateheuredebut))]
        public async Task<IHttpActionResult> Getdateheuredebut(int id)
        {
            dateheuredebut dateheuredebut = await db.dateheuredebut.FindAsync(id);
            if (dateheuredebut == null)
            {
                return NotFound();
            }

            return Ok(dateheuredebut);
        }

        // PUT: api/dateheuredebuts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdateheuredebut(int id, dateheuredebut dateheuredebut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dateheuredebut.id)
            {
                return BadRequest();
            }

            db.Entry(dateheuredebut).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dateheuredebutExists(id))
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

        // POST: api/dateheuredebuts
        [ResponseType(typeof(dateheuredebut))]
        public async Task<IHttpActionResult> Postdateheuredebut(dateheuredebut dateheuredebut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dateheuredebut.Add(dateheuredebut);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (dateheuredebutExists(dateheuredebut.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dateheuredebut.id }, dateheuredebut);
        }

        // DELETE: api/dateheuredebuts/5
        [ResponseType(typeof(dateheuredebut))]
        public async Task<IHttpActionResult> Deletedateheuredebut(int id)
        {
            dateheuredebut dateheuredebut = await db.dateheuredebut.FindAsync(id);
            if (dateheuredebut == null)
            {
                return NotFound();
            }

            db.dateheuredebut.Remove(dateheuredebut);
            await db.SaveChangesAsync();

            return Ok(dateheuredebut);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dateheuredebutExists(int id)
        {
            return db.dateheuredebut.Count(e => e.id == id) > 0;
        }
    }
}