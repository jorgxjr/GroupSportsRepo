using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IStrengthTestService
    {
        List<strengthTest> findAll();
        strengthTest findById(int id);
        List<strengthTest> findByAthleteId(int id);
        List<strengthTest> strengthTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate);
        string insertstrengthTest(strengthTest strengthTest);
        string updatestrengthTest(strengthTest strengthTest);
        string deletestrengthTest(int id);
    }
}
