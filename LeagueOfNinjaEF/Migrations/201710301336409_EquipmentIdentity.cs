namespace LeagueOfNinjaEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipmentIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ninjas", "ChestRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "GlovesRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "HelmetRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "LegRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "ShoesRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "Equipment_EquipmentId", "dbo.Equipments");
            DropPrimaryKey("dbo.Equipments");
            AlterColumn("dbo.Equipments", "EquipmentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "ChestRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "GlovesRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "HelmetRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "LegRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "ShoesRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "Equipment_EquipmentId", "dbo.Equipments", "EquipmentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ninjas", "Equipment_EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "ShoesRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "LegRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "HelmetRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "GlovesRefId", "dbo.Equipments");
            DropForeignKey("dbo.Ninjas", "ChestRefId", "dbo.Equipments");
            DropPrimaryKey("dbo.Equipments");
            AlterColumn("dbo.Equipments", "EquipmentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "Equipment_EquipmentId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "ShoesRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "LegRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "HelmetRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "GlovesRefId", "dbo.Equipments", "EquipmentId");
            AddForeignKey("dbo.Ninjas", "ChestRefId", "dbo.Equipments", "EquipmentId");
        }
    }
}
