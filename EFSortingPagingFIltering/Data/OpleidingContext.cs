using EFSortingPagingFIltering.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFSortingPagingFIltering.Data
{
    public class OpleidingContext:DbContext
    {
        public OpleidingContext(DbContextOptions<OpleidingContext> options) : base(options) { }
        public DbSet<Student> Studenten { get; set; }
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Cursus> Cursussen { get; set; }
    }
}
