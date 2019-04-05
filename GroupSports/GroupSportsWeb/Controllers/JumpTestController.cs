using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class JumpTestController : Controller
    {
        // GET: JumpTest
        [Authorize]
        public ActionResult Index(int id)
        {
            JumpTestViewModel jumpTestViewModel = new JumpTestViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            jumpTestViewModel.listJumpById(atletaid);
            return View(jumpTestViewModel);
        }

        public ActionResult GetData()
        {
            JumpTestViewModel jumpTestViewModel = new JumpTestViewModel();

            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            jumpTestViewModel.listJumpById(atletaid);
            jumpTestViewModel.listJumpById2(atletaid);
            var lisT1 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT1 = new string[jumpTestViewModel.listJumpTest.Count()];
            var lisT2 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT2 = new string[jumpTestViewModel.listJumpTest.Count()];
            var lisT3 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT3 = new string[jumpTestViewModel.listJumpTest.Count()];
            var lisT4 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT4 = new string[jumpTestViewModel.listJumpTest.Count()];
            var lisT5 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT5 = new string[jumpTestViewModel.listJumpTest.Count()];
            var lisT6 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT6 = new string[jumpTestViewModel.listJumpTest.Count()];
            var lisT7 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT7 = new string[jumpTestViewModel.listJumpTest.Count()];
            var lisT8 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT8 = new string[jumpTestViewModel.listJumpTest.Count()];
            var lisT9 = new double[jumpTestViewModel.listJumpTest.Count()];
            var fecT9 = new string[jumpTestViewModel.listJumpTest.Count()];
            var fecG = new string[jumpTestViewModel.listJumpTest.Count()];
            for (int i = 0; i < jumpTestViewModel.listJumpTest.Count(); i++)
            {
               if(jumpTestViewModel.listJumpTest2[i].jumpTestTypeId==1)
                {
                    lisT1[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT1[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }
                if (jumpTestViewModel.listJumpTest2[i].jumpTestTypeId == 2)
                {
                    lisT2[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT2[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }
                if (jumpTestViewModel.listJumpTest2[i].jumpTestTypeId == 3)
                {
                    lisT3[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT3[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }
                if (jumpTestViewModel.listJumpTest2[i].jumpTestTypeId == 4)
                {
                    lisT4[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT4[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }
                if (jumpTestViewModel.listJumpTest2[i].jumpTestTypeId == 5)
                {
                    lisT5[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT5[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }
                if (jumpTestViewModel.listJumpTest2[i].jumpTestTypeId == 6)
                {
                    lisT6[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT6[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }
                if (jumpTestViewModel.listJumpTest2[i].jumpTestTypeId == 7)
                {
                    lisT7[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT7[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }
                if (jumpTestViewModel.listJumpTest2[i].jumpTestTypeId == 8)
                {
                    lisT8[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT8[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }
                if (jumpTestViewModel.listJumpTest2[i].jumpTestTypeId == 9)
                {
                    lisT9[i] += jumpTestViewModel.listJumpTest2[i].distanceResult;
                    fecT9[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                    fecG[i] += jumpTestViewModel.listJumpTest2[i].date.ToShortDateString();
                }

            }

        
            Ratio obj = new Ratio();
            obj.distanciaT1 = lisT1;
            obj.fechaT1 = fecT1;
            obj.distanciaT2 = lisT2;
            obj.fechaT2 = fecT2;
            obj.distanciaT3 = lisT3;
            obj.fechaT3 = fecT3;
            obj.distanciaT4 = lisT4;
            obj.fechaT4 = fecT4;
            obj.distanciaT5 = lisT5;
            obj.fechaT5 = fecT5;
            obj.distanciaT6 = lisT6;
            obj.fechaT6 = fecT6;
            obj.distanciaT7 = lisT7;
            obj.fechaT7 = fecT7;
            obj.distanciaT8 = lisT8;
            obj.fechaT8 = fecT8;
            obj.distanciaT9 = lisT9;
            obj.fechaT9 = fecT9;
            obj.fechaG = fecG;

            return Json(obj, JsonRequestBehavior.AllowGet);
            

        }
        public class Ratio
        {
            public double[] distanciaT1 { get; set; }
            public string[] fechaT1 { get; set; }
            public double[] distanciaT2 { get; set; }
            public string[] fechaT2 { get; set; }
            public double[] distanciaT3 { get; set; }
            public string[] fechaT3 { get; set; }
            public double[] distanciaT4 { get; set; }
            public string[] fechaT4 { get; set; }
            public double[] distanciaT5 { get; set; }
            public string[] fechaT5 { get; set; }
            public double[] distanciaT6 { get; set; }
            public string[] fechaT6 { get; set; }
            public double[] distanciaT7 { get; set; }
            public string[] fechaT7 { get; set; }
            public double[] distanciaT8 { get; set; }
            public string[] fechaT8 { get; set; }
            public double[] distanciaT9 { get; set; }
            public string[] fechaT9 { get; set; }

            public string[] fechaG { get; set; }
        }
        // GET: JumpTest/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JumpTest/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: JumpTest/Create
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

        // GET: JumpTest/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JumpTest/Edit/5
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

        // GET: JumpTest/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JumpTest/Delete/5
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
