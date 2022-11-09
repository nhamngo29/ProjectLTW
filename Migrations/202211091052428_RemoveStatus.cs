namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Featureds",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProductId = c.String(nullable: false, maxLength: 40, unicode: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "DateCreate", c => c.DateTime());
            DropColumn("dbo.Products", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Status", c => c.String(maxLength: 4000));
            DropForeignKey("dbo.Featureds", "ProductId", "dbo.Products");
            DropIndex("dbo.Featureds", new[] { "ProductId" });
            DropColumn("dbo.Products", "DateCreate");
            DropTable("dbo.Featureds");
        }
    }
}
