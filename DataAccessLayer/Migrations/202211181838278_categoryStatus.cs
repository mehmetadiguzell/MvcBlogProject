namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CataStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CataStatus");
        }
    }
}
