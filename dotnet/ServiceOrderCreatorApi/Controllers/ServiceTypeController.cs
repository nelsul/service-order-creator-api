using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceOrderCreatorApi.DTOs.ServiceType;
using ServiceOrderCreatorApi.Interfaces.Services;

namespace ServiceOrderCreatorApi.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/service-type")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var serviceOrders = await _serviceTypeService.GetAllAsync();

                return Ok(serviceOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var serviceOrder = await _serviceTypeService.GetByIdAsync(id);

                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateServiceTypeDTO createServiceTypeDTO
        )
        {
            try
            {
                var serviceOrder = await _serviceTypeService.CreateAsync(createServiceTypeDTO);

                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateById(
            [FromRoute] int id,
            [FromBody] UpdateServiceTypeDTO updateServiceTypeDTO
        )
        {
            try
            {
                var serviceOrder = await _serviceTypeService.UpdateAsync(id, updateServiceTypeDTO);

                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }
    }
}
