using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using DTO;

namespace API.Controllers
{
    [RoutePrefix("immediateTurn")]
    public class ImmediateTurnController : ApiController
    {
        //http://localhost:52764/turn/turnByCategory?categoryId=5&latitude=32.109333&longitude=34.855499&isDriving=true
        [Route("immediateTurnByCategory")]

        public IHttpActionResult GetBusinessesWithEstimatedHour(string categoryId,string latitude,string longitude,string isDriving)
         {
             try
             {

                 return Ok(FindOptionalTurns.GetPossibleBusinessesWithHour(int.Parse(categoryId), latitude, longitude, bool.Parse(isDriving)));
             }
             catch (Exception)
             {

                 return BadRequest();
             }
         }

        //GET: http://localhost:52764/turn/turnByBusiness/1?latitude=32.109333&longitude=34.855499&isDriving=true

        [Route("immediateTurnByBusiness/{serviceId}")]
        
        public IHttpActionResult GetTurn(int serviceId, string latitude,string longitude,string isDriving)
        {
            try
            {
                return Ok(FindOptionalTurns.GetPossibleBusinessWithHour(serviceId, latitude, longitude,bool.Parse(isDriving)));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("ConfirmimmediateTurn")]
        public IHttpActionResult ConfirmTurn([FromBody]TurnDetailsDTO turn)
        {
            try
            {
                return Ok(ImmediateTurn.ConfirmImmediateTurn(turn));
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }



    }

}
