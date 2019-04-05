using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.BL.BC;
using GroupSports.DL.DM.DTO;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSportsWeb.ViewModels
{
    public class LstAthleteViewModel
    {
        public List<AthleteDTO> lstAtletas = new List<AthleteDTO>();
        public AthleteService athleteService = new AthleteService();

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int userType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cellPhone { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public string pictureUrl { get; set; }
        public DateTime birthDate { get; set; }

        public int idCoach { get; set; }

        //athlete
        public string disciplineName { get; set; }
        public int disciplineId { get; set; }
        public int userId { get; set; }


        internal void Fill()
        {
            this.lstAtletas = athleteService.atheletesByCoachId(idCoach);
        }

        internal void FillByCategoriesSub(int id, int edadInicio, int edadFin)
        {
            this.lstAtletas = athleteService.atheletesByCoachIdSubAge(idCoach, edadInicio, edadFin);
        }

        internal void FillByCategoriesUnder(int id, int edadFin)
        {
            this.lstAtletas = athleteService.atheletesByCoachIdUnderAge(id, edadFin);
        }

        internal void FindById(int id)
        {
            this.athleteService.findById(id);
        }
    }
}