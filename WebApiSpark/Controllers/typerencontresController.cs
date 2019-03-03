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
    public class typerencontresController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/typerencontres
        public IQueryable<typerencontre> Gettyperencontre()
        {
            return db.typerencontre;
        }

        [ResponseType(typeof(List<typerencontre>))]
        public async Task<IHttpActionResult> Gettyperencontre(int id)
        {
            List<typerencontre> typerencontre = await db.typerencontre.Where(x => x.idPersonne == id).ToListAsync();
            if (typerencontre == null)
            {
                return NotFound();
            }

            return Ok(typerencontre);
        }


        // GET: api/typerencontres/5
        [ResponseType(typeof(typerencontre))]
        public async Task<IHttpActionResult> Gettyperencontre(int idPersonne, int idSport)
        {
            typerencontre typerencontre = await db.typerencontre.FirstOrDefaultAsync(x => x.idPersonne == idPersonne && x.idSport == idSport);
            if (typerencontre == null)
            {
                return NotFound();
            }

            return Ok(typerencontre);
        }

        // PUT: api/typerencontres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Puttyperencontre(int id, typerencontre typerencontre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typerencontre.id)
            {
                return BadRequest();
            }

            db.Entry(typerencontre).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!typerencontreExists(id))
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

        // POST: api/typerencontres
        [ResponseType(typeof(typerencontre))]
        public async Task<IHttpActionResult> Posttyperencontre(typerencontre typerencontre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.typerencontre.Add(typerencontre);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = typerencontre.id }, typerencontre);
        }

        // DELETE: api/typerencontres/5
        [ResponseType(typeof(typerencontre))]
        public async Task<IHttpActionResult> Deletetyperencontre(int id)
        {
            typerencontre typerencontre = await db.typerencontre.FindAsync(id);
            if (typerencontre == null)
            {
                return NotFound();
            }

            db.typerencontre.Remove(typerencontre);
            await db.SaveChangesAsync();

            return Ok(typerencontre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool typerencontreExists(int id)
        {
            return db.typerencontre.Count(e => e.id == id) > 0;
        }
    }
}