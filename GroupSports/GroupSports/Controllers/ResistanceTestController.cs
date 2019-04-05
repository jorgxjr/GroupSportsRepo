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
    public class ResistanceTestController : ApiController
    {
        IResistanceTestService resistanceTestService = new ResistanceTestService();

        // GET: api/ResistanceTest
        [ResponseType(typeof(List<resistanceTest>))]
        public IHttpActionResult Get()
        {
            List<resistanceTest> resistanceTests;
            try
            {
                resistanceTests = resistanceTestService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(resistanceTests);
        }

        // GET: api/ResistanceTest/5
        [ResponseType(typeof(resistanceTest))]
        public IHttpActionResult Get(int id)
        {
            resistanceTest resistanceTest;
            try
            {
                resistanceTest = resistanceTestService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (resistanceTest == null)
            {
                return NotFound();
            }

            return Ok(resistanceTest);
        }

        // POST: api/ResistanceTest
        public IHttpActionResult Post([FromBody]resistanceTest value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = resistanceTestService.insertresistanceTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/ResistanceTest/5
        public IHttpActionResult Put(int id, [FromBody]resistanceTest value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = resistanceTestService.updateresistanceTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/ResistanceTest/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = resistanceTestService.deleteresistanceTest(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
