using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiSpark.Models;

namespace WebApiSpark.Controllers.ControllerView
{
    public class clubsController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: clubs
        public async Task<ActionResult> Index()
        {
            return View(await db.clubs.ToListAsync());
        }

        // GET: clubs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubs clubs = await db.clubs.FindAsync(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // GET: clubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nom,idcontact,logo,idsport,DateCreation,DateModification")] clubs clubs)
        {
            if (ModelState.IsValid)
            {
                db.clubs.Add(clubs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clubs);
        }

        // GET: clubs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubs clubs = await db.clubs.FindAsync(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nom,idcontact,logo,idsport,DateCreation,DateModification")] clubs clubs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clubs);
        }

        // GET: clubs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubs clubs = await db.clubs.FindAsync(id);
            if (clubs == null)
            {
                return HttpNotFound();
            }
            return View(clubs);
        }

        // POST: clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            clubs clubs = await db.clubs.FindAsync(id);
            db.clubs.Remove(clubs);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
