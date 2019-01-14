using dependency02.Services;
using dependency02.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency02.Controllers
{
    public class HomeController:Controller
    {
        private readonly WinkelWagenService winkelWagenService;
        public HomeController(WinkelWagenService service)
        {
            this.winkelWagenService = service;
        }
        public ViewResult Index()
        {
            String[] lijst = Enumerable.ToArray(this.winkelWagenService);
            ProductViewModel vm = new ProductViewModel { Producten = lijst };
            return View(vm);
        }
        [HttpPost]
        public ViewResult Index(ProductViewModel vm)
        {
            this.winkelWagenService.AddProduct(vm.ProductNaam);
            String[] lijst = Enumerable.ToArray(this.winkelWagenService);
            vm.Producten = lijst;
            vm.ProductNaam = String.Empty;
            ModelState.Clear();
            return View(vm);
        }
        
    }
}
