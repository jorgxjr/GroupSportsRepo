using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class MesocycleTypeService : IMesocycleTypeService
    {
        IMesocycleTypeRepository mesocycleTypeRepository = new MesocycleTypeRepository();
        public void deleteMesocycleType(int id)
        {
            mesocycleTypeRepository.deleteMesocycleType(id);
        }

        public List<mesocycleType> findAll()
        {
            return mesocycleTypeRepository.findAll();
        }

        public mesocycleType findById(int id)
        {
            return mesocycleTypeRepository.findById(id);
        }

        public List<mesocycleType> findByName(string name)
        {
            return mesocycleTypeRepository.findByName(name);
        }

        public void insertMesocycleType(mesocycleType mesocycleType)
        {
            mesocycleTypeRepository.insertMesocycleType(mesocycleType);
        }

        public void updateMesocycleType(mesocycleType mesocycleType)
        {
            mesocycleTypeRepository.updateMesocycleType(mesocycleType);
        }
    }
}
