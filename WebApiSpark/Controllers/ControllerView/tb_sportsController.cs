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
    public class tb_sportsController : Controller
    {
        private langma146884com33525_dev_saprkEntities db = new langma146884com33525_dev_saprkEntities();

        // GET: tb_sports
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_sports.ToListAsync());
        }

        // GET: tb_sports/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sports tb_sports = await db.tb_sports.FindAsync(id);
            if (tb_sports == null)
            {
                return HttpNotFound();
            }
            return View(tb_sports);
        }

        // GET: tb_sports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_sports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,sporttitre,FK_Subclasse_sport,FK_classifications_sport,typeSport")] tb_sports tb_sports)
        {
            if (ModelState.IsValid)
            {
                db.tb_sports.Add(tb_sports);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_sports);
        }

        // GET: tb_sports/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sports tb_sports = await db.tb_sports.FindAsync(id);
            if (tb_sports == null)
            {
                return HttpNotFound();
            }
            return View(tb_sports);
        }

        // POST: tb_sports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,sporttitre,FK_Subclasse_sport,FK_classifications_sport,typeSport")] tb_sports tb_sports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_sports).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_sports);
        }

        // GET: tb_sports/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sports tb_sports = await db.tb_sports.FindAsync(id);
            if (tb_sports == null)
            {
                return HttpNotFound();
            }
            return View(tb_sports);
        }

        // POST: tb_sports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_sports tb_sports = await db.tb_sports.FindAsync(id);
            db.tb_sports.Remove(tb_sports);
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
