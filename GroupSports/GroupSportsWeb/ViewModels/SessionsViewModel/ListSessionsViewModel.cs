using GroupSports.BL.BC;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupSportsWeb.ViewModels.SessionsViewModel
{
    public class ListSessionsViewModel
    {
        public ISessionService sessionService = new SessionService();
        public List<SessionDTO> ListSessions { get; set; }
        public int coachId { get; set; }
        public ListSessionsViewModel()
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
    }
}