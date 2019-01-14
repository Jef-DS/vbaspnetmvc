using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace validatie01.ViewModels
{
    public class Reis
    {
        [Required(ErrorMessage ="Bestemming is verplicht")]
        public String Bestemming { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Van")]
        public DateTime StartDatum { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "tot")]
        public DateTime EindDatum { get; set; }
    }
}
