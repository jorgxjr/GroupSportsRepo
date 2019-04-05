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
    public class JumpTestTypesController : ApiController
    {
        IJumpTestTypeService jumpTestTypeService = new JumpTestTypeService();

        // GET: api/JumpTestTypes
        [ResponseType(typeof(List<jumpTestType>))]
        public IHttpActionResult Get()
        {
            List<jumpTestType> jumpTestTypes;
            try
            {
                jumpTestTypes = jumpTestTypeService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(jumpTestTypes);
        }

        // GET: api/JumpTestTypes/5
        [ResponseType(typeof(jumpTestType))]
        public IHttpActionResult Get(int id)
        {
            jumpTestType strengthTestType;
            try
            {
                strengthTestType = jumpTestTypeService.findById(id);
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

        // POST: api/JumpTestTypes
        public IHttpActionResult Post([FromBody]jumpTestType value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = jumpTestTypeService.insertjumpTestType(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/JumpTestTypes/5
        public IHttpActionResult Put(int id, [FromBody]jumpTestType value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = jumpTestTypeService.updatejumpTestType(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/JumpTestTypes/5
        public void Delete(int id)
        {
            //try
            //{
            //    return ResponseMessage(Request.CreateResponse(new
            //    {
            //        response = jumpTestTypeService.deletejumpTestType(id)
            //    }));
            //}
            //catch (Exception e)
            //{
            //    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            //}
        }
    }
}
