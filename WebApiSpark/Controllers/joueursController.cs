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
    public class joueursController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();
        
        // GET: api/joueurs
        public IQueryable<joueurs> Getjoueurs()
        {
            return db.joueurs;
        }

        // GET: api/joueurs/5
/*
        [ResponseType(typeof(List<joueurs>))]
        public async Task<IHttpActionResult> Getjoueurs(int iduser,int idsport)
        {
            List<joueurs> joueurs = await db.joueurs.Where(x => x.idpersonne != iduser && x.idsport == idsport).OrderBy(x => x.ratingsatisfaction).ToListAsync();
            if (joueurs == null)
            {
                return NotFound();
            }

            return Ok(joueurs);
        }
       */

        // GET: api/joueurs/5
        [ResponseType(typeof(joueurs))]
        public async Task<IHttpActionResult> Getjoueur(int iduser, int idsport)
        {
           joueurs joueurs = await db.joueurs.FirstOrDefaultAsync(x => x.idpersonne ==  iduser && x.idsport == idsport);
            if (joueurs == null)
            {
                return NotFound();
            }

            return Ok(joueurs);
        }
        
        [ResponseType(typeof(joueurs))]
        public async Task<IHttpActionResult> Getjoueur(int id)
        {
            joueurs joueurs = await db.joueurs.SingleOrDefaultAsync(x => x.idpersonne == id);
            if (joueurs == null)
            {
                return NotFound();
            }

            return Ok(joueurs);
        }
        
        // PUT: api/joueurs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putjoueurs(int id, joueurs joueurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != joueurs.id)
            {
                return BadRequest();
            }

            db.Entry(joueurs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!joueursExists(id))
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

        // POST: api/joueurs
        [ResponseType(typeof(joueurs))]
        public async Task<IHttpActionResult> Postjoueurs(joueurs joueurs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.joueurs.Add(joueurs);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = joueurs.id }, joueurs);
        }

        // DELETE: api/joueurs/5
        [ResponseType(typeof(joueurs))]
        public async Task<IHttpActionResult> Deletejoueurs(int id)
        {
            joueurs joueurs = await db.joueurs.FindAsync(id);
            if (joueurs == null)
            {
                return NotFound();
            }

            db.joueurs.Remove(joueurs);
            await db.SaveChangesAsync();

            return Ok(joueurs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool joueursExists(int id)
        {
            return db.joueurs.Count(e => e.id == id) > 0;
        }
    }
}