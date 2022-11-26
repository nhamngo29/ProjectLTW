namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "IsHot", c => c.Boolean());
            AlterColumn("dbo.Products", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "IsHot", c => c.Boolean(nullable: false));
        }
    }
}
