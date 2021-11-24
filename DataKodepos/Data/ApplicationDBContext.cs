using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataKodepos.Models;
using Microsoft.EntityFrameworkCore;

namespace DataKodepos.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Kodepos> Kodepos{ get; set; }
        public DbSet<Kabupaten> Kabupaten { get; set; }
        public DbSet<Propinsi> Propinsi { get; set; }

    }
}
