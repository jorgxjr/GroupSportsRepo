using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSports.DL.DM.DTO
{
    public class QuizDTO
    {
        public quiz quiz { get; set; }
        public List<athleteQuiz> athleteQuizzes { get; set; }
        public List<quizQuestion> quizQuestions { get; set; }

    }
}
