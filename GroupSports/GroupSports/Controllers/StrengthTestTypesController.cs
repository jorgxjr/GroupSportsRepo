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
    public class StrengthTestTypesController : ApiController
    {
        IStrengthTestTypeService strengthTestTypeService = new StrengthTestTypeService();

        // GET: api/StrengthTestTypes
        [ResponseType(typeof(List<strengthTestType>))]
        public IHttpActionResult Get()
        {
            List<strengthTestType> strengthTestTypes;
            try
            {
                strengthTestTypes = strengthTestTypeService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(strengthTestTypes);
        }

        // GET: api/StrengthTestTypes/5
        [ResponseType(typeof(strengthTestType))]
        public IHttpActionResult Get(int id)
        {
            strengthTestType strengthTestType;
            try
            {
                strengthTestType = strengthTestTypeService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (strengthTestType == null)
            {
                return NotFound();
            }

            return Ok(strengthTestType);
        }

        // POST: api/StrengthTestTypes
        public IHttpActionResult Post([FromBody]strengthTestType value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = strengthTestTypeService.insertstrengthTestType(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/StrengthTestTypes/5
        public IHttpActionResult Put(int id, [FromBody]strengthTestType value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = strengthTestTypeService.updatestrengthTestType(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/StrengthTestTypes/5
        public void Delete(int id)
        {
            //try
            //{
            //    return ResponseMessage(Request.CreateResponse(new
            //    {
            //        response = strengthTestTypeService.deletestrengthTestType(id)
            //    }));
            //}
            //catch (Exception e)
            //{
            //    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            //}
        }
    }
}
