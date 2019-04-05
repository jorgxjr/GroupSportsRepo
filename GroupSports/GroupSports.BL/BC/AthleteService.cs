using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM.DTO;

namespace GroupSports.BL.BC
{
    public class AthleteService : IAthleteService
    {
        IAthleteRepository athleteRepository = new AthleteRepository();

        public List<AthleteDTO> atheletesByCoachId(int id)
        {
            return athleteRepository.atheletesByCoachId(id);
        }

        public List<AthleteDTO> atheletesByCoachIdSubAge(int id, int edadInicio, int edadFin)
        {
            return athleteRepository.atheletesByCoachIdSubAge(id, edadInicio, edadFin);
        }

        public List<AthleteDTO> atheletesByCoachIdUnderAge(int id, int edadFin)
        {
            return athleteRepository.atheletesByCoachIdUnderAge(id, edadFin);
        }

        public void deleteAthlete(int id)
        {
            athleteRepository.deleteAthlete(id);
        }

        public List<AthleteDTO> findAll()
        {
            return athleteRepository.findAll();
        }

        public AthleteDTO findById(int id)
        {
            return athleteRepository.findById(id);
        }

        public List<AthleteDTO> findByName(string name)
        {
            return athleteRepository.findByName(name);
        }

        public NewAthleteResponseDTO insertAthlete(AthleteDTO athleteDTO)
        {
            return athleteRepository.insertAthlete(athleteDTO);
        }

        public void updateAthlete(AthleteDTO athleteDTO)
        {
            athleteRepository.updateAthlete(athleteDTO);
        }
    }
}
