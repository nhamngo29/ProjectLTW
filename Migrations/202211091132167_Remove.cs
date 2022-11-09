namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Featureds", "ProductId", "dbo.Products");
            DropIndex("dbo.Featureds", new[] { "ProductId" });
            DropTable("dbo.Featureds");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Featureds",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProductId = c.String(nullable: false, maxLength: 40, unicode: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.ProductId });
            
            CreateIndex("dbo.Featureds", "ProductId");
            AddForeignKey("dbo.Featureds", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
