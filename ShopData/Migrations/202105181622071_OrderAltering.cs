namespace ShopData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderAltering : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CustomerName");
        }
    }
}
