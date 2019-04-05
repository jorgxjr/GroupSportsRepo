using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.BL.BC;
using GroupSports.DL.DM;

namespace GroupSportsWeb.ViewModels
{
    public class AthleteDetailsViewModel
    {
        public int id { get; set; }
        public Nullable<double> weight { get; set; }
        public Nullable<double> height { get; set; }
        public Nullable<double> bodySpan { get; set; }
        public Nullable<double> legLength { get; set; }
        public Nullable<double> halfSquatToFloor { get; set; }
        public string shirtSize { get; set; }
        public string pantsSize { get; set; }
        public string footwearSize { get; set; }
        public int athleteId { get; set; }
        public bool available { get; set; }
        public AthleteDetailsService athleteDetailsService = new AthleteDetailsService();
        public athleteDetails athleteDetails = new athleteDetails();

        public void findById(int id)
        {
            this.athleteDetails = athleteDetailsService.findById(id);
        }
    }
}