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
    public class WeightTestBySessionController : ApiController
    {
        IWeightTestBySessionService weightTestBySessionService = new WeightTestBySessionService();

        // GET: api/WeightTestBySession
        [ResponseType(typeof(List<weightTestBySession>))]
        public IHttpActionResult Get()
        {
            List<weightTestBySession> weightTestBySessions;
            try
            {
                weightTestBySessions = weightTestBySessionService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(weightTestBySessions);
        }

        // GET: api/WeightTestBySession/5
        [ResponseType(typeof(weightTestBySession))]
        public IHttpActionResult Get(int id)
        {
            weightTestBySession weightTestBySession;
            try
            {
                weightTestBySession = weightTestBySessionService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (weightTestBySession == null)
            {
                return NotFound();
            }

            return Ok(weightTestBySession);
        }

        // POST: api/WeightTestBySession
        public IHttpActionResult Post([FromBody]weightTestBySession value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = weightTestBySessionService.insertweightTestBySession(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/WeightTestBySession/5
        public IHttpActionResult Put(int id, [FromBody]weightTestBySession value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = weightTestBySessionService.updateweightTestBySession(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/WeightTestBySession/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = weightTestBySessionService.deleteweightTestBySession(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
