using BlazorApp3.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp3.Application.Products.Queries
{
    public record GetAllProductsQuery : IRequest<List<ProductDTO>>;

}
