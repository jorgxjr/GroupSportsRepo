using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class MesocycleRepository : IMesocycleRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteMesocycle(int id)
        {
            try
            {
                var mesocycle = context.mesocycle.FirstOrDefault(x => x.id == id);
                if (mesocycle != null)
                {
                    context.mesocycle.Remove(mesocycle);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<mesocycle> findAll()
        {
            return context.mesocycle
                .Where(m => m.available)
                .ToList();
        }

        public mesocycle findById(int id)
        {
            return context.mesocycle.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertMesocycle(mesocycle mesocycle)
        {
            try
            {
                mesocycle.available = true;
                context.mesocycle.Add(mesocycle);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<mesocycle> mesocyclesByTrainingPlanId(int trainingPlanId)
        {
            var trainingsPlanByCoach = context.mesocycle
                .Where(m => m.trainingPlanId == trainingPlanId &&
                        m.available &&
                        !(m.startDate == null) &&
                        !(m.endDate == null))
                .OrderBy(m => m.startDate)
                .ToList();

            var trainingsPlanByCoachDateNull = context.mesocycle
                .Where(m => m.trainingPlanId == trainingPlanId &&
                        m.available &&
                        m.startDate == null &&
                        m.endDate == null)
                .ToList();

            trainingsPlanByCoach.AddRange(trainingsPlanByCoachDateNull);

            return trainingsPlanByCoach;
        }

        public List<mesocycle> mesocyclesByTrainingPlanIdNoNulls(int trainingPlanId)
        {
            var trainingsPlanByCoach = context.mesocycle
                .Where(m => m.trainingPlanId == trainingPlanId &&
                        m.available &&
                        !(m.startDate == null) &&
                        !(m.endDate == null))
                .ToList();

            return trainingsPlanByCoach;
        }

        public int numberOfMesocyclesByTrainingPlanId(int id)
        {
            var trainingsPlanByCoach = context.mesocycle
                .Where(m => m.trainingPlanId == id && m.available);

            return trainingsPlanByCoach == null ? 0 : trainingsPlanByCoach.Count();
        }

        public string updateMesocycle(mesocycle mesocycle)
        {
            try
            {
                var result = context.mesocycle.FirstOrDefault(x => x.id == mesocycle.id);
                if (result != null)
                {
                    result.startDate = mesocycle.startDate;
                    result.endDate = mesocycle.endDate;
                    result.mesocycleTypeId = mesocycle.mesocycleTypeId;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }
    }
}
