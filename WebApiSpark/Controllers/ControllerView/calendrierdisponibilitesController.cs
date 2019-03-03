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
    public class calendrierdisponibilitesController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: calendrierdisponibilites
        public async Task<ActionResult> Index()
        {
            return View(await db.calendrierdisponibilite.ToListAsync());
        }

        // GET: calendrierdisponibilites/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calendrierdisponibilite calendrierdisponibilite = await db.calendrierdisponibilite.FindAsync(id);
            if (calendrierdisponibilite == null)
            {
                return HttpNotFound();
            }
            return View(calendrierdisponibilite);
        }

        // GET: calendrierdisponibilites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: calendrierdisponibilites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idcalendrier,iduser,lundimatin,lundiapmidi,lundisoir,mardimatin,mardiapmidi,mardisoir,mercredimatin,mercrediapmidi,mercredisoir,jeudimatin,jeudiapmidi,jeudisoir,vendredimatin,vendrediapmidi,vendredisoir,weekendmatin,weekendapmidi,weekendsoir,DateModification,tstBool")] calendrierdisponibilite calendrierdisponibilite)
        {
            if (ModelState.IsValid)
            {
                db.calendrierdisponibilite.Add(calendrierdisponibilite);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(calendrierdisponibilite);
        }

        // GET: calendrierdisponibilites/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calendrierdisponibilite calendrierdisponibilite = await db.calendrierdisponibilite.FindAsync(id);
            if (calendrierdisponibilite == null)
            {
                return HttpNotFound();
            }
            return View(calendrierdisponibilite);
        }

        // POST: calendrierdisponibilites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idcalendrier,iduser,lundimatin,lundiapmidi,lundisoir,mardimatin,mardiapmidi,mardisoir,mercredimatin,mercrediapmidi,mercredisoir,jeudimatin,jeudiapmidi,jeudisoir,vendredimatin,vendrediapmidi,vendredisoir,weekendmatin,weekendapmidi,weekendsoir,DateModification,tstBool")] calendrierdisponibilite calendrierdisponibilite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendrierdisponibilite).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(calendrierdisponibilite);
        }

        // GET: calendrierdisponibilites/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            calendrierdisponibilite calendrierdisponibilite = await db.calendrierdisponibilite.FindAsync(id);
            if (calendrierdisponibilite == null)
            {
                return HttpNotFound();
            }
            return View(calendrierdisponibilite);
        }

        // POST: calendrierdisponibilites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            calendrierdisponibilite calendrierdisponibilite = await db.calendrierdisponibilite.FindAsync(id);
            db.calendrierdisponibilite.Remove(calendrierdisponibilite);
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
