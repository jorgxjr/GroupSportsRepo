using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IJumpTestTypeService
    {
        List<jumpTestType> findAll();
        jumpTestType findById(int id);
        string insertjumpTestType(jumpTestType jumpTestType);
        string updatejumpTestType(jumpTestType jumpTestType);
        string deletejumpTestType(int id);
    }
}
