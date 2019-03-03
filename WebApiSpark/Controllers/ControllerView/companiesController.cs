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
    public class companiesController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: companies
        public async Task<ActionResult> Index()
        {
            return View(await db.companie.ToListAsync());
        }

        // GET: companies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            companie companie = await db.companie.FindAsync(id);
            if (companie == null)
            {
                return HttpNotFound();
            }
            return View(companie);
        }

        // GET: companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_compagnie,guid,nom,id_contact,guid_contact,website,id_user1,id_user2,id_user3,logo,idsport,DateCreation,DateModification")] companie companie)
        {
            if (ModelState.IsValid)
            {
                db.companie.Add(companie);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(companie);
        }

        // GET: companies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            companie companie = await db.companie.FindAsync(id);
            if (companie == null)
            {
                return HttpNotFound();
            }
            return View(companie);
        }

        // POST: companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_compagnie,guid,nom,id_contact,guid_contact,website,id_user1,id_user2,id_user3,logo,idsport,DateCreation,DateModification")] companie companie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companie).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companie);
        }

        // GET: companies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            companie companie = await db.companie.FindAsync(id);
            if (companie == null)
            {
                return HttpNotFound();
            }
            return View(companie);
        }

        // POST: companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            companie companie = await db.companie.FindAsync(id);
            db.companie.Remove(companie);
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
