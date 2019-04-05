using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class AntropometricTestController : Controller
    {
        // GET: AntropometricTest
        [Authorize]
        public ActionResult Index(int id)
        {
            AnthropometricTestViewModel anthropometricTestViewModel = new AnthropometricTestViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            anthropometricTestViewModel.listById(atletaid);
            return View(anthropometricTestViewModel);
        }

        // GET: AntropometricTest/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AntropometricTest/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AntropometricTest/Create
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

        // GET: AntropometricTest/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AntropometricTest/Edit/5
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

        // GET: AntropometricTest/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AntropometricTest/Delete/5
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
