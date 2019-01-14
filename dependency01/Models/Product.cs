using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dependency01.Models
{
    public class Product
    {
        [Required]
        public String Code { get; set; }
        [Required]
        public String Naam { get; set; }
        [Required]
        public decimal Prijs { get; set; }

        public override bool Equals(object obj) => obj is Product product &&
                   Code == product.Code;

        public override int GetHashCode() => HashCode.Combine(Code);
    }
}
