using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceOrderCreatorApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/service-order")]
    public class ServiceOrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Testing");
        }
    }
}
