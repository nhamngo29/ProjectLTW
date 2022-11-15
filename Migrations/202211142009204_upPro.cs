namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upPro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "FormId", "dbo.Forms");
            DropForeignKey("dbo.Sizes", "ProductTypeID", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "FormId" });
            DropIndex("dbo.Sizes", new[] { "ProductTypeID" });
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
            
            DropColumn("dbo.Products", "FormId");
            DropTable("dbo.Forms");
            DropTable("dbo.Sizes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        size = c.Int(nullable: false),
                        Text = c.String(maxLength: 4000),
                        ProductTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "FormId", c => c.Int());
            DropForeignKey("dbo.Details", "ProductId", "dbo.Products");
            DropIndex("dbo.Details", new[] { "ProductId" });
            DropTable("dbo.Details");
            CreateIndex("dbo.Sizes", "ProductTypeID");
            CreateIndex("dbo.Products", "FormId");
            AddForeignKey("dbo.Sizes", "ProductTypeID", "dbo.ProductTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "FormId", "dbo.Forms", "Id");
        }
    }
}
