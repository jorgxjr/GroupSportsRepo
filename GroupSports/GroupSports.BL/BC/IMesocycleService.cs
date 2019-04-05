using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IMesocycleService
    {
        List<mesocycle> findAll();
        mesocycle findById(int id);
        List<mesocycle> mesocyclesByTrainingPlanId(int id);
        string insertMesocycle(mesocycle mesocycle);
        string updateMesocycle(mesocycle mesocycle);
        string deleteMesocycle(int id);
    }
}
