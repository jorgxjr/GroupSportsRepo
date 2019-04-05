using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface ICoachRepository
    {
        List<CoachDTO> findAll();
        CoachDTO findById(int id);
        List<CoachDTO> findByAthleteId(int athleteId);
        List<CoachDTO> findByName(string name);
        void insertCoach(CoachDTO coach);
        string PostByAtheleteNameOnCoach(int coachId, string athleteName);
        void insertAthleteOnCoach(int athleteId, int coachId);
        void updateCoach(CoachDTO coach);
        void deleteCoach(int id);
    }
}
