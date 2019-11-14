using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motorport.Domain.Models;
using Motorport.Domain.Resources;
using Motorport.Infrastructure.Repositories;

namespace Motorport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _repository;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
        {
            try
            {
                var vehicles = await _repository.List();
                var resources = _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleResource>>(vehicles);
                return Ok(resources);
            }catch(Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> Find([FromRoute(Name ="id")] int id)
        {
            try
            {
                var vehicle = await _repository.Find(id);
                return Ok(vehicle);
            }catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vehicle vehicle)
        {
            try
            {
                await _repository.Add(vehicle);
                return Accepted(vehicle.Id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}