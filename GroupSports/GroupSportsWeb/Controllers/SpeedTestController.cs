using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;

namespace GroupSportsWeb.Controllers
{
    public class SpeedTestController : Controller
    {
        // GET: SpeedTest
        [Authorize]
        public ActionResult Index(int id)
        {
            SpeedTestViewModel speedTestViewModel = new SpeedTestViewModel();
            Session["aID"] = id;
            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            speedTestViewModel.ListarTest(atletaid);
            return View(speedTestViewModel);
        }


        public ActionResult GetData()
        {
            SpeedTestViewModel speedTestViewModel = new SpeedTestViewModel();

            string atletaString = Session["aID"].ToString();
            int atletaid = Int32.Parse(atletaString);

            speedTestViewModel.ListarTest(atletaid);
            var lisT1 = new int[speedTestViewModel.lstSpeedTst.Count()];
            var lisT2 = new int[speedTestViewModel.lstSpeedTst.Count()];
            var lisT3 = new int[speedTestViewModel.lstSpeedTst.Count()];
            var lisT4 = new int[speedTestViewModel.lstSpeedTst.Count()];
            var lisT5 = new int[speedTestViewModel.lstSpeedTst.Count()];
            var lisT6 = new int[speedTestViewModel.lstSpeedTst.Count()];
            var lisT7 = new int[speedTestViewModel.lstSpeedTst.Count()];
            var lisT8 = new int[speedTestViewModel.lstSpeedTst.Count()];
            var lisT9 = new int[speedTestViewModel.lstSpeedTst.Count()];
            for (int i = 0; i < speedTestViewModel.lstSpeedTst.Count(); i++)
            {
                if (speedTestViewModel.lstSpeedTst[i].meters == 10)
                {
                    lisT1[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
                if (speedTestViewModel.lstSpeedTst[i].meters == 20)
                {
                    lisT2[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
                if (speedTestViewModel.lstSpeedTst[i].meters == 30)
                {
                    lisT3[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
                if (speedTestViewModel.lstSpeedTst[i].meters == 40)
                {
                    lisT4[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
                if (speedTestViewModel.lstSpeedTst[i].meters == 50)
                {
                    lisT5[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
                if (speedTestViewModel.lstSpeedTst[i].meters == 60)
                {
                    lisT6[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
                if (speedTestViewModel.lstSpeedTst[i].meters == 100)
                {
                    lisT7[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
                if (speedTestViewModel.lstSpeedTst[i].meters == 200)
                {
                    lisT8[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
                if (speedTestViewModel.lstSpeedTst[i].meters == 400)
                {
                    lisT9[i] += speedTestViewModel.lstSpeedTst[i].milliseconds +
                      speedTestViewModel.lstSpeedTst[i].seconds * 1000 +
                      speedTestViewModel.lstSpeedTst[i].minutes * 60000 +
                      speedTestViewModel.lstSpeedTst[i].hours * 3600000;
                }
            }

            var lisF = new string[speedTestViewModel.lstSpeedTst.Count()];
            for (int i = 0; i < speedTestViewModel.lstSpeedTst.Count(); i++)
            {
                lisF[i] = speedTestViewModel.lstSpeedTst[i].date.ToShortDateString();

            }

           
            Ratio obj = new Ratio();
            obj.tiempoT1 = lisT1;
            obj.tiempoT2 = lisT2;
            obj.tiempoT3 = lisT3;
            obj.tiempoT4 = lisT4;
            obj.tiempoT5 = lisT5;
            obj.tiempoT6 = lisT6;
            obj.tiempoT7 = lisT7;
            obj.tiempoT8 = lisT8;
            obj.tiempoT9 = lisT9;
            obj.fechaT = lisF;

            return Json(obj, JsonRequestBehavior.AllowGet);
            //List<int> lista1 = new List<int>();
            //var lis = new int[speedTestViewModel.lstSpeedTst.Count()+10];
            //for (int i = 0; i < speedTestViewModel.lstSpeedTst.Count(); i++)
            //{
            //    //lis[i] = speedTestViewModel.lstSpeedTst[i].meters;
            //    lis[i] = speedTestViewModel.lstSpeedTst[i].meters;

            //}


        } 

        public class Ratio
        {
            public int[] tiempoT1 { get; set; }
            public int[] tiempoT2 { get; set; }
            public int[] tiempoT3 { get; set; }
            public int[] tiempoT4 { get; set; }
            public int[] tiempoT5 { get; set; }
            public int[] tiempoT6 { get; set; }
            public int[] tiempoT7 { get; set; }
            public int[] tiempoT8 { get; set; }
            public int[] tiempoT9 { get; set; }

            public string[] fechaT { get; set; }
        }

        // GET: SpeedTest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpeedTest/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            TempData["atletaid"] = id;

            return View();
        }

        // POST: SpeedTest/Create
        [HttpPost]
        public ActionResult Create(speedTest sp)
        {
            string coachUser = Session["userID"].ToString();
            SpeedTestViewModel a = new SpeedTestViewModel();
            LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();

            int x = int.Parse(TempData["atletaid"].ToString());
            sp.athleteId = x;
            int b = lstCoachViewModel.findCoachIDByUser(coachUser);

            sp.coachId = b;
            sp.date = DateTime.Today;
            if (sp != null)
            {
                a.Agregar(sp);
                return RedirectToAction("Index", "Athletes");
            }


            return View(a);


        }


        // GET: SpeedTest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpeedTest/Edit/5
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

        // GET: SpeedTest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpeedTest/Delete/5
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
