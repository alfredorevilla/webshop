using AlfredoRevillaWebshop.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlfredoRevillaWebshop.Services.Models
{
    public class CreateProductServiceModel
    {
        public CreateProductServiceModel(CreateProductModel model)
        {
            this.Title = model.Title;
            this.MPN = model.MPN;
        }

        public string MPN { get; }

        public string Title { get; }
    }
}