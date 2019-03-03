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
    public class dateheurefinsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/dateheurefins
        public IQueryable<dateheurefin> Getdateheurefin()
        {
            return db.dateheurefin;
        }

        // GET: api/dateheurefins/5
        [ResponseType(typeof(dateheurefin))]
        public async Task<IHttpActionResult> Getdateheurefin(int id)
        {
            dateheurefin dateheurefin = await db.dateheurefin.FindAsync(id);
            if (dateheurefin == null)
            {
                return NotFound();
            }

            return Ok(dateheurefin);
        }

        // PUT: api/dateheurefins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdateheurefin(int id, dateheurefin dateheurefin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dateheurefin.id)
            {
                return BadRequest();
            }

            db.Entry(dateheurefin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dateheurefinExists(id))
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

        // POST: api/dateheurefins
        [ResponseType(typeof(dateheurefin))]
        public async Task<IHttpActionResult> Postdateheurefin(dateheurefin dateheurefin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dateheurefin.Add(dateheurefin);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (dateheurefinExists(dateheurefin.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dateheurefin.id }, dateheurefin);
        }

        // DELETE: api/dateheurefins/5
        [ResponseType(typeof(dateheurefin))]
        public async Task<IHttpActionResult> Deletedateheurefin(int id)
        {
            dateheurefin dateheurefin = await db.dateheurefin.FindAsync(id);
            if (dateheurefin == null)
            {
                return NotFound();
            }

            db.dateheurefin.Remove(dateheurefin);
            await db.SaveChangesAsync();

            return Ok(dateheurefin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dateheurefinExists(int id)
        {
            return db.dateheurefin.Count(e => e.id == id) > 0;
        }
    }
}