using Microsoft.AspNetCore.Mvc;
using stap2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stap2.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            Persoon p = new Persoon { Voornaam = "Joske", Achternaam = "Vermeulen" };
            return View(p);
        }
        public ViewResult Begroeting(String voornaam="Marieke", String achternaam="Vermeulen")
        {
            Persoon p = new Persoon { Voornaam = voornaam, Achternaam = achternaam };
            return View("index", p);
        }
    }
}
