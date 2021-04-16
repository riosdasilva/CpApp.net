using CpApp.Models;
using CpApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ClientsController : ControllerBase
    {
        private readonly IUserService _service;

        public ClientsController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllClient());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.FindById(id));
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] User client)
        {
            if (client == null) return BadRequest();
            return Ok(_service.AddAsync(client));
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User client)
        {
            if (client == null) return BadRequest();
            return Ok(_service.UpdateAsync(client, id));
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _service.Delete(id);
        }
    }
}
