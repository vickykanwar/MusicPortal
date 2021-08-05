using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicValuesController : ControllerBase
    {
        // GET: api/<MusicValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MusicValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MusicValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MusicValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MusicValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)

        {


        }
    }
}
