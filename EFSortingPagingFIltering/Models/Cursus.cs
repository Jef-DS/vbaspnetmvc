using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFSortingPagingFIltering.Models
{
    [Table("Cursus")]
    public class Cursus
    {
        public int Id { get; set; }
        public String Naam { get; set; }
        public ICollection<Inschrijving> Inschrijvingen { get; set; }
    }
}
