using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IShotPutTestService
    {
        List<shotPutTest> findAll();
        shotPutTest findById(int id);
        List<shotPutTest> findByAthleteId(int id);
        string insertshotPutTest(shotPutTest shotPutTest);
        string updateshotPutTest(shotPutTest shotPutTest);
        string deleteshotPutTest(int id);
    }
}
