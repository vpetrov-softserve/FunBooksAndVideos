using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.DTOs;
using Application.Utilities;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Orders
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public OrderDto OrderDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var orderProducts = _context.Products.Where(p => request.OrderDto.ProductIds.Contains(p.Id));
                var allPrices = orderProducts.Select(p => p.Price).ToList();
                
                var order = new Domain.Order
                {
                    DateCreated = DateTime.Now,
                    UserId = request.OrderDto.UserId,
                    TotalPrice = allPrices.Sum(),
                    Products = orderProducts.ToList()
                };

                await _context.Orders.AddAsync(order);

                var contentProducts = _context.Products.OfType<Domain.ContentProduct>()
                                            .Where(p =>request.OrderDto.ProductIds.Contains(p.Id)).ToList();

                if(contentProducts != null)
                    await InsertContentProducts(contentProducts, order, request.OrderDto.UserId);

                var membershipProducts = _context.Products.OfType<Domain.Membership>()
                                             .Where(p =>request.OrderDto.ProductIds.Contains(p.Id)).ToList();

                if(membershipProducts != null)
                    await InsertMembershipProducts(membershipProducts, order, request.OrderDto.UserId);

                var result = await _context.SaveChangesAsync() > 0;

                if(!result) return Result<Unit>.Failure(ErrorMessages.FailureOrderCreation);

                return Result<Unit>.Success(order.Id);
            }

            private async Task InsertMembershipProducts(List<Membership> membershipProducts, Order order, Guid userId)
            {
                 if (membershipProducts != null)
                {
                    foreach (var prod in membershipProducts)
                    {
                        var usersMembership = new Domain.UsersMemberships
                        {
                            UserId = userId,
                            Membership = prod,
                            Order = order,
                            IsActivated = true
                        };

                        await _context.UsersMemberships.AddAsync(usersMembership);
                    }
                }
            }

            private async Task InsertContentProducts(List<Domain.ContentProduct> contentProducts, Domain.Order order, Guid userId)
            {
              
                if (contentProducts != null)
                {
                    foreach (var prod in contentProducts)
                    {
                        var usersContentProduct = new Domain.UsersContentProducts
                        {
                            UserId = userId,
                            ContentProduct = prod,
                            Order = order,
                        };

                        await _context.UsersContentProducts.AddAsync(usersContentProduct);
                    }
                }

                
            }
        }
    }
}