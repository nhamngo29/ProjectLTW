namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "IsActive", c => c.Boolean());
        }
    }
}
