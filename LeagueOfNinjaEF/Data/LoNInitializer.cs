using Devtalk.EF.CodeFirst;
using LeagueOfNinjaEF.Data;
using LeagueOfNinjaEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfNinjaEF.Data
{
    class LoNInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LoNContext>
    {
        public static void Initialize(LoNContext context)
        {
            var Types = new List<Models.Type>
            {
                new Models.Type{TypeId=1, Name="Head"},
                new Models.Type{TypeId=2, Name="Chest"},
                new Models.Type{TypeId=3, Name="Legs"},
                new Models.Type{TypeId=4, Name="Gloves"},
                new Models.Type{TypeId=5, Name="Shoes"}
            };

            Types.ForEach(s => context.Type.Add(s));
            context.SaveChanges();

            var Equipments = new List<Equipment>
            {
                new Equipment{EquipmentId=1, Name="Bronze helmet", Dexterity=3, Intelligence=0, Strength=8, Price=12, TypeRefId=1},
                new Equipment{EquipmentId=2, Name="Cloth helmet", Dexterity=5, Intelligence=6, Strength=0, Price=12, TypeRefId=1},
                new Equipment{EquipmentId=3, Name="leather helmet", Dexterity=8, Intelligence=2, Strength=2, Price=12, TypeRefId=1}
            };

            Equipments.ForEach(s => context.Equipment.Add(s));
            context.SaveChanges();
            
            var Ninjas = new List<Ninja>
            {
                new Ninja{NinjaId=0, HelmetRefId=2, Name="Sagar"}
            };

            Ninjas.ForEach(s => context.Ninja.Add(s));
            context.SaveChanges();
        }
    }
}
