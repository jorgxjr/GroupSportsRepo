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

namespace GroupSports.Controllers
{
    [Authorize]
    [RoutePrefix("api/coachs")]
    public class CoachsController : ApiController
    {
        ICoachService coachService = new CoachService();
        IAthleteService atheleteService = new AthleteService();
        ITrainingPlanService trainingPlanService = new TrainingPlanService();
        IAssistanceService assistanceService = new AssistanceService();
        IAnnouncementService announcementService = new AnnouncementService();
        ISessionService sessionService = new SessionService();
        IQuizService quizService = new QuizService();
        ICoachCurriculumDetailService coachCurriculumDetailService = new CoachCurriculumDetailService();
        ISpeedTestService speedTestService = new SpeedTestService();
        IJumpTestService jumpTestService = new JumpTestService();

        // GET: api/Coachs
        [ResponseType(typeof(List<CoachDTO>))]
        public IHttpActionResult Get()
        {
            List<CoachDTO> coachsFinded;
            try
            {
                coachsFinded = coachService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(coachsFinded);
        }

        // GET: api/Coachs/{id}/atheletes
        [HttpGet]
        [Route("{id:int}/atheletes")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoach(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/{id}/atheletes/sub12
        [HttpGet]
        [Route("{id:int}/atheletes/sub12")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoachSub12(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachIdUnderAge(id, 11);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/{id}/atheletes/sub14
        [HttpGet]
        [Route("{id:int}/atheletes/sub14")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoachSub14(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachIdUnderAge(id, 13);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/{id}/atheletes/sub16
        [HttpGet]
        [Route("{id:int}/atheletes/sub16")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoachSub16(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachIdUnderAge(id, 15);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/{id}/atheletes/sub18
        [HttpGet]
        [Route("{id:int}/atheletes/sub18")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoachSub18(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachIdUnderAge(id,17);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/{id}/atheletes/sub20
        [HttpGet]
        [Route("{id:int}/atheletes/sub20")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoachSub20(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachIdUnderAge(id, 19);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/{id}/atheletes/sub23
        [HttpGet]
        [Route("{id:int}/atheletes/sub23")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoachSub23(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachIdUnderAge(id, 22);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/{id}/atheletes/sub23
        [HttpGet]
        [Route("{id:int}/atheletes/sub30")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoachSub30(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachIdUnderAge(id, 29);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/{id}/atheletes/masters
        [HttpGet]
        [Route("{id:int}/atheletes/masters")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetAtheletesByCoachAdultos(int id)
        {
            List<AthleteDTO> atheletesFinded;
            try
            {
                atheletesFinded = atheleteService.atheletesByCoachIdSubAge(id, 30, 150);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(atheletesFinded);
        }

        // GET: api/Coachs/5
        [ResponseType(typeof(CoachDTO))]
        public IHttpActionResult Get(int id)
        {
            CoachDTO coachFound;
            try
            {
                coachFound = coachService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (coachFound == null)
            {
                return NotFound();
            }

            return Ok(coachFound);
        }

        // POST: api/Coachs
        public IHttpActionResult Post([FromBody]CoachDTO value)
        {
            try
            {
                coachService.insertCoach(value);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok();
        }

        // POST: api/Coachs/{coachId}/{athleteId}
        [HttpPost]
        [Route("{coachId:int}/{athleteId:int}")]
        public IHttpActionResult PostAtheleteByCoach(int coachId, int athleteId)
        {
            try
            {
                coachService.insertAthleteOnCoach(athleteId, coachId);
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = "Usuario agregado"
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // POST: api/Coachs/{coachId}/{athleteName}
        [HttpPost]
        [Route("{coachId:int}/{athleteName}")]
        public IHttpActionResult PostByAtheleteNameOnCoach(int coachId, string athleteName)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    respuesta = coachService.PostByAtheleteNameOnCoach(coachId, athleteName)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/Coachs/5
        public IHttpActionResult Put([FromBody]CoachDTO value)
        {
            try
            { 
                coachService.updateCoach(value);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok();
        }

        // DELETE: api/Coach/5
        public IHttpActionResult Delete(int id)
        {
            try
            { 
                coachService.deleteCoach(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok();
        }

        // GET: api/Coachs/{id}/trainingPlans
        [HttpGet]
        [Route("{id:int}/trainingPlans")]
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult GetTrainingPlansByCoach(int id)
        {
            List<trainingPlan> trainingPlansFinded;
            try
            {
                trainingPlansFinded = trainingPlanService.trainingPlansByCoachId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(trainingPlansFinded);
        }

        // GET: api/Coachs/{id}/assistance/{day:datetime}
        [HttpGet]
        [Route("{id:int}/assistance/{day:datetime}")]
        [ResponseType(typeof(List<AssistanceDTO>))]
        public IHttpActionResult GetAssistanceByCoach(int id, DateTime day)
        {
            List<AssistanceDTO> assistanceDtoFinded;
            try
            {
                assistanceDtoFinded = assistanceService.findByCoachId(id, day);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(assistanceDtoFinded);
        }

        // PUT: api/Coachs/{id}/assistance
        [HttpPut]
        [Route("{id:int}/assistance/")]
        public IHttpActionResult PutAssistanceByCoach([FromBody] AssistanceUpdatesDTO assistanceUpdates)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = assistanceService.updateAssistanceDTO(assistanceUpdates.assistanceShifts)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // GET: api/Coachs/{id}/announcement
        [HttpGet]
        [Route("{id:int}/announcement/")]
        public IHttpActionResult GetAnnouncementByCoach(int id)
        {
            List<AnnouncementDTO> announcementsFinded;
            try
            {
                announcementsFinded = announcementService.findAllAnnouncementsFromCoach(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(announcementsFinded);
        }

        // GET: api/Coachs/{id}/WorkSessions/{day:datetime}
        [HttpGet]
        [Route("{id:int}/WorkSessions/{day:datetime}")]
        [ResponseType(typeof(List<SessionDTO>))]
        public IHttpActionResult GetWorkSessionsByCoachAndDay(int id, DateTime day)
        {
            List<SessionDTO> sessions;
            try
            {
                sessions = sessionService.sessionsByCoachAndDate(id, day);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(sessions);
        }

        // GET: api/Coachs/{id}/quizzes/
        [HttpGet]
        [Route("{id:int}/quizzes/")]
        [ResponseType(typeof(List<quiz>))]
        public IHttpActionResult GetQuizzesByCoach(int id)
        {
            List<quiz> quizzes;
            try
            {
                quizzes = quizService.quizByCoachId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(quizzes);
        }

        // GET: api/Coachs/{id}/quizzes/{day:datetime}
        [HttpGet]
        [Route("{id:int}/quizzes/{day:datetime}")]
        [ResponseType(typeof(List<quiz>))]
        public IHttpActionResult GetQuizzesByCoachAndDay(int id, DateTime day)
        {
            List<quiz> quizzes;
            try
            {
                quizzes = quizService.quizByCoachIdByDay(id, day);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(quizzes);
        }

        // GET: api/Coachs/{id}/CoachCurriculumDetails/
        [HttpGet]
        [Route("{id:int}/CoachCurriculumDetails/")]
        [ResponseType(typeof(List<quiz>))]
        public IHttpActionResult GetCoachCurriculumDetailsByCoach(int id)
        {
            List<coachCurriculumDetail> coachCurriculumDetails;
            try
            {
                coachCurriculumDetails = coachCurriculumDetailService.coachCurriculumDetailByCoachId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(coachCurriculumDetails);
        }

        // GET: api/Coachs/{id}/AthletesSpeedPerformance/{meters}
        [HttpGet]
        [Route("{id:int}/AthletesSpeedPerformance/{meters:int}")]
        [ResponseType(typeof(List<AthleteSpeedPerformanceDTO>))]
        public IHttpActionResult GetAthletesSpeedPerformanceByCoach(int id, int meters)
        {
            List<AthleteSpeedPerformanceDTO> athleteSpeedPerformanceDTOs;
            try
            {
                athleteSpeedPerformanceDTOs = speedTestService.speedPerformanceByCoachIdByMeters(id,meters);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteSpeedPerformanceDTOs);
        }

        // GET: api/Coachs/{id}/AthletesSaltabilityPerformance/{jumpTestTypeId}
        [HttpGet]
        [Route("{id:int}/AthletesSaltabilityPerformance/{jumpTestTypeId:int}")]
        [ResponseType(typeof(List<AthleteSaltabilityPerformanceDTO>))]
        public IHttpActionResult GetAthletesSaltabilityPerformanceByCoach(int id, int jumpTestTypeId)
        {
            List<AthleteSaltabilityPerformanceDTO> athleteSaltabilityPerformanceDTOs;
            try
            {
                athleteSaltabilityPerformanceDTOs = jumpTestService.saltabilityPerformanceByCoachIdByJumpTestTypeId(id, jumpTestTypeId);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteSaltabilityPerformanceDTOs);
        }
    }
}
