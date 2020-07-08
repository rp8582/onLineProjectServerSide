using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class BusinessController : ApiController
    {
        public IHttpActionResult GetBusinesses()
        {
            try
            {
                return Ok(BusinessBL.GetBusinesses());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
