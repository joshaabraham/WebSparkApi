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
    public class tb_sportsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/tb_sports
        public IQueryable<tb_sports> Gettb_sports()
        {
            return db.tb_sports;
        }

        // GET: api/tb_sports/5
        [ResponseType(typeof(tb_sports))]
        public async Task<IHttpActionResult> Gettb_sports(int id)
        {
            tb_sports tb_sports = await db.tb_sports.FindAsync(id);
            if (tb_sports == null)
            {
                return NotFound();
            }

            return Ok(tb_sports);
        }

        // PUT: api/tb_sports/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttb_sports(int id, tb_sports tb_sports)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_sports.id)
            {
                return BadRequest();
            }

            db.Entry(tb_sports).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_sportsExists(id))
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

        // POST: api/tb_sports
        [ResponseType(typeof(tb_sports))]
        public async Task<IHttpActionResult> Posttb_sports(tb_sports tb_sports)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_sports.Add(tb_sports);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tb_sports.id }, tb_sports);
        }

        // DELETE: api/tb_sports/5
        [ResponseType(typeof(tb_sports))]
        public async Task<IHttpActionResult> Deletetb_sports(int id)
        {
            tb_sports tb_sports = await db.tb_sports.FindAsync(id);
            if (tb_sports == null)
            {
                return NotFound();
            }

            db.tb_sports.Remove(tb_sports);
            await db.SaveChangesAsync();

            return Ok(tb_sports);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_sportsExists(int id)
        {
            return db.tb_sports.Count(e => e.id == id) > 0;
        }
    }
}