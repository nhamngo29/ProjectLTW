namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PropertieProducts", new[] { "Size" });
            DropIndex("dbo.PropertieProducts", new[] { "Color" });
            AlterColumn("dbo.PropertieProducts", "Size", c => c.String(maxLength: 41));
            AlterColumn("dbo.PropertieProducts", "Color", c => c.String(maxLength: 100));
            CreateIndex("dbo.PropertieProducts", "Size", unique: true);
            CreateIndex("dbo.PropertieProducts", "Color", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.PropertieProducts", new[] { "Color" });
            DropIndex("dbo.PropertieProducts", new[] { "Size" });
            AlterColumn("dbo.PropertieProducts", "Color", c => c.Int());
            AlterColumn("dbo.PropertieProducts", "Size", c => c.Int());
            CreateIndex("dbo.PropertieProducts", "Color", unique: true);
            CreateIndex("dbo.PropertieProducts", "Size", unique: true);
        }
    }
}
