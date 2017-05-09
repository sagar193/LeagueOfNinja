using LeagueOfNinjaEF.Data;
using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.DAL
{
    class LoNInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LoNContext>
    {
        protected override void Seed(LoNContext context)
        {
            var Types = new List<Models.Type>
            {
                new Models.Type{Name="Head"},
                new Models.Type{Name="Chest"},
                new Models.Type{Name="Legs"},
                new Models.Type{Name="Gloves"},
                new Models.Type{Name="Shoes"},
            };

            Types.ForEach(s => context.Type.Add(s));
            context.SaveChanges();

            var Ninjas = new List<Ninja>
            {

            };

            Ninjas.ForEach(s => context.Ninja.Add(s));
            context.SaveChanges();

            var Equipments = new List<Equipment>
            {

            };

            Equipments.ForEach(s => context.Equipment.Add(s));
            context.SaveChanges();
        }
    }
}
