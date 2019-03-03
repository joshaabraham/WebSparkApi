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
    public class equipesController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/equipes
        public IQueryable<equipe> Getequipe()
        {
            return db.equipe;
        }

        // GET: api/equipes/5
        [ResponseType(typeof(List<equipe>))]
        public async Task<IHttpActionResult> Getequipe(int id)
        {
            List<equipe> equipe = await db.equipe.Where(x=>x.idadmin == id).ToListAsync();
            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

        // PUT: api/equipes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putequipe(int id, equipe equipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipe.id)
            {
                return BadRequest();
            }

            db.Entry(equipe).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!equipeExists(id))
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

        // POST: api/equipes
        [ResponseType(typeof(equipe))]
        public async Task<IHttpActionResult> Postequipe(equipe equipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.equipe.Add(equipe);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = equipe.id }, equipe);
        }

        // DELETE: api/equipes/5
        [ResponseType(typeof(equipe))]
        public async Task<IHttpActionResult> Deleteequipe(int id)
        {
            equipe equipe = await db.equipe.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            db.equipe.Remove(equipe);
            await db.SaveChangesAsync();

            return Ok(equipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool equipeExists(int id)
        {
            return db.equipe.Count(e => e.id == id) > 0;
        }
    }
}