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
    public class SpeedTestController : ApiController
    {
        ISpeedTestService speedTestService = new SpeedTestService();
        // GET: api/SpeedTest
        [ResponseType(typeof(List<speedTest>))]
        public IHttpActionResult Get()
        {
            List<speedTest> speedTests;
            try
            {
                speedTests = speedTestService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(speedTests);
        }

        // GET: api/SpeedTest/5
        [ResponseType(typeof(speedTest))]
        public IHttpActionResult Get(int id)
        {
            speedTest speedTestFound;
            try
            {
                speedTestFound = speedTestService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (speedTestFound == null)
            {
                return NotFound();
            }

            return Ok(speedTestFound);
        }

        // POST: api/SpeedTest
        public IHttpActionResult Post([FromBody]speedTest value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = speedTestService.insertSpeedTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/SpeedTest/5
        public IHttpActionResult Put(int id, [FromBody]speedTest value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = speedTestService.updateSpeedTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/SpeedTest/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = speedTestService.deleteSpeedTest(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
