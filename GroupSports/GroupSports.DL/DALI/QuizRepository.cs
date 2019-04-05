using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class QuizRepository : IQuizRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deletequiz(int id)
        {
            try
            {
                var quiz = context.quiz.FirstOrDefault(x => x.id == id);
                if (quiz != null)
                {
                    context.quiz.Remove(quiz);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<quiz> findAll()
        {
            return context.quiz.Where(s => s.available).ToList();
        }

        public quiz findById(int id)
        {
            return context.quiz.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertquiz(QuizDTO quizDTO)
        {
            try
            {
                quizDTO.quiz.available = true;
                quiz quizInserted = context.quiz.Add(quizDTO.quiz);
                int quizIdInserted = quizInserted.id;

                quizDTO.athleteQuizzes.ForEach(a => {
                    a.quizId = quizIdInserted;
                    a.available = true;
                    context.athleteQuiz.Add(a);
                });

                quizDTO.quizQuestions.ForEach(q => {
                    q.quizId = quizIdInserted;
                    q.available = true;
                    context.quizQuestion.Add(q);
                });

                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<quiz> quizByCoachId(int coachId)
        {
            return context.quiz
                .Where(s => s.coachId == coachId && s.available)
                .ToList();
        }

        public List<quiz> quizByCoachIdByDay(int coachId, DateTime day)
        {
            return context.quiz
                .Where(s => s.coachId == coachId &&
                        DbFunctions.TruncateTime(s.date) == DbFunctions.TruncateTime(day) &&
                        s.available)
                .ToList();
        }

        public string updatequiz(quiz quiz)
        {
            try
            {
                var result = context.quiz.FirstOrDefault(x => x.id == quiz.id);
                if (result != null)
                {
                    result.quizTitle = quiz.quizTitle;
                    result.date = quiz.date;
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
