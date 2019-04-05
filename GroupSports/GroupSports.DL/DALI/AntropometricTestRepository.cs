using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class AntropometricTestRepository : IAntropometricTestRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteanthropometricTest(int id)
        {
            try
            {
                var anthropometricTest = context.anthropometricTest.FirstOrDefault(m => m.id == id);
                if (anthropometricTest != null)
                {
                    context.anthropometricTest.Remove(anthropometricTest);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<anthropometricTest> findAll()
        {
            return context.anthropometricTest.Where(m => m.available)
                                .OrderByDescending(m => m.date)
                                .ToList();
        }

        public List<anthropometricTest> findByAthleteId(int id)
        {
            return context.anthropometricTest.Where(m => m.available && m.athleteId == id)
                                .OrderByDescending(m => m.date)
                                .ToList();
        }

        public anthropometricTest findById(int id)
        {
            return context.anthropometricTest.FirstOrDefault(m => m.available && m.id == id);
        }

        public string insertanthropometricTest(anthropometricTest anthropometricTest)
        {
            try
            {
                anthropometricTest.available = true;
                context.anthropometricTest.Add(anthropometricTest);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateanthropometricTest(anthropometricTest anthropometricTest)
        {
            try
            {
                var result = context.anthropometricTest.FirstOrDefault(x => x.id == anthropometricTest.id);
                if (result != null)
                {
                    result.size = anthropometricTest.size;
                    result.weight = anthropometricTest.weight;
                    result.wingspan = anthropometricTest.wingspan;
                    result.bodyFatPercentage = anthropometricTest.bodyFatPercentage;
                    result.leanBodyPercentage = anthropometricTest.leanBodyPercentage;
                    result.date = anthropometricTest.date;
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
