using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class ResistanceTestRepository : IResistanceTestRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteresistanceTest(int id)
        {
            try
            {
                var resistanceTest = context.resistanceTest.FirstOrDefault(x => x.id == id);
                if (resistanceTest != null)
                {
                    context.resistanceTest.Remove(resistanceTest);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<resistanceTest> findAll()
        {
            return context.resistanceTest.Where(st => st.available).ToList();
        }

        public resistanceTest findById(int id)
        {
            return context.resistanceTest.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertresistanceTest(resistanceTest resistanceTest)
        {
            try
            {
                resistanceTest.available = true;
                context.resistanceTest.Add(resistanceTest);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<resistanceTest> resistanceTestByAthleteId(int athleteId)
        {
            var resistanceByAthlete = context.resistanceTest
               .Where(w => w.athleteId == athleteId && w.available)
               .OrderBy(s => s.date)
               .ToList();

            return resistanceByAthlete;
        }

        public List<resistanceTest> resistanceTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate)
        {
            var resistanceByAthlete = context.resistanceTest
               .Where(w => w.athleteId == athleteId &&
                      w.available &&
                      w.date >= startDate && w.date <= endDate)
               .OrderBy(s => s.date)
               .ThenBy(s => (s.hours + s.minutes + s.seconds + s.milliseconds))
               .ToList();

            return resistanceByAthlete;
        }

        public string updateresistanceTest(resistanceTest resistanceTest)
        {
            try
            {
                var result = context.resistanceTest.FirstOrDefault(x => x.id == resistanceTest.id);
                if (result != null)
                {
                    result.hours = resistanceTest.hours;
                    result.minutes = resistanceTest.minutes;
                    result.seconds = resistanceTest.seconds;
                    result.milliseconds = resistanceTest.milliseconds;
                    result.meters = resistanceTest.meters;
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
