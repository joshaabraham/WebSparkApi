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
    public class niveauxController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/niveaux
        public IQueryable<niveau> Getniveau()
        {
            return db.niveau;
        }

        // GET: api/niveaux/5
        [ResponseType(typeof(niveau))]
        public async Task<IHttpActionResult> Getniveau(int idpersonne, string idsport)
        {
            niveau niveau = await db.niveau.FirstOrDefaultAsync(x => x.idPersonne == idpersonne && x.idsport ==  idsport);
            if (niveau == null)
            {
                return NotFound();
            }

            return Ok(niveau);
        }

        [ResponseType(typeof(List<niveau>))]
        public async Task<IHttpActionResult> Getniveau(int idpersonne)
        {
            List<niveau> niveau = await db.niveau.Where(x => x.idPersonne == idpersonne).ToListAsync();
            if (niveau == null)
            {
                return NotFound();
            }

            return Ok(niveau);
        }

        // PUT: api/niveaux/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putniveau(int id, niveau niveau)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != niveau.id)
            {
                return BadRequest();
            }

            db.Entry(niveau).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!niveauExists(id))
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

        // POST: api/niveaux
        [ResponseType(typeof(niveau))]
        public async Task<IHttpActionResult> Postniveau(niveau niveau)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.niveau.Add(niveau);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = niveau.id }, niveau);
        }

        // DELETE: api/niveaux/5
        [ResponseType(typeof(niveau))]
        public async Task<IHttpActionResult> Deleteniveau(int id)
        {
            niveau niveau = await db.niveau.FindAsync(id);
            if (niveau == null)
            {
                return NotFound();
            }

            db.niveau.Remove(niveau);
            await db.SaveChangesAsync();

            return Ok(niveau);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool niveauExists(int id)
        {
            return db.niveau.Count(e => e.id == id) > 0;
        }
    }
}