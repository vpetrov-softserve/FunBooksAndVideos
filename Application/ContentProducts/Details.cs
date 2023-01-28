using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ContentProducts
{
    public class Details
    {
        public class Query : IRequest<ContentProduct>
        {
            public int Id { get; set;}
        }

        public class Handler : IRequestHandler<Query, ContentProduct>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
                
            }

            public async Task<ContentProduct> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Products.OfType<ContentProduct>().SingleOrDefaultAsync(p => p.Id == request.Id);

                return result;
            }
        }
    }
}