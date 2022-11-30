namespace Project.identityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        IdOrder = c.Int(nullable: false),
                        IdProductt = c.String(nullable: false, maxLength: 40, unicode: false),
                        Count = c.Int(),
                        Price = c.Double(),
                        Thanhtien = c.Double(),
                    })
                .PrimaryKey(t => new { t.IdOrder, t.IdProductt })
                .ForeignKey("dbo.Orders", t => t.IdOrder, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.IdProductt, cascadeDelete: true)
                .Index(t => t.IdOrder)
                .Index(t => t.IdProductt);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateBooking = c.DateTime(),
                        Status = c.Int(),
                        IdUser = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser)
                .Index(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "IdProductt", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "IdOrder", "dbo.Orders");
            DropForeignKey("dbo.Orders", "IdUser", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "IdUser" });
            DropIndex("dbo.OrderDetails", new[] { "IdProductt" });
            DropIndex("dbo.OrderDetails", new[] { "IdOrder" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
