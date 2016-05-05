using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Hiking.Services;
using System.Security.Claims;
using Hiking.Models;
using Hiking.ViewModels.Profile;

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
        
        // GET: api/values
        [HttpGet]
        [Route("bkpkpage")]
        public IEnumerable<Trail> GetBkPkList(int num)
        {
            var userId = User.GetUserId();
            var trails = service.BkPkPagination(num, userId);
            return trails;
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
            service.AddToBackpack(data);
            return Ok();
        }

        // POST api/values
        [HttpPost]
        [Route ("saveCompletedTrail")]
        public IActionResult SaveCompletedTrail([FromBody]UserTrail id)
        {
            service.SaveCompletedTrail(id);
            return Ok();
        }

        [HttpPost]
        [Route("rateTrails")]
        public IActionResult RateTrails([FromBody] TrailRateViewModel data)
        {
            var userId = User.GetUserId();
            service.RateTrails(data, userId);
            return Ok();
        }

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
