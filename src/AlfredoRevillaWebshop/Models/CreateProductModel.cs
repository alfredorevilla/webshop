using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AlfredoRevillaWebshop.Models
{
    public class CreateProductModel
    {
        [Required]
        public string MPN { get; set; }

        [Required]
        public string Title { get; set; }
    }
}