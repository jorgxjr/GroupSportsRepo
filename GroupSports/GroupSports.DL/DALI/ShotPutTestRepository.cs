using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class ShotPutTestRepository : IShotPutTestRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteshotPutTest(int id)
        {
            try
            {
                var shotPutTest = context.shotPutTest.FirstOrDefault(m => m.id == id);
                if (shotPutTest != null)
                {
                    context.shotPutTest.Remove(shotPutTest);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<shotPutTest> findAll()
        {
            return context.shotPutTest.Where(m => m.available)
                                .OrderByDescending(m => m.date)
                                .ToList();
        }

        public List<shotPutTest> findByAthleteId(int id)
        {
            return context.shotPutTest.Where(m => m.available && m.athleteId == id)
                                .OrderByDescending(m => m.date)
                                .ToList();
        }

        public shotPutTest findById(int id)
        {
            return context.shotPutTest.FirstOrDefault(m => m.available && m.id == id);
        }

        public string insertshotPutTest(shotPutTest shotPutTest)
        {
            try
            {
                shotPutTest.available = true;
                context.shotPutTest.Add(shotPutTest);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateshotPutTest(shotPutTest shotPutTest)
        {
            try
            {
                var result = context.shotPutTest.FirstOrDefault(x => x.id == shotPutTest.id);
                if (result != null)
                {
                    result.result = shotPutTest.result;
                    result.ballWeight = shotPutTest.ballWeight;
                    result.shotPutTypeId = shotPutTest.shotPutTypeId;
                    result.date = shotPutTest.date;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }
    }
}
