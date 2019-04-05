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
using GroupSportsWeb.ViewModels.QuizsViewModel;

namespace GroupSportsWeb.Controllers
{
    public class QuizsController : Controller
    {
        private group_sportsEntities db = new group_sportsEntities();

        // GET: Quizs
        [Authorize]
        public ActionResult Index()
        {
            string userId = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachId = lstCoachViewModel.findCoachIDByUser(userId);

            ListQuizsPlanViewModel listTrainingPlanViewModel = new ListQuizsPlanViewModel();
            listTrainingPlanViewModel.idCoach = coachId;
            listTrainingPlanViewModel.Fill();
            return View(listTrainingPlanViewModel.ListQuizs);
        }

        // GET: Quizs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiz quiz = db.quiz.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quizs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.coachId = new SelectList(db.coach, "id", "id");
            return View();
        }

        // POST: Quizs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,coachId,quizTitle,date,available")] quiz quiz)
        {
            if (ModelState.IsValid)
            {
                quiz.available = true;
                quiz.coachId = (int)Session["userID"];
                quiz.date = DateTime.Today;
                db.quiz.Add(quiz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.coachId = new SelectList(db.coach, "id", "id", quiz.coachId);
            return View(quiz);
        }

        // GET: Quizs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiz quiz = db.quiz.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            ViewBag.coachId = new SelectList(db.coach, "id", "id", quiz.coachId);
            return View(quiz);
        }

        // POST: Quizs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,coachId,quizTitle,date,available")] quiz quiz)
        {
            if (ModelState.IsValid)
            {
                quiz.available = true;
                quiz.coachId = (int)Session["userID"];
                db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coachId = new SelectList(db.coach, "id", "id", quiz.coachId);
            return View(quiz);
        }

        // GET: Quizs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quiz quiz = db.quiz.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            quiz quiz = db.quiz.Find(id);
            db.quiz.Remove(quiz);
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
