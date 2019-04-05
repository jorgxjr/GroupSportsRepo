using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using GroupSports.BL.BC;

namespace GroupSportsWeb.ViewModels
{
    public class LstTeamViewModel
    {
        public int id { get; set; }
        public string teamName { get; set; }
        public string coachId { get; set; }
        public List<team> lstTeam { get; set; } = new List<team>();
        public TeamService teamService { get; set; } = new TeamService();

        
        internal void FindById(int id)
        {
            this.teamService.findById(id);
        }

        internal void FindAll()
        {
            this.lstTeam = teamService.findAll();
        }


    }
}