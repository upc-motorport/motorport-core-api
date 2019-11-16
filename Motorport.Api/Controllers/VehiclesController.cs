using System;
using System.Collections.Generic;
using System.Linq;
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
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _service;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of Vehicles
        /// </summary>
        /// <returns>A response with a list of Vehicles</returns>
        /// <response code="201">Returns Vehicles</response>
        /// <response code="400">Returns inner exception</response>
        [HttpGet, Authorize(Roles="Administrator,Owner,Member")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            try
            {
                var vehicles = await _service.ListAsync();
                var resources = _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);
                var response = new ResultResponse(resources);
                return Ok(response);
            }catch(Exception ex)
            {
                 var response = new ResultResponse(ex.InnerException.Message);
                 return BadRequest(response);
            }
        }

        /// <summary>
        /// Get a specific Vehicle by Id
        /// </summary>
        /// <returns>A response with a single Vehicle</returns>
        /// <response code="201">Returns Vehicle by Id</response>
        /// <response code="404">Vehicle Not Found</response>  
        [HttpGet("{id}"), Authorize(Roles = "Administrator,Owner,Member")]
        public async Task<ActionResult<Vehicle>> Find([FromRoute(Name = "id")] int id)
        {
            try
            {
                var vehicle = await _service.FindAsync(id);
                if(vehicle == null)
                {
                    return NotFound(new ResultResponse("Vehicle not found"));
                }
                var resource = _mapper.Map<Vehicle, VehicleResource>(vehicle);
                var response = new ResultResponse(resource);
                return Ok(response);
            }catch (Exception ex)
            {
                var response = new ResultResponse(ex.InnerException.Message);
                return NotFound(response);
            }
        }

        /// <summary>
        /// Creates a Vehicle Item
        /// </summary>
        /// <returns>A response with the newly created Id</returns>
        /// <response code="201">Returns the newly created Id</response>
        /// <response code="400">If throws an Exception or item is null</response>            
        [HttpPost, Authorize(Roles = "Administrator,Owner")]
        public async Task<IActionResult> Post([FromBody] SaveVehicleResource resource)
        {
            try
            {
                var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(resource);
                await _service.AddAsync(vehicle);
                var response = new ResultResponse(vehicle.Id);
                return Accepted(response);
            }
            catch (Exception ex)
            {
                var response = new ResultResponse(ex.InnerException.Message);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Updates a specific Vehicle Item given the Id
        /// </summary>
        /// <returns>No Content</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">If throws an Exception or item is null</response>  
        [HttpPut("{id}"), Authorize(Roles = "Administrator,Owner")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] SaveVehicleResource resource)
        {
            try
            {
                var current = await _service.FindAsync(id);
                if(current == null)
                {
                    return NotFound(new ResultResponse("Vehicle not found"));
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
        /// Deletes a specific Vehicle.
        /// </summary>
        /// <param name="id"></param>        
        [HttpDelete("{id}"), Authorize(Roles = "Administrator,Owner")]
        public async Task<IActionResult> Delete([FromRoute(Name ="id")] int id)
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           