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
    public class maintypesportsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/maintypesports
        public IQueryable<maintypesport> Getmaintypesport()
        {
            return db.maintypesport;
        }

        // GET: api/maintypesports/5
        [ResponseType(typeof(maintypesport))]
        public async Task<IHttpActionResult> Getmaintypesport(int id)
        {
            maintypesport maintypesport = await db.maintypesport.FindAsync(id);
            if (maintypesport == null)
            {
                return NotFound();
            }

            return Ok(maintypesport);
        }

        // PUT: api/maintypesports/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmaintypesport(int id, maintypesport maintypesport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintypesport.id)
            {
                return BadRequest();
            }

            db.Entry(maintypesport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!maintypesportExists(id))
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

        // POST: api/maintypesports
        [ResponseType(typeof(maintypesport))]
        public async Task<IHttpActionResult> Postmaintypesport(maintypesport maintypesport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.maintypesport.Add(maintypesport);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = maintypesport.id }, maintypesport);
        }

        // DELETE: api/maintypesports/5
        [ResponseType(typeof(maintypesport))]
        public async Task<IHttpActionResult> Deletemaintypesport(int id)
        {
            maintypesport maintypesport = await db.maintypesport.FindAsync(id);
            if (maintypesport == null)
            {
                return NotFound();
            }

            db.maintypesport.Remove(maintypesport);
            await db.SaveChangesAsync();

            return Ok(maintypesport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool maintypesportExists(int id)
        {
            return db.maintypesport.Count(e => e.id == id) > 0;
        }
    }
}