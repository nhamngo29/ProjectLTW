namespace Project.identityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IdProduct = c.String(nullable: false, maxLength: 40, unicode: false),
                        TotalMoney = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.IdProduct })
                .ForeignKey("dbo.Orders", t => t.ID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(),
                        Total = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        IdUser = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser)
                .Index(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "IdUser", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "IdUser" });
            DropIndex("dbo.OrderDetails", new[] { "IdProduct" });
            DropIndex("dbo.OrderDetails", new[] { "ID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
