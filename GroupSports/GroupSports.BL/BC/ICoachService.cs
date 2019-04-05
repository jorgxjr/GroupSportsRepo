using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface ICoachService
    {
        List<CoachDTO> findAll();
        CoachDTO findById(int id);
        List<CoachDTO> findByName(string name);
        List<CoachDTO> findByAthleteId(int athleteId);
        void insertCoach(CoachDTO CoachDTO);
        void insertAthleteOnCoach(int athleteId, int coachId);
        string PostByAtheleteNameOnCoach(int coachId, string athleteName);
        void updateCoach(CoachDTO CoachDTO);
        void deleteCoach(int id);
    }
}
