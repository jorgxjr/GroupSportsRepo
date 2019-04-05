using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class FodaRepository : IFodaRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public List<athleteFoda> athleteFodaByAthleteId(int athleteId)
        {
            var athleteFoda = context.athleteFoda
               .Where(w => w.athleteId == athleteId && w.available)
               .ToList();

            return athleteFoda;
        }

        public string deleteathleteFoda(int id)
        {
            try
            {
                var athleteFoda = context.athleteFoda.FirstOrDefault(x => x.id == id);
                if (athleteFoda != null)
                {
                    context.athleteFoda.Remove(athleteFoda);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<athleteFoda> findAll()
        {
            return context.athleteFoda.Where(st => st.available).ToList();
        }

        public athleteFoda findById(int id)
        {
            return context.athleteFoda.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertathleteFoda(athleteFoda athleteFoda)
        {
            try
            {
                athleteFoda.available = true;
                context.athleteFoda.Add(athleteFoda);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateathleteFoda(athleteFoda athleteFoda)
        {
            try
            {
                var result = context.athleteFoda.FirstOrDefault(x => x.id == athleteFoda.id);
                if (result != null)
                {
                    result.fodaItemValue = athleteFoda.fodaItemValue;
                    result.date = athleteFoda.date;
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
