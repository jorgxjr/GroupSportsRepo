using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.BL.BC;
using GroupSports.DL.DM;

namespace GroupSportsWeb.ViewModels
{
    public class LanzamientoTestViewModel
    {
        public ShotPutTestService shotPutTest = new ShotPutTestService();
        public int id { get; set; }
        public double result { get; set; }
        public double ballWeight { get; set; }
        public int shotPutTypeId { get; set; }
        public Nullable<int> sessionId { get; set; }
        public int coachId { get; set; }
        public int athleteId { get; set; }
        public System.DateTime date { get; set; }
        public bool available { get; set; }

    }
}