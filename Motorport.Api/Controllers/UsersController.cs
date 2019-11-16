using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motorport.Domain.Communication;
using Motorport.Domain.Models;
using Motorport.Domain.Resources;
using Motorport.Infrastructure.Services;

namespace Motorport.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// Get user given a valid token
        /// </summary>
        /// <returns>A result response with user data</returns>
        /// <response code="200">Returns User Data</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>     
        [HttpGet("self"), Authorize]
        public async Task<ActionResult> Self()
        {
            try
            {
                var idClaim = GetClaim("id");
                var id = Convert.ToInt32(idClaim.Value);
                var user = await _userService.FindAsync(id);
                var resource = _mapper.Map<User, UserResource>(user);
                var response = new ResultResponse(resource);
                return Ok(response);
            }
            catch(Exception ex)
            {
                string message;
                if(ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                else
                {
                    message = ex.Message;
                }
                var response = new ResultResponse(message);
                return NotFound(response);
            }
        }

        private Claim GetClaim(string name)
        {
            return User.Claims.FirstOrDefault(x => x.Type.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}