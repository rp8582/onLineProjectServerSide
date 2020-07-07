using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CustInTurnController : ApiController
    {
        public IHttpActionResult GetTurnsToCustomer()
        {
            //todo: לחלץ token
            int custId = 2;
            try
            {
                return Ok(BL.CustInLineBL.getTurnsToCustomer(custId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
