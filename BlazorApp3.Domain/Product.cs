using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp3.Domain
{
    public class Product
    {
        public int Id { get; set; }  // Primary key
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
