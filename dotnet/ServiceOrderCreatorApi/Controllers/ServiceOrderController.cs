using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceOrderCreatorApi.DTOs.ServiceOrder;
using ServiceOrderCreatorApi.Interfaces.Services;

namespace ServiceOrderCreatorApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/service-order")]
    public class ServiceOrderController : ControllerBase
    {
        private readonly IServiceOrderService _serviceOrderService;

        public ServiceOrderController(IServiceOrderService serviceOrderService)
        {
            _serviceOrderService = serviceOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Invalid token.");
                }

                var serviceOrders = await _serviceOrderService.GetAllAsync(userId);

                return Ok(serviceOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateServiceOrderDTO createServiceOrderDTO
        )
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Invalid token.");
                }

                var serviceOrder = await _serviceOrderService.CreateAsync(
                    userId,
                    createServiceOrderDTO
                );

                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpPost("image")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddImage(
            [FromForm] AddImageServiceOrderDTO addImageServiceOrderDTO
        )
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Invalid token.");
                }

                var serviceOrder = await _serviceOrderService.AddImageAsync(
                    userId,
                    addImageServiceOrderDTO
                );

                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }
    }
}
