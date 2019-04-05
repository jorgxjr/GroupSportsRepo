using GroupSports.BL.BC;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupSportsWeb.ViewModels.AssitancesViewModel
{
    public class ListAssitancesViewModel
    {
        public ISessionService sessionService = new SessionService();
        public List<SessionDTO> ListSessions { get; set; }
        public int coachId { get; set; }
        public ListAssitancesViewModel()
        {

        }
        public void Fill()
        {
            ListSessions = sessionService.sessionsByCoachAndDate(coachId, DateTime.Today);
        }
        public string deleteSession(int id)
        {
            return sessionService.deleteSession(id);
        }
        public session getSession(int id)
        {
            return sessionService.findById(id);
        }
        public string updateSession(session session)
        {
            return sessionService.updateSession(session);
        }
    }
}