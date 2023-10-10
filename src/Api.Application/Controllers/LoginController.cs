using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<Object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (loginDto == null)
                return BadRequest();

            try
            {
                var result = await service.FindByLogin(loginDto);
                if (result != null)
                    return result;
                else
                    return NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
