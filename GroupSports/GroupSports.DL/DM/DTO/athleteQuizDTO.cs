using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class athleteQuizDTO
    {
        public athleteQuizDTO(athleteQuiz athleteQuiz)
        {
            id = athleteQuiz.id;
            athleteId = athleteQuiz.athleteId;
            quizId = athleteQuiz.quizId;
            answeredDate = athleteQuiz.answeredDate;
            userName = athleteQuiz.athelete.user.username;
            pictureUrl = athleteQuiz.athelete.user.pictureUrl;
            quizTitle = athleteQuiz.quiz.quizTitle;
            date = athleteQuiz.quiz.date;
            coachId = athleteQuiz.quiz.coachId;
            pictureUrlCoach = athleteQuiz.quiz.coach.user.pictureUrl;
            quizQuestionByAthlete = athleteQuiz.quizQuestionByAthlete;
        }
        public int id { get; set; }
        public int athleteId { get; set; }
        public int quizId { get; set; }
        public Nullable<System.DateTime> answeredDate { get; set; }
        public string userName { get; set; }
        public string pictureUrl { get; set; }
        public string quizTitle { get; set; }
        public DateTime date { get; set; }
        public int coachId { get; set; }
        public string pictureUrlCoach { get; set; }
        public virtual ICollection<quizQuestionByAthlete> quizQuestionByAthlete { get; set; }
    }
}
