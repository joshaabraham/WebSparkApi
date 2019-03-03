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
    public class userslogsController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: userslogs
        public async Task<ActionResult> Index()
        {
            return View(await db.userslog.ToListAsync());
        }

        // GET: userslogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userslog userslog = await db.userslog.FindAsync(id);
            if (userslog == null)
            {
                return HttpNotFound();
            }
            return View(userslog);
        }

        // GET: userslogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userslogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,photo,age,nom,prenom,sex,email,telephone,adresse,lattitude,longitude,idpersonne,idcontact,DateCreation,DateModification")] userslog userslog)
        {
            if (ModelState.IsValid)
            {
                db.userslog.Add(userslog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userslog);
        }

        // GET: userslogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userslog userslog = await db.userslog.FindAsync(id);
            if (userslog == null)
            {
                return HttpNotFound();
            }
            return View(userslog);
        }

        // POST: userslogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,photo,age,nom,prenom,sex,email,telephone,adresse,lattitude,longitude,idpersonne,idcontact,DateCreation,DateModification")] userslog userslog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userslog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userslog);
        }

        // GET: userslogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userslog userslog = await db.userslog.FindAsync(id);
            if (userslog == null)
            {
                return HttpNotFound();
            }
            return View(userslog);
        }

        // POST: userslogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            userslog userslog = await db.userslog.FindAsync(id);
            db.userslog.Remove(userslog);
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
