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

namespace GroupSportsWeb.Controllers
{
    public class TeamsController : Controller
    {
        private group_sportsEntities db = new group_sportsEntities();

        // GET: Teams
        public ActionResult Index()
        {
            LstTeamViewModel listar = new LstTeamViewModel();
            listar.FindAll();
            return View(listar);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            LstTeamViewModel lstTeam = new LstTeamViewModel();
            lstTeam.FindById(id);
            return View(lstTeam);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            ViewBag.coachId = new SelectList(db.coach, "id", "id");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(team team)
        {
            if (team != null)
            {
                AddTeamViewModel lstteam = new AddTeamViewModel();
                //ViewBag.coachId = new SelectList(db.coach, "id", "id", team.coachId);
                lstteam.AddTeam(team);
                return RedirectToAction("Index");
            }
          

            
            return View(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
           
            EditTeamViewModel editTeamViewModel = new EditTeamViewModel();
           editTeamViewModel.FindTeam(id);
            
            var team = db.team.Find(id);
            //ViewBag.coachId = new SelectList(db.coach, "id", "id", team.coachId);
            return View(editTeamViewModel);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(team team)
        {
            if (team != null)
            {
                EditTeamViewModel editTeamViewModel = new EditTeamViewModel();
                editTeamViewModel.EditTeam(team);
                return RedirectToAction("Index");
            }
            //ViewBag.coachId = new SelectList(db.coach, "id", "id", team.coachId);
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteTeamViewModel deleteTeamViewModel = new DeleteTeamViewModel();
            deleteTeamViewModel.FindById(id);
            return View(deleteTeamViewModel);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id != 0)
            {
                DeleteTeamViewModel deleteTeamViewModel = new DeleteTeamViewModel();
                deleteTeamViewModel.DeleteTeam(id);
                return View(deleteTeamViewModel);
            }
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
