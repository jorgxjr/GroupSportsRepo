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
using GroupSportsWeb.ViewModels.TrainingPlanViewModel;

namespace GroupSportsWeb.Controllers
{
    public class TrainingPlansController : Controller
    {
        private group_sportsEntities db = new group_sportsEntities();

        // GET: TrainingPlans
        [Authorize]
        public ActionResult Index()
        {
            string userId = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachId = lstCoachViewModel.findCoachIDByUser(userId);
            
            ListTrainingPlanViewModel listTrainingPlanViewModel = new ListTrainingPlanViewModel();
            listTrainingPlanViewModel.idCoach = coachId;
            listTrainingPlanViewModel.Fill();
           

            return View(listTrainingPlanViewModel.ListTrainingPlan);
        }

        // GET: TrainingPlans/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingPlan trainingPlan = db.trainingPlan.Find(id);
            if (trainingPlan == null)
            {
                return HttpNotFound();
            }
            return View(trainingPlan);
        }

        // GET: TrainingPlans/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.athleteId = new SelectList(db.athelete, "id", "id");
            ViewBag.coachId = new SelectList(db.coach, "id", "id");
            return View();
        }

        // POST: TrainingPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,startDate,endDate,coachId,athleteId,available")] trainingPlan trainingPlan)
        {
            if (ModelState.IsValid)
            {
                db.trainingPlan.Add(trainingPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.athleteId = new SelectList(db.athelete, "id", "id", trainingPlan.athleteId);
            ViewBag.coachId = new SelectList(db.coach, "id", "id", trainingPlan.coachId);
            return View(trainingPlan);
        }

        // GET: TrainingPlans/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingPlan trainingPlan = db.trainingPlan.Find(id);
            if (trainingPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.athleteId = new SelectList(db.athelete, "id", "id", trainingPlan.athleteId);
            ViewBag.coachId = new SelectList(db.coach, "id", "id", trainingPlan.coachId);
            return View(trainingPlan);
        }

        // POST: TrainingPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,startDate,endDate,coachId,athleteId,available")] trainingPlan trainingPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.athleteId = new SelectList(db.athelete, "id", "id", trainingPlan.athleteId);
            ViewBag.coachId = new SelectList(db.coach, "id", "id", trainingPlan.coachId);
            return View(trainingPlan);
        }

        // GET: TrainingPlans/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingPlan trainingPlan = db.trainingPlan.Find(id);
            if (trainingPlan == null)
            {
                return HttpNotFound();
            }
            return View(trainingPlan);
        }

        // POST: TrainingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainingPlan trainingPlan = db.trainingPlan.Find(id);
            db.trainingPlan.Remove(trainingPlan);
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
