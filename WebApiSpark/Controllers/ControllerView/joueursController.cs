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
    public class joueursController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: joueurs
        public async Task<ActionResult> Index()
        {
            return View(await db.joueurs.ToListAsync());
        }

        // GET: joueurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            joueurs joueurs = await db.joueurs.FindAsync(id);
            if (joueurs == null)
            {
                return HttpNotFound();
            }
            return View(joueurs);
        }

        // GET: joueurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: joueurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idpersonne,id_niveau,ratingsatisfaction,idsport,idcalendrierdisponibilite,idtyperencontre,DateCreation,Datemodification")] joueurs joueurs)
        {
            if (ModelState.IsValid)
            {
                db.joueurs.Add(joueurs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(joueurs);
        }

        // GET: joueurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            joueurs joueurs = await db.joueurs.FindAsync(id);
            if (joueurs == null)
            {
                return HttpNotFound();
            }
            return View(joueurs);
        }

        // POST: joueurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idpersonne,id_niveau,ratingsatisfaction,idsport,idcalendrierdisponibilite,idtyperencontre,DateCreation,Datemodification")] joueurs joueurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joueurs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(joueurs);
        }

        // GET: joueurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            joueurs joueurs = await db.joueurs.FindAsync(id);
            if (joueurs == null)
            {
                return HttpNotFound();
            }
            return View(joueurs);
        }

        // POST: joueurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            joueurs joueurs = await db.joueurs.FindAsync(id);
            db.joueurs.Remove(joueurs);
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
