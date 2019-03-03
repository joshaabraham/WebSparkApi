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
    public class contactsController : ApiController
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: api/contacts
        public IQueryable<contact> Getcontact()
        {
            return db.contact;
        }

        // GET: api/contacts/5
        [ResponseType(typeof(contact))]
        public async Task<IHttpActionResult> Getcontact(int id)
        {
            contact contact = await db.contact.FirstOrDefaultAsync(x=>x.id_contact == id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // PUT: api/contacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcontact(int id, contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.id_contact)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contactExists(id))
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

        // POST: api/contacts
        [ResponseType(typeof(contact))]
        public async Task<IHttpActionResult> Postcontact(contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.contact.Add(contact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contact.id_contact }, contact);
        }

        // DELETE: api/contacts/5
        [ResponseType(typeof(contact))]
        public async Task<IHttpActionResult> Deletecontact(int id)
        {
            contact contact = await db.contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.contact.Remove(contact);
            await db.SaveChangesAsync();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool contactExists(int id)
        {
            return db.contact.Count(e => e.id_contact == id) > 0;
        }
    }
}