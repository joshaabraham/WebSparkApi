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
    public class listejoueurequipesController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/listejoueurequipes
        public IQueryable<listejoueurequipe> Getlistejoueurequipe()
        {
            return db.listejoueurequipe;
        }

        // GET: api/listejoueurequipes/5
        [ResponseType(typeof(listejoueurequipe))]
        public async Task<IHttpActionResult> Getlistejoueurequipe(int id)
        {
            listejoueurequipe listejoueurequipe = await db.listejoueurequipe.FindAsync(id);
            if (listejoueurequipe == null)
            {
                return NotFound();
            }

            return Ok(listejoueurequipe);
        }

        // PUT: api/listejoueurequipes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putlistejoueurequipe(int id, listejoueurequipe listejoueurequipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listejoueurequipe.id_team)
            {
                return BadRequest();
            }

            db.Entry(listejoueurequipe).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!listejoueurequipeExists(id))
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

        // POST: api/listejoueurequipes
        [ResponseType(typeof(listejoueurequipe))]
        public async Task<IHttpActionResult> Postlistejoueurequipe(listejoueurequipe listejoueurequipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.listejoueurequipe.Add(listejoueurequipe);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (listejoueurequipeExists(listejoueurequipe.id_team))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = listejoueurequipe.id_team }, listejoueurequipe);
        }

        // DELETE: api/listejoueurequipes/5
        [ResponseType(typeof(listejoueurequipe))]
        public async Task<IHttpActionResult> Deletelistejoueurequipe(int id)
        {
            listejoueurequipe listejoueurequipe = await db.listejoueurequipe.FindAsync(id);
            if (listejoueurequipe == null)
            {
                return NotFound();
            }

            db.listejoueurequipe.Remove(listejoueurequipe);
            await db.SaveChangesAsync();

            return Ok(listejoueurequipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool listejoueurequipeExists(int id)
        {
            return db.listejoueurequipe.Count(e => e.id_team == id) > 0;
        }
    }
}