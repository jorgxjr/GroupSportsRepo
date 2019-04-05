using GroupSports.BL.BC;
using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GroupSportsApiRest.Controllers
{
    [Authorize]
    [RoutePrefix("api/QuizQuestions")]
    public class QuizQuestionsController : ApiController
    {
        IQuizQuestionService quizQuestionService = new QuizQuestionService();

        // GET: api/QuizQuestions
        [ResponseType(typeof(List<quizQuestion>))]
        public IHttpActionResult Get()
        {
            List<quizQuestion> quizQuestions;
            try
            {
                quizQuestions = quizQuestionService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(quizQuestions);
        }

        // GET: api/QuizQuestions/5
        public IHttpActionResult Get(int id)
        {
            quizQuestion quizQuestion;
            try
            {
                quizQuestion = quizQuestionService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (quizQuestion == null)
            {
                return NotFound();
            }

            return Ok(quizQuestion);
        }

        // POST: api/QuizQuestions
        public IHttpActionResult Post([FromBody]quizQuestion value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = quizQuestionService.insertquizQuestion(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/QuizQuestions/5
        public IHttpActionResult Put(int id, [FromBody]quizQuestion value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = quizQuestionService.updatequizQuestion(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/QuizQuestions/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = quizQuestionService.deletequizQuestion(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // POST: api/QuizQuestions/answers
        [HttpPost]
        [Route("answers")]
        public IHttpActionResult insertquizQuestionAnswers(List<quizQuestionByAthlete> quizQuestionByAthletes)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = quizQuestionService.insertquizQuestionAnswers(quizQuestionByAthletes)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
