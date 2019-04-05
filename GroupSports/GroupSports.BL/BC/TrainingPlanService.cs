using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class TrainingPlanService : ITrainingPlanService
    {
        ITrainingPlanRepository trainingPlanRepository = new TrainingPlanRepository();
        public string deleteTrainingPlan(int id)
        {
            return trainingPlanRepository.deleteTrainingPlan(id);
        }

        public List<trainingPlan> findAll()
        {
            return trainingPlanRepository.findAll();
        }

        public trainingPlan findById(int id)
        {
            return trainingPlanRepository.findById(id);
        }

        public List<trainingPlan> findByName(string name)
        {
            return trainingPlanRepository.findByName(name);
        }

        public string insertTrainingPlan(trainingPlan trainingPlan)
        {
            return trainingPlanRepository.insertTrainingPlan(trainingPlan);
        }

        public List<trainingPlan> trainingPlansByCoachId(int id)
        {
            return trainingPlanRepository.trainingPlansByCoachId(id);
        }

        public string updateTrainingPlan(trainingPlan trainingPlan)
        {
            return trainingPlanRepository.updateTrainingPlan(trainingPlan);
        }
    }
}
