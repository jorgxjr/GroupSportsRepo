using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.BL.BC
{
    public interface IQuizService
    {
        List<quiz> findAll();
        quiz findById(int id);
        List<quiz> quizByCoachId(int coachId);
        List<quiz> quizByCoachIdByDay(int coachId, DateTime day);
        string insertquiz(QuizDTO quizDTO);
        string updatequiz(quiz quiz);
        string deletequiz(int id);
    }
}
