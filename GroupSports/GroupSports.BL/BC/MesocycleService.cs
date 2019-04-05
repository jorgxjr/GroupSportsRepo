using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class MesocycleService : IMesocycleService
    {
        IMesocycleRepository mesocycleRepository = new MesocycleRepository();
        public string deleteMesocycle(int id)
        {
            return mesocycleRepository.deleteMesocycle(id);
        }

        public List<mesocycle> findAll()
        {
            return mesocycleRepository.findAll();
        }

        public mesocycle findById(int id)
        {
            return mesocycleRepository.findById(id);
        }

        public string insertMesocycle(mesocycle mesocycle)
        {
            return mesocycleRepository.insertMesocycle(mesocycle);
        }

        public List<mesocycle> mesocyclesByTrainingPlanId(int id)
        {
            return mesocycleRepository.mesocyclesByTrainingPlanId(id);
        }

        public string updateMesocycle(mesocycle mesocycle)
        {
            return mesocycleRepository.updateMesocycle(mesocycle);
        }
    }
}
