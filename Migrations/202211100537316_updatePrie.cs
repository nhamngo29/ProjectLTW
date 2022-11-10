namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePrie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Price", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
