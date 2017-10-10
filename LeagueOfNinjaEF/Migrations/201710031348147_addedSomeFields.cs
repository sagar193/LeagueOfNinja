namespace LeagueOfNinjaEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSomeFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "Health", c => c.Int(nullable: false));
            AddColumn("dbo.Equipments", "Mana", c => c.Int(nullable: false));
            AddColumn("dbo.Equipments", "Stamina", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipments", "Stamina");
            DropColumn("dbo.Equipments", "Mana");
            DropColumn("dbo.Equipments", "Health");
        }
    }
}
