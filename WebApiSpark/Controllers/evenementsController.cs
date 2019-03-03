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
    public class evenementsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/evenements
        public IQueryable<evenement> Getevenement()
        {
            return db.evenement;
        }

        // GET: api/evenements/5
        [ResponseType(typeof(List<evenement>))]
        public async Task<IHttpActionResult> Getevenement(int id)
        {
            List<evenement> evenement = await db.evenement.Where(x => x.id_sport == id).OrderByDescending(x => x.datedebut > DateTime.Now).ToListAsync();
            if (evenement == null)
            {
                return NotFound();
            }

            return Ok(evenement);
        }

        // PUT: api/evenements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putevenement(int id, evenement evenement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evenement.id_evenement)
            {
                return BadRequest();
            }

            db.Entry(evenement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!evenementExists(id))
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

        // POST: api/evenements
        [ResponseType(typeof(evenement))]
        public async Task<IHttpActionResult> Postevenement(evenement evenement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.evenement.Add(evenement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = evenement.id_evenement }, evenement);
        }

        // DELETE: api/evenements/5
        [ResponseType(typeof(evenement))]
        public async Task<IHttpActionResult> Deleteevenement(int id)
        {
            evenement evenement = await db.evenement.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }

            db.evenement.Remove(evenement);
            await db.SaveChangesAsync();

            return Ok(evenement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool evenementExists(int id)
        {
            return db.evenement.Count(e => e.id_evenement == id) > 0;
        }
    }
}