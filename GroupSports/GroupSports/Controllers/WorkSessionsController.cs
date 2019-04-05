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
    [RoutePrefix("api/WorkSessions")]
    public class WorkSessionsController : ApiController
    {
        ISessionService sessionService = new SessionService();
        IBinnacleDetailService binnacleDetailService = new BinnacleDetailService();
        IWeightTestBySessionService weightTestBySessionService = new WeightTestBySessionService();

        // GET: api/WorkSessions
        [ResponseType(typeof(List<session>))]
        public IHttpActionResult Get()
        {
            List<session> sessions;
            try
            {
                sessions = sessionService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(sessions);
        }

        // GET: api/WorkSessions/5
        [ResponseType(typeof(session))]
        public IHttpActionResult Get(int id)
        {
            session sessionFound;
            try
            {
                sessionFound = sessionService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (sessionFound == null)
            {
                return NotFound();
            }

            return Ok(sessionFound);
        }

        // POST: api/WorkSessions
        public IHttpActionResult Post([FromBody]session value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = sessionService.insertSession(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/WorkSessions/5
        public IHttpActionResult Put(int id, [FromBody]session value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = sessionService.updateSession(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/WorkSessions/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = sessionService.deleteSession(id)
            }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // GET: api/WorkSessions/{id}/BinnacleDetails
        [HttpGet]
        [Route("{id:int}/BinnacleDetails")]
        [ResponseType(typeof(List<binnacleDetail>))]
        public IHttpActionResult GetBinnacleDetailsBySession(int id)
        {
            List<binnacleDetail> binnacleDetails;
            try
            {
                binnacleDetails = binnacleDetailService.binnacleBySessionId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(binnacleDetails);
        }

        // GET: api/WorkSessions/{id}/WeightTestBySession
        [HttpGet]
        [Route("{id:int}/WeightTestBySession")]
        [ResponseType(typeof(List<weightTestBySession>))]
        public IHttpActionResult GetWeightTestBySessionBySession(int id)
        {
            List<weightTestBySession> weightTestBySessions;
            try
            {
                weightTestBySessions = weightTestBySessionService.findBySessionId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(weightTestBySessions);
        }
    }
}
