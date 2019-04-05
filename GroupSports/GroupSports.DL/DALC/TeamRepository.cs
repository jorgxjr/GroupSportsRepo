using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class TeamRepository : ITeamRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public void deleteTeam(int id)
        {
            var team = context.team.FirstOrDefault(x => x.id == id);
            if (team != null)
            {
                context.team.Remove(team);
                context.SaveChanges();
            }
        }

        public List<team> findAll()
        {
            return context.team.ToList();
        }

        public team findById(int id)
        {
            return context.team.FirstOrDefault(x => x.id == id);
        }

        public List<team> findByName(string name)
        {
            return context.team.Where(x => x.teamName == name).ToList();
        }

        public void insertTeam(team team)
        {
            context.team.Add(team);
            context.SaveChanges();
        }

        public void updateTeam(team team)
        {
            var result = context.team.FirstOrDefault(x => x.id == team.id);
            if (result != null)
            {
                result.teamName = team.teamName;
                result.coachId = team.coachId;
                context.SaveChanges();
            }
        }
    }
}
