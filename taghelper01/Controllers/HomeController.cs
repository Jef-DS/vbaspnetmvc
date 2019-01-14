using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taghelper01.ViewModels;

namespace taghelper01.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            ReisViewModel vm = new ReisViewModel();
            return View(vm);
        }
        [HttpPost]
        public ViewResult Index(ReisViewModel vm)
        {
            return View("resultaat", vm);
        }
    }
}
