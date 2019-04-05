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
    public class SpeedTestService : ISpeedTestService
    {
        ISpeedTestRepository speedTestRepository = new SpeedTestRepository();
        public string deleteSpeedTest(int id)
        {
            return speedTestRepository.deleteSpeedTest(id);
        }

        public List<speedTest> findAll()
        {
            return speedTestRepository.findAll();
        }

        public speedTest findById(int id)
        {
            return speedTestRepository.findById(id);
        }

        public string insertSpeedTest(speedTest speedTest)
        {
            return speedTestRepository.insertSpeedTest(speedTest);
        }

        public List<AthleteSpeedPerformanceDTO> speedPerformanceByCoachIdByMeters(int coachId, int meters)
        {
            return speedTestRepository.speedPerformanceByCoachIdByMeters(coachId, meters);
        }

        public List<speedTest> speedTestByAthleteId(int athleteId)
        {
            return speedTestRepository.speedTestByAthleteId(athleteId);
        }

        public List<speedTest> speedTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate)
        {
            return speedTestRepository.speedTestByAthleteIdByDateRange(athleteId,startDate,endDate);
        }

        public string updateSpeedTest(speedTest speedTest)
        {
            return speedTestRepository.updateSpeedTest(speedTest);
        }
    }
}
