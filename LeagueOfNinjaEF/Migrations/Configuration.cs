namespace LeagueOfNinjaEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeagueOfNinjaEF.DAL.LoNContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        private void clearDatabase(DbContext context)
        {
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");
        }

        protected override void Seed(LeagueOfNinjaEF.DAL.LoNContext context)
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
                new Models.Equipment { EquipmentId = 2, Name = "Cloth helmet", Dexterity = 5, Intelligence = 6, Strength = 0, Price = 11, TypeRefId = 1 },
                new Models.Equipment { EquipmentId = 3, Name = "leather helmet", Dexterity = 8, Intelligence = 2, Strength = 2, Price = 13, TypeRefId = 1 },
                new Models.Equipment { EquipmentId = 4, Name = "Bronze Chest", Dexterity = 3, Intelligence = 0, Strength = 8, Price = 8, TypeRefId = 2 },
                new Models.Equipment { EquipmentId = 5, Name = "Cloth Chest", Dexterity = 5, Intelligence = 6, Strength = 0, Price = 9, TypeRefId = 2 },
                new Models.Equipment { EquipmentId = 6, Name = "leather Chest", Dexterity = 8, Intelligence = 2, Strength = 2, Price = 7, TypeRefId = 2 },
                new Models.Equipment { EquipmentId = 7, Name = "Bronze Legs", Dexterity = 3, Intelligence = 0, Strength = 8, Price = 4, TypeRefId = 3 },
                new Models.Equipment { EquipmentId = 8, Name = "Cloth Legs", Dexterity = 5, Intelligence = 6, Strength = 0, Price = 3, TypeRefId = 3 },
                new Models.Equipment { EquipmentId = 9, Name = "leather Legs", Dexterity = 8, Intelligence = 2, Strength = 2, Price = 4, TypeRefId = 3 },
                new Models.Equipment { EquipmentId = 10, Name = "Bronze Gloves", Dexterity = 3, Intelligence = 0, Strength = 8, Price = 1, TypeRefId = 4 },
                new Models.Equipment { EquipmentId = 11, Name = "Cloth Gloves", Dexterity = 5, Intelligence = 6, Strength = 0, Price = 2, TypeRefId = 4 },
                new Models.Equipment { EquipmentId = 12, Name = "leather Gloves", Dexterity = 8, Intelligence = 2, Strength = 2, Price = 2, TypeRefId = 4 }
                );
            context.Ninja.AddOrUpdate(
                n => n.NinjaId,
                new Models.Ninja { NinjaId = 1, Name = "Sagar", Money = 20},
                new Models.Ninja { NinjaId = 2, Name = "Rick", Money = 30 },
                new Models.Ninja { NinjaId = 3, Name = "Narutard", Money = 5},
                new Models.Ninja { NinjaId = 4, Name = "testNinja", Money = 200 }
                );
        }
    }
}
