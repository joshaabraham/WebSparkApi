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
    public class listejoueurequipesController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: listejoueurequipes
        public async Task<ActionResult> Index()
        {
            return View(await db.listejoueurequipe.ToListAsync());
        }

        // GET: listejoueurequipes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listejoueurequipe listejoueurequipe = await db.listejoueurequipe.FindAsync(id);
            if (listejoueurequipe == null)
            {
                return HttpNotFound();
            }
            return View(listejoueurequipe);
        }

        // GET: listejoueurequipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: listejoueurequipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_team,joueur1,joueur2,joueur3,joueur4,joueur5,joueur6,joueur7,joueur8,joueur9,joueur10,joueur11,joueur12,joueur13,joueur14,joueur15,joueur16,joueur17,joueur18,joueur19,joueur20,joueur21,joueur22,joueur23,joueur24,joueur25,joueur26,joueur27,joueur28,joueur29,joueur30,joueur31,guidteam,DateCreation,DateModification")] listejoueurequipe listejoueurequipe)
        {
            if (ModelState.IsValid)
            {
                db.listejoueurequipe.Add(listejoueurequipe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(listejoueurequipe);
        }

        // GET: listejoueurequipes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listejoueurequipe listejoueurequipe = await db.listejoueurequipe.FindAsync(id);
            if (listejoueurequipe == null)
            {
                return HttpNotFound();
            }
            return View(listejoueurequipe);
        }

        // POST: listejoueurequipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_team,joueur1,joueur2,joueur3,joueur4,joueur5,joueur6,joueur7,joueur8,joueur9,joueur10,joueur11,joueur12,joueur13,joueur14,joueur15,joueur16,joueur17,joueur18,joueur19,joueur20,joueur21,joueur22,joueur23,joueur24,joueur25,joueur26,joueur27,joueur28,joueur29,joueur30,joueur31,guidteam,DateCreation,DateModification")] listejoueurequipe listejoueurequipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listejoueurequipe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(listejoueurequipe);
        }

        // GET: listejoueurequipes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            listejoueurequipe listejoueurequipe = await db.listejoueurequipe.FindAsync(id);
            if (listejoueurequipe == null)
            {
                return HttpNotFound();
            }
            return View(listejoueurequipe);
        }

        // POST: listejoueurequipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            listejoueurequipe listejoueurequipe = await db.listejoueurequipe.FindAsync(id);
            db.listejoueurequipe.Remove(listejoueurequipe);
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
