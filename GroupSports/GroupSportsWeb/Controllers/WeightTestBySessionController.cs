using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSports.DL.DM;
using GroupSportsWeb.ViewModels;

namespace GroupSportsWeb.Controllers
{
    public class WeightTestBySessionController : Controller
    {
        // GET: WeightTestBySession
        [Authorize]
        public ActionResult Index(int id)
        {
            WeightTestBySessionViewModel weightTestBySessionViewModel = new WeightTestBySessionViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            weightTestBySessionViewModel.findById(atletaid);
            return View(weightTestBySessionViewModel);
        }

        // GET: WeightTestBySession/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeightTestBySession/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeightTestBySession/Create
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

        // GET: WeightTestBySession/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeightTestBySession/Edit/5
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

        // GET: WeightTestBySession/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeightTestBySession/Delete/5
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
