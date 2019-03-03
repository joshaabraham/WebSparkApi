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
    public class companiesController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/companies
        public IQueryable<companie> Getcompanie()
        {
            return db.companie;
        }

        // GET: api/companies/5
        [ResponseType(typeof(companie))]
        public async Task<IHttpActionResult> Getcompanie(int id)
        {
            companie companie = await db.companie.FirstOrDefaultAsync(x=>x.id_user1 == id);
            if (companie == null)
            {
                return NotFound();
            }

            return Ok(companie);
        }

        // PUT: api/companies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcompanie(int id, companie companie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companie.id_compagnie)
            {
                return BadRequest();
            }

            db.Entry(companie).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!companieExists(id))
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

        // POST: api/companies
        [ResponseType(typeof(companie))]
        public async Task<IHttpActionResult> Postcompanie(companie companie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.companie.Add(companie);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (companieExists(companie.id_compagnie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = companie.id_compagnie }, companie);
        }

        // DELETE: api/companies/5
        [ResponseType(typeof(companie))]
        public async Task<IHttpActionResult> Deletecompanie(int id)
        {
            companie companie = await db.companie.FindAsync(id);
            if (companie == null)
            {
                return NotFound();
            }

            db.companie.Remove(companie);
            await db.SaveChangesAsync();

            return Ok(companie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool companieExists(int id)
        {
            return db.companie.Count(e => e.id_compagnie == id) > 0;
        }
    }
}