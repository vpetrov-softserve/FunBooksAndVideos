using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Domain.Order>>> GetAllOrders()
        {
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Domain.Order>>> GetUsersAllOrders(Guid userId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> PlaceOrder()
        {
            return Ok();
        }

    }
}