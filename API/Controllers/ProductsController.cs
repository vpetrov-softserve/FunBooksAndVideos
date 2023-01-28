using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly DataContext _dbContext;

        public ProductsController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}