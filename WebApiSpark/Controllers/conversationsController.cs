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
    public class conversationsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/conversations
        public IQueryable<conversation> Getconversation()
        {
            return db.conversation;
        }

        // GET: api/conversations/5
        [ResponseType(typeof(List<conversation>))]
        public async Task<IHttpActionResult> Getconversation(int idUser1)
        {
            List<conversation> conversation = await db.conversation.Where(x => x.id_user1 == idUser1|| x.id_user2 == idUser1).OrderByDescending(x => x.DateModification).ToListAsync();
            if (conversation == null)
            {
                return NotFound();
            }

            return Ok(conversation);
        }

        // PUT: api/conversations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putconversation(int id, conversation conversation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conversation.id_conversation)
            {
                return BadRequest();
            }

            db.Entry(conversation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!conversationExists(id))
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

        // POST: api/conversations
        [ResponseType(typeof(conversation))]
        public async Task<IHttpActionResult> Postconversation(conversation conversation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.conversation.Add(conversation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = conversation.id_conversation }, conversation);
        }

        // DELETE: api/conversations/5
        [ResponseType(typeof(conversation))]
        public async Task<IHttpActionResult> Deleteconversation(int id)
        {
            conversation conversation = await db.conversation.FindAsync(id);
            if (conversation == null)
            {
                return NotFound();
            }

            db.conversation.Remove(conversation);
            await db.SaveChangesAsync();

            return Ok(conversation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool conversationExists(int id)
        {
            return db.conversation.Count(e => e.id_conversation == id) > 0;
        }
    }
}