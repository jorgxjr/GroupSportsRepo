﻿using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IWeekRepository
    {
        List<week> findAll();
        week findById(int id);
        List<week> weeksByMesocycleId(int mesocycleId);
        int numberOfWeeksByMesocycleId(int id);
        string insertWeek(week week);
        string updateWeek(week week);
        string deleteWeek(int id);
    }
}