using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace taghelper02.ViewModels
{
    public class RekenMachine
    {
        public Bewerkingen? Bewerking { get; set; }
        [Display(Name ="Getal1")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:N3}")]
        public double Getal1 { get; set; }
        public double Getal2 { get; set; }
        [DisplayFormat(DataFormatString ="{0:N3}")]
        public double Resultaat
        {
            get
            {
                double resultaat = Double.NaN;
                switch (Bewerking)
                {
                    case Bewerkingen.optellen:
                        resultaat = Getal1 + Getal2;
                        break;
                    case Bewerkingen.aftrekken:
                        resultaat = Getal1 - Getal2;
                        break;
                    case Bewerkingen.vermenigvuldigen:
                        resultaat = Getal1 * Getal2;
                        break;
                    case Bewerkingen.delen:
                        resultaat = (double)Getal1 / Getal2;
                        break;
                }
                return resultaat;
            }
        }
    }
    public enum Bewerkingen {
        [Display(Name = "+")]
        optellen,
        [Display(Name = "-")]
        aftrekken,
        [Display(Name = "*")]
        vermenigvuldigen,
        [Display(Name = "/")]
        delen
    }
    public static class BewerkingenExtensions
    {
        public static String ToOperator(this Bewerkingen? bewerking)
        {
            Bewerkingen b = bewerking.Value;
            Type membertype = b.GetType();
            MemberInfo info = membertype.GetMember(b.ToString()).First();
            DisplayAttribute display = info.GetCustomAttribute<DisplayAttribute>();
            return display.Name;
        }
    }
}
