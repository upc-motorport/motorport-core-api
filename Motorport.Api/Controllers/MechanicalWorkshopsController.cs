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
    public class MechanicalWorkshopsController : ControllerBase
    {
        private readonly IMechanicalWorkshopService _service;
        private readonly IMapper _mapper;
        public MechanicalWorkshopsController(IMechanicalWorkshopService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a list of MechanicalWorkshops
        /// </summary>
        /// <returns>A response with a list of MechanicalWorkshops</returns>
        /// <response code="201">Returns MechanicalWorkshops</response>
        /// <response code="400">Returns inner exception</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet,Authorize(Roles = "Administrator,Owner,Member")]
        public async Task<ActionResult<IEnumerable<MechanicalWorkshop>>> Get()
        {
            try
            {
                var mechanicalworkshops = await _service.ListAsync();
                var resources = _mapper.Map<IEnumerable<MechanicalWorkshop>, IEnumerable<MechanicalWorkshopResource>>(mechanicalworkshops);
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
        /// Get a specific MechanicalWorkshop by Id
        /// </summary>
        /// <returns>A response with a single MechanicalWorkshop</returns>
        /// <response code="201">Returns MechanicalWorkshop by Id</response>
        /// <response code="404">MechanicalWorkshop Not Found</response>  
        [HttpGet("{id}"),Authorize(Roles = "Administrator,Owner,Member")]
        public async Task<ActionResult<MechanicalWorkshop>> Find([FromRoute(Name = "id")] int id)
        {
            try
            {
                var mechanicalworkshop = await _service.FindAsync(id);
                if (mechanicalworkshop == null)
                {
                    return NotFound(new ResultResponse("MechanicalWorkshop not found"));
                }
                var resource = _mapper.Map<MechanicalWorkshop, MechanicalWorkshopResource>(mechanicalworkshop);
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
        /// Creates a MechanicalWorkshop Item
        /// </summary>
        /// <returns>A response with the newly created Id</returns>
        /// <response code="201">Returns the newly created Id</response>
        /// <response code="400">If throws an Exception or item is null</response>  
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveMechanicalWorkshopResource resource)
        {
            try
            {
                var mechanicalworkshop = _mapper.Map<SaveMechanicalWorkshopResource, MechanicalWorkshop>(resource);
                await _service.AddAsync(mechanicalworkshop);
                var response = new ResultResponse(mechanicalworkshop.Id);
                return Accepted(response);
            }
            catch (Exception ex)
            {
                var response = new ResultResponse(ex.InnerException.Message);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Updates a specific MechanicalWorkshop Item given the Id
        /// </summary>
        /// <returns>No Content</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">If throws an Exception or item is null</response> 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] SaveMechanicalWorkshopResource resource)
        {
            try
            {
                var current = await _service.FindAsync(id);
                if (current == null)
                {
                    return NotFound(new ResultResponse("MechanicalWorkshop not found"));
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
        /// Deletes a specific MechanicalWorkshop.
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
