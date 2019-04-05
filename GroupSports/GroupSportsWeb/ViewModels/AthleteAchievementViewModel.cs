using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.BL.BC;
using GroupSports.DL.DM;


namespace GroupSportsWeb.ViewModels
{
    public class AthleteAchievementViewModel
    {
        public int id { get; set; }
        public int athleteAchievementTypeId { get; set; }
        public int place { get; set; }
        public string description { get; set; }
        public int athleteId { get; set; }
        public bool available { get; set; }
        public Nullable<System.TimeSpan> resultTime { get; set; }
        public Nullable<double> resultDistance { get; set; }

        public List<athleteAchievement> listAthleteAchievement = new List<athleteAchievement>();
        public AthleteAchievementService athleteAchievementService = new AthleteAchievementService();

        public void FillById(int id)
        {
            this.listAthleteAchievement = athleteAchievementService.athleteAchievementByAthleteId(id);
        }
    }
}