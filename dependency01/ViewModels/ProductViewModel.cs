using dependency01.Models;
using dependency01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency01.ViewModels
{
    public class ProductViewModel
    {
        public Product NieuwProduct { get; set; }
        public ProductRepository Repository { get; set; }
    }
}
