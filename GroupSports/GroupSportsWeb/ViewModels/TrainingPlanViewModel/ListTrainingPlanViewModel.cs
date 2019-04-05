using GroupSports.BL.BC;
using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupSportsWeb.ViewModels.TrainingPlanViewModel
{
    public class ListTrainingPlanViewModel
    {
        public List<trainingPlan> ListTrainingPlan { get; set; }
        public int idCoach { get; set; }
        public ListTrainingPlanViewModel()
        {
            
        }
        public void Fill()
        {
            ITrainingPlanService trainingPlanService = new TrainingPlanService();
            ListTrainingPlan = trainingPlanService.trainingPlansByCoachId(idCoach);
        }
    }
}