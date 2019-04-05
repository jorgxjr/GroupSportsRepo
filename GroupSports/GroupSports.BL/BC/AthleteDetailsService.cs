using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class AthleteDetailsService : IAthleteDetailsService
    {
        IAthleteDetailsRepository athleteRepository = new AthleteDetailsRepository();
        public string deleteathleteDetails(int id)
        {
            return athleteRepository.deleteathleteDetails(id);
        }

        public List<athleteDetails> findAll()
        {
            return athleteRepository.findAll();
        }

        public List<athleteDetails> findByAthleteId(int id)
        {
            return athleteRepository.findByAthleteId(id);
        }

        public athleteDetails findById(int id)
        {
            return athleteRepository.findById(id);
        }

        public athleteDetails findDetailByAthleteId(int id)
        {
            return athleteRepository.findDetailByAthleteId(id);
        }

        public string insertathleteDetails(athleteDetails athleteDetails)
        {
            return athleteRepository.insertathleteDetails(athleteDetails);
        }

        public string updateathleteDetails(athleteDetails athleteDetails)
        {
            return athleteRepository.updateathleteDetails(athleteDetails);
        }
    }
}
