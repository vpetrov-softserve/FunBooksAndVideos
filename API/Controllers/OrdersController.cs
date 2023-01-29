using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<OrderSlipDto>> PlaceOrder(OrderDto orderDto)
        {
            var result = await Mediator.Send(new Application.Orders.Create.Command { OrderDto = orderDto});

            if(!result.IsSuccess)
                return BadRequest(result);
                
            var slipDto = await Mediator.Send(new Application.Orders.QueryOrderProducts.Query{ OrderId = result.Id});
            
            return Ok(slipDto);
        }

    }
}