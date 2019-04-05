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
    public class StrengthTestController : ApiController
    {
        IStrengthTestService strengthTestService = new StrengthTestService();

        // GET: api/StrengthTest
        [ResponseType(typeof(List<strengthTest>))]
        public IHttpActionResult Get()
        {
            List<strengthTest> strengthTests;
            try
            {
                strengthTests = strengthTestService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(strengthTests);
        }

        // GET: api/StrengthTest/5
        [ResponseType(typeof(strengthTest))]
        public IHttpActionResult Get(int id)
        {
            strengthTest strengthTest;
            try
            {
                strengthTest = strengthTestService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (strengthTest == null)
            {
                return NotFound();
            }

            return Ok(strengthTest);
        }

        // POST: api/StrengthTest
        public IHttpActionResult Post([FromBody]strengthTest value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = strengthTestService.insertstrengthTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/StrengthTest/5
        public IHttpActionResult Put(int id, [FromBody]strengthTest value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = strengthTestService.updatestrengthTest(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/StrengthTest/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = strengthTestService.deletestrengthTest(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
