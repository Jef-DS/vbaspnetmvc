using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stap1.controllers
{
    public class HomeController: Controller
    {
        public String Index()
        {
            return "Dag allemaal";
        }
        public ViewResult Index2()
        {
            ViewData["bericht"] = "Dit is geen bericht";
            ViewData["ander bericht"] = "Dit is wel een bericht";
            return View();
        }
    }
}
