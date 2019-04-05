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
    public class AthleteAchievementsController : ApiController
    {
        IAthleteAchievementService athleteAchievementService = new AthleteAchievementService();

        // GET: api/AthleteAchievements
        [ResponseType(typeof(List<athleteAchievement>))]
        public IHttpActionResult Get()
        {
            List<athleteAchievement> athleteAchievements;
            try
            {
                athleteAchievements = athleteAchievementService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteAchievements);
        }

        // GET: api/AthleteAchievements/5
        [ResponseType(typeof(athleteAchievement))]
        public IHttpActionResult Get(int id)
        {
            athleteAchievement athleteAchievement;
            try
            {
                athleteAchievement = athleteAchievementService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (athleteAchievement == null)
            {
                return NotFound();
            }

            return Ok(athleteAchievement);
        }

        // POST: api/AthleteAchievements
        public IHttpActionResult Post([FromBody]athleteAchievement value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = athleteAchievementService.insertathleteAchievement(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/AthleteAchievements/5
        public IHttpActionResult Put(int id, [FromBody]athleteAchievement value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = athleteAchievementService.updateathleteAchievement(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/AthleteAchievements/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = athleteAchievementService.deleteathleteAchievement(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
