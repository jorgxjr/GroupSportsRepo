using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DALI;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.BL.BC
{
    public class QuizService : IQuizService
    {
        IQuizRepository quizService = new QuizRepository();
        public string deletequiz(int id)
        {
            return quizService.deletequiz(id);
        }

        public List<quiz> findAll()
        {
            return quizService.findAll();
        }

        public quiz findById(int id)
        {
            return quizService.findById(id);
        }

        public string insertquiz(QuizDTO quizDTO)
        {
            return quizService.insertquiz(quizDTO);
        }

        public List<quiz> quizByCoachId(int coachId)
        {
            return quizService.quizByCoachId(coachId);
        }

        public List<quiz> quizByCoachIdByDay(int coachId, DateTime day)
        {
            return quizService.quizByCoachIdByDay(coachId,day);
        }

        public string updatequiz(quiz quiz)
        {
            return quizService.updatequiz(quiz);
        }
    }
}
