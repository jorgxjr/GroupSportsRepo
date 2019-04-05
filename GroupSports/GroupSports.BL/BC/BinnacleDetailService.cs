using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class BinnacleDetailService : IBinnacleDetailService
    {
        IBinnacleDetailRepository binnacleService = new BinnacleDetailRepository();
        public List<binnacleDetail> binnacleBySessionId(int sessionId)
        {
            return binnacleService.binnacleBySessionId(sessionId);
        }

        public string deleteBinnacleDetail(int id)
        {
            return binnacleService.deleteBinnacleDetail(id);
        }

        public List<binnacleDetail> findAll()
        {
            return binnacleService.findAll();
        }

        public binnacleDetail findById(int id)
        {
            return binnacleService.findById(id);
        }

        public string insertBinnacleDetail(binnacleDetail binnacleDetail)
        {
            return binnacleService.insertBinnacleDetail(binnacleDetail);
        }

        public string updateBinnacleDetail(binnacleDetail binnacleDetail)
        {
            return binnacleService.updateBinnacleDetail(binnacleDetail);
        }
    }
}
