using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class StrengthTestController : Controller
    {
        // GET: StrengthTest
        [Authorize]
        public ActionResult Index(int id)
        {
            StrTestViewModel strTestViewModel = new StrTestViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            strTestViewModel.FindStrTestById(atletaid);
            return View(strTestViewModel);
        }

        // GET: StrengthTest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StrengthTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StrengthTest/Create
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

        // GET: StrengthTest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StrengthTest/Edit/5
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

        // GET: StrengthTest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StrengthTest/Delete/5
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
