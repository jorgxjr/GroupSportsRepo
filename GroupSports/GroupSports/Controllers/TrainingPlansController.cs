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
    [RoutePrefix("api/trainingPlans")]
    public class TrainingPlansController : ApiController
    {
        ITrainingPlanService userService = new TrainingPlanService();
        IMesocycleService mesocycleService = new MesocycleService();

        // GET: api/TrainingPlans
        [ResponseType(typeof(List<trainingPlan>))]
        public IHttpActionResult Get()
        {
            List<trainingPlan> trainingPlans;
            try
            {
                trainingPlans = userService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(trainingPlans);
        }

        // GET: api/TrainingPlans/5
        [ResponseType(typeof(trainingPlan))]
        public IHttpActionResult Get(int id)
        {
            trainingPlan trainingPlanFound;
            try
            {
                trainingPlanFound = userService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (trainingPlanFound == null)
            {
                return NotFound();
            }

            return Ok(trainingPlanFound);
        }

        // POST: api/TrainingPlans
        public IHttpActionResult Post([FromBody]trainingPlan value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = userService.insertTrainingPlan(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/TrainingPlans/5
        public IHttpActionResult Put(int id, [FromBody]trainingPlan value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = userService.updateTrainingPlan(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/TrainingPlans/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = userService.deleteTrainingPlan(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // GET: api/TrainingPlans/{id}/mesocycles
        [HttpGet]
        [Route("{id:int}/mesocycles")]
        [ResponseType(typeof(List<mesocycle>))]
        public IHttpActionResult GetMesocyclesByTrainingPlan(int id)
        {
            List<mesocycle> mesocyclesFinded;
            try
            {
                mesocyclesFinded = mesocycleService.mesocyclesByTrainingPlanId(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(mesocyclesFinded);
        }
    }
}
