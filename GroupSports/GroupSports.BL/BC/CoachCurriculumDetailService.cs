using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;

namespace GroupSports.BL.BC
{
    public class CoachCurriculumDetailService : ICoachCurriculumDetailService
    {
        ICoachCurriculumDetailRepository coachCurriculumDetailRepository = new CoachCurriculumDetailRepository();
        public List<coachCurriculumDetail> coachCurriculumDetailByCoachId(int coachId)
        {
            return coachCurriculumDetailRepository.coachCurriculumDetailByCoachId(coachId);
        }

        public string deletecoachCurriculumDetail(int id)
        {
            return coachCurriculumDetailRepository.deletecoachCurriculumDetail(id);
        }

        public List<coachCurriculumDetail> findAll()
        {
            return coachCurriculumDetailRepository.findAll();
        }

        public coachCurriculumDetail findById(int id)
        {
            return coachCurriculumDetailRepository.findById(id);
        }

        public string insertcoachCurriculumDetail(coachCurriculumDetail coachCurriculumDetail)
        {
            return coachCurriculumDetailRepository.insertcoachCurriculumDetail(coachCurriculumDetail);
        }

        public string updatecoachCurriculumDetail(coachCurriculumDetail coachCurriculumDetail)
        {
            return coachCurriculumDetailRepository.updatecoachCurriculumDetail(coachCurriculumDetail);
        }
    }
}
