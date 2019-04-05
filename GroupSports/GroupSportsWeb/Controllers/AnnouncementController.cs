using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        [Authorize]
        public ActionResult Index(int id)
        {
            AnnouncementViewModel announcementViewModel = new AnnouncementViewModel();
            string coachID = Session["userID"].ToString();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            int coachi = lstCoachViewModel.findCoachIDByUser(coachID);


            announcementViewModel.FillByCoachID(coachi);
            return View(announcementViewModel);

        }

        // GET: Announcement/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Announcement/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcement/Create
        [HttpPost]
        public ActionResult Create(announcement announcement)
        {
            

                return View();
            
        }

        // GET: Announcement/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Announcement/Edit/5
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

        // GET: Announcement/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Announcement/Delete/5
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
