namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "Size", c => c.String(maxLength: 4000));
            AddColumn("dbo.Details", "Material", c => c.String(maxLength: 4000));
            AddColumn("dbo.Details", "Characteristics", c => c.String(maxLength: 4000));
            DropColumn("dbo.Details", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "Text", c => c.String(maxLength: 4000));
            DropColumn("dbo.Details", "Characteristics");
            DropColumn("dbo.Details", "Material");
            DropColumn("dbo.Details", "Size");
        }
    }
}
