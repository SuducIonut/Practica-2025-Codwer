using BlazorApp3.Application.Products.Queries;
using BlazorApp3.Infrastructure.Data;
using BlazorApp3.Shared.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Practica25.Application.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDTO?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                 .Where(p => p.Id == query.Id)
                 .Select(p => new ProductDTO
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Quantity = p.Quantity,
                     Price = p.Price
                 })
                 .FirstOrDefaultAsync(cancellationToken);
            return products;
        }
    }
}
