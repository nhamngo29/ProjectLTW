namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "SeoTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "SeoDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "SeoKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Detail");
            DropColumn("dbo.Products", "SeoKeywords");
            DropColumn("dbo.Products", "SeoDescription");
            DropColumn("dbo.Products", "SeoTitle");
            DropColumn("dbo.Products", "IsActive");
            DropColumn("dbo.Products", "IsHot");
        }
    }
}
