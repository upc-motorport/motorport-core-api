using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Motorport.Domain.Communication;
using Motorport.Domain.Models;
using Motorport.Domain.Resources;
using Motorport.Infrastructure.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Motorport.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class DrivingSessionsDetailsController : ControllerBase
    {
        private readonly IDrivingSessionDetailService _service;
        private readonly IMapper _mapper;
        public DrivingSessionsDetailsController(IDrivingSessionDetailService service , IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of DrivingSessionsDetails
        /// </summary>
        /// <returns>A response with a list of DrivingSessionsDetails</returns>
        /// <response code="201">Returns DrivingSessionsDetails</response>
        /// <response code="400">Returns inner exception</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet, Authorize(Roles = "Administrator,Owner,Member")]
        public async Task<ActionResult<IEnumerable<DrivingSessionDetail>>> Get()
        {
            try
            {
                var drivingsessionsdetails = await _service.ListAsync();
                var resources = _mapper.Map<IEnumerable<DrivingSessionDetail>, IEnumerable<DrivingSessionDetailResource>>(drivingsessionsdetails);
                var response = new ResultResponse(resources);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResultResponse(ex.InnerException.Message);
                return NotFound(response);
            }
        }

        /// <summary>
        /// Get a specific Driving Session Detail by Id
        /// </summary>
        /// <returns>A response with a single Driving Session</returns>
        /// <response code="201">Returns DrivingSessionDetails by Id</response>
        /// <response code="404">DrivingSessionDetail Not Found</response>  
        [HttpGet("{id}"), Authorize(Roles = "Administrator,Owner,Member")]
        public async Task<ActionResult<DrivingSessionDetail>> Find([FromRoute(Name = "id")] int id)
        {
            try
            {
                var drivingsessiondetail = await _service.FindAsync(id);
                if (drivingsessiondetail == null)
                {
                    return NotFound(new ResultResponse("DrivingSessionDetail not found"));
                }
                var resource = _mapper.Map<DrivingSessionDetail, DrivingSessionDetailResource>(drivingsessiondetail);
                var response = new ResultResponse(resource);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResultResponse(ex.InnerException.Message);
                return NotFound(response);
            }
        }

        /// <summary>
        /// Creates a DrivingSessionDetail Item
        /// </summary>
        /// <returns>A response with the newly created Id</returns>
        /// <response code="201">Returns the newly created Id</response>
        /// <response code="400">If throws an Exception or item is null</response>  
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveDrivingSessionDetailResource resource)
        {
            try
            {
                var drivingsessiondetail = _mapper.Map<SaveDrivingSessionDetailResource, DrivingSessionDetail>(resource);
                await _service.AddAsync(drivingsessiondetail);
                var response = new ResultResponse(drivingsessiondetail.Id);
                return Accepted(response);
            }
            catch (Exception ex)
            {
                var response = new ResultResponse(ex.InnerException.Message);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Updates a specific Driving Session Detail Item given the Id
        /// </summary>
        /// <returns>No Content</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">If throws an Exception or item is null</response> 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] SaveDrivingSessionDetailResource resource)
        {
            try
            {
                var current = await _service.FindAsync(id);
                if (current == null)
                {
                    return NotFound(new ResultResponse("Driving Session Detail not found"));
                }
                _mapper.Map(resource, current);
                await _service.UpdateAsync(current);
                return NoContent();
            }
            catch (Exception ex)
            {
                var response = new ResultResponse(ex.InnerException.Message);
                return BadRequest(response);
            }
        }
        /// <summary>
        /// Deletes a specific Driving Session Detail.
        /// </summary>
        /// <param name="id"></param>    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                var response = new ResultResponse(ex.InnerException.Message);
                return NotFound(response);
            }
        }








    }
}
