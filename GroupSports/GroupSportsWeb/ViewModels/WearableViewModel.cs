using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSportsWeb.ViewModels
{
    public class WearableViewModel
    {
        group_sportsEntities context = new group_sportsEntities();
        public List<heartRateWearable> hearRates = new List<heartRateWearable>();
        public List<activeCaloriesWearable> calories = new List<activeCaloriesWearable>();
        public List<stepsCountWearable> steps = new List<stepsCountWearable>();

        public void wearablebyAthlete(int athleteId)
        {
            var wearableByAthlete = context.heartRateWearable
                .OrderBy(s => s.date)
                .ToList();

            hearRates = wearableByAthlete;

            var activeCaloriesbyAthlete = context.activeCaloriesWearable
              .OrderBy(s => s.date)
              .ToList();

            calories = activeCaloriesbyAthlete;

            var stepsbyAthlete = context.stepsCountWearable
             .OrderBy(s => s.date)
             .ToList();

            steps = stepsbyAthlete;

      }

        //public void activeCaloriesbyAthlete(int athleteId)
        //{
        //    var activeCaloriesbyAthlete = context.activeCaloriesWearable
        //      .OrderBy(s => s.date)
        //      .ToList();

        //    calories = activeCaloriesbyAthlete;
        //}

        //public void stepsbyAthlete(int athleteId)
        //{
        //    var stepsbyAthlete = context.stepsCountWearable
        //      .OrderBy(s => s.date)
        //      .ToList();

        //    steps = stepsbyAthlete;
        //}
    }
}