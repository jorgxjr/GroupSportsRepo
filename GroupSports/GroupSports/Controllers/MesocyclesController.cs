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
    [RoutePrefix("api/mesocycles")]
    public class MesocyclesController : ApiController
    {
        IMesocycleService mesocycleService = new MesocycleService();
        IWeekService weekService = new WeekService();

        // GET: api/Mesocycles
        [ResponseType(typeof(List<mesocycle>))]
        public IHttpActionResult Get()
        {
            List<mesocycle> mesocycles;
            try
            {
                mesocycles = mesocycleService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(mesocycles);
        }

        // GET: api/Mesocycles/5
        [ResponseType(typeof(mesocycle))]
        public IHttpActionResult Get(int id)
        {
            mesocycle mesocycleFound;
            try
            {
                mesocycleFound = mesocycleService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (mesocycleFound == null)
            {
                return NotFound();
            }

            return Ok(mesocycleFound);
        }

        // POST: api/Mesocycles
        public IHttpActionResult Post([FromBody]mesocycle value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = mesocycleService.insertMesocycle(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/Mesocycles/5
        public IHttpActionResult Put(int id, [FromBody]mesocycle value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = mesocycleService.updateMesocycle(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/Mesocycles/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = mesocycleService.deleteMesocycle(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // GET: api/Mesocycles/{id}/Weeks
        [HttpGet]
        [Route("{id:int}/weeks")]
        [ResponseType(typeof(List<week>))]
        public IHttpActionResult GetWeeksByMesocycles(int id)
        {
            List<week> weekssFinded;
            try
            {
                weekssFinded = weekService.weeksByMesocycleId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(weekssFinded);
        }
    }
}
