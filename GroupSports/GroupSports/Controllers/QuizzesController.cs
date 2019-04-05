using GroupSports.BL.BC;
using GroupSports.DL.DM;
using GroupSports.DL.DM.DTO;
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
    [RoutePrefix("api/Quizzes")]
    public class QuizzesController : ApiController
    {
        IQuizService quizService = new QuizService();
        IQuizQuestionService quizQuestionService = new QuizQuestionService();

        // GET: api/Quizzes
        [ResponseType(typeof(List<quiz>))]
        public IHttpActionResult Get()
        {
            List<quiz> quizzes;
            try
            {
                quizzes = quizService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(quizzes);
        }

        // GET: api/Quizzes/5
        [ResponseType(typeof(quiz))]
        public IHttpActionResult Get(int id)
        {
            quiz quiz;
            try
            {
                quiz = quizService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(quiz);
        }

        // POST: api/Quizzes
        public IHttpActionResult Post([FromBody]QuizDTO value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = quizService.insertquiz(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/Quizzes/5
        public IHttpActionResult Put(int id, [FromBody]quiz value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = quizService.updatequiz(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/Quizzes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = quizService.deletequiz(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // GET: api/Quizzes/{id}/QuizQuestions
        [HttpGet]
        [Route("{id:int}/QuizQuestions/")]
        public IHttpActionResult GetQuizQuestionsByQuizId(int id)
        {
            List<quizQuestion> quizQuestions;
            try
            {
                quizQuestions = quizQuestionService.quizQuestionByQuizId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(quizQuestions);
        }

        // GET: api/Quizzes/{id}/athletesQuestions
        [HttpGet]
        [Route("{id:int}/athletesQuestions/")]
        public IHttpActionResult athletesQuizByQuizId(int id)
        {
            List<athleteQuizDTO> athleteQuizzes;
            try
            {
                athleteQuizzes = quizQuestionService.athletesQuizByQuizId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteQuizzes);
        }
    }
}
