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
    public class messagesController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/messages
        public IQueryable<messages> Getmessages()
        {
            return db.messages;
        }

        // GET: api/messages/5
        [ResponseType(typeof(List<messages>))]
        public async Task<IHttpActionResult> Getmessages(int id_conversation)
        {
            List<messages> messages = await db.messages.Where(x => x.id_conversation == id_conversation).OrderBy(x => x.DateCreation).ToListAsync();
            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        // PUT: api/messages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmessages(int id, messages messages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messages.id_message)
            {
                return BadRequest();
            }

            db.Entry(messages).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!messagesExists(id))
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

        // POST: api/messages
        [ResponseType(typeof(messages))]
        public async Task<IHttpActionResult> Postmessages(messages messages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.messages.Add(messages);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = messages.id_message }, messages);
        }

        // DELETE: api/messages/5
        [ResponseType(typeof(messages))]
        public async Task<IHttpActionResult> Deletemessages(int id)
        {
            messages messages = await db.messages.FindAsync(id);
            if (messages == null)
            {
                return NotFound();
            }

            db.messages.Remove(messages);
            await db.SaveChangesAsync();

            return Ok(messages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool messagesExists(int id)
        {
            return db.messages.Count(e => e.id_message == id) > 0;
        }
    }
}