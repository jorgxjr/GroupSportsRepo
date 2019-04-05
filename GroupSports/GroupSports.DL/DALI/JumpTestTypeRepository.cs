using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class JumpTestTypeRepository : IJumpTestTypeRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deletejumpTestType(int id)
        {
            try
            {
                var jumpTestType = context.jumpTestType.FirstOrDefault(m => m.id == id);
                if (jumpTestType != null)
                {
                    context.jumpTestType.Remove(jumpTestType);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<jumpTestType> findAll()
        {
            return context.jumpTestType.Where(m => m.available).ToList();
        }

        public jumpTestType findById(int id)
        {
            return context.jumpTestType.FirstOrDefault(m => m.available && m.id == id);
        }

        public string insertjumpTestType(jumpTestType jumpTestType)
        {
            try
            {
                jumpTestType.available = true;
                context.jumpTestType.Add(jumpTestType);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updatejumpTestType(jumpTestType jumpTestType)
        {
            try
            {
                var result = context.strengthTestType.FirstOrDefault(x => x.id == jumpTestType.id);
                if (result != null)
                {
                    result.description = jumpTestType.description;
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
