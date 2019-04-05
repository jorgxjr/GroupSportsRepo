using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IAntropometricTestRepository
    {
        List<anthropometricTest> findAll();
        anthropometricTest findById(int id);
        List<anthropometricTest> findByAthleteId(int id);
        string insertanthropometricTest(anthropometricTest anthropometricTest);
        string updateanthropometricTest(anthropometricTest anthropometricTest);
        string deleteanthropometricTest(int id);
    }
}
