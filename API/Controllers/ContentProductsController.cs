using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentProductsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Domain.ContentProduct>>> GetAllContentProducts()
        {
            return  await Mediator.Send(new Application.ContentProducts.List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.ContentProduct>> GetSingleContentProduct(int id)
        {
            return await Mediator.Send(new Application.ContentProducts.Details.Query{Id = id});
        }
    
    }
}