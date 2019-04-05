using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class SessionRepository : ISessionRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteSession(int id)
        {
            try
            {
                var session = context.session.FirstOrDefault(x => x.id == id);
                if (session != null)
                {
                    context.session.Remove(session);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<session> findAll()
        {
            return context.session.Where(s => s.available).ToList();
        }

        public session findById(int id)
        {
            return context.session
                .FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertSession(session session)
        {
            try
            {
                session.available = true;
                context.session.Add(session);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<SessionDTO> sessionsByAthleteAndDate(int athleteId, DateTime day)
        {
            List<SessionDTO> sessionDTOs = new List<SessionDTO>();
            var sessions = context.session
                            .Where(s => s.athleteId == athleteId &&
                                   DbFunctions.TruncateTime(s.sessionDay) == DbFunctions.TruncateTime(day) &&
                                   s.available)
                            .OrderBy(s => s.shiftId)
                            .ToList();

            sessions.ForEach(s => sessionDTOs.Add(new SessionDTO(s)));

            return sessionDTOs;
        }

        public List<SessionDTO> sessionsByCoachAndDate(int coachId, DateTime day)
        {
            List<SessionDTO> sessionDTOs = new List<SessionDTO>();
            var sessions = context.session
                            .Where(s => s.coachId == coachId &&
                                   DbFunctions.TruncateTime(s.sessionDay) == DbFunctions.TruncateTime(day) &&
                                   s.available)
                            .OrderBy(s => s.shiftId)
                            .ToList();

            sessions.ForEach(s => sessionDTOs.Add(new SessionDTO(s)));

            return sessionDTOs;
        }

        public List<SessionDTO> sessionsByWeek(int weekId)
        {
            List<SessionDTO> sessionDTOs = new List<SessionDTO>();
            var sessionByWeek = context.session
                .Where(s => s.weekId == weekId && s.available)
                .OrderBy(s => s.sessionDay)
                .ThenBy(s => s.shiftId)
                .ToList();

            sessionByWeek.ForEach(s => sessionDTOs.Add(new SessionDTO(s)));

            return sessionDTOs;
        }

        public string updateSession(session session)
        {
            try
            {
                var result = context.session.FirstOrDefault(x => x.id == session.id);
                if (result != null)
                {
                    //result.sessionDay = session.sessionDay;
                    result.intensityPercentage = session.intensityPercentage;
                    //result.shiftId = session.shiftId;
                    result.attendance = session.attendance;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }
    }
}
