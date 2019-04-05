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
    [RoutePrefix("api/mesocycleType")]
    public class MesocycleTypeController : ApiController
    {
        IMesocycleTypeService mesocycleTypeService = new MesocycleTypeService();

        // GET: api/MesocycleType
        [ResponseType(typeof(List<mesocycleType>))]
        public IHttpActionResult Get()
        {
            List<mesocycleType> mesocycleTypes;
            try
            {
                mesocycleTypes = mesocycleTypeService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(mesocycleTypes);
        }

        // GET: api/MesocycleType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MesocycleType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MesocycleType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MesocycleType/5
        public void Delete(int id)
        {
        }
    }
}
