using GroupSports.BL.BC;
using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupSportsWeb.ViewModels.QuizsViewModel
{
    public class ListQuizsPlanViewModel
    {
        public List<quiz> ListQuizs { get; set; }
        public int idCoach { get; set; }
        public ListQuizsPlanViewModel()
        {

        }
        public void Fill()
        {
            IQuizService quizService = new QuizService();
            ListQuizs = quizService.quizByCoachId(idCoach);
        }
    }
}