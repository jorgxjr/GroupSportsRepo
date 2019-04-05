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
    public class LstCoachViewModel
    {
        group_sportsEntities context = new group_sportsEntities();

        public List<AthleteDTO> lstAtletas = new List<AthleteDTO>();
        public AthleteService athleteService = new AthleteService();
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int user_type { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cellPhone { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public int edad { get; set; }
        public int yearsOfExperience { get; set; }
        public int userId { get; set; }

        internal void Fill()
        {
           this.lstAtletas = athleteService.atheletesByCoachId(1);
        }
        internal void FindById(int id)
        {
            this.athleteService.findById(id);
        }
        public int findCoachIDByUser(string name)
        {
            coach coachsDTO = new coach();

            coachsDTO = context.coach
                .Include("user")
                .Where(x => x.user.username == name && x.available)
                .FirstOrDefault();

            
            return coachsDTO.id;
        }
    }
}