using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.BL.BC;
using GroupSports.DL.DM;

namespace GroupSportsWeb.ViewModels
{
    public class FodaViewModel
    {
        public int id { get; set; }
        public string fodaItemValue { get; set; }
        public int fodaItemTypeId { get; set; }
        public int athleteId { get; set; }
        public System.DateTime date { get; set; }
        public bool available { get; set; }

        public List<athleteFoda> listAthleteFoda = new List<athleteFoda>();
        public FodaService fodaService = new FodaService();

        public void findById(int id)
        {
            this.listAthleteFoda = fodaService.athleteFodaByAthleteId(id);
        }



    }
}