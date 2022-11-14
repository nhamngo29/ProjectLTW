namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "FormId", c => c.Int());
            CreateIndex("dbo.Products", "FormId");
            AddForeignKey("dbo.Products", "FormId", "dbo.Forms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "FormId", "dbo.Forms");
            DropIndex("dbo.Products", new[] { "FormId" });
            DropColumn("dbo.Products", "FormId");
        }
    }
}
