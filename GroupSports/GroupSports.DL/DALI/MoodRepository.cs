using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class MoodRepository : IMoodRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deleteMood(int id)
        {
            try
            {
                var mood = context.mood.FirstOrDefault(m => m.id == id);
                if (mood != null)
                {
                    context.mood.Remove(mood);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<mood> findAll()
        {
            return context.mood.Where(m => m.available)
                                .OrderByDescending(m => m.dayOfMood)
                                .ToList();
        }

        public List<mood> findByAthleteId(int id)
        {
            return context.mood.Where(x => x.athleteId == id && 
                                x.available &&
                                !(x.colorOfMoodId == null))
                                .OrderByDescending(x => x.dayOfMood)
                                .ToList();
        }

        public List<mood> findByAthleteIdAndDay(int id, DateTime day)
        {
            return context.mood.Where(x => x.athleteId == id && 
                                        DbFunctions.TruncateTime(x.dayOfMood) == DbFunctions.TruncateTime(day) &&
                                        x.colorOfMoodId == null &&
                                        x.available)
                                        .OrderBy(x => x.dayOfMood)
                                        .ToList();
        }

        public mood findById(int id)
        {
            return context.mood.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertMood(mood mood)
        {
            try
            {
                mood.available = true;
                context.mood.Add(mood);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateMood(mood mood)
        {
            try
            {
                var result = context.mood.FirstOrDefault(x => x.id == mood.id);
                if (result != null)
                {
                    result.colorOfMoodId = mood.colorOfMoodId;
                    result.dayOfMood = mood.dayOfMood;
                    result.athleteId = mood.athleteId;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateMoodResponse(mood mood)
        {
            try
            {
                var result = context.mood.FirstOrDefault(x => x.id == mood.id);
                if (result != null)
                {
                    result.colorOfMoodId = mood.colorOfMoodId;
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
