namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PropertieProducts", new[] { "Size" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PropertieProducts", "Size", unique: true);
        }
    }
}
