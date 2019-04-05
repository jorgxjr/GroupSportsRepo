using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IMoodService
    {
        List<mood> findAll();
        mood findById(int id);
        List<mood> findByAthleteId(int id);
        List<mood> findByAthleteIdAndDay(int id, DateTime day);
        string insertMood(mood mood);
        string updateMood(mood mood);
        string updateMoodResponse(mood mood);
        string deleteMood(int id);
    }
}
