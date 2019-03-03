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
    public class calendrierdisponibilitesController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/calendrierdisponibilites
        public IQueryable<calendrierdisponibilite> Getcalendrierdisponibilite()
        {
            return db.calendrierdisponibilite;
        }

        // GET: api/calendrierdisponibilites/5
        [ResponseType(typeof(calendrierdisponibilite))]
        public async Task<IHttpActionResult> Getcalendrierdisponibilite(int id)
        {
          

            calendrierdisponibilite calendrierdisponibilite = await db.calendrierdisponibilite.FirstOrDefaultAsync(x => x.iduser == id);
            if (calendrierdisponibilite == null)
            {
                return NotFound();
            }

            return Ok(calendrierdisponibilite);
        }

        // PUT: api/calendrierdisponibilites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcalendrierdisponibilite(int id, calendrierdisponibilite calendrierdisponibilite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendrierdisponibilite.idcalendrier)
            {
                return BadRequest();
            }

            db.Entry(calendrierdisponibilite).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!calendrierdisponibiliteExists(id))
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

        // POST: api/calendrierdisponibilites
        [ResponseType(typeof(calendrierdisponibilite))]
        public async Task<IHttpActionResult> Postcalendrierdisponibilite(calendrierdisponibilite calendrierdisponibilite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.calendrierdisponibilite.Add(calendrierdisponibilite);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = calendrierdisponibilite.idcalendrier }, calendrierdisponibilite);
        }

        // DELETE: api/calendrierdisponibilites/5
        [ResponseType(typeof(calendrierdisponibilite))]
        public async Task<IHttpActionResult> Deletecalendrierdisponibilite(int id)
        {
            calendrierdisponibilite calendrierdisponibilite = await db.calendrierdisponibilite.FindAsync(id);
            if (calendrierdisponibilite == null)
            {
                return NotFound();
            }

            db.calendrierdisponibilite.Remove(calendrierdisponibilite);
            await db.SaveChangesAsync();

            return Ok(calendrierdisponibilite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool calendrierdisponibiliteExists(int id)
        {
            return db.calendrierdisponibilite.Count(e => e.idcalendrier == id) > 0;
        }
    }
}