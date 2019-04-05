using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IBinnacleDetailRepository
    {
        List<binnacleDetail> findAll();
        binnacleDetail findById(int id);
        List<binnacleDetail> binnacleBySessionId(int sessionId);
        string insertBinnacleDetail(binnacleDetail binnacleDetail);
        string updateBinnacleDetail(binnacleDetail binnacleDetail);
        string deleteBinnacleDetail(int id);
    }
}
