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
    public class evenementsController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: evenements
        public async Task<ActionResult> Index()
        {
            return View(await db.evenement.ToListAsync());
        }

        // GET: evenements/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evenement evenement = await db.evenement.FindAsync(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        // GET: evenements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: evenements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_evenement,titre,iduser,id_article,description,introduction,conclusion,website,datedebut,datefin,id_sport,DateCreation,DateModification")] evenement evenement)
        {
            if (ModelState.IsValid)
            {
                db.evenement.Add(evenement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(evenement);
        }

        // GET: evenements/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evenement evenement = await db.evenement.FindAsync(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        // POST: evenements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_evenement,titre,iduser,id_article,description,introduction,conclusion,website,datedebut,datefin,id_sport,DateCreation,DateModification")] evenement evenement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evenement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(evenement);
        }

        // GET: evenements/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            evenement evenement = await db.evenement.FindAsync(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        // POST: evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            evenement evenement = await db.evenement.FindAsync(id);
            db.evenement.Remove(evenement);
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
