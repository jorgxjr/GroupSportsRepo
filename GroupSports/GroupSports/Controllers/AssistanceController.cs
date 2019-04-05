using GroupSports.BL.BC;
using GroupSports.DL.DM.DTO;
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
    public class AssistanceController : ApiController
    {
        IAssistanceService assistanceService = new AssistanceService();

        // GET: api/Assistance
        [ResponseType(typeof(List<AssistanceDTO>))]
        public IHttpActionResult Get()
        {
            List<AssistanceDTO> assistanceDTOs;
            try
            {
                assistanceDTOs = assistanceService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(assistanceDTOs);
        }

        // GET: api/Assistance/5
        [ResponseType(typeof(AssistanceDTO))]
        public IHttpActionResult Get(int id)
        {
            AssistanceDTO assistanceDTO;
            try
            {
                assistanceDTO = assistanceService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (assistanceDTO == null)
            {
                return NotFound();
            }

            return Ok(assistanceDTO);
        }

        // POST: api/Assistance
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Assistance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Assistance/5
        public void Delete(int id)
        {
        }
    }
}
