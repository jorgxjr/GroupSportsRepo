using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class AntropometricTestService : IAntropometricTestService
    {
        IAntropometricTestRepository antropometricTestRepository = new AntropometricTestRepository();
        public string deleteanthropometricTest(int id)
        {
            return antropometricTestRepository.deleteanthropometricTest(id);
        }

        public List<anthropometricTest> findAll()
        {
            return antropometricTestRepository.findAll();
        }

        public List<anthropometricTest> findByAthleteId(int id)
        {
            return antropometricTestRepository.findByAthleteId(id);
        }

        public anthropometricTest findById(int id)
        {
            return antropometricTestRepository.findById(id);
        }

        public string insertanthropometricTest(anthropometricTest anthropometricTest)
        {
            return antropometricTestRepository.insertanthropometricTest(anthropometricTest);
        }

        public string updateanthropometricTest(anthropometricTest anthropometricTest)
        {
            return antropometricTestRepository.updateanthropometricTest(anthropometricTest);
        }
    }
}
