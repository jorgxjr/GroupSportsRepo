using GroupSports.BL.BC;
using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupSportsWeb.ViewModels.BinnaclesViewModel
{
    public class ListBinnacleViewModel
    {
        public List<binnacleDetail> ListBinnacle { get; set; }
        public int idSession { get; set; }
        public ListBinnacleViewModel()
        {

        }
        public void Fill()
        {
            IBinnacleDetailService binnacleDetailService = new BinnacleDetailService();
            ListBinnacle = binnacleDetailService.binnacleBySessionId(idSession);
        }
    }
}