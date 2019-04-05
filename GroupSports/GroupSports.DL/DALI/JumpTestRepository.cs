using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class JumpTestRepository : IJumpTestRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deletejumpTest(int id)
        {
            try
            {
                var jumpTest = context.jumpTest.FirstOrDefault(m => m.id == id);
                if (jumpTest != null)
                {
                    context.jumpTest.Remove(jumpTest);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<jumpTest> findAll()
        {
            return context.jumpTest.Where(m => m.available)
                                .OrderByDescending(m => m.date)
                                .ToList();
        }

        public List<jumpTest> findByAthleteId(int id)
        {
            return context.jumpTest.Where(m => m.available && m.athleteId == id)
                                .OrderByDescending(m => m.date)
                                .ThenByDescending(m => m.id)
                                .ToList();
        }

        public List<AthleteSaltabilityPerformanceDTO> saltabilityPerformanceByCoachIdByJumpTestTypeId(int coachId, int jumptTestTypeId)
        {
            List<AthleteSaltabilityPerformanceDTO> asDTO = new List<AthleteSaltabilityPerformanceDTO>();

            var athletesByCoach = context.coachByAthelete
                .Include("coach")
                .Include("athelete")
                .Where(a => a.coachId == coachId && a.available)
                .ToList();

            athletesByCoach.ForEach(a => {
                AthleteSaltabilityPerformanceDTO asp = AthleteSaltabilityPerformanceDTO.from(a.athelete, jumptTestTypeId);
                if (asp.isValid())
                    asDTO.Add(asp);
            });

            return asDTO;
        }

        public List<jumpTest> jumpTestByAthleteIdByDateRange(int athleteId, DateTime startDate, DateTime endDate)
        {
            var jumpTests = context.jumpTest
               .Where(w => w.athleteId == athleteId &&
                      w.available &&
                      w.date >= startDate && w.date <= endDate)
               .OrderBy(s => s.date)
               .ThenBy(s => s.distanceResult)
               .ToList();

            return jumpTests;
        }

        public jumpTest findById(int id)
        {
            return context.jumpTest.FirstOrDefault(m => m.available && m.id == id);
        }

        public string insertjumpTest(jumpTest jumpTest)
        {
            try
            {
                jumpTest.available = true;
                context.jumpTest.Add(jumpTest);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updatejumpTest(jumpTest jumpTest)
        {
            try
            {
                var result = context.jumpTest.FirstOrDefault(x => x.id == jumpTest.id);
                if (result != null)
                {
                    result.distanceResult = jumpTest.distanceResult;
                    result.jumpTestTypeId = jumpTest.jumpTestTypeId;
                    result.date = jumpTest.date;
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
