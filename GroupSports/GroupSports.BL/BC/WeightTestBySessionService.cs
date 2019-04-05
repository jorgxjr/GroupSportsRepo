using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class WeightTestBySessionService : IWeightTestBySessionService
    {
        IWeightTestBySessionRepository weightTestBySessionRepository = new WeightTestBySessionRepository();
        public string deleteweightTestBySession(int id)
        {
            return weightTestBySessionRepository.deleteweightTestBySession(id);
        }

        public List<weightTestBySession> findAll()
        {
            return weightTestBySessionRepository.findAll();
        }

        public List<weightTestBySession> findByAthleteId(int id)
        {
            return weightTestBySessionRepository.findByAthleteId(id);
        }

        public weightTestBySession findById(int id)
        {
            return weightTestBySessionRepository.findById(id);
        }

        public List<weightTestBySession> findBySessionId(int id)
        {
            return weightTestBySessionRepository.findBySessionId(id);
        }

        public string insertweightTestBySession(weightTestBySession weightTestBySession)
        {
            return weightTestBySessionRepository.insertweightTestBySession(weightTestBySession);
        }

        public string updateweightTestBySession(weightTestBySession weightTestBySession)
        {
            return weightTestBySessionRepository.updateweightTestBySession(weightTestBySession);
        }
    }
}
