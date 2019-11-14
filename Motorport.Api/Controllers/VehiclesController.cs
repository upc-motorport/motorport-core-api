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
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _service;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            try
            {
                var vehicles = await _service.ListAsync();
                var resources = _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);
                var response = new ResultResponse(resources);
                return Ok(resources);
            }catch(Exception ex)
            {
                var response = new ResultResponse(ex.Message);
                return NotFound(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> Find([FromRoute(Name = "id")] int id)
        {
            try
            {
                var vehicle = await _service.FindAsync(id);
                var resource = _mapper.Map<Vehicle, VehicleResource>(vehicle);
                var response = new ResultResponse(resource);
                return Ok(resource);
            }catch (Exception ex)
            {
                var response = new ResultResponse(ex.Message);
                return NotFound(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vehicle vehicle)
        {
            try
            {
                await _service.AddAsync(vehicle);
                return Accepted(vehicle.Id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           