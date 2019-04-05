using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IAthleteRepository
    {
        List<AthleteDTO> findAll();
        AthleteDTO findById(int id);
        List<AthleteDTO> findByName(string name);
        List<AthleteDTO> atheletesByCoachId(int id);
        NewAthleteResponseDTO insertAthlete(AthleteDTO athlete);
        void updateAthlete(AthleteDTO athlete);
        void deleteAthlete(int id);
        List<AthleteDTO> atheletesByCoachIdSubAge(int id, int edadInicio, int edadFin);
        List<AthleteDTO> atheletesByCoachIdUnderAge(int id, int edadFin);
    }
}
