using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IMesocycleRepository
    {
        List<mesocycle> findAll();
        mesocycle findById(int id);
        List<mesocycle> mesocyclesByTrainingPlanId(int id);
        List<mesocycle> mesocyclesByTrainingPlanIdNoNulls(int id);
        int numberOfMesocyclesByTrainingPlanId(int id);
        string insertMesocycle(mesocycle mesocycle);
        string updateMesocycle(mesocycle mesocycle);
        string deleteMesocycle(int id);
    }
}
