using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taghelper01.ViewModels
{
    public class ReisViewModel
    {
        private List<Bestemming> bestemmingen = new List<Bestemming>
                {
                    new Bestemming{Code = 1, Naam="de zee", Prijs=100},
                    new Bestemming{Code = 2, Naam="het strand", Prijs=200},
                    new Bestemming{Code = 3, Naam="de kust", Prijs = 300}
                };
        public SelectList Bestemmingen
        {
            get
            {
               
                return new SelectList(bestemmingen, "Code", "Naam");
            }
        }
        public int BestemmingCode { get; set; }
         public int AantalDagen { get; set; }
        public bool MetKorting { get; set; }
        public string Resultaat
        {
            get
            {
                Bestemming bestemming = bestemmingen.Find(b => b.Code == BestemmingCode);
                decimal prijs = AantalDagen * bestemming.Prijs;
                prijs = MetKorting ? prijs * 0.9m : prijs;
                return String.Format("De reis naar {0} kost {1:C}", bestemming.Naam, prijs);
            }
        }
    }
    public class Bestemming
    {
        public int Code { get; set; }
        public String Naam { get; set; }
        public decimal Prijs { get; set; }
    }

}
