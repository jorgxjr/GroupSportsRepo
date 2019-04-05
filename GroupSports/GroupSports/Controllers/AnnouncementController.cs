using GroupSports.BL.BC;
using GroupSports.DL.DM;
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
    public class AnnouncementController : ApiController
    {
        IAnnouncementService announcementService = new AnnouncementService();

        // GET: api/Announcement
        [ResponseType(typeof(List<announcement>))]
        public IHttpActionResult Get()
        {
            List<announcement> announcements;
            try
            {
                announcements = announcementService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(announcements);
        }

        // GET: api/Announcement/5
        [ResponseType(typeof(announcement))]
        public IHttpActionResult Get(int id)
        {
            announcement announcement;
            try
            {
                announcement = announcementService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }

        // POST: api/Announcement
        public IHttpActionResult Post([FromBody]AnnouncementForAthletesDTO value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = announcementService.setAthletesForAnnouncement(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/Announcement/5
        public IHttpActionResult Put(int id, [FromBody]announcement value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = announcementService.updateAnnouncement(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/Announcement/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = announcementService.deleteAnnouncement(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
