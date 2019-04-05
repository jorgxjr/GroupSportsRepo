using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IStrengthTestTypeRepository
    {
        List<strengthTestType> findAll();
        strengthTestType findById(int id);
        string insertstrengthTestType(strengthTestType strengthTestType);
        string updatestrengthTestType(strengthTestType strengthTestType);
        string deletestrengthTestType(int id);
    }
}
