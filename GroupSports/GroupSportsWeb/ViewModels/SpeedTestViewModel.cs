using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.DL.DM;
using GroupSports.BL.BC;

namespace GroupSportsWeb.ViewModels
{
    public class SpeedTestViewModel
    {

        public List<speedTest> lstSpeedTst = new List<speedTest>();
        public List<speedTest> lstSpeedTst2 = new List<speedTest>();

        //public System.Linq.IOrderedEnumerable<speedTest> lista2 { get; set; }
        public int id { get; set; }
        public int meters { get; set; }
        public Nullable<int> sessionId { get; set; }
        public int coachId { get; set; }
        public int athleteId { get; set; }
        public System.DateTime date { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int milliseconds { get; set; }

        public bool available { get; set; }
        public int count { get; set; }



        public string fullHour { get; set; }
        public SpeedTestService speedTestService = new SpeedTestService();

        public speedTest speedTest = new speedTest();

        [Newtonsoft.Json.JsonIgnore] public virtual athelete athelete { get; set; }
        [Newtonsoft.Json.JsonIgnore] public virtual coach coach { get; set; }
        [Newtonsoft.Json.JsonIgnore] public virtual session session { get; set; }



        internal void Agregar(speedTest s)
        {
            speedTestService.insertSpeedTest(s);
        }
        internal void ListarTest(int atletaId)
        {
            this.count = speedTestService.speedTestByAthleteId(atletaId).Count();
            //this.lstSpeedTst = speedTestService.speedTestByAthleteId(atletaId).OrderByDescending(s => s.date).ToList();
            this.lstSpeedTst = speedTestService.speedTestByAthleteId(atletaId);
            this.lstSpeedTst2 = speedTestService.speedTestByAthleteId(atletaId).OrderByDescending(m => m.date)
                                          .ThenByDescending(m => m.id)
                                          .ToList();
            //this.lstSpeedTst.Sort();
            //this.lstSpeedTst.Reverse();
            fullHour = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString() + ":" + milliseconds.ToString();

          

        }
       
    }


}