using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IJumpTestTypeRepository
    {
        List<jumpTestType> findAll();
        jumpTestType findById(int id);
        string insertjumpTestType(jumpTestType jumpTestType);
        string updatejumpTestType(jumpTestType jumpTestType);
        string deletejumpTestType(int id);
    }
}
