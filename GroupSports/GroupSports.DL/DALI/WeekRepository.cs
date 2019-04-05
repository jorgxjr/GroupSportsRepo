using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class WeekRepository : IWeekRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteWeek(int id)
        {
            try
            {
                var week = context.week.FirstOrDefault(x => x.id == id);
                if (week != null)
                {
                    context.week.Remove(week);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<week> findAll()
        {
            return context.week.Where(w => w.available).ToList();
        }

        public week findById(int id)
        {
            return context.week.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertWeek(week week)
        {
            try
            {
                week.available = true;
                context.week.Add(week);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public int numberOfWeeksByMesocycleId(int id)
        {
            var weeksByMesocycle = context.week
                .Where(w => w.mesocycleId == id && w.available);

            return weeksByMesocycle == null ? 0 : weeksByMesocycle.Count();
        }

        public string updateWeek(week week)
        {
            try
            {
                var result = context.week.FirstOrDefault(x => x.id == week.id);
                if (result != null)
                {
                    result.weekTypeId = week.weekTypeId;
                    result.startDate = week.startDate;
                    result.endDate = week.endDate;
                    result.mesocycleId = week.mesocycleId;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<week> weeksByMesocycleId(int mesocycleId)
        {
            var weeksByMesocycle = context.week
                .Where(w => w.mesocycleId == mesocycleId && w.available)
                .ToList();

            return weeksByMesocycle;
        }
    }
}
