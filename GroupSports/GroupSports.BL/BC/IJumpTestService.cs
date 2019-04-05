using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IJumpTestService
    {
        List<jumpTest> findAll();
        jumpTest findById(int id);
        List<jumpTest> findByAthleteId(int id);
        List<jumpTest> jumpTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate);
        List<AthleteSaltabilityPerformanceDTO> saltabilityPerformanceByCoachIdByJumpTestTypeId(int coachId, int jumptTestTypeId);
        string insertjumpTest(jumpTest jumpTest);
        string updatejumpTest(jumpTest jumpTest);
        string deletejumpTest(int id);
    }
}
