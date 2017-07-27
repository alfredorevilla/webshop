using AlfredoRevillaWebshop.Services.Models;
using System;
using System.Linq;

namespace AlfredoRevillaWebshop.Models
{
    public class ProductModel
    {
        public ProductModel(ProductServiceModel model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.Price = model.Price;
            this.MPN = model.MPN;
        }

        public int Id { get; }
        public string MPN { get; }
        public decimal Price { get; }
        public string Title { get; }
    }
}