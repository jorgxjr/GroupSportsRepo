using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface ITeamRepository
    {
        List<team> findAll();
        team findById(int id);
        List<team> findByName(string name);
        void insertTeam(team team);
        void updateTeam(team team);
        void deleteTeam(int id);
    }
}
