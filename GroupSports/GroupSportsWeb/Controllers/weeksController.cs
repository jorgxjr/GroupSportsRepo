using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class weeksController : Controller
    {
        private group_sportsEntities db = new group_sportsEntities();

        // GET: weeks
        public ActionResult Index()
        {
            var week = db.week.Include(w => w.mesocycle).Include(w => w.weekType);
            return View(week.ToList());
        }

        // GET: weeks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            week week = db.week.Find(id);
            if (week == null)
            {
                return HttpNotFound();
            }
            return View(week);
        }

        // GET: weeks/Create
        public ActionResult Create()
        {
            ViewBag.mesocycleId = new SelectList(db.mesocycle, "id", "id");
            ViewBag.weekTypeId = new SelectList(db.weekType, "id", "description");
            return View();
        }

        // POST: weeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,weekTypeId,startDate,endDate,mesocycleId,activity,available")] week week)
        {
            if (ModelState.IsValid)
            {
                db.week.Add(week);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mesocycleId = new SelectList(db.mesocycle, "id", "id", week.mesocycleId);
            ViewBag.weekTypeId = new SelectList(db.weekType, "id", "description", week.weekTypeId);
            return View(week);
        }

        // GET: weeks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            week week = db.week.Find(id);
            if (week == null)
            {
                return HttpNotFound();
            }
            ViewBag.mesocycleId = new SelectList(db.mesocycle, "id", "id", week.mesocycleId);
            ViewBag.weekTypeId = new SelectList(db.weekType, "id", "description", week.weekTypeId);
            return View(week);
        }

        // POST: weeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,weekTypeId,startDate,endDate,mesocycleId,activity,available")] week week)
        {
            if (ModelState.IsValid)
            {
                db.Entry(week).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mesocycleId = new SelectList(db.mesocycle, "id", "id", week.mesocycleId);
            ViewBag.weekTypeId = new SelectList(db.weekType, "id", "description", week.weekTypeId);
            return View(week);
        }

        // GET: weeks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            week week = db.week.Find(id);
            if (week == null)
            {
                return HttpNotFound();
            }
            return View(week);
        }

        // POST: weeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            week week = db.week.Find(id);
            db.week.Remove(week);
            db.SaveChanges();
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
