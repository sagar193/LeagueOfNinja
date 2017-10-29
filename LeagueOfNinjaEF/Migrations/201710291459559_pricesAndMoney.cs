namespace LeagueOfNinjaEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pricesAndMoney : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "Money", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "Money");
        }
    }
}
