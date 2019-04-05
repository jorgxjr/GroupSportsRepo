using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class StrengthTestTypeService : IStrengthTestTypeService
    {
        IStrengthTestTypeRepository strengthTestTypeRepository = new StrengthTestTypeRepository();
        public string deletestrengthTestType(int id)
        {
            return strengthTestTypeRepository.deletestrengthTestType(id);
        }

        public List<strengthTestType> findAll()
        {
            return strengthTestTypeRepository.findAll();
        }

        public strengthTestType findById(int id)
        {
            return strengthTestTypeRepository.findById(id);
        }

        public string insertstrengthTestType(strengthTestType strengthTestType)
        {
            return strengthTestTypeRepository.insertstrengthTestType(strengthTestType);
        }

        public string updatestrengthTestType(strengthTestType strengthTestType)
        {
            return strengthTestTypeRepository.updatestrengthTestType(strengthTestType);
        }
    }
}
