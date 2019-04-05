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
    [RoutePrefix("api/weeks")]
    public class WeeksController : ApiController
    {
        IWeekService weekService = new WeekService();
        ISessionService sessionService = new SessionService();

        // GET: api/Weeks
        [ResponseType(typeof(List<week>))]
        public IHttpActionResult Get()
        {
            List<week> weeks;
            try
            {
                weeks = weekService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(weeks);
        }

        // GET: api/Weeks/5
        [ResponseType(typeof(week))]
        public IHttpActionResult Get(int id)
        {
            week weekFound;
            try
            {
                weekFound = weekService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (weekFound == null)
            {
                return NotFound();
            }

            return Ok(weekFound);
        }

        // POST: api/Weeks
        public IHttpActionResult Post([FromBody]week value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = weekService.insertWeek(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/Weeks/5
        public IHttpActionResult Put(int id, [FromBody]week value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = weekService.updateWeek(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/Weeks/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = weekService.deleteWeek(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // GET: api/Weeks/{id}/workSessions
        [HttpGet]
        [Route("{id:int}/workSessions")]
        [ResponseType(typeof(List<SessionDTO>))]
        public IHttpActionResult GetSessionsByWeeks(int id)
        {
            List<SessionDTO> sessionsFinded;
            try
            {
                sessionsFinded = sessionService.sessionsByWeek(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(sessionsFinded);
        }
    }
}
