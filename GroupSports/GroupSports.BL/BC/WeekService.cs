using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class WeekService : IWeekService
    {
        IWeekRepository weekRepository = new WeekRepository();
        public string deleteWeek(int id)
        {
            return weekRepository.deleteWeek(id);
        }

        public List<week> findAll()
        {
            return weekRepository.findAll();
        }

        public week findById(int id)
        {
            return weekRepository.findById(id);
        }

        public string insertWeek(week week)
        {
            return weekRepository.insertWeek(week);
        }

        public string updateWeek(week week)
        {
            return weekRepository.updateWeek(week);
        }

        public List<week> weeksByMesocycleId(int mesocycleId)
        {
            return weekRepository.weeksByMesocycleId(mesocycleId);
        }
    }
}
