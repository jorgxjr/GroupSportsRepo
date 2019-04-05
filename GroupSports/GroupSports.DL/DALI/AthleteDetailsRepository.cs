using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class AthleteDetailsRepository : IAthleteDetailsRepository
    {
        group_sportsEntities context = new group_sportsEntities();

        public string deleteathleteDetails(int id)
        {
            try
            {
                var athleteDetails = context.athleteDetails.FirstOrDefault(m => m.id == id);
                if (athleteDetails != null)
                {
                    context.athleteDetails.Remove(athleteDetails);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<athleteDetails> findAll()
        {
            return context.athleteDetails.Where(m => m.available)
                                .ToList();
        }

        public List<athleteDetails> findByAthleteId(int id)
        {
            return context.athleteDetails.Where(m => m.available && m.athleteId == id)
                                .ToList();
        }

        public athleteDetails findDetailByAthleteId(int id)
        {
            return context.athleteDetails.FirstOrDefault(m => m.available && m.athleteId == id);
        }

        public athleteDetails findById(int id)
        {
            return context.athleteDetails.FirstOrDefault(m => m.available && m.id == id);
        }

        public string insertathleteDetails(athleteDetails athleteDetails)
        {
            try
            {
                athleteDetails.available = true;
                context.athleteDetails.Add(athleteDetails);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateathleteDetails(athleteDetails athleteDetails)
        {
            try
            {
                var result = context.athleteDetails.FirstOrDefault(x => x.id == athleteDetails.id);
                if (result != null)
                {
                    result.weight = athleteDetails.weight;
                    result.height = athleteDetails.height;
                    result.bodySpan = athleteDetails.bodySpan;
                    result.legLength = athleteDetails.legLength;
                    result.halfSquatToFloor = athleteDetails.halfSquatToFloor;
                    result.shirtSize = athleteDetails.shirtSize;
                    result.pantsSize = athleteDetails.pantsSize;
                    result.footwearSize = athleteDetails.footwearSize;
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
