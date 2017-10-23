using LeagueOfNinjaEF.DAL;
using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.DAL
{
    class LoNInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LoNContext>
    {
        public static void Initialize(LoNContext context)
        {
            var Types = new List<Models.Type>
            {
            };

            Types.ForEach(s => context.Type.Add(s));
            context.SaveChanges();

            var Equipments = new List<Equipment>
            {
            };

            Equipments.ForEach(s => context.Equipment.Add(s));
            context.SaveChanges();
            
            var Ninjas = new List<Ninja>
            {
            };

            Ninjas.ForEach(s => context.Ninja.Add(s));
            context.SaveChanges();
        }
    }
}
