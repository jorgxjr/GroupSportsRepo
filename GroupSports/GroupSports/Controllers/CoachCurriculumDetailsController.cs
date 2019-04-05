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
    public class CoachCurriculumDetailsController : ApiController
    {
        ICoachCurriculumDetailService coachCurriculumDetailService = new CoachCurriculumDetailService();

        // GET: api/CoachCurriculumDetails
        [ResponseType(typeof(List<coachCurriculumDetail>))]
        public IHttpActionResult Get()
        {
            List<coachCurriculumDetail> coachCurriculumDetails;
            try
            {
                coachCurriculumDetails = coachCurriculumDetailService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(coachCurriculumDetails);
        }

        // GET: api/CoachCurriculumDetails/5
        [ResponseType(typeof(coachCurriculumDetail))]
        public IHttpActionResult Get(int id)
        {
            coachCurriculumDetail coachCurriculumDetail;
            try
            {
                coachCurriculumDetail = coachCurriculumDetailService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (coachCurriculumDetail == null)
            {
                return NotFound();
            }

            return Ok(coachCurriculumDetail);
        }

        // POST: api/CoachCurriculumDetails
        public IHttpActionResult Post([FromBody]coachCurriculumDetail value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = coachCurriculumDetailService.insertcoachCurriculumDetail(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/CoachCurriculumDetails/5
        public IHttpActionResult Put(int id, [FromBody]coachCurriculumDetail value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = coachCurriculumDetailService.updatecoachCurriculumDetail(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/CoachCurriculumDetails/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = coachCurriculumDetailService.deletecoachCurriculumDetail(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
