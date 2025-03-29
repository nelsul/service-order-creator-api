using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                var serviceOrders = await _serviceOrderService.GetAllAsync();

                return Ok(serviceOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, Details = ex.Data });
            }
        }
    }
}
