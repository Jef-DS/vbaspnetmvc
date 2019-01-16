using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFSortingPagingFIltering.Models
{
    [Table("Inschrijving")]
    public class Inschrijving
    {
        public int Id { get; set; }
        public int CursusId { get; set; }
        public int StudentId { get; set; }
        public Cursus Cursus { get; set; }
        public Student Student { get; set; }
        public int? Punten { get; set; }
    }
}
