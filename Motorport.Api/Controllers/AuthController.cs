using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motorport.Domain.Communication;
using Motorport.Infrastructure.Services;
using Motorport.Infrastructure.Util.Authentication;

namespace Motorport.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var user = await _userService.FindByEmailAndPasswordAsync(request.Email, request.Password);
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                claims.Add(new Claim(ClaimTypes.Role, "Reader"));
                claims.Add(new Claim("id", user.Id.ToString()));
                claims.Add(new Claim("email", user.Email));
                var token = MotorportToken.Instance.GetToken(claims);
                var response = new LoginResponse("Login successfully",token);
                return Ok(response);
            }catch(Exception ex)
            {
                var response = new LoginResponse(false, ex.Message);
                return BadRequest(response);
            }
        }
    }
}