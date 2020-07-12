using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
namespace API.Controllers
{
    [EnableCors("*","*","*")]
    public class CategoryController : ApiController
    {
        // GET: api/Category
        public IHttpActionResult Get()
        {
            try
            {

                return Ok(CategoryBL.GetCategories());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // GET: api/Category/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
