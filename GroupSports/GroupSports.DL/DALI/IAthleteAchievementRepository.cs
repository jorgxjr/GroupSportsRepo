﻿using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IAthleteAchievementRepository
    {
        List<athleteAchievement> findAll();
        athleteAchievement findById(int id);
        List<athleteAchievement> athleteAchievementByAthleteId(int athleteId);
        string insertathleteAchievement(athleteAchievement athleteAchievement);
        string updateathleteAchievement(athleteAchievement athleteAchievement);
        string deleteathleteAchievement(int id);
    }
}
