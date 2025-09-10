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

namespace BlazorApp3.Application.Products.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllProductsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                 .Select(p => new ProductDTO
                 {
                     Id = p.Id,
                     Name = p.Name,
                     Quantity = p.Quantity,
                     Price = p.Price
                 })
                 .ToListAsync(cancellationToken);

            return products;
        }
    }
}
