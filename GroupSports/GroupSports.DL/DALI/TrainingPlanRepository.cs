using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        group_sportsEntities context = new group_sportsEntities();

        public string deleteTrainingPlan(int id)
        {
            try
            {
                var trainingPlan = context.trainingPlan.FirstOrDefault(x => x.id == id);
                if (trainingPlan != null)
                {
                    context.trainingPlan.Remove(trainingPlan);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<trainingPlan> findAll()
        {
            return context.trainingPlan.Where(t => t.available).ToList();
        }

        public trainingPlan findById(int id)
        {
            return context.trainingPlan.FirstOrDefault(x => x.id == id && x.available);
        }

        public List<trainingPlan> findByName(string name)
        {
            return context.trainingPlan.Where(x => x.name == name && x.available).ToList();
        }

        public string insertTrainingPlan(trainingPlan trainingPlan)
        {
            try
            {
                trainingPlan.available = true;
                context.trainingPlan.Add(trainingPlan);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<trainingPlan> trainingPlansByCoachId(int coachId)
        {
            var trainingsPlanByCoach = context.trainingPlan
                .Include("athelete")
                .Where(t => t.coachId == coachId && t.available)
                .ToList();

            return trainingsPlanByCoach;
        }

        public string updateTrainingPlan(trainingPlan trainingPlan)
        {
            try
            {
                var result = context.trainingPlan.FirstOrDefault(x => x.id == trainingPlan.id);
                if (result != null)
                {
                    result.name = trainingPlan.name;
                    result.startDate = trainingPlan.startDate;
                    result.endDate = trainingPlan.endDate;
                    //if (result.athelete != null)
                    //{
                    //    result.athleteId = trainingPlan.athelete.id;
                    //    result.athelete = trainingPlan.athelete;
                    //}
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
