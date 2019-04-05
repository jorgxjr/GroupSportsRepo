﻿using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IFodaRepository
    {
        List<athleteFoda> findAll();
        athleteFoda findById(int id);
        List<athleteFoda> athleteFodaByAthleteId(int athleteId);
        string insertathleteFoda(athleteFoda athleteFoda);
        string updateathleteFoda(athleteFoda athleteFoda);
        string deleteathleteFoda(int id);
    }
}