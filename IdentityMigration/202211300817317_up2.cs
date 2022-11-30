namespace Project.identityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Ship", c => c.Double(nullable: false,defaultValue:0));
            AddColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalPrice");
            DropColumn("dbo.Orders", "Ship");
        }
    }
}
