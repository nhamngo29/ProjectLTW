namespace Project.identityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "IncludeVAT", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "IncludeVAT", c => c.Boolean());
        }
    }
}
