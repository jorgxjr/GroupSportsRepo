using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IAthleteAchievementService
    {
        List<athleteAchievement> findAll();
        athleteAchievement findById(int id);
        List<athleteAchievement> athleteAchievementByAthleteId(int athleteId);
        string insertathleteAchievement(athleteAchievement athleteAchievement);
        string updateathleteAchievement(athleteAchievement athleteAchievement);
        string deleteathleteAchievement(int id);
    }
}
