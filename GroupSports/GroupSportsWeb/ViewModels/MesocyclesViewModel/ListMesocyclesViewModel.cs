using GroupSports.BL.BC;
using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupSportsWeb.ViewModels.MesocyclesViewModel
{
    public class ListMesocyclesViewModel
    {
        public List<mesocycle> List { get; set; }
        public int idTP { get; set; }
        public ListMesocyclesViewModel()
        {

        }
        public void Fill()
        {
            IMesocycleService mesocycleService = new MesocycleService();
            List = mesocycleService.mesocyclesByTrainingPlanId(idTP);
        }
    }
}