using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.BL.BC;
using GroupSports.DL.DM;

namespace GroupSportsWeb.ViewModels
{
    public class AddTeamViewModel
    {
        public int id { get; set; }
        public string teamName { get; set; }
        public string coachId { get; set; }
        public TeamService teamService { get; set; } = new TeamService();
        public List<team> lstTeam = new List<team>();
        public team equipo { get; set; } = new team();

    
        internal void AddTeam(team t)
        {
            teamService.insertTeam(t);
        }
    }
}