using Microsoft.AspNetCore.Mvc;
using stap3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stap3.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Index(String voornaam, String achternaam)
        {
            Persoon p = new Persoon { Voornaam = voornaam, Achternaam = achternaam };
            return View("resultaat", p);
        }
    }
}
