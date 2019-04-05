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
using GroupSportsWeb.ViewModels.MesocyclesViewModel;

namespace GroupSportsWeb.Controllers
{
    public class MesocyclesController : Controller
    {
        private group_sportsEntities db = new group_sportsEntities();

        // GET: Mesocycles
        [Authorize]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session["tpId"] = id.Value;
            
            string userId = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachId = lstCoachViewModel.findCoachIDByUser(userId);

            ListMesocyclesViewModel listTrainingPlanViewModel = new ListMesocyclesViewModel();
            listTrainingPlanViewModel.idTP = id.Value;
            listTrainingPlanViewModel.Fill();
            return View(listTrainingPlanViewModel.List);
        }

        // GET: Mesocycles/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesocycle mesocycle = db.mesocycle.Find(id);
            if (mesocycle == null)
            {
                return HttpNotFound();
            }
            return View(mesocycle);
        }

        // GET: Mesocycles/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.mesocycleTypeId = new SelectList(db.mesocycleType, "id", "mesocycleName");
            ViewBag.trainingPlanId = new SelectList(db.trainingPlan, "id", "name");
            return View();
        }

        // POST: Mesocycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,trainingPlanId,numberOfIntenseWeeks,numberOfRestWeeks,startDate,endDate,mesocycleTypeId,available")] mesocycle mesocycle)
        {
            if (ModelState.IsValid)
            {
                db.mesocycle.Add(mesocycle);
                db.SaveChanges();
                return RedirectToAction("Index", "Mesocycles", new { id = (int)Session["tpId"] });
            }

            ViewBag.mesocycleTypeId = new SelectList(db.mesocycleType, "id", "mesocycleName", mesocycle.mesocycleTypeId);
            ViewBag.trainingPlanId = new SelectList(db.trainingPlan, "id", "name", mesocycle.trainingPlanId);
            return View(mesocycle);
        }

        // GET: Mesocycles/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesocycle mesocycle = db.mesocycle.Find(id);
            if (mesocycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.mesocycleTypeId = new SelectList(db.mesocycleType, "id", "mesocycleName", mesocycle.mesocycleTypeId);
            ViewBag.trainingPlanId = new SelectList(db.trainingPlan, "id", "name", mesocycle.trainingPlanId);
            return View(mesocycle);
        }

        // POST: Mesocycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,trainingPlanId,numberOfIntenseWeeks,numberOfRestWeeks,startDate,endDate,mesocycleTypeId,available")] mesocycle mesocycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mesocycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Mesocycles", new { id = (int)Session["tpId"] });
            }
            ViewBag.mesocycleTypeId = new SelectList(db.mesocycleType, "id", "mesocycleName", mesocycle.mesocycleTypeId);
            ViewBag.trainingPlanId = new SelectList(db.trainingPlan, "id", "name", mesocycle.trainingPlanId);
            return View(mesocycle);
        }

        // GET: Mesocycles/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mesocycle mesocycle = db.mesocycle.Find(id);
            if (mesocycle == null)
            {
                return HttpNotFound();
            }
            return View(mesocycle);
        }

        // POST: Mesocycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mesocycle mesocycle = db.mesocycle.Find(id);
            db.mesocycle.Remove(mesocycle);
            db.SaveChanges();
            return RedirectToAction("Index", "Mesocycles", new { id = (int)Session["tpId"] });
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
