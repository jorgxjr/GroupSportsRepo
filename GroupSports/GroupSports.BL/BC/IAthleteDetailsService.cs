using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IAthleteDetailsService
    {
        List<athleteDetails> findAll();
        athleteDetails findById(int id);
        List<athleteDetails> findByAthleteId(int id);
        athleteDetails findDetailByAthleteId(int id);
        string insertathleteDetails(athleteDetails athleteDetails);
        string updateathleteDetails(athleteDetails athleteDetails);
        string deleteathleteDetails(int id);
    }
}
