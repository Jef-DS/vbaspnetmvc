using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using validatie01.ViewModels;

namespace validatie01.Controllers
{
    public class HomeController:Controller
    {

        public ViewResult Index()
        {
            Reis reis = new Reis
            {
                StartDatum = DateTime.Today,
                EindDatum = DateTime.Today
            };
            return View(reis);
        }
        [HttpPost]
        public ViewResult Index(Reis reis)
        {
            if (reis.EindDatum < reis.StartDatum)
            {
                ModelState.AddModelError(String.Empty, "Einddatum mag niet voor startdatum liggen");
            }
            if (ModelState.IsValid)
            {
                return View("resultaat", reis);
            }
            else
            {
                return View();
            }
        }
    }
}
