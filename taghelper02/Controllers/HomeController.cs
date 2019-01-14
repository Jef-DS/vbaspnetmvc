using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taghelper02.ViewModels;

namespace taghelper02.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index()
        {
            RekenMachine rek = new RekenMachine();
            return View(rek);
        }
        [HttpPost]
        public ViewResult Index(RekenMachine rek)
        {
            return View("resultaat", rek);
        }
    }
}
