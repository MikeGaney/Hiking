using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Hiking.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Hiking.API
{
    [Route("api/[controller]")]
    public class BackpackController : Controller
    {
        IBackpackService service;

        public BackpackController(IBackpackService _service)
        {
            this.service = _service;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var myTrail = this.service.GetTrail(id);
            return Ok(myTrail);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Ok();
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.RemoveTrail(id);
            return Ok();
        }
    }
}
