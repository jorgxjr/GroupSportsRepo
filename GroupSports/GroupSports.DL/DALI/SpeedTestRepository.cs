using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class SpeedTestRepository : ISpeedTestRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteSpeedTest(int id)
        {
            try
            {
                var speedTest = context.speedTest.FirstOrDefault(x => x.id == id);
                if (speedTest != null)
                {
                    context.speedTest.Remove(speedTest);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<speedTest> findAll()
        {
            return context.speedTest.Where(st => st.available).ToList();
        }

        public speedTest findById(int id)
        {
            return context.speedTest.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertSpeedTest(speedTest speedTest)
        {
            try
            {
                speedTest.available = true;
                context.speedTest.Add(speedTest);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<speedTest> speedTestByAthleteId(int athleteId)
        {
            var speedTestByAthlete = context.speedTest
               .Where(w => w.athleteId == athleteId && w.available)
               .OrderBy(s => s.date)
               .ToList();

            return speedTestByAthlete;
        }

        public List<AthleteSpeedPerformanceDTO> speedPerformanceByCoachIdByMeters(int coachId, int meters)
        {
            List<AthleteSpeedPerformanceDTO> asDTO = new List<AthleteSpeedPerformanceDTO>();

            var athletesByCoach = context.coachByAthelete
                .Include("coach")
                .Include("athelete")
                .Where(a => a.coachId == coachId && a.available)
                .ToList();

            athletesByCoach.ForEach(a => {
                AthleteSpeedPerformanceDTO asp = AthleteSpeedPerformanceDTO.from(a.athelete, meters);
                if (asp.isValid())
                    asDTO.Add(asp);
            });

            return asDTO;
        }

        public List<speedTest> speedTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate)
        {
            var speedTestByAthlete = context.speedTest
               .Where(w => w.athleteId == athleteId && 
                      w.available &&
                      w.date >= startDate && w.date <= endDate)
               .OrderBy(s => s.date)
               .ThenBy(s => (s.hours + s.minutes + s.seconds + s.milliseconds))
               .ToList();

            return speedTestByAthlete;
        }

        public string updateSpeedTest(speedTest speedTest)
        {
            try
            {
                var result = context.speedTest.FirstOrDefault(x => x.id == speedTest.id);
                if (result != null)
                {
                    result.hours = speedTest.hours;
                    result.minutes = speedTest.minutes;
                    result.seconds = speedTest.seconds;
                    result.milliseconds = speedTest.milliseconds;
                    result.meters = speedTest.meters;
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
