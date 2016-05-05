using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Hiking.Services;
using Hiking.ViewModels.Gatherings;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;

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

        [HttpGet]
        [Route("search")]
        public IActionResult GetSearchList(GatheringSearchViewModel data)
        {
            var searchList = repo.SearchGatherings(data);


            return Ok(searchList);

        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]AddGatheringViewModel value)
        {
            value.OwnerId = this.User.GetUserId();
            if (value.Id == 0)
            {
                repo.AddGathering(value);
            } else
            {
                repo.UpdateGathering(value);
            }
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repo.DeleteGathering(id);
            return Ok();
        }
    }
}
