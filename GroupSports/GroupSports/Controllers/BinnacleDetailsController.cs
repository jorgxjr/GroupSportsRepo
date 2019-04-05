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
    public class BinnacleDetailsController : ApiController
    {
        IBinnacleDetailService binnacleDetailService = new BinnacleDetailService();

        // GET: api/BinnacleDetails
        [ResponseType(typeof(List<binnacleDetail>))]
        public IHttpActionResult Get()
        {
            List<binnacleDetail> binnacleDetails;
            try
            {
                binnacleDetails = binnacleDetailService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(binnacleDetails);
        }

        // GET: api/BinnacleDetails/5
        [ResponseType(typeof(binnacleDetail))]
        public IHttpActionResult Get(int id)
        {
            binnacleDetail binnacleDetail;
            try
            {
                binnacleDetail = binnacleDetailService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (binnacleDetail == null)
            {
                return NotFound();
            }

            return Ok(binnacleDetail);
        }

        // POST: api/BinnacleDetails
        public IHttpActionResult Post([FromBody]binnacleDetail value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = binnacleDetailService.insertBinnacleDetail(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/BinnacleDetails/5
        public IHttpActionResult Put(int id, [FromBody]binnacleDetail value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = binnacleDetailService.updateBinnacleDetail(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/BinnacleDetails/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = binnacleDetailService.deleteBinnacleDetail(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
