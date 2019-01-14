using dependency01.Models;
using dependency01.Services;
using dependency01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency01.Controllers
{
    public class HomeController:Controller
    {
        private ProductRepository repository;
        public HomeController(ProductRepository repository)
        {
            this.repository = repository;
        }

        public object ProductViewModel { get; private set; }

        public ViewResult Index()
        {
            ProductViewModel vm = new ProductViewModel
            {
                NieuwProduct = new Product(),
                Repository = repository
            };
            return View(vm);
        }
        [HttpPost]
        public ViewResult Index(ProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (repository.Bevat(vm.NieuwProduct))
                {
                    ModelState.AddModelError(String.Empty, "Code bestaat al");
                }
                else
                {
                    repository.Add(vm.NieuwProduct);
                    ModelState.Clear();
                    vm.NieuwProduct = new Product();
                }
            }
            vm.Repository = repository;
            return View(vm);
        }
    }
}
