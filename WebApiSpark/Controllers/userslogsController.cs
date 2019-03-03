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
    public class userslogsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/userslogs
        [ResponseType(typeof(List<userslog>))]
        public async Task<IHttpActionResult> Getuserslog()
        {
            List<userslog> userslog = await db.userslog.ToListAsync();
            if (userslog == null)
            {
                return NotFound();
            }

            return Ok(userslog);
        }
        
        // GET: api/userslogs/5
        [ResponseType(typeof(userslog))]
        public async Task<IHttpActionResult> Getuserslog(int id)
        {
            userslog userslog = await db.userslog.FirstOrDefaultAsync(x=>x.idpersonne == id);
            if (userslog == null)
            {
                return NotFound();
            }

            return Ok(userslog);
        }

        // GET: api/userslogs/5/1.25/2.654
        [ResponseType(typeof(List<userslog>))]
        public async Task<IHttpActionResult> Getuserslog(int id, float lat, float longi)
        {
            List<userslog> userslog = await db.userslog.Where(x => Convert.ToDouble(x.lattitude) < lat && Convert.ToDouble(x.longitude) < longi).OrderByDescending(x => x.DateModification).ToListAsync();
            if (userslog == null)
            {
                return NotFound();
            }

            return Ok(userslog);
        }

        // PUT: api/userslogs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putuserslog(int id, userslog userslog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userslog.id)
            {
                return BadRequest();
            }

            db.Entry(userslog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userslogExists(id))
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

        // POST: api/userslogs
        [ResponseType(typeof(userslog))]
        public async Task<IHttpActionResult> Postuserslog(userslog userslog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.userslog.Add(userslog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userslog.id }, userslog);
        }

        // DELETE: api/userslogs/5
        [ResponseType(typeof(userslog))]
        public async Task<IHttpActionResult> Deleteuserslog(int id)
        {
            userslog userslog = await db.userslog.FindAsync(id);
            if (userslog == null)
            {
                return NotFound();
            }

            db.userslog.Remove(userslog);
            await db.SaveChangesAsync();

            return Ok(userslog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool userslogExists(int id)
        {
            return db.userslog.Count(e => e.id == id) > 0;
        }
    }
}