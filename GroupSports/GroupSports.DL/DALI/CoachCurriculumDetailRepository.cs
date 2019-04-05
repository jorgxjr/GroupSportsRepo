using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;

namespace GroupSports.DL.DALI
{
    public class CoachCurriculumDetailRepository : ICoachCurriculumDetailRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public List<coachCurriculumDetail> coachCurriculumDetailByCoachId(int coachId)
        {
            var coachCurriculumDetails = context.coachCurriculumDetail
               .Where(w => w.coachId == coachId && w.available)
               .ToList();

            return coachCurriculumDetails;
        }

        public string deletecoachCurriculumDetail(int id)
        {
            try
            {
                var coachCurriculumDetail = context.coachCurriculumDetail.FirstOrDefault(x => x.id == id);
                if (coachCurriculumDetail != null)
                {
                    context.coachCurriculumDetail.Remove(coachCurriculumDetail);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<coachCurriculumDetail> findAll()
        {
            return context.coachCurriculumDetail.Where(st => st.available).ToList();
        }

        public coachCurriculumDetail findById(int id)
        {
            return context.coachCurriculumDetail.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertcoachCurriculumDetail(coachCurriculumDetail coachCurriculumDetail)
        {
            try
            {
                coachCurriculumDetail.available = true;
                context.coachCurriculumDetail.Add(coachCurriculumDetail);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public string updatecoachCurriculumDetail(coachCurriculumDetail coachCurriculumDetail)
        {
            try
            {
                var result = context.coachCurriculumDetail.FirstOrDefault(x => x.id == coachCurriculumDetail.id);
                if (result != null)
                {
                    result.title = coachCurriculumDetail.title;
                    result.description = coachCurriculumDetail.description;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception e)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }
    }
}
