using ElsaConcept.Models;
using ElsaConcept.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _service;
        
        public StocksController(IStockService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllStocks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.FindById(id));
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Stock Stock)
        {
            if (Stock == null) return BadRequest();
            return Ok(_service.AddAsync(Stock));
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Stock Stock)
        {
            if (Stock == null) return BadRequest();
            return Ok(_service.UpdateAsync(Stock, id));
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           _service.Delete(id);
        }
    }
}
