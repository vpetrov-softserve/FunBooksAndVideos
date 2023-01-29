using Application.DTOs;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Orders
{
    public class QueryOrderProducts
    {
        public class Query : IRequest<OrderSlipDto>
        {
            public int OrderId { get; set; }
        }

        public class Handler : IRequestHandler<Query, OrderSlipDto>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<OrderSlipDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders
                                        .Include(o => o.Products)
                                        .FirstOrDefaultAsync(o => o.Id == request.OrderId);

                var productDtos = await GetProductDtos(order.Products);

                var slipDto = new OrderSlipDto
                {
                    OrderId = order.Id,
                    ShppingAddress = order.ShippingAddress ?? string.Empty,
                    Products = productDtos,
                    TotalPrice = order.TotalPrice
                };

                return slipDto;
            }

            private async Task<List<ProductDto>> GetProductDtos(List<ProductDetails> products)
            {
                var productDtoList = new List<ProductDto>();

                var contentProducts = products.OfType<Domain.ContentProduct>().ToList();

                var memberships = products.OfType<Domain.Membership>().ToList();

                if (contentProducts != null)
                {
                    foreach (var cp in contentProducts)
                    {
                        productDtoList.Add(new ProductDto
                        {
                            Id = cp.Id,
                            Name = cp.Name,
                            IsActivated = false
                        });
                    }
                }

                if (memberships != null)
                {
                    foreach (var mem in memberships)
                    {

                        var userMembership = await _context.UsersMemberships.SingleOrDefaultAsync(um => um.Id == mem.Id);
                        productDtoList.Add(new ProductDto
                        {
                            Id = mem.Id,
                            Name = mem.Name,
                            IsActivated = userMembership.IsActivated
                        });
                    }
                }

                return productDtoList;
            }
        }
    }

}