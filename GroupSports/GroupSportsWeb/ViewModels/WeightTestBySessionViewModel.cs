using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.DL.DM;
using GroupSports.BL.BC;

namespace GroupSportsWeb.ViewModels
{
    public class WeightTestBySessionViewModel
    {
        public WeightTestBySessionService weightTestBySessionService = new WeightTestBySessionService();
        public List<weightTestBySession> listWeightTestBySession = new List<weightTestBySession>();

        public int id { get; set; }
        public Nullable<double> weightBefore { get; set; }
        public Nullable<double> weightAfter { get; set; }
        public int sessionId { get; set; }
        public bool available { get; set; }

        public void findById(int id)
        {
            this.listWeightTestBySession = weightTestBySessionService.findByAthleteId(id);
        }
    }
}