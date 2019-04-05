using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class StrengthTestService : IStrengthTestService
    {
        IStrengthTestRepository strengthTestRepository = new StrengthTestRepository();
        public string deletestrengthTest(int id)
        {
            return strengthTestRepository.deletestrengthTest(id);
        }

        public List<strengthTest> findAll()
        {
            return strengthTestRepository.findAll();
        }

        public List<strengthTest> findByAthleteId(int id)
        {
            return strengthTestRepository.findByAthleteId(id);
        }

        public strengthTest findById(int id)
        {
            return strengthTestRepository.findById(id);
        }

        public string insertstrengthTest(strengthTest strengthTest)
        {
            return strengthTestRepository.insertstrengthTest(strengthTest);
        }

        public List<strengthTest> strengthTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate)
        {
            return strengthTestRepository.strengthTestByAthleteIdByDateRange(athleteId,startDate,endDate);
        }

        public string updatestrengthTest(strengthTest strengthTest)
        {
            return strengthTestRepository.updatestrengthTest(strengthTest);
        }
    }
}
