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
    [RoutePrefix("api/Athletes")]
    public class AthletesController : ApiController
    {
        IAthleteService athleteService = new AthleteService();
        ISpeedTestService speedTestService = new SpeedTestService();
        IMoodService moodService = new MoodService();
        IAnnouncementService announcementService = new AnnouncementService();
        IQuizQuestionService quizQuestionService = new QuizQuestionService();
        IAthleteDetailsService athleteDetailsService = new AthleteDetailsService();
        IShotPutTestService shotPutTestService = new ShotPutTestService();
        IWeightTestBySessionService weightTestBySessionService = new WeightTestBySessionService();
        IAntropometricTestService antropometricTestService = new AntropometricTestService();
        IJumpTestService jumpTestService = new JumpTestService();
        IStrengthTestService strengthTestService = new StrengthTestService();
        IFodaService fodaService = new FodaService();
        IAthleteAchievementService athleteAchievementService = new AthleteAchievementService();
        ICoachService coachService = new CoachService();
        IResistanceTestService resistanceTestService = new ResistanceTestService();
        ISessionService sessionService = new SessionService();

        // GET: api/Athletes
        [ResponseType(typeof(List<AthleteDTO>))]
        public IHttpActionResult Get()
        {
            List<AthleteDTO> athletesFinded;
            try
            {
                athletesFinded = athleteService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athletesFinded);
        }

        // GET: api/Athletes/5
        [ResponseType(typeof(AthleteDTO))]
        public IHttpActionResult Get(int id)
        {
            AthleteDTO athleteFound;
            try
            {
                athleteFound = athleteService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (athleteFound == null)
            {
                return NotFound();
            }

            return Ok(athleteFound);
        }

        // POST: api/Athletes
        public IHttpActionResult Post([FromBody]AthleteDTO value)
        {
            try
            {
                NewAthleteResponseDTO athleteAdded = athleteService.insertAthlete(value);
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = athleteAdded.response,
                    idAthleteAdded = athleteAdded.id
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/Athletes/5
        public IHttpActionResult Put(int id, [FromBody]AthleteDTO value)
        {
            try
            {
                athleteService.updateAthlete(value);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok();
        }

        // DELETE: api/Athletes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                athleteService.deleteAthlete(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok();
        }

        // GET: api/Athletes/{id}/SpeedTest
        [HttpGet]
        [Route("{id:int}/SpeedTest")]
        [ResponseType(typeof(List<speedTest>))]
        public IHttpActionResult GetSpeedTestsByAthlete(int id)
        {
            List<speedTest> speedTestsFinded;
            try
            {
                speedTestsFinded = speedTestService.speedTestByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(speedTestsFinded);
        }

        // GET: api/Athletes/{id}/ResistanceTest
        [HttpGet]
        [Route("{id:int}/ResistanceTest")]
        [ResponseType(typeof(List<resistanceTest>))]
        public IHttpActionResult GetResistanceTestsByAthlete(int id)
        {
            List<resistanceTest> resistanceTests;
            try
            {
                resistanceTests = resistanceTestService.resistanceTestByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(resistanceTests);
        }

        // GET: api/Athletes/{id}/moods
        [HttpGet]
        [Route("{id:int}/moods")]
        [ResponseType(typeof(List<mood>))]
        public IHttpActionResult GetMoodsByAthlete(int id)
        {
            List<mood> moodsFinded;
            try
            {
                moodsFinded = moodService.findByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(moodsFinded);
        }

        // GET: api/Athletes/{id}/moods/{day:datetime}
        [HttpGet]
        [Route("{id:int}/moods/{day:datetime}")]
        [ResponseType(typeof(List<mood>))]
        public IHttpActionResult GetMoodsByAthleteAndDay(int id, DateTime day)
        {
            List<mood> moodsFinded;
            try
            {
                moodsFinded = moodService.findByAthleteIdAndDay(id,day);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(moodsFinded);
        }

        // GET: api/Athletes/{id}/announcement
        [HttpGet]
        [Route("{id:int}/announcement")]
        [ResponseType(typeof(List<mood>))]
        public IHttpActionResult GetAnnouncementsByAthlete(int id)
        {
            List<announcement> announcementsFinded;
            try
            {
                announcementsFinded = announcementService.announcementByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(announcementsFinded);
        }

        // DELETE: api/Athletes/{id}/announcement
        [HttpDelete]
        [Route("{id:int}/announcement/{announcementId:int}")]
        public IHttpActionResult DeleteAnnouncementByAthlete(int id, int announcementId)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = announcementService.deleteAthleteAnnouncement(id, announcementId)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // GET: api/Athletes/{id}/WorkSessions/{day:datetime}
        [HttpGet]
        [Route("{id:int}/WorkSessions/{day:datetime}")]
        [ResponseType(typeof(List<SessionDTO>))]
        public IHttpActionResult GetWorkSessionsByCoachAndDay(int id, DateTime day)
        {
            List<SessionDTO> sessions;
            try
            {
                sessions = sessionService.sessionsByAthleteAndDate(id, day);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(sessions);
        }

        // GET: api/Athletes/{id}/athletesQuestions
        [HttpGet]
        [Route("{id:int}/athletesQuestions/")]
        public IHttpActionResult athletesQuizByQuizId(int id)
        {
            List<athleteQuizDTO> athleteQuizzes;
            try
            {
                athleteQuizzes = quizQuestionService.athletesQuizByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteQuizzes);
        }

        // GET: api/Athletes/{id}/AthleteDetails
        [HttpGet]
        [Route("{id:int}/AthleteDetails/")]
        public IHttpActionResult AthleteDetailsByAthlete(int id)
        {
            athleteDetails athleteDetails;
            try
            {
                athleteDetails = athleteDetailsService.findDetailByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteDetails);
        }

        // GET: api/Athletes/{id}/ShotPutTest
        [HttpGet]
        [Route("{id:int}/ShotPutTest/")]
        public IHttpActionResult ShotPutTestByAthlete(int id)
        {
            List<shotPutTest> shotPutTest;
            try
            {
                shotPutTest = shotPutTestService.findByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(shotPutTest);
        }

        // GET: api/Athletes/{id}/WeightTestBySession
        [HttpGet]
        [Route("{id:int}/WeightTestBySession/")]
        public IHttpActionResult WeightTestBySessionByAthlete(int id)
        {
            List<weightTestBySession> weightTestBySessions;
            try
            {
                weightTestBySessions = weightTestBySessionService.findByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(weightTestBySessions);
        }

        // GET: api/Athletes/{id}/AntropometricTest
        [HttpGet]
        [Route("{id:int}/AntropometricTest/")]
        public IHttpActionResult AntropometricTestByAthlete(int id)
        {
            List<anthropometricTest> anthropometricTests;
            try
            {
                anthropometricTests = antropometricTestService.findByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(anthropometricTests);
        }

        // GET: api/Athletes/{id}/JumpTest
        [HttpGet]
        [Route("{id:int}/JumpTest/")]
        public IHttpActionResult JumpTestByAthlete(int id)
        {
            List<jumpTest> jumpTests;
            try
            {
                jumpTests = jumpTestService.findByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(jumpTests);
        }

        // GET: api/Athletes/{id}/StrengthTest
        [HttpGet]
        [Route("{id:int}/StrengthTest/")]
        public IHttpActionResult StrengthTestByAthlete(int id)
        {
            List<strengthTest> strengthTests;
            try
            {
                strengthTests = strengthTestService.findByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(strengthTests);
        }

        // GET: api/Athletes/{id}/AthleteFodas
        [HttpGet]
        [Route("{id:int}/AthleteFodas/")]
        public IHttpActionResult athleteFodasByAthlete(int id)
        {
            List<athleteFoda> athleteFodas;
            try
            {
                athleteFodas = fodaService.athleteFodaByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteFodas);
        }

        // GET: api/Athletes/{id}/AthleteAchievements
        [HttpGet]
        [Route("{id:int}/AthleteAchievements/")]
        public IHttpActionResult athleteAchievementsByAthlete(int id)
        {
            List<athleteAchievement> athleteAchievements;
            try
            {
                athleteAchievements = athleteAchievementService.athleteAchievementByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteAchievements);
        }

        // GET: api/Athletes/{id}/coachs
        [HttpGet]
        [Route("{id:int}/coachs/")]
        public IHttpActionResult coachsByAthlete(int id)
        {
            List<CoachDTO> coachDTOs;
            try
            {
                coachDTOs = coachService.findByAthleteId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(coachDTOs);
        }

        // GET: api/Athletes/{id}/SpeedTest/?startDate=2018-09-24&endDate=2018-09-30
        [HttpGet]
        [Route("{id:int}/SpeedTest/")]
        [ResponseType(typeof(List<speedTest>))]
        public IHttpActionResult GetSpeedTestByAthleteIdByDateRange(int id, DateTime startDate, DateTime endDate)
        {
            List<speedTest> speedTests;
            try
            {
                speedTests = speedTestService.speedTestByAthleteIdByDateRange(id, startDate, endDate);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(speedTests);
        }

        // GET: api/Athletes/{id}/JumpTest/?startDate=2018-09-24&endDate=2018-09-30
        [HttpGet]
        [Route("{id:int}/JumpTest/")]
        [ResponseType(typeof(List<jumpTest>))]
        public IHttpActionResult GetJumpTestByAthleteIdByDateRange(int id, DateTime startDate, DateTime endDate)
        {
            List<jumpTest> jumpTests;
            try
            {
                jumpTests = jumpTestService.jumpTestByAthleteIdByDateRange(id, startDate, endDate);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(jumpTests);
        }

        // GET: api/Athletes/{id}/StrengthTest/?startDate=2018-09-24&endDate=2018-09-30
        [HttpGet]
        [Route("{id:int}/StrengthTest/")]
        [ResponseType(typeof(List<strengthTest>))]
        public IHttpActionResult GetStrengthTestByAthleteIdByDateRange(int id, DateTime startDate, DateTime endDate)
        {
            List<strengthTest> strengthTests;
            try
            {
                strengthTests = strengthTestService.strengthTestByAthleteIdByDateRange(id, startDate, endDate);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(strengthTests);
        }


        // GET: api/Athletes/{id}/ResistanceTest/?startDate=2018-09-24&endDate=2018-09-30
        [HttpGet]
        [Route("{id:int}/ResistanceTest/")]
        [ResponseType(typeof(List<resistanceTest>))]
        public IHttpActionResult GetResistanceTestByAthleteIdByDateRange(int id, DateTime startDate, DateTime endDate)
        {
            List<resistanceTest> resistanceTests;
            try
            {
                resistanceTests = resistanceTestService.resistanceTestByAthleteIdByDateRange(id, startDate, endDate);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(resistanceTests);
        }
    }
}
