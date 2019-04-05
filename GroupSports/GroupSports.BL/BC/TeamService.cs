using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public class TeamService : ITeamService
    {
        ITeamRepository userRepository = new TeamRepository();

        public void deleteTeam(int id)
        {
            userRepository.deleteTeam(id);
        }

        public List<team> findAll()
        {
            return userRepository.findAll();
        }

        public team findById(int id)
        {
            return userRepository.findById(id);
        }

        public List<team> findByName(string name)
        {
            return userRepository.findByName(name);
        }

        public void insertTeam(team team)
        {
            userRepository.insertTeam(team);
        }

        public void updateTeam(team team)
        {
            userRepository.updateTeam(team);
        }
    }
}
