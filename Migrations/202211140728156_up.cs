namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Material");
            DropColumn("dbo.Products", "Characteristics");
            DropColumn("dbo.Products", "From");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "From", c => c.String(maxLength: 4000));
            AddColumn("dbo.Products", "Characteristics", c => c.String(maxLength: 4000));
            AddColumn("dbo.Products", "Material", c => c.String(maxLength: 4000));
        }
    }
}
