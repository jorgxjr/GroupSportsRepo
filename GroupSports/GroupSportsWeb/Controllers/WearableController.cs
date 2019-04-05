using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class WearableController : Controller
    {
        // GET: Wearable
        public ActionResult Index(int id)
        {
            WearableViewModel wearableViewModel = new WearableViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            wearableViewModel.wearablebyAthlete(atletaid);
            return View(wearableViewModel);
        }

        // GET: Wearable/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Wearable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wearable/Create
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

        // GET: Wearable/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Wearable/Edit/5
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

        // GET: Wearable/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wearable/Delete/5
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
