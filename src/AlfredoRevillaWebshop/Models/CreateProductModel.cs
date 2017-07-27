using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AlfredoRevillaWebshop.Models
{
    public class CreateProductModel
    {
        public string MPN { get; set; }

        public string Title { get; set; }
    }
}