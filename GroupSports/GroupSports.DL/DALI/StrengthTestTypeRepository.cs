using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class StrengthTestTypeRepository : IStrengthTestTypeRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deletestrengthTestType(int id)
        {
            try
            {
                var strengthTestType = context.strengthTestType.FirstOrDefault(m => m.id == id);
                if (strengthTestType != null)
                {
                    context.strengthTestType.Remove(strengthTestType);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<strengthTestType> findAll()
        {
            return context.strengthTestType.Where(m => m.available).ToList();
        }

        public strengthTestType findById(int id)
        {
            return context.strengthTestType.FirstOrDefault(m => m.available && m.id == id);
        }

        public string insertstrengthTestType(strengthTestType strengthTestType)
        {
            try
            {
                strengthTestType.available = true;
                context.strengthTestType.Add(strengthTestType);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updatestrengthTestType(strengthTestType strengthTestType)
        {
            try
            {
                var result = context.strengthTestType.FirstOrDefault(x => x.id == strengthTestType.id);
                if (result != null)
                {
                    result.description = strengthTestType.description;
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
