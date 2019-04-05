using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class AthleteAchievementService : IAthleteAchievementService
    {
        IAthleteAchievementRepository athleteAchievementRepository = new AthleteAchievementRepository();
        public List<athleteAchievement> athleteAchievementByAthleteId(int athleteId)
        {
            return athleteAchievementRepository.athleteAchievementByAthleteId(athleteId);
        }

        public string deleteathleteAchievement(int id)
        {
            return athleteAchievementRepository.deleteathleteAchievement(id);
        }

        public List<athleteAchievement> findAll()
        {
            return athleteAchievementRepository.findAll();
        }

        public athleteAchievement findById(int id)
        {
            return athleteAchievementRepository.findById(id);
        }

        public string insertathleteAchievement(athleteAchievement athleteAchievement)
        {
            return athleteAchievementRepository.insertathleteAchievement(athleteAchievement);
        }

        public string updateathleteAchievement(athleteAchievement athleteAchievement)
        {
            return athleteAchievementRepository.updateathleteAchievement(athleteAchievement);
        }
    }
}
