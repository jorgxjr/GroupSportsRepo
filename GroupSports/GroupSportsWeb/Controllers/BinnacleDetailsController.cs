using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupSports.DL.DM;
using GroupSportsWeb.ViewModels;
using GroupSportsWeb.ViewModels.BinnaclesViewModel;

namespace GroupSportsWeb.Controllers
{
    public class BinnacleDetailsController : Controller
    {
        private group_sportsEntities db = new group_sportsEntities();
        // GET: BinnacleDetails
        [Authorize]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session["sessionWorkId"] = id.Value;

            string userId = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachId = lstCoachViewModel.findCoachIDByUser(userId);

            ListBinnacleViewModel listTrainingPlanViewModel = new ListBinnacleViewModel();
            listTrainingPlanViewModel.idSession = id.Value;
            listTrainingPlanViewModel.Fill();
            return View(listTrainingPlanViewModel.ListBinnacle);
        }

        // GET: BinnacleDetails/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            binnacleDetail binnacleDetail = db.binnacleDetail.Find(id);
            if (binnacleDetail == null)
            {
                return HttpNotFound();
            }
            return View(binnacleDetail);
        }

        // GET: BinnacleDetails/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.sessionId = new SelectList(db.session, "id", "id");
            return View();
        }

        // POST: BinnacleDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,detail,available,sessionId")] binnacleDetail binnacleDetail)
        {
            if (ModelState.IsValid)
            {
                binnacleDetail.available = true;
                binnacleDetail.sessionId = (int)Session["sessionWorkId"];
                db.binnacleDetail.Add(binnacleDetail);
                db.SaveChanges();
                return RedirectToAction("Index", "BinnacleDetails", new { id = (int)Session["sessionWorkId"] });
            }

            ViewBag.sessionId = new SelectList(db.session, "id", "id", binnacleDetail.sessionId);
            return View(binnacleDetail);
        }

        // GET: BinnacleDetails/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            binnacleDetail binnacleDetail = db.binnacleDetail.Find(id);
            if (binnacleDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.sessionId = new SelectList(db.session, "id", "id", binnacleDetail.sessionId);
            return View(binnacleDetail);
        }

        // POST: BinnacleDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,detail,available,sessionId")] binnacleDetail binnacleDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binnacleDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "BinnacleDetails", new { id = (int)Session["sessionWorkId"] });
            }
            ViewBag.sessionId = new SelectList(db.session, "id", "id", binnacleDetail.sessionId);
            return View(binnacleDetail);
        }

        // GET: BinnacleDetails/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            binnacleDetail binnacleDetail = db.binnacleDetail.Find(id);
            if (binnacleDetail == null)
            {
                return HttpNotFound();
            }
            return View(binnacleDetail);
        }

        // POST: BinnacleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            binnacleDetail binnacleDetail = db.binnacleDetail.Find(id);
            db.binnacleDetail.Remove(binnacleDetail);
            db.SaveChanges();
            return RedirectToAction("Index", "BinnacleDetails", new { id = (int)Session["sessionWorkId"] });
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
