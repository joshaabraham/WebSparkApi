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
    public class countriesController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/countries
        public IQueryable<country> Getcountry()
        {
            return db.country;
        }

        // GET: api/countries/5
        [ResponseType(typeof(country))]
        public async Task<IHttpActionResult> Getcountry(int id)
        {
            country country = await db.country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT: api/countries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcountry(int id, country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.id)
            {
                return BadRequest();
            }

            db.Entry(country).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!countryExists(id))
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

        // POST: api/countries
        [ResponseType(typeof(country))]
        public async Task<IHttpActionResult> Postcountry(country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.country.Add(country);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (countryExists(country.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = country.id }, country);
        }

        // DELETE: api/countries/5
        [ResponseType(typeof(country))]
        public async Task<IHttpActionResult> Deletecountry(int id)
        {
            country country = await db.country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            db.country.Remove(country);
            await db.SaveChangesAsync();

            return Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool countryExists(int id)
        {
            return db.country.Count(e => e.id == id) > 0;
        }
    }
}