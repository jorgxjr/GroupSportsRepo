using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IWeightTestBySessionRepository
    {
        List<weightTestBySession> findAll();
        weightTestBySession findById(int id);
        List<weightTestBySession> findByAthleteId(int id);
        List<weightTestBySession> findBySessionId(int id);
        string insertweightTestBySession(weightTestBySession weightTestBySession);
        string updateweightTestBySession(weightTestBySession weightTestBySession);
        string deleteweightTestBySession(int id);
    }
}
