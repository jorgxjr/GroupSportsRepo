using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class ResistanceTestService : IResistanceTestService
    {
        IResistanceTestRepository resistanceTestRepository = new ResistanceTestRepository();
        public string deleteresistanceTest(int id)
        {
            return resistanceTestRepository.deleteresistanceTest(id);
        }

        public List<resistanceTest> findAll()
        {
            return resistanceTestRepository.findAll();
        }

        public resistanceTest findById(int id)
        {
            return resistanceTestRepository.findById(id);
        }

        public string insertresistanceTest(resistanceTest resistanceTest)
        {
            return resistanceTestRepository.insertresistanceTest(resistanceTest);
        }

        public List<resistanceTest> resistanceTestByAthleteId(int athleteId)
        {
            return resistanceTestRepository.resistanceTestByAthleteId(athleteId);
        }

        public List<resistanceTest> resistanceTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate)
        {
            return resistanceTestRepository.resistanceTestByAthleteIdByDateRange(athleteId, startDate, endDate);
        }

        public string updateresistanceTest(resistanceTest resistanceTest)
        {
            return resistanceTestRepository.updateresistanceTest(resistanceTest);
        }
    }
}
