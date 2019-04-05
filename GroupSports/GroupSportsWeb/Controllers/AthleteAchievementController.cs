using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSports.DL.DM;
using GroupSportsWeb.ViewModels;

namespace GroupSportsWeb.Controllers
{
    public class AthleteAchievementController : Controller
    {
        // GET: AthleteAchievement
        [Authorize]
        public ActionResult Index(int id)
        {
            AthleteAchievementViewModel athleteAchievementViewModel = new AthleteAchievementViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            athleteAchievementViewModel.FillById(atletaid);
            return View(athleteAchievementViewModel);
        }

        // GET: AthleteAchievement/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AthleteAchievement/
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AthleteAchievement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AthleteAchievement/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AthleteAchievement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AthleteAchievement/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AthleteAchievement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
