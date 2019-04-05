using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class AthleteAchievementRepository : IAthleteAchievementRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public List<athleteAchievement> athleteAchievementByAthleteId(int athleteId)
        {
            var athleteAchievement = context.athleteAchievement
               .Where(w => w.athleteId == athleteId && w.available)
               .ToList();

            return athleteAchievement;
        }

        public string deleteathleteAchievement(int id)
        {
            try
            {
                var athleteAchievement = context.athleteAchievement.FirstOrDefault(x => x.id == id);
                if (athleteAchievement != null)
                {
                    context.athleteAchievement.Remove(athleteAchievement);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<athleteAchievement> findAll()
        {
            return context.athleteAchievement.Where(st => st.available).ToList();
        }

        public athleteAchievement findById(int id)
        {
            return context.athleteAchievement.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertathleteAchievement(athleteAchievement athleteAchievement)
        {
            try
            {
                athleteAchievement.available = true;
                context.athleteAchievement.Add(athleteAchievement);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateathleteAchievement(athleteAchievement athleteAchievement)
        {
            try
            {
                var result = context.athleteAchievement.FirstOrDefault(x => x.id == athleteAchievement.id);
                if (result != null)
                {
                    result.place = athleteAchievement.place;
                    result.description = athleteAchievement.description;
                    result.athleteAchievementType = athleteAchievement.athleteAchievementType;
                    result.resultTime = athleteAchievement.resultTime;
                    result.resultDistance = athleteAchievement.resultDistance;
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
