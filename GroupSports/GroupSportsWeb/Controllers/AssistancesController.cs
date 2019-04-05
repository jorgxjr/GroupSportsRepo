using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using GroupSportsWeb.ViewModels;
using GroupSportsWeb.ViewModels.AssitancesViewModel;
using GroupSportsWeb.ViewModels.SessionsViewModel;

namespace GroupSportsWeb.Controllers
{
    public class AssistancesController : Controller
    {
        private group_sportsEntities db = new group_sportsEntities();

        // GET: TrainingPlans
        [Authorize]
        public ActionResult Index()
        {
            string userId = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachId = lstCoachViewModel.findCoachIDByUser(userId);

            ListSessionsViewModel listTrainingPlanViewModel = new ListSessionsViewModel();
            listTrainingPlanViewModel.coachId = coachId;
            listTrainingPlanViewModel.Fill();
            return View(listTrainingPlanViewModel.ListSessions);
        }

        // GET: TrainingPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string userId = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachId = lstCoachViewModel.findCoachIDByUser(userId);

            ListSessionsViewModel listTrainingPlanViewModel = new ListSessionsViewModel();
            listTrainingPlanViewModel.coachId = coachId;
            listTrainingPlanViewModel.Fill();
            SessionDTO sessionDTO = listTrainingPlanViewModel.ListSessions.FirstOrDefault(x => x.id == id);
            if (sessionDTO == null)
            {
                return HttpNotFound();
            }
            return View(sessionDTO);
        }

        // GET: TrainingPlans/Create
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string userId = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachId = lstCoachViewModel.findCoachIDByUser(userId);

            ListAssitancesViewModel listTrainingPlanViewModel = new ListAssitancesViewModel();
            session session = listTrainingPlanViewModel.getSession(id.Value);
            
            if (session == null)
            {
                return HttpNotFound();
            }

            //ViewBag.athleteId = new SelectList(db.athelete, "id", "id", trainingPlan.athleteId);
            //ViewBag.coachId = new SelectList(db.coach, "id", "id", trainingPlan.coachId);
            return View(session);
        }

        // POST: TrainingPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,attendance,intensityPercentage")] session session)
        {
            ListAssitancesViewModel listTrainingPlanViewModel = new ListAssitancesViewModel();
            listTrainingPlanViewModel.updateSession(session);
            return RedirectToAction("Index");
            //if (ModelState.IsValid)
            //{
            //    db.Entry(trainingPlan).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //ViewBag.athleteId = new SelectList(db.athelete, "id", "id", trainingPlan.athleteId);
            //ViewBag.coachId = new SelectList(db.coach, "id", "id", trainingPlan.coachId);
            //return View(trainingPlan);
        }

        // GET: TrainingPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string userId = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachId = lstCoachViewModel.findCoachIDByUser(userId);

            ListSessionsViewModel listTrainingPlanViewModel = new ListSessionsViewModel();
            listTrainingPlanViewModel.coachId = coachId;
            listTrainingPlanViewModel.Fill();
            SessionDTO sessionDTO = listTrainingPlanViewModel.ListSessions.FirstOrDefault(x => x.id == id);
            if (sessionDTO == null)
            {
                return HttpNotFound();
            }
            return View(sessionDTO);
        }

        // POST: TrainingPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListSessionsViewModel listTrainingPlanViewModel = new ListSessionsViewModel();
            listTrainingPlanViewModel.deleteSession(id);
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
