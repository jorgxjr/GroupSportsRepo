using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class ShotPutTestService : IShotPutTestService
    {
        IShotPutTestRepository shotPutTestRepository = new ShotPutTestRepository();
        public string deleteshotPutTest(int id)
        {
            return shotPutTestRepository.deleteshotPutTest(id);
        }

        public List<shotPutTest> findAll()
        {
            return shotPutTestRepository.findAll();
        }

        public List<shotPutTest> findByAthleteId(int id)
        {
            return shotPutTestRepository.findByAthleteId(id);
        }

        public shotPutTest findById(int id)
        {
            return shotPutTestRepository.findById(id);
        }

        public string insertshotPutTest(shotPutTest shotPutTest)
        {
            return shotPutTestRepository.insertshotPutTest(shotPutTest);
        }

        public string updateshotPutTest(shotPutTest shotPutTest)
        {
            return shotPutTestRepository.updateshotPutTest(shotPutTest);
        }
    }
}
