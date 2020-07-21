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
        //get business

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
                return Ok(MakeAppointment.GetOptionalHoursPerDay(int.Parse(serviceId) , int.Parse(day)));
            }
            catch
            {
                return BadRequest();
            }
        }

        public IHttpActionResult BookAppointment(TurnDetailsDTO appointment )
        {//todo:
            try
            {
                MakeAppointment.BookAppointment(appointment);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
