using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IMesocycleTypeRepository
    {
        List<mesocycleType> findAll();
        mesocycleType findById(int id);
        List<mesocycleType> findByName(string name);
        void insertMesocycleType(mesocycleType mesocycleType);
        void updateMesocycleType(mesocycleType mesocycleType);
        void deleteMesocycleType(int id);
    }
}
