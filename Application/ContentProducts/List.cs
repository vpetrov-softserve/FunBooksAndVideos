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
    public class List
    {
        public class Query : IRequest<List<Domain.ContentProduct>>{}

        public class Handler : IRequestHandler<Query, List<Domain.ContentProduct>>
        {
            private readonly DataContext _context;
            
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Domain.ContentProduct>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Products.OfType<Domain.ContentProduct>().ToListAsync();
            
            }
        }
    }
}