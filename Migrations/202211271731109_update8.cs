namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "FormId", "dbo.Forms");
            DropIndex("dbo.Products", new[] { "FormId" });
            DropColumn("dbo.Products", "IncludeVAT");
            DropColumn("dbo.Products", "Featured");
            DropColumn("dbo.Products", "FormId");
            DropColumn("dbo.Products", "SeoTitle");
            DropColumn("dbo.Products", "SeoDescription");
            DropColumn("dbo.Products", "SeoKeywords");
            DropTable("dbo.Forms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "SeoKeywords", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "SeoDescription", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "SeoTitle", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "FormId", c => c.Int());
            AddColumn("dbo.Products", "Featured", c => c.Boolean());
            AddColumn("dbo.Products", "IncludeVAT", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Products", "FormId");
            AddForeignKey("dbo.Products", "FormId", "dbo.Forms", "Id");
        }
    }
}
