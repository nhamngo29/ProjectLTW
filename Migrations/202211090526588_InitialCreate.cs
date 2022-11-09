namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.String(nullable: false, maxLength: 40, unicode: false),
                        Text = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.Id, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 40, unicode: false),
                        Name = c.String(maxLength: 4000),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Promotion = c.Single(),
                        IncludeVAT = c.Boolean(),
                        Quantity = c.Int(),
                        Status = c.String(maxLength: 4000),
                        Evaluate = c.Int(),
                        ImgeMain = c.String(),
                        ProductTypeID = c.Int(nullable: false),
                        TotalSold = c.Int(),
                        BrandID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID, cascadeDelete: true)
                .Index(t => t.ProductTypeID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ImgeProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.String(nullable: false, maxLength: 40, unicode: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PropertieProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.String(maxLength: 40, unicode: false),
                        Quantity = c.Int(),
                        Size = c.Int(),
                        Color = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.Quantity)
                .Index(t => t.Size, unique: true)
                .Index(t => t.Color, unique: true);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 4000),
                        ProductId = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slides", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PropertieProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ImgeProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Details", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.ProductTypes", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.Slides", new[] { "ProductId" });
            DropIndex("dbo.PropertieProducts", new[] { "Color" });
            DropIndex("dbo.PropertieProducts", new[] { "Size" });
            DropIndex("dbo.PropertieProducts", new[] { "Quantity" });
            DropIndex("dbo.PropertieProducts", new[] { "ProductId" });
            DropIndex("dbo.ImgeProducts", new[] { "ProductId" });
            DropIndex("dbo.ProductTypes", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "ProductTypeID" });
            DropIndex("dbo.Details", new[] { "ProductId" });
            DropTable("dbo.Slides");
            DropTable("dbo.PropertieProducts");
            DropTable("dbo.ImgeProducts");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Details");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
