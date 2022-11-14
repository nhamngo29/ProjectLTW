namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Details", "ProductId", "dbo.Products");
            DropIndex("dbo.Details", new[] { "ProductId" });
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
            
            AddColumn("dbo.Products", "Material", c => c.String(maxLength: 4000));
            AddColumn("dbo.Products", "Characteristics", c => c.String(maxLength: 4000));
            AddColumn("dbo.Products", "From", c => c.String(maxLength: 4000));
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
                        Size = c.String(maxLength: 4000),
                        Material = c.String(maxLength: 4000),
                        Characteristics = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => new { t.Id, t.ProductId });
            
            DropForeignKey("dbo.Sizes", "ProductTypeID", "dbo.ProductTypes");
            DropIndex("dbo.Sizes", new[] { "ProductTypeID" });
            DropColumn("dbo.Products", "From");
            DropColumn("dbo.Products", "Characteristics");
            DropColumn("dbo.Products", "Material");
            DropTable("dbo.Sizes");
            CreateIndex("dbo.Details", "ProductId");
            AddForeignKey("dbo.Details", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
