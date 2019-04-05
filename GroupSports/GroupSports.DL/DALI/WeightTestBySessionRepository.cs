using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class WeightTestBySessionRepository : IWeightTestBySessionRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteweightTestBySession(int id)
        {
            try
            {
                var weightTestBySession = context.weightTestBySession.FirstOrDefault(m => m.id == id);
                if (weightTestBySession != null)
                {
                    context.weightTestBySession.Remove(weightTestBySession);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<weightTestBySession> findAll()
        {
            return context.weightTestBySession.Where(m => m.available)
                                .OrderByDescending(m => m.session.sessionDay)
                                .ToList();
        }

        public List<weightTestBySession> findByAthleteId(int id)
        {
            return context.weightTestBySession.Where(m => m.available && m.session.athleteId == id)
                                .OrderByDescending(m => m.session.sessionDay)
                                .ToList();
        }

        public weightTestBySession findById(int id)
        {
            return context.weightTestBySession.FirstOrDefault(m => m.available && m.id == id);
        }

        public List<weightTestBySession> findBySessionId(int id)
        {
            return context.weightTestBySession.Where(m => m.available && m.session.id == id)
                                .OrderByDescending(m => m.session.sessionDay)
                                .ToList();
        }

        public string insertweightTestBySession(weightTestBySession weightTestBySession)
        {
            try
            {
                weightTestBySession.available = true;
                context.weightTestBySession.Add(weightTestBySession);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateweightTestBySession(weightTestBySession weightTestBySession)
        {
            try
            {
                var result = context.weightTestBySession.FirstOrDefault(x => x.id == weightTestBySession.id);
                if (result != null)
                {
                    result.sessionId = weightTestBySession.sessionId;
                    result.weightAfter = weightTestBySession.weightAfter;
                    result.weightBefore = weightTestBySession.weightBefore;
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
