using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IResistanceTestRepository
    {
        List<resistanceTest> findAll();
        resistanceTest findById(int id);
        List<resistanceTest> resistanceTestByAthleteId(int athleteId);
        List<resistanceTest> resistanceTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate);
        string insertresistanceTest(resistanceTest resistanceTest);
        string updateresistanceTest(resistanceTest resistanceTest);
        string deleteresistanceTest(int id);
    }
}
