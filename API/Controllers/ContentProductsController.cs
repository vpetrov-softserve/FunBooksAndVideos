using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ContentProducts;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

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