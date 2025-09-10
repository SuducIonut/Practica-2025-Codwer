using BlazorApp3.Infrastructure.Data;
using BlazorApp3.Migrations;
using MediatR;
using BlazorApp3.Domain;
using BlazorApp3.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BlazorApp3.Application.Products.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public AddProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Product
            {
                Name = request.Product.Name,
                Quantity = request.Product.Quantity,
                Price = request.Product.Price
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;

        }
    }
}
