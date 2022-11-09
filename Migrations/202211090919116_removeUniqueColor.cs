namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUniqueColor : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PropertieProducts", new[] { "Color" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PropertieProducts", "Color", unique: true);
        }
    }
}
