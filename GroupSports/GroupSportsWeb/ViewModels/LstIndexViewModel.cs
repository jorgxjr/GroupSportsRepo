using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using GroupSports.BL.BC;
namespace GroupSportsWeb.ViewModels
{
    public class LstIndexViewModel
    {
        public TeamService teamService { get; set; } = new TeamService();
        public CoachService coachService { get; set; } = new CoachService();
        public List<team> lstTeam = new List<team>();
        

        public int edad { get; set; }
        public int añosexp { get; set; }
        public int userid { get; set; } 
        public int id { get; set; }
        public string nombreequipo { get; set; }
        public List<CoachDTO> lstCoach = new List<CoachDTO>();
        internal void Listar()
        {
            this.lstTeam = teamService.findAll();
            this.lstCoach = coachService.findAll();
            
        }
    }
}