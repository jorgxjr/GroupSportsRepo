using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;

namespace GroupSports.DL.DALI
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        group_sportsEntities context = new group_sportsEntities();
        public string deletequizQuestion(int id)
        {
            try
            {
                var quizQuestion = context.quizQuestion.FirstOrDefault(x => x.id == id);
                if (quizQuestion != null)
                {
                    context.quizQuestion.Remove(quizQuestion);
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<quizQuestion> findAll()
        {
            return context.quizQuestion.Where(s => s.available).ToList();
        }

        public quizQuestion findById(int id)
        {
            return context.quizQuestion.FirstOrDefault(x => x.id == id && x.available);
        }

        public string insertquizQuestion(quizQuestion quizQuestion)
        {
            try
            {
                quizQuestion.available = true;
                context.quizQuestion.Add(quizQuestion);
                context.SaveChanges();
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }
        public string insertquizQuestionAnswers(List<quizQuestionByAthlete> quizQuestionByAthletes)
        {
            try
            {
                if (quizQuestionByAthletes.Count > 0) {
                    int athleteQuizId = quizQuestionByAthletes.FirstOrDefault().athleteQuizId;

                    athleteQuiz aquiz = context.athleteQuiz.FirstOrDefault(aq => aq.id == athleteQuizId);
                    aquiz.answeredDate = DateTime.UtcNow.Date;
                    context.quizQuestionByAthlete.AddRange(quizQuestionByAthletes);
                    context.SaveChanges();
                    return CONSTANTES.CONSTANTES.ServiceResponse.ok;
                }
                else
                {
                    return CONSTANTES.CONSTANTES.ServiceResponse.error;
                }
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<quizQuestion> quizQuestionByQuizId(int quizId)
        {
            return context.quizQuestion
                .Where(s => s.quizId == quizId && s.available)
                .ToList();
        }

        public List<athleteQuizDTO> athletesQuizByQuizId(int quizId)
        {
            List<athleteQuizDTO> athleteQuizDTOs = new List<athleteQuizDTO>();

            var athletesQuizzes = context.athleteQuiz
                                    .Where(s => s.quizId == quizId && s.available)
                                    .ToList();

            athletesQuizzes.ForEach(a => athleteQuizDTOs.Add(new athleteQuizDTO(a)));
            return athleteQuizDTOs;
        }

        public string updatequizQuestion(quizQuestion quizQuestion)
        {
            try
            {
                var result = context.quizQuestion.FirstOrDefault(x => x.id == quizQuestion.id);
                if (result != null)
                {
                    result.questionTitle = quizQuestion.questionTitle;
                    context.SaveChanges();
                }
                return CONSTANTES.CONSTANTES.ServiceResponse.ok;
            }
            catch (Exception)
            {
                return CONSTANTES.CONSTANTES.ServiceResponse.error;
            }
        }

        public List<athleteQuizDTO> athletesQuizByAthleteId(int athleteId)
        {
            List<athleteQuizDTO> athleteQuizDTOs = new List<athleteQuizDTO>();

            var athletesQuizzes = context.athleteQuiz
                                    .Where(s => s.athleteId == athleteId && s.available)
                                    .ToList();

            athletesQuizzes.ForEach(a => athleteQuizDTOs.Add(new athleteQuizDTO(a)));
            return athleteQuizDTOs;
        }
    }
}
