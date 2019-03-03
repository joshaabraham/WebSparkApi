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

namespace WebApiSpark.Controllers.ControllerView
{
    public class classificationsportsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/classificationsports
        public IQueryable<classificationsport> Getclassificationsport()
        {
            return db.classificationsport;
        }

        // GET: api/classificationsports/5
        [ResponseType(typeof(classificationsport))]
        public async Task<IHttpActionResult> Getclassificationsport(int id)
        {
            classificationsport classificationsport = await db.classificationsport.FindAsync(id);
            if (classificationsport == null)
            {
                return NotFound();
            }

            return Ok(classificationsport);
        }

        // PUT: api/classificationsports/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putclassificationsport(int id, classificationsport classificationsport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classificationsport.id)
            {
                return BadRequest();
            }

            db.Entry(classificationsport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!classificationsportExists(id))
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

        // POST: api/classificationsports
        [ResponseType(typeof(classificationsport))]
        public async Task<IHttpActionResult> Postclassificationsport(classificationsport classificationsport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.classificationsport.Add(classificationsport);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = classificationsport.id }, classificationsport);
        }

        // DELETE: api/classificationsports/5
        [ResponseType(typeof(classificationsport))]
        public async Task<IHttpActionResult> Deleteclassificationsport(int id)
        {
            classificationsport classificationsport = await db.classificationsport.FindAsync(id);
            if (classificationsport == null)
            {
                return NotFound();
            }

            db.classificationsport.Remove(classificationsport);
            await db.SaveChangesAsync();

            return Ok(classificationsport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool classificationsportExists(int id)
        {
            return db.classificationsport.Count(e => e.id == id) > 0;
        }
    }
}