using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class StrengthTestRepository : IStrengthTestRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deletestrengthTest(int id)
        {
            try
            {
                var strengthTest = context.strengthTest.FirstOrDefault(m => m.id == id);
                if (strengthTest != null)
                {
                    context.strengthTest.Remove(strengthTest);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<strengthTest> findAll()
        {
            return context.strengthTest.Where(m => m.available)
                                .OrderByDescending(m => m.date)
                                .ToList();
        }

        public List<strengthTest> strengthTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate)
        {
            var strengthTestByAthlete = context.strengthTest
               .Where(w => w.athleteId == athleteId &&
                      w.available &&
                      w.date >= startDate && w.date <= endDate)
               .OrderBy(s => s.date)
               .ThenBy(s => s.maxRepetitionWeightValue)
               .ToList();

            return strengthTestByAthlete;
        }

        public List<strengthTest> findByAthleteId(int id)
        {
            return context.strengthTest.Where(m => m.available && m.athleteId == id)
                                .OrderByDescending(m => m.date)
                                .ThenByDescending(m => m.id)
                                .ToList();
        }

        public strengthTest findById(int id)
        {
            return context.strengthTest.FirstOrDefault(m => m.available && m.id == id);
        }

        public string insertstrengthTest(strengthTest strengthTest)
        {
            try
            {
                strengthTest.available = true;
                context.strengthTest.Add(strengthTest);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updatestrengthTest(strengthTest strengthTest)
        {
            try
            {
                var result = context.strengthTest.FirstOrDefault(x => x.id == strengthTest.id);
                if (result != null)
                {
                    result.maxRepetitionWeightValue = strengthTest.maxRepetitionWeightValue;
                    result.strengthTestTypeId = strengthTest.strengthTestTypeId;
                    result.date = strengthTest.date;
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
