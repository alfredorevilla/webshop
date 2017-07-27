using AlfredoRevillaWebshop.Services.Models;
using System;
using System.Linq;

namespace AlfredoRevillaWebshop.Models
{
    public class GetProductsResult
    {
        public GetProductsResult(GetProductsServiceResult model)
        {
            this.Products = model.Products.Select(o => new ProductModel(o)).ToArray();
            this.TotalProducts = model.TotalProducts;
        }

        public ProductModel[] Products { get; }
        public int TotalProducts { get; }
    }
}