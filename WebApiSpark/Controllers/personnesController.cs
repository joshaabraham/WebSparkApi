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
    public class personnesController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/personnes
        public IQueryable<personnes> Getpersonnes()
        {
            return db.personnes;
        }

        [ResponseType(typeof(personnes))]
        public async Task<IHttpActionResult> Getpersonnes(int id)
        {
            personnes personnes = await db.personnes.FirstOrDefaultAsync(x => x.id == id);
            if (personnes == null)
            {
                return NotFound();
            }

            return Ok(personnes);
        }

        // GET: api/personnes?email=duplan.remi@gmail.com&password=20051982Az!
        [ResponseType(typeof(personnes))]
        public async Task<IHttpActionResult> Getpersonnes(string email, string password)
        {
            personnes personnes = await db.personnes.SingleAsync(x => x.password == password && x.email == email);
            if (personnes == null)
            {
                return NotFound();
            }

            return Ok(personnes);
        }

        // PUT: api/personnes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpersonnes(int id, personnes personnes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personnes.id)
            {
                return BadRequest();
            }

            db.Entry(personnes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personnesExists(id))
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

        // POST: api/personnes
        [ResponseType(typeof(personnes))]
        public async Task<IHttpActionResult> Postpersonnes(personnes personnes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.personnes.Add(personnes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = personnes.id }, personnes);
        }

        // DELETE: api/personnes/5
        [ResponseType(typeof(personnes))]
        public async Task<IHttpActionResult> Deletepersonnes(int id)
        {
            personnes personnes = await db.personnes.FindAsync(id);
            if (personnes == null)
            {
                return NotFound();
            }

            db.personnes.Remove(personnes);
            await db.SaveChangesAsync();

            return Ok(personnes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool personnesExists(int id)
        {
            return db.personnes.Count(e => e.id == id) > 0;
        }
    }
}