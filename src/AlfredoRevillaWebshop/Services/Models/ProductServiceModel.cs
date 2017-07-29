using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Repositories.Models;

namespace AlfredoRevillaWebshop.Services.Models
{
    public class ProductServiceModel
    {
        public ProductServiceModel(ProductRepositoryModel model)
        {
            this.Id = model.Id;
            this.MPN = model.MPN;
            this.Price = model.Price;
            this.Title = model.Title;
        }

        public int Id { get; }
        public string MPN { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}