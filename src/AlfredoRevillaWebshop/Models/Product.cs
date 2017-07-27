using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaWebshop.Services.Models;

namespace AlfredoRevillaWebshop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(13)]
        public string MPN { get; set; }


    }

    public static class ProductExtensions
    {
        public static ProductServiceModel MapToServiceModel(this Product product)
        {
            return new ProductServiceModel
            {
            };
        }

        public static TCollection MapElementsToServiceModel<TCollection,TElement>(this TCollection collection) where TCollection : IEnumerable<Product>
        {
            throw new NotImplementedException();
        }
    }

}
