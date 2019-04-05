using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DALI
{
    public interface IQuizQuestionRepository
    {
        List<quizQuestion> findAll();
        quizQuestion findById(int id);
        List<quizQuestion> quizQuestionByQuizId(int quizId);
        List<athleteQuizDTO> athletesQuizByQuizId(int quizId);
        List<athleteQuizDTO> athletesQuizByAthleteId(int athleteId);
        string insertquizQuestion(quizQuestion quizQuestion);
        string insertquizQuestionAnswers(List<quizQuestionByAthlete> quizQuestionByAthletes);
        string updatequizQuestion(quizQuestion quizQuestion);
        string deletequizQuestion(int id);
    }
}
