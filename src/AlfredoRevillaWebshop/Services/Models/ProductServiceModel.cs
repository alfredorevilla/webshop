using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfredoRevillaWebshop.Services.Models
{
    public class ProductServiceModel
    {
        public int Id { get; internal set; }
        public string Title { get; internal set; }
        public decimal Price { get; internal set; }
        public string MPN { get; internal set; }
    }
}
