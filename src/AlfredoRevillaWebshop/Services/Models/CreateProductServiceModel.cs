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

        [Required]
        [MaxLength(13)]
        public string MPN { get; }

        [Required]
        [MaxLength(255)]
        public string Title { get; }
    }
}