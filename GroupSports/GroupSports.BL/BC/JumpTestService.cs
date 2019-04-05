using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.BL.BC
{
    public class JumpTestService : IJumpTestService
    {
        IJumpTestRepository jumpTestRepository = new JumpTestRepository();
        public string deletejumpTest(int id)
        {
            return jumpTestRepository.deletejumpTest(id);
        }

        public List<jumpTest> findAll()
        {
            return jumpTestRepository.findAll();
        }

        public List<jumpTest> findByAthleteId(int id)
        {
            return jumpTestRepository.findByAthleteId(id);
        }

        public jumpTest findById(int id)
        {
            return jumpTestRepository.findById(id);
        }

        public string insertjumpTest(jumpTest jumpTest)
        {
            return jumpTestRepository.insertjumpTest(jumpTest);
        }

        public List<jumpTest> jumpTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate)
        {
            return jumpTestRepository.jumpTestByAthleteIdByDateRange(athleteId, startDate,endDate);
        }

        public List<AthleteSaltabilityPerformanceDTO> saltabilityPerformanceByCoachIdByJumpTestTypeId(int coachId, int jumptTestTypeId)
        {
            return jumpTestRepository.saltabilityPerformanceByCoachIdByJumpTestTypeId(coachId, jumptTestTypeId);
        }

        public string updatejumpTest(jumpTest jumpTest)
        {
            return jumpTestRepository.updatejumpTest(jumpTest);
        }
    }
}
