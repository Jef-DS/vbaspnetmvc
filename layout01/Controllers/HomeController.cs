using layout01.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layout01.Controllers
{
    public class HomeController:Controller
    {
        private readonly K3Service lijst;
        public HomeController(K3Service lijst)
        {
            this.lijst = lijst;
        }
        public ViewResult Index()
        {
            ViewBag.Lijst = lijst;
            return View();
        }
        public ViewResult Edit()
        {
            ViewBag.Lijst = lijst;
            return View();
        }
        public RedirectToActionResult Delete(String id)
        {
            lijst.VerwijderNaam(id);
            return RedirectToAction("Edit");
        }
        public RedirectToActionResult Add(String naam)
        {
            lijst.VoegNaamToe(naam);
            return RedirectToAction("Edit");
        }
    }
}
