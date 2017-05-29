namespace LeagueOfNinjaEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeagueOfNinjaEF.Data.LoNContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LeagueOfNinjaEF.Data.LoNContext context)
        {
            context.Type.AddOrUpdate(
                t => t.TypeId,
                new Models.Type { TypeId = 1, Name = "Head" },
                new Models.Type { TypeId = 2, Name = "Chest" },
                new Models.Type { TypeId = 3, Name = "Legs" },
                new Models.Type { TypeId = 4, Name = "Gloves" },
                new Models.Type { TypeId = 5, Name = "Shoes" }
                );
            context.Equipment.AddOrUpdate(
                e => e.EquipmentId,
                new Models.Equipment { EquipmentId = 1, Name = "Bronze helmet", Dexterity = 3, Intelligence = 0, Strength = 8, Price = 12, TypeRefId = 1 },
                new Models.Equipment { EquipmentId = 2, Name = "Cloth helmet", Dexterity = 5, Intelligence = 6, Strength = 0, Price = 12, TypeRefId = 1 },
                new Models.Equipment { EquipmentId = 3, Name = "leather helmet", Dexterity = 8, Intelligence = 2, Strength = 2, Price = 12, TypeRefId = 1 }
                );
            context.Ninja.AddOrUpdate(
                n => n.NinjaId,
                new Models.Ninja { NinjaId = 0, HelmetRefId = 2, Name = "Sagar" }
                );
        }
    }
}
