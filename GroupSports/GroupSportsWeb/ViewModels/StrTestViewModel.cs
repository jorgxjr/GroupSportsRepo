using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.DL.DM;
using GroupSports.BL.BC;

namespace GroupSportsWeb.ViewModels
{
    public class StrTestViewModel
    {
        StrengthTestService strengthTestService = new StrengthTestService();
        public int id { get; set; }
        public double maxRepetitionWeightValue { get; set; }
        public int strengthTestTypeId { get; set; }
        public Nullable<int> sessionId { get; set; }
        public int coachId { get; set; }
        public int athleteId { get; set; }
        public System.DateTime date { get; set; }
        public bool available { get; set; }

        public List<strengthTest> listStr = new List<strengthTest>();

        internal void FindStrTestById(int id)
        {
            this.listStr = strengthTestService.findByAthleteId(id);
        }
    }
}