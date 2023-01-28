using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Orders
{
    public class ListUserOrders
    {
        public class Query : IRequest<List<Domain.Order>>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Domain.Order>>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
                
            }

            public async Task<List<Order>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Orders.ToListAsync();
            }
        }
    }
}