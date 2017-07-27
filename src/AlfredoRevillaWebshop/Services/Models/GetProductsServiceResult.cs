using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlfredoRevillaWebshop.Services.Models
{
    public class GetProductsServiceResult
    {
        public ProductServiceModel[] Products { get; }
        public int TotalProducts { get; }
    }
}
