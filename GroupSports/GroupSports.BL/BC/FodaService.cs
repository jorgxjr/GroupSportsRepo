using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class FodaService : IFodaService
    {
        IFodaRepository fodaRepository = new FodaRepository();
        public List<athleteFoda> athleteFodaByAthleteId(int athleteId)
        {
            return fodaRepository.athleteFodaByAthleteId(athleteId);
        }

        public string deleteathleteFoda(int id)
        {
            return fodaRepository.deleteathleteFoda(id);
        }

        public List<athleteFoda> findAll()
        {
            return fodaRepository.findAll();
        }

        public athleteFoda findById(int id)
        {
            return fodaRepository.findById(id);
        }

        public string insertathleteFoda(athleteFoda athleteFoda)
        {
            return fodaRepository.insertathleteFoda(athleteFoda);
        }

        public string updateathleteFoda(athleteFoda athleteFoda)
        {
            return fodaRepository.updateathleteFoda(athleteFoda);
        }
    }
}
