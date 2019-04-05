using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class CoachService : ICoachService
    {
        ICoachRepository coachRepository = new CoachRepository();
        public void deleteCoach(int id)
        {
            coachRepository.deleteCoach(id);
        }

        public List<CoachDTO> findAll()
        {
            return coachRepository.findAll();
        }

        public List<CoachDTO> findByAthleteId(int athleteId)
        {
            return coachRepository.findByAthleteId(athleteId);
        }

        public CoachDTO findById(int id)
        {
            return coachRepository.findById(id);
        }

        public List<CoachDTO> findByName(string name)
        {
            return coachRepository.findByName(name);
        }

        public void insertAthleteOnCoach(int athleteId, int coachId)
        {
            coachRepository.insertAthleteOnCoach(athleteId, coachId);
        }

        public void insertCoach(CoachDTO coachDTO)
        {
            coachRepository.insertCoach(coachDTO);
        }

        public string PostByAtheleteNameOnCoach(int coachId, string athleteName)
        {
            return coachRepository.PostByAtheleteNameOnCoach(coachId, athleteName);
        }

        public void updateCoach(CoachDTO coachDTO)
        {
            coachRepository.updateCoach(coachDTO);
        }
    }
}
