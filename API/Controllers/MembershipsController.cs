
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Domain.Membership>>> GetAllMemberships()
        {
            return await Mediator.Send(new Application.Memberships.List.Query());
        }
    }
}