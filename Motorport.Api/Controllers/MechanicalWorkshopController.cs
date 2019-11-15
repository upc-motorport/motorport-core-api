using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motorport.Domain.Communication;
using Motorport.Domain.Models;
using Motorport.Domain.Resources;
using Motorport.Infrastructure.Services;



namespace Motorport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicalWorkshopController : ControllerBase
    {
        private readonly IMechanicalWorkshopService _service;
        private readonly IMapper _mapper;
        public MechanicalWorkshopController(IMechanicalWorkshopService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<MechanicalWorkshop>> Find([FromRoute(Name = "id")] int id)
        {
            try
            {
                var mechanicalworkshop = await _service.FindAsync(id);
                if (mechanicalworkshop == null)
                {
                    return NotFound(new ResultResponse("Vehicle not found"));
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
