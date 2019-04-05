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
    public class AthleteDetailsController : ApiController
    {
        IAthleteDetailsService athleteDetailsService = new AthleteDetailsService();

        // GET: api/AthleteDetails
        [ResponseType(typeof(List<athleteDetails>))]
        public IHttpActionResult Get()
        {
            List<athleteDetails> athleteDetails;
            try
            {
                athleteDetails = athleteDetailsService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteDetails);
        }

        // GET: api/AthleteDetails/5
        [ResponseType(typeof(athleteDetails))]
        public IHttpActionResult Get(int id)
        {
            athleteDetails athleteDetails;
            try
            {
                athleteDetails = athleteDetailsService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (athleteDetails == null)
            {
                return NotFound();
            }

            return Ok(athleteDetails);
        }

        // POST: api/AthleteDetails
        public IHttpActionResult Post([FromBody]athleteDetails value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = athleteDetailsService.insertathleteDetails(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/AthleteDetails/5
        public IHttpActionResult Put(int id, [FromBody]athleteDetails value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = athleteDetailsService.updateathleteDetails(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/AthleteDetails/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = athleteDetailsService.deleteathleteDetails(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
