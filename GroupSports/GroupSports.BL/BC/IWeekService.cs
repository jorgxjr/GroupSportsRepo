using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IWeekService
    {
        List<week> findAll();
        week findById(int id);
        List<week> weeksByMesocycleId(int mesocycleId);
        string insertWeek(week week);
        string updateWeek(week week);
        string deleteWeek(int id);
    }
}
