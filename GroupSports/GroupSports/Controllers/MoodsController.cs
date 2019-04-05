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
    public class MoodsController : ApiController
    {
        IMoodService moodService = new MoodService();
        // GET: api/Moods
        [ResponseType(typeof(List<mood>))]
        public IHttpActionResult Get()
        {
            List<mood> moods;
            try
            {
                moods = moodService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(moods);
        }

        // GET: api/Moods/5
        [ResponseType(typeof(mood))]
        public IHttpActionResult Get(int id)
        {
            mood moodFound;
            try
            {
                moodFound = moodService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (moodFound == null)
            {
                return NotFound();
            }

            return Ok(moodFound);
        }

        // POST: api/Moods
        public IHttpActionResult Post([FromBody]mood value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = moodService.insertMood(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/Moods/5
        public IHttpActionResult Put(int id, [FromBody]mood value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = moodService.updateMoodResponse(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/Moods/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = moodService.deleteMood(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
