﻿using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface ICoachCurriculumDetailService
    {
        List<coachCurriculumDetail> findAll();
        coachCurriculumDetail findById(int id);
        List<coachCurriculumDetail> coachCurriculumDetailByCoachId(int coachId);
        string insertcoachCurriculumDetail(coachCurriculumDetail coachCurriculumDetail);
        string updatecoachCurriculumDetail(coachCurriculumDetail coachCurriculumDetail);
        string deletecoachCurriculumDetail(int id);
    }
}
