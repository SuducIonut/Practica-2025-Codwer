using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BlazorApp3.Shared.DTOs;

namespace BlazorApp3.Application.Products.Commands
{
    public record DeleteProductCommand(int Id) : IRequest;

}
