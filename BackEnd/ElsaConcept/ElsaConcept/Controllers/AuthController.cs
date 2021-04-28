using ElsaConcept.Data.DTO;
using ElsaConcept.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaConcept.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserDTO user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var token = _loginService.ValidateCredentials(user);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Signin([FromBody] TokenDTO tokenDTO)
        {
            if (tokenDTO == null) return BadRequest("Invalid client request");
            var token = _loginService.ValidateCredentials(tokenDTO);
            if (token == null)
            {
                return BadRequest("Invalid client request");
            }
            return Ok(token);
        }
    }
}
