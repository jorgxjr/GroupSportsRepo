using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IAthleteService
    {
        List<AthleteDTO> findAll();
        AthleteDTO findById(int id);
        List<AthleteDTO> findByName(string name);
        List<AthleteDTO> atheletesByCoachId(int id);
        NewAthleteResponseDTO insertAthlete(AthleteDTO athleteDTO);
        void updateAthlete(AthleteDTO athleteDTO);
        void deleteAthlete(int id);
        List<AthleteDTO> atheletesByCoachIdSubAge(int id, int edadInicio, int edadFin);
        List<AthleteDTO> atheletesByCoachIdUnderAge(int id, int edadFin);
    }
}
