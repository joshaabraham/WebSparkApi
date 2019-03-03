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
    public class articlesController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/articles
        public IQueryable<article> Getarticle()
        {
            return db.article.OrderByDescending(x => x.DateModification);
        }

        // GET: api/articles/5
        [ResponseType(typeof(article))]
        public async Task<IHttpActionResult> Getarticle(int id)
        {
            article article = await db.article.FirstOrDefaultAsync(x=>x.id_personnes == id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT: api/articles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putarticle(int id, article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.id_article)
            {
                return BadRequest();
            }

            db.Entry(article).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!articleExists(id))
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

        // POST: api/articles
        [ResponseType(typeof(article))]
        public async Task<IHttpActionResult> Postarticle(article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.article.Add(article);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = article.id_article }, article);
        }

        // DELETE: api/articles/5
        [ResponseType(typeof(article))]
        public async Task<IHttpActionResult> Deletearticle(int id)
        {
            article article = await db.article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            db.article.Remove(article);
            await db.SaveChangesAsync();

            return Ok(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool articleExists(int id)
        {
            return db.article.Count(e => e.id_article == id) > 0;
        }
    }
}