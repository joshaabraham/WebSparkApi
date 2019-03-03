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
    public class typerencontresController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: typerencontres
        public async Task<ActionResult> Index()
        {
            return View(await db.typerencontre.ToListAsync());
        }

        // GET: typerencontres/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typerencontre typerencontre = await db.typerencontre.FindAsync(id);
            if (typerencontre == null)
            {
                return HttpNotFound();
            }
            return View(typerencontre);
        }

        // GET: typerencontres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: typerencontres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idPersonne,idSport,reprise,competition,entrainement,amical")] typerencontre typerencontre)
        {
            if (ModelState.IsValid)
            {
                db.typerencontre.Add(typerencontre);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(typerencontre);
        }

        // GET: typerencontres/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typerencontre typerencontre = await db.typerencontre.FindAsync(id);
            if (typerencontre == null)
            {
                return HttpNotFound();
            }
            return View(typerencontre);
        }

        // POST: typerencontres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idPersonne,idSport,reprise,competition,entrainement,amical")] typerencontre typerencontre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typerencontre).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(typerencontre);
        }

        // GET: typerencontres/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typerencontre typerencontre = await db.typerencontre.FindAsync(id);
            if (typerencontre == null)
            {
                return HttpNotFound();
            }
            return View(typerencontre);
        }

        // POST: typerencontres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            typerencontre typerencontre = await db.typerencontre.FindAsync(id);
            db.typerencontre.Remove(typerencontre);
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
