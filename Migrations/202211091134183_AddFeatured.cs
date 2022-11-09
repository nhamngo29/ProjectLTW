namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeatured : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Featured", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Featured");
        }
    }
}
