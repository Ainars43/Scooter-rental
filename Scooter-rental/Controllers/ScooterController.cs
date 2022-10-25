using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scooter_rental.Controllers
{
    [Route("scooter-api")]
    [ApiController, Authorize, EnableCors]
    public class ScooterController : ControllerBase
    {
        // GET: api/<ScooterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ScooterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ScooterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ScooterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ScooterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
