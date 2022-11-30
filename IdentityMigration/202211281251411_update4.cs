namespace Project.identityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            
        }
    }
}
