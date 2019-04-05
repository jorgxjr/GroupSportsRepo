using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface ISessionService
    {
        List<session> findAll();
        session findById(int id);
        List<SessionDTO> sessionsByWeek(int weekId);
        List<SessionDTO> sessionsByCoachAndDate(int coachId, DateTime day);
        List<SessionDTO> sessionsByAthleteAndDate(int athleteId, DateTime day);
        string insertSession(session session);
        string updateSession(session session);
        string deleteSession(int id);
    }
}
