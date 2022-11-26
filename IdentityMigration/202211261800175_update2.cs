namespace Project.identityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "IsHot", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "IsHot", c => c.Boolean());
        }
    }
}
