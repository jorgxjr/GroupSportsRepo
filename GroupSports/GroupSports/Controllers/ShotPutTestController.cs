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
    public class ShotPutTestController : ApiController
    {
        IShotPutTestService shotPutTestService = new ShotPutTestService();

        // GET: api/ShotPutTest
        [ResponseType(typeof(List<shotPutTest>))]
        public IHttpActionResult Get()
        {
            List<shotPutTest> shotPutTests;
            try
            {
                shotPutTests = shotPutTestService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(shotPutTests);
        }

        // GET: api/ShotPutTest/5
        [ResponseType(typeof(shotPutTest))]
        public IHttpActionResult Get(int id)
        {
            shotPutTest shotPutTest;
            try
            {
                shotPutTest = shotPutTestService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (shotPutTest == null)
            {
                return NotFound();
            }

            return Ok(shotPutTest);
        }

        // POST: api/ShotPutTest
        public IHttpActionResult Post([FromBody]shotPutTest value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = shotPutTestService.insertshotPutTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/ShotPutTest/5
        public IHttpActionResult Put(int id, [FromBody]shotPutTest value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = shotPutTestService.updateshotPutTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/ShotPutTest/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = shotPutTestService.deleteshotPutTest(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
