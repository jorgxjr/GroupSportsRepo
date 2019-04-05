using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface ISpeedTestService
    {
        List<speedTest> findAll();
        speedTest findById(int id);
        List<speedTest> speedTestByAthleteId(int athleteId);
        List<speedTest> speedTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate);
        List<AthleteSpeedPerformanceDTO> speedPerformanceByCoachIdByMeters(int coachId, int meters);
        string insertSpeedTest(speedTest speedTest);
        string updateSpeedTest(speedTest speedTest);
        string deleteSpeedTest(int id);
    }
}
