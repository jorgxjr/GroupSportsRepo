using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface ITrainingPlanRepository
    {
        List<trainingPlan> findAll();
        trainingPlan findById(int id);
        List<trainingPlan> findByName(string name);
        List<trainingPlan> trainingPlansByCoachId(int id);
        string insertTrainingPlan(trainingPlan trainingPlan);
        string updateTrainingPlan(trainingPlan trainingPlan);
        string deleteTrainingPlan(int id);
    }
}
