using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RegisterController : ApiController
    {
        public IHttpActionResult GetToken(string name, string phone)
        {
            try
            {
                return Ok( BL.Token.GetToken(name, phone));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
