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
    public class AthleteFodasController : ApiController
    {
        IFodaService fodaService = new FodaService();

        // GET: api/AthleteFodas
        [ResponseType(typeof(List<athleteFoda>))]
        public IHttpActionResult Get()
        {
            List<athleteFoda> athleteFodas;
            try
            {
                athleteFodas = fodaService.findAll();
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            return Ok(athleteFodas);
        }

        // GET: api/AthleteFodas/5
        [ResponseType(typeof(athleteFoda))]
        public IHttpActionResult Get(int id)
        {
            athleteFoda athleteFoda;
            try
            {
                athleteFoda = fodaService.findById(id);
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }

            if (athleteFoda == null)
            {
                return NotFound();
            }

            return Ok(athleteFoda);
        }

        // POST: api/AthleteFodas
        public IHttpActionResult Post([FromBody]athleteFoda value)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = fodaService.insertathleteFoda(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // PUT: api/AthleteFodas/5
        public IHttpActionResult Put(int id, [FromBody]athleteFoda value)
        {
            try
            {
                value.id = id;
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = fodaService.updateathleteFoda(value)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }

        // DELETE: api/AthleteFodas/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return ResponseMessage(Request.CreateResponse(new
                {
                    response = fodaService.deleteathleteFoda(id)
                }));
            }
            catch (Exception e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString()));
            }
        }
    }
}
