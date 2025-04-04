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

                var serviceOrders = await _serviceOrderService.GetAllAsync(Guid.Parse(userId));

                return Ok(serviceOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Invalid token.");
                }

                var serviceOrder = await _serviceOrderService.GetByIdAsync(Guid.Parse(userId), id);

                return Ok(serviceOrder);
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
                    Guid.Parse(userId),
                    createServiceOrderDTO
                );

                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateById(
            [FromRoute] Guid id,
            [FromBody] UpdateServiceOrderDTO updateServiceOrderDTO
        )
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Invalid token.");
                }

                var serviceOrder = await _serviceOrderService.UpdateAsync(
                    Guid.Parse(userId),
                    id,
                    updateServiceOrderDTO
                );

                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpGet("image")]
        public async Task<IActionResult> GetImage(
            [FromQuery] RequestImageServiceOrderDTO requestImageServiceOrderDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Invalid token.");
                }

                var image = await _serviceOrderService.GetImageAsyc(
                    Guid.Parse(userId),
                    requestImageServiceOrderDTO
                );

                return File(image, "image/jpeg");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpGet("image-base64")]
        public async Task<IActionResult> GetImageBase64(
            [FromQuery] RequestImageServiceOrderDTO requestImageServiceOrderDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Invalid token.");
                }

                var image = await _serviceOrderService.GetImageAsyc(
                    Guid.Parse(userId),
                    requestImageServiceOrderDTO
                );

                var base64Image = Convert.ToBase64String(image);

                return Ok(base64Image);
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
                    Guid.Parse(userId),
                    addImageServiceOrderDTO
                );

                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }

        [HttpDelete("image")]
        public async Task<IActionResult> RemoveImage(
            [FromBody] RemoveImageServiceOrderDTO removeImageServiceOrderDTO
        )
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("Invalid token.");
                }

                var serviceOrder = await _serviceOrderService.RemoveImageAsync(
                    Guid.Parse(userId),
                    removeImageServiceOrderDTO
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
