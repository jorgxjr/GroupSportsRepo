using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface ICoachRepository
    {
        List<CoachDTO> findAll();
        CoachDTO findById(int id);
        List<CoachDTO> findByName(string name);
        void insertCoach(CoachDTO coach);
        void updateCoach(CoachDTO coach);
        void deleteCoach(int id);
    }
}
