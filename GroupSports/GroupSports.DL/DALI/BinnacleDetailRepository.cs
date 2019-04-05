using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class BinnacleDetailRepository : IBinnacleDetailRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public List<binnacleDetail> binnacleBySessionId(int sessionId)
        {
            return context.binnacleDetail
                .Where(s => s.sessionId == sessionId && s.available)
                .ToList();
        }

        public string deleteBinnacleDetail(int id)
        {
            try
            {
                var binnacleDetail = context.binnacleDetail.FirstOrDefault(x => x.id == id);
                if (binnacleDetail != null)
                {
                    context.binnacleDetail.Remove(binnacleDetail);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<binnacleDetail> findAll()
        {
            return context.binnacleDetail.Where(s => s.available).ToList();
        }

        public binnacleDetail findById(int id)
        {
            return context.binnacleDetail
                .FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertBinnacleDetail(binnacleDetail binnacleDetail)
        {
            try
            {
                binnacleDetail.available = true;
                context.binnacleDetail.Add(binnacleDetail);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updateBinnacleDetail(binnacleDetail binnacleDetail)
        {
            try
            {
                var result = context.binnacleDetail.FirstOrDefault(x => x.id == binnacleDetail.id);
                if (result != null)
                {
                    result.detail = binnacleDetail.detail;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }
    }
}
