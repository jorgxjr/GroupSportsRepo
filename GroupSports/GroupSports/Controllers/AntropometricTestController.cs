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
    public class AntropometricTestController : ApiController
    {
        IAntropometricTestService antropometricTestService = new AntropometricTestService();

        // GET: api/AntropometricTest
        [ResponseType(typeof(List<anthropometricTest>))]
        public IHttpActionResult Get()
        {
            List<anthropometricTest> anthropometricTests;
            try
            {
                anthropometricTests = antropometricTestService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(anthropometricTests);
        }

        // GET: api/AntropometricTest/5
        [ResponseType(typeof(anthropometricTest))]
        public IHttpActionResult Get(int id)
        {
            anthropometricTest anthropometricTest;
            try
            {
                anthropometricTest = antropometricTestService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (anthropometricTest == null)
            {
                return NotFound();
            }

            return Ok(anthropometricTest);
        }

        // POST: api/AntropometricTest
        public IHttpActionResult Post([FromBody]anthropometricTest value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = antropometricTestService.insertanthropometricTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/AntropometricTest/5
        public IHttpActionResult Put(int id, [FromBody]anthropometricTest value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = antropometricTestService.updateanthropometricTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/AntropometricTest/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = antropometricTestService.deleteanthropometricTest(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
