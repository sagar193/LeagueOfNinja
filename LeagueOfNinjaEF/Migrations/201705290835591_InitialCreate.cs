namespace LeagueOfNinjaEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false),
                        Name = c.String(),
                        Strength = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        TypeRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentId)
                .ForeignKey("dbo.Types", t => t.TypeRefId, cascadeDelete: true)
                .Index(t => t.TypeRefId);
            
            CreateTable(
                "dbo.Ninjas",
                c => new
                    {
                        NinjaId = c.Int(nullable: false),
                        Name = c.String(),
                        ChestRefId = c.Int(),
                        HelmetRefId = c.Int(),
                        LegRefId = c.Int(),
                        GlovesRefId = c.Int(),
                        ShoesRefId = c.Int(),
                        Equipment_EquipmentId = c.Int(),
                    })
                .PrimaryKey(t => t.NinjaId)
                .ForeignKey("dbo.Equipments", t => t.ChestRefId)
                .ForeignKey("dbo.Equipments", t => t.GlovesRefId)
                .ForeignKey("dbo.Equipments", t => t.HelmetRefId)
                .ForeignKey("dbo.Equipments", t => t.LegRefId)
                .ForeignKey("dbo.Equipments", t => t.ShoesRefId)
                .ForeignKey("dbo.Equipments", t => t.Equipment_EquipmentId)
                .Index(t => t.ChestRefId)
                .Index(t => t.HelmetRefId)
                .Index(t => t.LegRefId)
                .Index(t => t.GlovesRefId)
                .Index(t => t.ShoesRefId)
                .Index(t => t.Equipment_EquipmentId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "TypeRefId", "dbo.Types");
            DropForeignKey("dbo.Ninjas", "Equipment_EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "ShoesRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "LegRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "HelmetRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "GlovesRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "ChestRefId", "dbo.Equipments");
            DropIndex("dbo.Ninjas", new[] { "Equipment_EquipmentId" });
            DropIndex("dbo.Ninjas", new[] { "ShoesRefId" });
            DropIndex("dbo.Ninjas", new[] { "GlovesRefId" });
            DropIndex("dbo.Ninjas", new[] { "LegRefId" });
            DropIndex("dbo.Ninjas", new[] { "HelmetRefId" });
            DropIndex("dbo.Ninjas", new[] { "ChestRefId" });
            DropIndex("dbo.Equipments", new[] { "TypeRefId" });
            DropTable("dbo.Types");
            DropTable("dbo.Ninjas");
            DropTable("dbo.Equipments");
        }
    }
}
