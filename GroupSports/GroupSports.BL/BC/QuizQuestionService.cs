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
    public class QuizQuestionService : IQuizQuestionService
    {
        IQuizQuestionRepository quizQuestionRepository = new QuizQuestionRepository();

        public List<athleteQuizDTO> athletesQuizByAthleteId(int athleteId)
        {
            return quizQuestionRepository.athletesQuizByAthleteId(athleteId);
        }

        public List<athleteQuizDTO> athletesQuizByQuizId(int quizId)
        {
            return quizQuestionRepository.athletesQuizByQuizId(quizId);
        }

        public string deletequizQuestion(int id)
        {
            return quizQuestionRepository.deletequizQuestion(id);
        }

        public List<quizQuestion> findAll()
        {
            return quizQuestionRepository.findAll();
        }

        public quizQuestion findById(int id)
        {
            return quizQuestionRepository.findById(id);
        }

        public string insertquizQuestion(quizQuestion quizQuestion)
        {
            return quizQuestionRepository.insertquizQuestion(quizQuestion);
        }

        public string insertquizQuestionAnswers(List<quizQuestionByAthlete> quizQuestionByAthletes)
        {
            return quizQuestionRepository.insertquizQuestionAnswers(quizQuestionByAthletes);
        }

        public List<quizQuestion> quizQuestionByQuizId(int quizId)
        {
            return quizQuestionRepository.quizQuestionByQuizId(quizId);
        }

        public string updatequizQuestion(quizQuestion quizQuestion)
        {
            return quizQuestionRepository.updatequizQuestion(quizQuestion);
        }
    }
}
