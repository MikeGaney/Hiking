﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Hiking.Models;
using Hiking.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Hiking.API
{
    [Route("api/[controller]")]
    public class AddEditDeleteTrailController : Controller
    {
        ISATrailsService _service;
        public AddEditDeleteTrailController (ISATrailsService service)
        {
            this._service = service;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetTrailsList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Trail Get(int id)
        {
            var OneTrail = _service.GetOneTrail(id);
            return OneTrail;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Trail value)
        {
            if (value.Id == 0)
            {
            _service.AddTrail(value);

            }
            else
            {
                _service.EditTrail(value);
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
        public void Delete(int id)
        {
        }
    }
}
