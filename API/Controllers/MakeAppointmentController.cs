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
    [RoutePrefix("appointment")]

    public class MakeAppointmentController : ApiController
    {

        [Route("optionalDays")]
        public IHttpActionResult GetDaysToService(string serviceId)
        {
            try
            {
                return Ok(MakeAppointment.GetOptionalDaysPerService(int.Parse(serviceId)));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("optionalHours")]
        public IHttpActionResult GetOptionalHoursPerDay(string serviceId , string day)
        {
            try
            {
              
                return Ok(MakeAppointment.GetOptionalHoursPerDay(int.Parse(serviceId) ,(int) (DateTime.Parse(day).DayOfWeek)+1));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("ConfirmTurn")]
        public IHttpActionResult BookAppointment(HttpRequestMessage request,[FromBody]TurnDetailsDTO appointment)
        {
            String access_token = request.Headers.Authorization.ToString();
            int custId = Token.GetCustIdFromToken(access_token);
            appointment.CustId = custId;
            try
            {
               
                return Ok(MakeAppointment.BookAppointment(appointment));
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
