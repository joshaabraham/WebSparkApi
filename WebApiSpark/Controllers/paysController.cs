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
    public class paysController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/pays
        public IQueryable<pays> Getpays()
        {
            return db.pays;
        }

        // GET: api/pays/5
        [ResponseType(typeof(pays))]
        public async Task<IHttpActionResult> Getpays(int id)
        {
            pays pays = await db.pays.FindAsync(id);
            if (pays == null)
            {
                return NotFound();
            }

            return Ok(pays);
        }

        // PUT: api/pays/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpays(int id, pays pays)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pays.id)
            {
                return BadRequest();
            }

            db.Entry(pays).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!paysExists(id))
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

        // POST: api/pays
        [ResponseType(typeof(pays))]
        public async Task<IHttpActionResult> Postpays(pays pays)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pays.Add(pays);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pays.id }, pays);
        }

        // DELETE: api/pays/5
        [ResponseType(typeof(pays))]
        public async Task<IHttpActionResult> Deletepays(int id)
        {
            pays pays = await db.pays.FindAsync(id);
            if (pays == null)
            {
                return NotFound();
            }

            db.pays.Remove(pays);
            await db.SaveChangesAsync();

            return Ok(pays);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool paysExists(int id)
        {
            return db.pays.Count(e => e.id == id) > 0;
        }
    }
}