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
    public class JumpTestController : ApiController
    {
        IJumpTestService jumpTestService = new JumpTestService();

        // GET: api/JumpTest
        [ResponseType(typeof(List<jumpTest>))]
        public IHttpActionResult Get()
        {
            List<jumpTest> jumpTests;
            try
            {
                jumpTests = jumpTestService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(jumpTests);
        }

        // GET: api/JumpTest/5
        [ResponseType(typeof(jumpTest))]
        public IHttpActionResult Get(int id)
        {
            jumpTest jumpTest;
            try
            {
                jumpTest = jumpTestService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (jumpTest == null)
            {
                return NotFound();
            }

            return Ok(jumpTest);
        }

        // POST: api/JumpTest
        public IHttpActionResult Post([FromBody]jumpTest value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = jumpTestService.insertjumpTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/JumpTest/5
        public IHttpActionResult Put(int id, [FromBody]jumpTest value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = jumpTestService.updatejumpTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/JumpTest/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = jumpTestService.deletejumpTest(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
