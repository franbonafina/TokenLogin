using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/getAll")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/get")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/post")]
        [HttpGet]
        public void Post([FromBody]string value)
        {
        }

        [Route("api/put")]
        [HttpGet]
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("api/delete")]
        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
