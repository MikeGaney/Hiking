using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Hiking.Models;
using Hiking.Repositories;
using Microsoft.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Hiking.API
{
    [Route("api/[controller]")]
    public class TrailsController : Controller
    {
        private ApplicationDbContext _db;

        public TrailsController(ApplicationDbContext db)
        {
            this._db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Trail> Get()
        {
            var trails = _db.Trails.ToList();
            return trails;
        }

        // GET: api/values
        [HttpGet]
        [Route("browse")]
        public IEnumerable<Trail> getpage(int num)
        {
            var trails = _db.Trails.Skip(10 * (num - 1)).Take(10).ToList();
            return trails;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var trail = _db.Trails.Where(t => t.Id == id).FirstOrDefault();
            if(trail == null)
            {
                return HttpNotFound();
            }
            return Ok(trail);
        }

        [HttpGet]
        [Route("search")]
        public IActionResult GetSearchList(SearchViewModel data)
        {
            List<Trail> searchList = _db.Trails.ToList();
            if (data.Name != null) searchList = _db.Trails.Where(t => t.Name.Contains(data.Name)).ToList();

            if (data.Location != null) searchList = searchList.Where(t => t.Location.Contains(data.Location)).ToList();

            if (data.Rating != 0) searchList = searchList.Where(t => t.Rating >= data.Rating).ToList();

            if (data.DifficultyLevel != 0) searchList = searchList.Where(t => t.DifficultyLevel<= data.DifficultyLevel).ToList();

            if (data.Camping) searchList = searchList.Where(t => t.Camping == data.Camping).ToList();

            if (data.Fishing) searchList = searchList.Where(t => t.Fishing == data.Fishing).ToList();

            if (data.Biking) searchList = searchList.Where(t => t.Biking == data.Biking).ToList();

            if (data.Horses) searchList = searchList.Where(t => t.Horses == data.Horses).ToList();

            if (data.Lakes) searchList = searchList.Where(t => t.Lakes == data.Lakes).ToList();

            if (data.Rivers) searchList = searchList.Where(t => t.Rivers == data.Rivers).ToList();

            if (data.Waterfalls) searchList = searchList.Where(t => t.Waterfalls == data.Waterfalls).ToList();

            if (data.Lookouts) searchList = searchList.Where(t => t.Lookouts == data.Lookouts).ToList();

            return Ok(searchList);


            //return Ok(list);

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
