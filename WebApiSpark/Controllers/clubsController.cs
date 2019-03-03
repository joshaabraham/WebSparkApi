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
    public class clubsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/clubs
        public IQueryable<clubs> Getclubs()
        {
            return db.clubs;
        }

        // GET: api/clubs/5
        [ResponseType(typeof(clubs))]
        public async Task<IHttpActionResult> Getclubs(int id)
        {
            clubs clubs = await db.clubs.FirstOrDefaultAsync(x=>x.idcontact == id);
            if (clubs == null)
            {
                return NotFound();
            }

            return Ok(clubs);
        }

        // PUT: api/clubs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putclubs(int id, clubs clubs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clubs.id)
            {
                return BadRequest();
            }

            db.Entry(clubs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clubsExists(id))
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

        // POST: api/clubs
        [ResponseType(typeof(clubs))]
        public async Task<IHttpActionResult> Postclubs(clubs clubs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.clubs.Add(clubs);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clubs.id }, clubs);
        }

        // DELETE: api/clubs/5
        [ResponseType(typeof(clubs))]
        public async Task<IHttpActionResult> Deleteclubs(int id)
        {
            clubs clubs = await db.clubs.FindAsync(id);
            if (clubs == null)
            {
                return NotFound();
            }

            db.clubs.Remove(clubs);
            await db.SaveChangesAsync();

            return Ok(clubs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clubsExists(int id)
        {
            return db.clubs.Count(e => e.id == id) > 0;
        }
    }
}