using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class MesocycleTypeRepository : IMesocycleTypeRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public void deleteMesocycleType(int id)
        {
            var mesocycleType = context.mesocycleType.FirstOrDefault(x => x.id == id);
            if (mesocycleType != null)
            {
                context.mesocycleType.Remove(mesocycleType);
                context.SaveChanges();
            }
        }

        public List<mesocycleType> findAll()
        {
            return context.mesocycleType.ToList();
        }

        public mesocycleType findById(int id)
        {
            return context.mesocycleType.FirstOrDefault(x => x.id == id);
        }

        public List<mesocycleType> findByName(string name)
        {
            return context.mesocycleType.Where(x => x.mesocycleName == name).ToList();
        }

        public void insertMesocycleType(mesocycleType mesocycleType)
        {
            context.mesocycleType.Add(mesocycleType);
            context.SaveChanges();
        }

        public void updateMesocycleType(mesocycleType mesocycleType)
        {
            var result = context.mesocycleType.FirstOrDefault(x => x.id == mesocycleType.id);
            if (result != null)
            {
                result.mesocycleName = mesocycleType.mesocycleName;
                context.SaveChanges();
            }
        }
    }
}
