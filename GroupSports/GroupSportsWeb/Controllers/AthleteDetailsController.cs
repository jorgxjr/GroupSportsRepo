using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class AthleteDetailsController : Controller
    {
        // GET: AthleteDetails
        [Authorize]
        public ActionResult Index(int id)
        {
            AthleteDetailsViewModel athleteDetailsViewModel = new AthleteDetailsViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            athleteDetailsViewModel.findById(atletaid);
            return View(athleteDetailsViewModel);
        }

        // GET: AthleteDetails/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AthleteDetails/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AthleteDetails/Create
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

        // GET: AthleteDetails/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AthleteDetails/Edit/5
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

        // GET: AthleteDetails/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AthleteDetails/Delete/5
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
