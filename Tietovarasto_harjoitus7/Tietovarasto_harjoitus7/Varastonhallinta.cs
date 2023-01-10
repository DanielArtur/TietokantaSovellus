using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tietovarasto_harjoitus7
{
    public class Varastonhallinta : DbContext
    {
        public DbSet<Tuote>? Tuotteet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=BC-5CD026D1XD;" + "Initial Catalog=Varastonhallinta;" +
                "Integrated Security=true;" + "MultipleActiveResultSets=true;" + "TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connection);


        }



    }
}




