using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.BL.BC
{
    public class SessionService : ISessionService
    {
        ISessionRepository sessionRepository = new SessionRepository();
        public string deleteSession(int id)
        {
            return sessionRepository.deleteSession(id);
        }

        public List<session> findAll()
        {
            return sessionRepository.findAll();
        }

        public session findById(int id)
        {
            return sessionRepository.findById(id);
        }

        public string insertSession(session session)
        {
            return sessionRepository.insertSession(session);
        }

        public List<SessionDTO> sessionsByAthleteAndDate(int athleteId, DateTime day)
        {
            return sessionRepository.sessionsByAthleteAndDate(athleteId, day);
        }

        public List<SessionDTO> sessionsByCoachAndDate(int coachId, DateTime day)
        {
            return sessionRepository.sessionsByCoachAndDate(coachId,day);
        }

        public List<SessionDTO> sessionsByWeek(int weekId)
        {
            return sessionRepository.sessionsByWeek(weekId);
        }

        public string updateSession(session session)
        {
            return sessionRepository.updateSession(session);
        }
    }
}
