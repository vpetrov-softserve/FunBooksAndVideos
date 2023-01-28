using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Memberships
{
     public class List
    {
        public class Query : IRequest<List<Domain.Membership>>{}

        public class Handler : IRequestHandler<Query, List<Domain.Membership>>
        {
            private readonly DataContext _context;
            
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Domain.Membership>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Products.OfType<Domain.Membership>().ToListAsync();
            
            }
        }
    }
}