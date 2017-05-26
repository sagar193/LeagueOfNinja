using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.Data
{
    class LoNContext : DbContext
    {
        public LoNContext() : base("NinjaLeagueConnectionString")
        {
        }

        public DbSet<Ninja> Ninja { get; set; }
        public DbSet<Models.Type> Type { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

    }
}
