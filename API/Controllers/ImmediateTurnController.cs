using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using DTO;

namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class ImmediateTurnController : ApiController
    {
        //http://localhost:52764/turn/turnByCategory?categoryId=5&latitude=32.109333&longitude=34.855499&isDriving=true
        [Route("immediateTurnByCategory")]

        public IHttpActionResult GetImmediateTurnByCategory(HttpRequestMessage request, string categoryId,string latitude,string longitude,string isDriving)
         {
             try
             {
                String access_token = request.Headers.Authorization.ToString();
                int custId = Token.GetCustIdFromToken(access_token);
                return Ok(FindOptionalTurns.GetPossibleBusinessesWithHour(int.Parse(categoryId), latitude, longitude, bool.Parse(isDriving),custId));
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }
         }

        //GET: http://localhost:52764/turn/turnByBusiness/1?latitude=32.109333&longitude=34.855499&isDriving=true

        [Route("immediateTurnByBusiness/{serviceId}")]
        
        public IHttpActionResult GetTurn(HttpRequestMessage request, int serviceId, string latitude,string longitude,string isDriving)
        {
            try
            {
                string access_token = request.Headers.Authorization.ToString();
                int custId = Token.GetCustIdFromToken(access_token);
                return Ok(FindOptionalTurns.GetPossibleBusinessWithHour(serviceId, latitude, longitude,bool.Parse(isDriving),custId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
