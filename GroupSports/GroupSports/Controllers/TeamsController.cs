using GroupSports.BL.BC;
using GroupSports.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GroupSports.Controllers
{
    [Authorize]
    public class TeamsController : ApiController
    {
        ITeamService userService = new TeamService();

        // GET: api/Teams
        [ResponseType(typeof(List<team>))]
        public IHttpActionResult Get()
        {
            List<team> teams;
            try
            {
                teams = userService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(teams);
        }

        // GET: api/Teams/5
        [ResponseType(typeof(team))]
        public IHttpActionResult Get(int id)
        {
            team teamFound;
            try
            {
                teamFound = userService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
            
            if (teamFound == null)
            {
                return NotFound();
            }

            return Ok(teamFound);
        }

        // POST: api/Teams
        public IHttpActionResult Post([FromBody]team value)
        {
            try
            {
                userService.insertTeam(value);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok();
        }

        // PUT: api/Teams/5
        public IHttpActionResult Put([FromBody]team value)
        {
            try
            {
                userService.updateTeam(value);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
            return Ok();
        }

        // DELETE: api/Teams/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                userService.deleteTeam(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
            return Ok();
        }
    }
}
