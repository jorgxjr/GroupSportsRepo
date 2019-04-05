using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class ShotPutTestController : Controller
    {
        // GET: ShotPutTest
        [Authorize]
        public ActionResult Index(int id)
        {
            ShotPutTestViewModel shotPutTestViewModel = new ShotPutTestViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            shotPutTestViewModel.FindById(atletaid);
            return View(shotPutTestViewModel);
        }

        // GET: ShotPutTest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShotPutTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShotPutTest/Create
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

        // GET: ShotPutTest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShotPutTest/Edit/5
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

        // GET: ShotPutTest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShotPutTest/Delete/5
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
