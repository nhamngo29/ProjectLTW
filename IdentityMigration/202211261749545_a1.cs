namespace Project.identityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "IsActive", c => c.Boolean());
        }
    }
}
