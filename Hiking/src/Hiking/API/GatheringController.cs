using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Hiking.Services;
using Hiking.ViewModels.Gatherings;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Hiking.API
{
    [Route("api/[controller]")]
    public class GatheringController : Controller
    {
        IGatheringService repo;

        public GatheringController(IGatheringService _repo)
        {
            this.repo = _repo;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var list = repo.GetAllGatherings();
            return Ok(list);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var gathering = repo.GetOneGathering(id);

            return Ok(gathering);
        }

        [HttpGet]
        [Route("isUserInGathering")]
        public IActionResult IsUserInGathering(AddUserToGatherViewModel data)
        {
            var gathering = repo.IsUserInGathering(data);
            return Ok(gathering);
        }

        [HttpPost]
        [Route("addToGathering")]
        public IActionResult AddToGathering([FromBody]AddUserToGatherViewModel data)
        {
            repo.AddToGathering(data);
            return Ok();
        }

        [HttpDelete]
        [Route("removeUserFromGathering")]
        public IActionResult RemoveFromGathering(AddUserToGatherViewModel data)
        {
            repo.RemoveFromGathering(data);
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
