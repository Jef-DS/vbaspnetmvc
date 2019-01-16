using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFSortingPagingFIltering.Models
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        public String Voornaam { get; set; }
        public String Achternaam { get; set; }
        public String Naam { get { return Voornaam + " " + Achternaam; } }
        [DataType(DataType.Date)]
        public DateTime InschrijvingsDatum { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
