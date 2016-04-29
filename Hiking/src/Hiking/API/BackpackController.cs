using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Hiking.Services;
using System.Security.Claims;
using Hiking.Models;

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
            var userId = User.GetUserId();
            var data = service.GetTrailList(userId);

            return Ok(data);
        }

        [HttpGet]
        [Route("completedTrail")]
        public IActionResult GetCompletedTrails()
        {
            var userId = User.GetUserId();
            var completedTrails = service.GetCompletedTrails(userId);
            return Ok(completedTrails);
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
        public IActionResult Post([FromBody]UserTrail data)
        {
            //var userId = User.GetUserId();
            //var userTrail = new UserTrail
            //{
            //    ApplicationUserId = userId,
            //    TrailId = id
            //};
            service.AddToBackpack(data);

            return Ok();
        }
        // POST api/values
        [HttpPost]
        [Route ("saveCompletedTrail")]
        public IActionResult SaveCompletedTrail([FromBody]UserTrail id)
        {
            //var userTrail = new UserTrail
            //{
            //    ApplicationUserId = User.GetUserId(),
            //    TrailId = id.TrailId
            //};
            service.SaveCompletedTrail(id);

            return Ok();
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete]
        [Route("removeMyTrail")]
        public IActionResult Delete(UserTrail data)
        {
            service.RemoveTrail(data);
            return Ok();
        }
    }
}
