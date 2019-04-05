using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class JumpTestTypeService : IJumpTestTypeService
    {
        IJumpTestTypeRepository jumpTestTypeRepository = new JumpTestTypeRepository();
        public string deletejumpTestType(int id)
        {
            return jumpTestTypeRepository.deletejumpTestType(id);
        }

        public List<jumpTestType> findAll()
        {
            return jumpTestTypeRepository.findAll();
        }

        public jumpTestType findById(int id)
        {
            return jumpTestTypeRepository.findById(id);
        }

        public string insertjumpTestType(jumpTestType jumpTestType)
        {
            return jumpTestTypeRepository.insertjumpTestType(jumpTestType);
        }

        public string updatejumpTestType(jumpTestType jumpTestType)
        {
            return jumpTestTypeRepository.updatejumpTestType(jumpTestType);
        }
    }
}
