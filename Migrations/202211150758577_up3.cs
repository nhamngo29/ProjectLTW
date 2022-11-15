namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Details", "ProductId", "dbo.Products");
            DropIndex("dbo.Details", new[] { "ProductId" });
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        size = c.Int(nullable: false),
                        Text = c.String(maxLength: 4000),
                        ProductTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID, cascadeDelete: true)
                .Index(t => t.ProductTypeID);
            
            AddColumn("dbo.Products", "FormId", c => c.Int());
            CreateIndex("dbo.Products", "FormId");
            AddForeignKey("dbo.Products", "FormId", "dbo.Forms", "Id");
            DropTable("dbo.Details");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.String(nullable: false, maxLength: 40, unicode: false),
                        Text = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.Id, t.ProductId });
            
            DropForeignKey("dbo.Sizes", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.Products", "FormId", "dbo.Forms");
            DropIndex("dbo.Sizes", new[] { "ProductTypeID" });
            DropIndex("dbo.Products", new[] { "FormId" });
            DropColumn("dbo.Products", "FormId");
            DropTable("dbo.Sizes");
            DropTable("dbo.Forms");
            CreateIndex("dbo.Details", "ProductId");
            AddForeignKey("dbo.Details", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
